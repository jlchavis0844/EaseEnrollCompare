using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using System.Reflection;
using ExtensionMethods;

namespace EaseEnrollCompare {
    public partial class Form1 : Form {
        public static string OLDINPUTFILE;
        public static string NEWINPUTFILE;
        public static bool OldLoaded = false;
        public static bool NewLoaded = false;

        public static List<CensusRow> OldRecords = new List<CensusRow>();
        public static List<CensusRow> NewRecords = new List<CensusRow>();
        public static List<CensusRow> OriginalOldRecords = new List<CensusRow>();
        public static List<CensusRow> OriginalNewRecords = new List<CensusRow>();
        public static List<CensusRow> Drops = new List<CensusRow>();
        public static List<CensusRow> Adds = new List<CensusRow>();
        public static List<CensusRow> Changes = new List<CensusRow>();
        public static List<CensusRow> output = new List<CensusRow>();

        public Form1() {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            InitializeComponent();
            dpActiveDateOld.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            // Log the exception, display it, etc
            MessageBox.Show((e.ExceptionObject as Exception).Message, "UNHANDLED EXCEPTION", MessageBoxButtons.OK);
        }

        private void btnLoadOld_Click(object sender, EventArgs e) {
            btnLoadOld.Enabled = false;
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = "CSV File (*.csv) | *.csv";
                ofd.RestoreDirectory = true;
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK) {
                    OLDINPUTFILE = ofd.FileName;
                    this.lblOldFile.Text = OLDINPUTFILE;

                    var loadedFile = File.Open(OLDINPUTFILE, FileMode.Open, FileAccess.Read,
                        FileShare.ReadWrite);

                    using (var reader = new StreamReader(loadedFile)) {
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {
                            csv.Configuration.HeaderValidated = null;
                            csv.Configuration.HasHeaderRecord = true;
                            csv.Configuration.MissingFieldFound = null;
                            csv.Configuration.RegisterClassMap<CensusRowClassMap>();

                            try {
                                OriginalOldRecords = csv.GetRecords<CensusRow>().ToList();
                                OldRecords = new List<CensusRow>(OriginalOldRecords);

                                int cnt = OldRecords.RemoveAll(ShouldBeRemovedOld);
                                Console.WriteLine(cnt + " lines removed");
                                btnLoadOld.Text = "Loaded " + OldRecords.Count + " Records";

                            } catch (Exception ex) {
                                Console.WriteLine(ex);
                                ErrorMessage(ex);
                            }
                        }
                    }
                } else {
                    MessageBox.Show("No File loaded, Please try again", "NO FILE", MessageBoxButtons.OK);
                    btnLoadOld.Enabled = true;
                }
            }

        }

        private void btnLoadNew_Click(object sender, EventArgs e) {
            btnLoadNew.Enabled = false;
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = "CSV File (*.csv) | *.csv";
                ofd.RestoreDirectory = true;
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK) {
                    NEWINPUTFILE = ofd.FileName;
                    this.lblNewFile.Text = NEWINPUTFILE;

                    var loadedFile = File.Open(NEWINPUTFILE, FileMode.Open, FileAccess.Read,
                        FileShare.ReadWrite);

                    using (var reader = new StreamReader(loadedFile)) {
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {
                            csv.Configuration.HeaderValidated = null;
                            csv.Configuration.HasHeaderRecord = true;
                            csv.Configuration.MissingFieldFound = null;
                            csv.Configuration.RegisterClassMap<CensusRowClassMap>();

                            try {
                                OriginalNewRecords = csv.GetRecords<CensusRow>().ToList();
                                NewRecords = new List<CensusRow>(OriginalNewRecords);

                                int cnt = NewRecords.RemoveAll(ShouldBeRemovedNew);
                                Console.WriteLine(cnt + " lines removed");
                                btnLoadNew.Text = "Loaded " + NewRecords.Count + " Records";

                            } catch (Exception ex) {
                                Console.WriteLine(ex);
                                ErrorMessage(ex);
                            }
                        }
                    }
                } else {
                    MessageBox.Show("No File loaded, Please try again", "NO FILE", MessageBoxButtons.OK);
                    btnLoadNew.Enabled = true;
                }
            }
        }

        private void PrintList<T>(List<T> list) {
            foreach (var t in list) {
                Console.WriteLine(t.ToString());
            }
        }

        private void RemoveColumns() {
            foreach (DataGridViewColumn col in dgvOutPut.Columns) {
                dgvOutPut.Columns[col.Name].Visible = false;
            }
            if (dgvOutPut.Columns.Count > 0) {
                dgvOutPut.Columns["EID"].Visible = true;
                dgvOutPut.Columns["FirstName"].Visible = true;
                dgvOutPut.Columns["MiddleName"].Visible = true;
                dgvOutPut.Columns["LastName"].Visible = true;
                dgvOutPut.Columns["Relationship"].Visible = true;
                dgvOutPut.Columns["HireDate"].Visible = true;
                dgvOutPut.Columns["TerminationDate"].Visible = true;
                dgvOutPut.Columns["JobClass"].Visible = true;
                dgvOutPut.Columns["JobTitle"].Visible = true;
                dgvOutPut.Columns["PayPeriods"].Visible = true;
                dgvOutPut.Columns["PlanType"].Visible = true;
                dgvOutPut.Columns["PlanDisplayName"].Visible = true;
                dgvOutPut.Columns["EffectiveDate"].Visible = true;
                dgvOutPut.Columns["CoverageDetails"].Visible = true;
                dgvOutPut.Columns["ElectionStatus"].Visible = true;
                dgvOutPut.Columns["EmployeeCostPerDeductionPeriod"].Visible = true;
                dgvOutPut.Columns["Changes"].Visible = true;
                dgvOutPut.Columns["Changes"].DisplayIndex = 0;
            }
        }

        private void btnCompare_Click(object sender, EventArgs e) {
            btnCompare.Enabled = false;
            btnDropData.Enabled = true;
            btnOutput.Enabled = true;

            NewRecords = (from rec in NewRecords
                          orderby rec.EID, rec.RelationshipCode, rec.FirstName
                          select rec).ToList();

            OldRecords = (from rec in OldRecords
                          orderby rec.EID, rec.RelationshipCode, rec.FirstName
                          select rec).ToList();

            foreach (var rec in OldRecords) {
                List<CensusRow> matches = NewRecords.Where(x =>
                x.EID == rec.EID && x.FirstName == rec.FirstName &&
                x.MiddleName == rec.MiddleName && x.LastName == rec.LastName &&
                x.Relationship == rec.Relationship && x.PlanType == rec.PlanType).ToList();

                if (matches.Count == 0) {
                    rec.Changes = "DROP";
                    rec.ElectionStatus = "DROP";
                    Drops.Add(rec);
                } else if (matches.Count > 1) {
                    MessageBox.Show("possible duplicate\n" + rec.ToString(), "Duplicate entry?", MessageBoxButtons.OK);
                } else {
                    if (!rec.Compare(matches.First())) {
                        Changes.Add(matches.First());
                    }
                }
            }

            foreach (var rec in NewRecords) {
                if (rec.LastName == "Knight")
                    Console.WriteLine("STOP");
                List<CensusRow> matches = OldRecords.Where(x =>
                x.EID == rec.EID && x.FirstName == rec.FirstName &&
                x.MiddleName == rec.MiddleName && x.LastName == rec.LastName &&
                x.Relationship == rec.Relationship && x.PlanType == rec.PlanType).ToList();

                if (matches.Count == 0) {
                    rec.Changes = "ADD";
                    rec.ElectionStatus = "ADD";
                    Adds.Add(rec);
                } else if (matches.Count > 1) {
                    MessageBox.Show("possible duplicate\n" + rec.ToString(), "Duplicate entry?", MessageBoxButtons.OK);
                }
            }
            //PrintList(Adds);
            //PrintList(Drops);
            //PrintList(Changes);

            output.AddRange(Adds);
            output.AddRange(Drops);
            output.AddRange(Changes);

            dgvOutPut.DataSource = output.OrderByDescending(o => o.PlanType).ThenBy(o => o.EID).
                ThenBy(o => o.RelationshipCode).ThenBy(o => o.FirstName).ToList();

            foreach (var col in dgvOutPut.Columns) {
                Console.WriteLine(col.ToString());
            }

            RemoveColumns();
        }

        private void btnOutput_Click(object sender, EventArgs e) {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string OutputFile = string.Empty;
            using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                string defaultPath = Path.GetDirectoryName(NEWINPUTFILE);
                fbd.Description = "Select the directory to output files to";
                fbd.SelectedPath = defaultPath;
                fbd.ShowNewFolderButton = true;

                // fbd.RootFolder = Environment.SpecialFolder.MyDocuments;
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK) {
                    OutputFile = fbd.SelectedPath;
                }
            }
            if (OutputFile == string.Empty)
                return;

            OutputFile = OutputFile + @"\Changes_" +
                DateTime.Now.ToString("MMddyyyy") + ".xlsx";

            string tempFile = Path.GetTempFileName();

            try {
                using (TextWriter writer = new StreamWriter(tempFile)) {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)) {
                        csv.WriteRecords(output);
                    }
                }

                if (cbExcel.Checked) {

                    var format = new ExcelTextFormat();
                    format.Delimiter = ',';
                    //format.EOL = "\r";
                    format.TextQualifier = '\"';

                    if (File.Exists(OutputFile)) {
                        File.Delete(OutputFile);
                    }

                    using (ExcelPackage package = new ExcelPackage(new FileInfo(OutputFile))) {
                        ExcelWorksheet ws = package.Workbook.Worksheets.Add("Changes");
                        ws.Cells["A1"].LoadFromText(new FileInfo(tempFile), format, OfficeOpenXml.Table.TableStyles.None, true);

                        int totalRows = ws.Dimension.End.Row;
                        int totalCols = ws.Dimension.End.Column;
                        var range = ws.Cells[1, 1, 1, totalCols];

                        for (int i = 1; i <= totalCols; i++) {
                            if (range[1, i].Address != "" && range[1, i].Value != null && range[1, i].Value.ToString().Contains("Date"))
                                ws.Column(i).Style.Numberformat.Format = "mm/dd/yyyy";
                        }

                        ws = package.Workbook.Worksheets.First();

                        int lastRow = ws.Dimension.End.Row;
                        string lastLoc = ws.Cells["B" + lastRow].ToString();

                        while (ws.Cells[lastLoc].Value == null || string.IsNullOrWhiteSpace(ws.Cells[lastLoc].Value.ToString())) {
                            ws.DeleteRow(lastRow);
                            ws = package.Workbook.Worksheets.First();
                            lastRow = ws.Dimension.End.Row;
                            lastLoc = ws.Cells["B" + lastRow].ToString();
                        }

                        package.Save();
                    }

                    //MessageBox.Show("File written:\n" + OutputFile, "File written", MessageBoxButtons.OK);
                    System.Diagnostics.Process.Start(OutputFile);
                }

                if (cbCSV.Checked) {
                    OutputFile = OutputFile.Replace(".xlsx", ".csv");

                    if (File.Exists(OutputFile))
                        File.Delete(OutputFile);

                    File.Move(tempFile, OutputFile);
                    //MessageBox.Show("File written:\n" + OutputFile, "File written", MessageBoxButtons.OK);
                    System.Diagnostics.Process.Start(OutputFile);
                } else {
                    if (File.Exists(tempFile)) {
                        File.Delete(tempFile);
                    }
                }
            } catch (Exception exc) {
                MessageBox.Show("Could not write file:" + OutputFile + "\n" + exc.Message, "Write Error", MessageBoxButtons.OK);

            }

        }

        private bool ShouldBeRemovedOld(CensusRow row) {
            if (cbOldTerm.Checked) {
                if (row.ElectionStatus == "Terminated")
                    return true;
            }

            if (cbOldWaived.Checked) {
                if (row.ElectionStatus == "Waived") {
                    return true;
                }
            }

            if (cbActiveOld.Checked) {
                if (row.ElectionStatus == "Waived") {
                    return true;
                } else if (row.ElectionStatus == "Terminated") {
                    if (DateTime.Parse(row.EffectiveDate) <= dpActiveDateOld.Value) {
                        return true;
                    }
                } else {
                    if (DateTime.Parse(row.EffectiveDate) > dpActiveDateOld.Value) {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool ShouldBeRemovedNew(CensusRow row) {
            if (cbNewTerm.Checked) {
                if (row.ElectionStatus == "Terminated")
                    return true;
            }

            if (cbNewWaived.Checked) {
                if (row.ElectionStatus == "Waived") {
                    return true;
                }
            }

            if (cbActiveOld.Checked) {
                if (row.ElectionStatus == "Waived") {
                    return true;
                } else if (row.ElectionStatus == "Terminated") {
                    if (DateTime.Parse(row.EffectiveDate) <= dpActiveDateNew.Value) {
                        return true;
                    }
                } else {
                    if (DateTime.Parse(row.EffectiveDate) > dpActiveDateNew.Value) {
                        return true;
                    }
                }
            }

            return false;
        }

        private void cbOldWaive_CheckedChanged(object sender, EventArgs e) {

        }

        private void ErrorMessage(Exception ExIn) {
            MessageBox.Show("ERR: " + ExIn.Message, "ERROR", MessageBoxButtons.OK);
        }

        private void btnReset_Click(object sender, EventArgs e) {
            OLDINPUTFILE = string.Empty;
            NEWINPUTFILE = string.Empty;
            OldLoaded = false;
            NewLoaded = false;

            OldRecords = new List<CensusRow>();
            NewRecords = new List<CensusRow>();
            OriginalOldRecords = new List<CensusRow>();
            OriginalNewRecords = new List<CensusRow>();
            Drops = new List<CensusRow>();
            Adds = new List<CensusRow>();
            Changes = new List<CensusRow>();
            output = new List<CensusRow>();

            dpActiveDateOld.Enabled = false;
            dpActiveDateNew.Enabled = false;
            cbActiveNew.Checked = false;
            cbActiveOld.Checked = false;
            btnCompare.Enabled = true;

            btnLoadNew.Enabled = true;
            btnLoadOld.Enabled = true;
            btnLoadNew.Text = "Load new file";
            btnLoadOld.Text = "Load old file";

            lblNewFile.Text = "Load new file";
            lblOldFile.Text = "Load old file";
            dgvOutPut.DataSource = null;
            dgvOutPut.Rows.Clear();
        }

        private void cbNewTerm_CheckedChanged(object sender, EventArgs e) {

        }

        private void cbActiveOld_CheckedChanged(object sender, EventArgs e) {
            cbActiveNew.CheckedChanged -= new System.EventHandler(this.cbActiveNew_CheckedChanged);
            cbActiveNew.Checked = !cbActiveNew.Checked;
            cbActiveNew.CheckedChanged += new System.EventHandler(this.cbActiveNew_CheckedChanged);

            if (!cbActiveOld.Checked) {//fires before changing, logic based on pre-click
                this.cbOldTerm.Checked = true;
                this.cbOldTerm.Enabled = true;
                this.cbOldWaived.Checked = true;
                this.cbOldWaived.Enabled = true;
                this.cbNewTerm.Checked = true;
                this.cbNewTerm.Enabled = true;
                this.cbNewWaived.Checked = true;
                this.cbNewWaived.Enabled = true;
                this.dpActiveDateOld.Enabled = false;
                this.dpActiveDateNew.Enabled = false;
            } else {
                this.cbOldTerm.Checked = false;
                this.cbOldTerm.Enabled = false;
                this.cbOldWaived.Checked = false;
                this.cbOldWaived.Enabled = false;
                this.cbNewTerm.Checked = false;
                this.cbNewTerm.Enabled = false;
                this.cbNewWaived.Checked = false;
                this.cbNewWaived.Enabled = false;
                this.dpActiveDateOld.Enabled = true;
                this.dpActiveDateNew.Enabled = true;
            }
        }

        private void cbActiveNew_CheckedChanged(object sender, EventArgs e) {
            cbActiveOld.CheckedChanged -= new System.EventHandler(this.cbActiveOld_CheckedChanged);
            cbActiveOld.Checked = !cbActiveOld.Checked;
            cbActiveOld.CheckedChanged += new System.EventHandler(this.cbActiveOld_CheckedChanged);

            if (!cbActiveNew.Checked) {//fires before changing, logic based on pre-click
                this.cbNewTerm.Checked = true;
                this.cbNewTerm.Enabled = true;
                this.cbNewWaived.Checked = true;
                this.cbNewWaived.Enabled = true;
                this.cbOldTerm.Checked = true;
                this.cbOldTerm.Enabled = true;
                this.cbOldWaived.Checked = true;
                this.cbOldWaived.Enabled = true;
                this.dpActiveDateOld.Enabled = false;
                this.dpActiveDateNew.Enabled = false;
            } else {
                this.cbNewTerm.Checked = false;
                this.cbNewTerm.Enabled = false;
                this.cbNewWaived.Checked = false;
                this.cbNewWaived.Enabled = false;
                this.cbOldTerm.Checked = false;
                this.cbOldTerm.Enabled = false;
                this.cbOldWaived.Checked = false;
                this.cbOldWaived.Enabled = false;
                this.dpActiveDateOld.Enabled = true;
                this.dpActiveDateNew.Enabled = true;
            }
        }

        private void btnDropData_Click(object sender, EventArgs e) {
            List<CensusRow> newDrops = new List<CensusRow>();
            foreach (var rec in Drops) {

                var tempRec = OriginalNewRecords.Where(x =>
                x.EID == rec.EID && x.FirstName == rec.FirstName &&
                x.MiddleName == rec.MiddleName && x.LastName == rec.LastName &&
                x.Relationship == rec.Relationship && x.PlanType == rec.PlanType).FirstOrDefault();

                if (tempRec == null) {
                    MessageBox.Show("Could not find term record for\n" + rec.FirstName + " " + rec.LastName);
                    continue;
                }
                tempRec.PlanEffectiveStartDate = rec.EffectiveDate; //during drops, PLan Effective Start Date is used for plan start and effective date is for term date
                tempRec.Changes = rec.Changes;
                tempRec.ElectionStatus = rec.ElectionStatus;

                newDrops.Add(tempRec);
            }


            var totalOut = NewRecords.Concat(newDrops);
            totalOut = totalOut.OrderBy(r => r.EID).ThenBy(r => r.RelationshipCode).ThenBy(r => r.FirstName).ToList();

            string OutputFile = string.Empty;
            using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                string defaultPath = Path.GetDirectoryName(NEWINPUTFILE);
                fbd.Description = "Select the directory to output files to";
                fbd.SelectedPath = defaultPath;
                fbd.ShowNewFolderButton = true;

                // fbd.RootFolder = Environment.SpecialFolder.MyDocuments;
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK) {
                    OutputFile = fbd.SelectedPath;
                }
            }

            if (OutputFile == string.Empty)
                return;

            OutputFile = OutputFile + @"\DataIn_" +
                DateTime.Now.ToString("MMddyyyy") + ".CSV";

            using (TextWriter writer = new StreamWriter(OutputFile)) {
                DataTable dt = totalOut.ToList().ToDataTable();
                RenameHeaders(dt);
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)) {
                    foreach(DataColumn col in dt.Columns){
                        csv.WriteField(col.ColumnName);
                    }
                    csv.NextRecord();

                    foreach(DataRow row in dt.Rows) {
                        for (var i = 0; i < dt.Columns.Count; i++) {
                            csv.WriteField(row[i]);
                        }
                        csv.NextRecord();
                    }
                }
            }

            System.Diagnostics.Process.Start(OutputFile);
        }

        public static void RenameHeaders(DataTable dt) {
            dt.Columns[0].ColumnName = "Changes";
            dt.Columns[1].ColumnName = "Company Name";
            dt.Columns[2].ColumnName = "EID";
            dt.Columns[3].ColumnName = "Location";
            dt.Columns[4].ColumnName = "First Name";
            dt.Columns[5].ColumnName = "Middle Name";
            dt.Columns[6].ColumnName = "Last Name";
            dt.Columns[7].ColumnName = "Relationship";
            dt.Columns[8].ColumnName = "Relationship Code";
            dt.Columns[9].ColumnName = "SSN";
            dt.Columns[10].ColumnName = "Gender";
            dt.Columns[11].ColumnName = "Birth Date";
            dt.Columns[12].ColumnName = "Race";
            dt.Columns[13].ColumnName = "Citizenship";
            dt.Columns[14].ColumnName = "Address 1";
            dt.Columns[15].ColumnName = "Address 2";
            dt.Columns[16].ColumnName = "City";
            dt.Columns[17].ColumnName = "State";
            dt.Columns[18].ColumnName = "Zip";
            dt.Columns[19].ColumnName = "County";
            dt.Columns[20].ColumnName = "Country";
            dt.Columns[21].ColumnName = "Personal Phone";
            dt.Columns[22].ColumnName = "Work Phone";
            dt.Columns[23].ColumnName = "Mobile Phone";
            dt.Columns[24].ColumnName = "Email";
            dt.Columns[25].ColumnName = "Personal Email";
            dt.Columns[26].ColumnName = "Employee Type";
            dt.Columns[27].ColumnName = "Employee Status";
            dt.Columns[28].ColumnName = "Hire Date";
            dt.Columns[29].ColumnName = "Termination Date";
            dt.Columns[30].ColumnName = "Department";
            dt.Columns[31].ColumnName = "Division";
            dt.Columns[32].ColumnName = "Job Class";
            dt.Columns[33].ColumnName = "Job Title";
            dt.Columns[34].ColumnName = "Marital Status";
            dt.Columns[35].ColumnName = "Marital Date";
            dt.Columns[36].ColumnName = "Marital Location";
            dt.Columns[37].ColumnName = "Student Status";
            dt.Columns[38].ColumnName = "Scheduled Hours";
            dt.Columns[39].ColumnName = "Sick Hours";
            dt.Columns[40].ColumnName = "Personal Hours";
            dt.Columns[41].ColumnName = "W2 Wages";
            dt.Columns[42].ColumnName = "Compensation";
            dt.Columns[43].ColumnName = "Compensation Type";
            dt.Columns[44].ColumnName = "Pay Cycle";
            dt.Columns[45].ColumnName = "Pay Periods";
            dt.Columns[46].ColumnName = "Cost Factor";
            dt.Columns[47].ColumnName = "Tobacco User";
            dt.Columns[48].ColumnName = "Disabled";
            dt.Columns[49].ColumnName = "Medicare A Date";
            dt.Columns[50].ColumnName = "Medicare B Date";
            dt.Columns[51].ColumnName = "Medicare C Date";
            dt.Columns[52].ColumnName = "Medicare D Date";
            dt.Columns[53].ColumnName = "Medical PCP Name";
            dt.Columns[54].ColumnName = "Medical PCP ID";
            dt.Columns[55].ColumnName = "Dental PCP Name";
            dt.Columns[56].ColumnName = "Dental PCP ID";
            dt.Columns[57].ColumnName = "IPA Number";
            dt.Columns[58].ColumnName = "OBGYN";
            dt.Columns[59].ColumnName = "Benefit Eligible Date";
            dt.Columns[60].ColumnName = "Unlock Enrollment Date";
            dt.Columns[61].ColumnName = "Original Effective Date Info";
            dt.Columns[62].ColumnName = "Subscriber Key";
            dt.Columns[63].ColumnName = "Plan Type";
            dt.Columns[64].ColumnName = "Plan Effective Start Date";
            dt.Columns[65].ColumnName = "Plan Effective End Date";
            dt.Columns[66].ColumnName = "Plan Admin Name";
            dt.Columns[67].ColumnName = "Plan Display Name";
            dt.Columns[68].ColumnName = "Plan Import ID";
            dt.Columns[69].ColumnName = "Effective Date";
            dt.Columns[70].ColumnName = "Activity Date";
            dt.Columns[71].ColumnName = "Coverage Details";
            dt.Columns[72].ColumnName = "Election Status";
            dt.Columns[73].ColumnName = "Processed Date";
            dt.Columns[74].ColumnName = "Rider Codes";
            dt.Columns[75].ColumnName = "Action";
            dt.Columns[76].ColumnName = "Waive Reason";
            dt.Columns[77].ColumnName = "Policy Number";
            dt.Columns[78].ColumnName = "Subgroup Number";
            dt.Columns[79].ColumnName = "Age Determination";
            dt.Columns[80].ColumnName = "Carrier";
            dt.Columns[81].ColumnName = "Total Rate";
            dt.Columns[82].ColumnName = "Employee Rate";
            dt.Columns[83].ColumnName = "Spouse Rate";
            dt.Columns[84].ColumnName = "Children Rate";
            dt.Columns[85].ColumnName = "Employee Contribution";
            dt.Columns[86].ColumnName = "Employee Pre-Tax Cost";
            dt.Columns[87].ColumnName = "Employee Post-Tax Cost";
            dt.Columns[88].ColumnName = "Employee Cost Per Deduction Period";
            dt.Columns[89].ColumnName = "Plan Deduction Cycle";
            dt.Columns[90].ColumnName = "Last Modified Date";
            dt.Columns[91].ColumnName = "Last Modified By";
            dt.Columns[92].ColumnName = "E-Sign Date";
            dt.Columns[93].ColumnName = "Enrolled By";
            dt.Columns[94].ColumnName = "New Business";
            dt.Columns[95].ColumnName = "VSP Code";
        }
    }
}
