using CsvHelper;
using ExtensionMethods;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
        public static List<string> MissingTermEIDs = new List<string>();

        public Form1() {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            InitializeComponent();
            dpActiveDateOld.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            cbAutoChanges.Checked = Properties.Settings.Default.OpenChangesFile;
            cbOpenEDIData.Checked = Properties.Settings.Default.OpenDataOut;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            // Log the exception, display it, etc
            MessageBox.Show((e.ExceptionObject as Exception).Message, "UNHANDLED EXCEPTION", MessageBoxButtons.OK);
        }
        static bool Junk(int myint) {
            bool answer = myint % 2 == 0;
            switch (answer) {
                case true:
                    return true;
                case false:
                    return false;
                default:
                    return Junk((int)Math.IEEERemainder(myint, 2));
            }
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
                                //OldRecords = csv.GetRecords<CensusRow>().ToList();

                                int cnt = OldRecords.RemoveAll(ShouldBeRemovedOld);
                                Console.WriteLine(cnt + " lines removed");
                                btnLoadOld.Text = "Loaded " + OldRecords.Count + " Records";

                            } catch (Exception ex) {
                                Console.WriteLine(ex);
                                ErrorMessage(ex);
                            }
                        }
                    }

                    loadedFile.Close();
                    loadedFile = File.Open(OLDINPUTFILE, FileMode.Open, FileAccess.Read,
                        FileShare.ReadWrite);

                    using (var reader = new StreamReader(loadedFile)) {
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {
                            csv.Configuration.HeaderValidated = null;
                            csv.Configuration.HasHeaderRecord = true;
                            csv.Configuration.MissingFieldFound = null;
                            csv.Configuration.RegisterClassMap<CensusRowClassMap>();

                            try {
                                //OriginalOldRecords = csv.GetRecords<CensusRow>().ToList();
                                OldRecords = csv.GetRecords<CensusRow>().ToList();

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
                                //NewRecords = csv.GetRecords<CensusRow>().ToList();

                                int cnt = NewRecords.RemoveAll(ShouldBeRemovedNew);
                                Console.WriteLine(cnt + " lines removed");
                                btnLoadNew.Text = "Loaded " + NewRecords.Count + " Records";

                            } catch (Exception ex) {
                                Console.WriteLine(ex);
                                ErrorMessage(ex);
                            }
                        }
                    }


                    loadedFile.Close();
                    loadedFile = File.Open(NEWINPUTFILE, FileMode.Open, FileAccess.Read,
                        FileShare.ReadWrite);

                    using (var reader = new StreamReader(loadedFile)) {
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {
                            csv.Configuration.HeaderValidated = null;
                            csv.Configuration.HasHeaderRecord = true;
                            csv.Configuration.MissingFieldFound = null;
                            csv.Configuration.RegisterClassMap<CensusRowClassMap>();

                            try {
                                //OriginalNewRecords = csv.GetRecords<CensusRow>().ToList();
                                NewRecords = csv.GetRecords<CensusRow>().ToList();

                                int cnt = NewRecords.RemoveAll(ShouldBeRemovedNew);
                                Console.WriteLine(cnt + " lines removed");
                                btnLoadNew.Text = "Loaded " + NewRecords.Count + " Records";

                            } catch (Exception ex) {
                                Console.WriteLine(ex);
                                ErrorMessage(ex);
                            }
                        }
                    }

                    lBoxPlanType.DataSource = NewRecords.Select(x => x.PlanType).Distinct().ToList();
                    lBoxPlanType.SelectedIndex = -1;
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
                dgvOutPut.Columns["PlanEffectiveStartDate"].Visible = true;
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
            //btnCompare.Enabled = false;
            btnOutputEDIdata.Enabled = true;
            btnOutput.Enabled = true;
            dgvOutPut.DataSource = null;

            Drops.Clear();
            Adds.Clear();
            Changes.Clear();
            output.Clear();

            dgvOutPut.Update();


            if (cbEmpOnly.Checked) {
                NewRecords.RemoveAll(r => r.RelationshipCode != "0");
                OldRecords.RemoveAll(r => r.RelationshipCode != "0");
            }

            NewRecords = (from rec in NewRecords
                          orderby rec.EID, rec.RelationshipCode, rec.FirstName
                          select rec).ToList();

            OldRecords = (from rec in OldRecords
                          orderby rec.EID, rec.RelationshipCode, rec.FirstName
                          select rec).ToList();

            if (this.cbBasic.Checked) {
                NewRecords.RemoveAll(r => r.RelationshipCode != "0");
                OldRecords.RemoveAll(r => r.Relationship != "Employee");
            }


            foreach (var rec in OldRecords) {
                List<CensusRow> matches;
                if (this.cbBasic.Checked) {
                    matches = NewRecords.Where(x => x.EID == rec.EID && x.PlanType == rec.PlanType).ToList();
                } else {
                    matches = NewRecords.Where(x =>
                    x.EID == rec.EID && x.FirstName.ToUpper() == rec.FirstName.ToUpper() && //rec.SSN.Trim().Replace("-", "") == x.SSN.Trim().Replace("-", "") &&
                    /*x.MiddleName.ToUpper() == rec.MiddleName.ToUpper() &&*/ x.LastName.ToUpper() == rec.LastName.ToUpper() &&
                    x.Relationship == rec.Relationship && x.PlanType == rec.PlanType).ToList();
                }

                if (matches.Count == 0) {
                    rec.Changes = "DROP";
                    rec.ElectionStatus = "DROP";
                    rec.flagged = true;
                    Drops.Add(rec);
                } else if (matches.Count > 1) {
                    MessageBox.Show("possible duplicate\n" + rec.ToString(), "Duplicate entry?", MessageBoxButtons.OK);
                } else {
                    if (!rec.Compare(matches.First(), this.cbBasic.Checked)) {
                        Changes.Add(matches.First());
                    }
                }
            }

            foreach (var rec in NewRecords) {
                List<CensusRow> matches;

                if (this.cbBasic.Checked) {
                    matches = OldRecords.Where(x => x.EID == rec.EID && x.PlanType == rec.PlanType).ToList();
                } else {
                    matches = OldRecords.Where(x =>
                        x.EID == rec.EID && x.FirstName.ToUpper() == rec.FirstName.ToUpper() && //rec.SSN.Trim().Replace("-", "") == x.SSN.Trim().Replace("-", "") &&
                        /*x.MiddleName.ToUpper() == rec.MiddleName.ToUpper() && */x.LastName.ToUpper() == rec.LastName.ToUpper() &&
                        x.Relationship == rec.Relationship && x.PlanType == rec.PlanType).ToList();
                }

                if (matches.Count == 0) {
                    rec.Changes = "ADD";
                    rec.ElectionStatus = "ADD";
                    rec.flagged = true;
                    Adds.Add(rec);
                } else if (matches.Count > 1) {
                    MessageBox.Show("possible duplicate\n" + rec.ToString(), "Duplicate entry?", MessageBoxButtons.OK);
                }
            }

            var newDrops = new List<CensusRow>();
            foreach (var drop in Drops) {
                var tempDrop = drop;
                var tList = OriginalNewRecords.Where(d => d.EID == tempDrop.EID && d.SSN == tempDrop.SSN && d.PlanType == tempDrop.PlanType).ToList();

                string dropDate = string.Empty;
                if (tList.Count > 0) {
                    dropDate = tList.First().EffectiveDate.ToString();
                    tempDrop.EffectiveDate = dropDate;
                }

                var ogRec = OriginalOldRecords.Where(d => d.EID == drop.EID && d.SSN == drop.SSN && d.PlanType == tempDrop.PlanType).ToList();
                var newRec = OriginalNewRecords.Where(d => d.EID == drop.EID && d.SSN == drop.SSN && d.PlanType == tempDrop.PlanType).ToList();

                tempDrop.PlanEffectiveStartDate = OriginalOldRecords.Where(d => d.EID == drop.EID && d.SSN == drop.SSN && d.PlanType == tempDrop.PlanType).ToList().First().EffectiveDate;

                if(!tempDrop.CoverageDetails.Contains("TERMINATED"))
                    tempDrop.CoverageDetails = (drop.CoverageDetails + " - TERMINATED " + dropDate).Trim();
                //tempDrop.ElectionStatus = "Terminated";
            }

            output.AddRange(Adds);
            output.AddRange(Drops);
            output.AddRange(Changes);

            var selected = lBoxPlanType.SelectedItems;

            if (selected.Count > 0) {
                var tempRecs = new List<CensusRow>();
                if (lBoxPlanType.SelectedItems.Count > 0) {
                    foreach (var rec in output) {
                        if (selected.Contains(rec.PlanType)) {
                            tempRecs.Add(rec);
                        }
                    }
                }
                output = tempRecs;
            }

            //check for flagged
            if (cbFlagged.Checked) {
                output = output.Where(f => f.flagged == true).ToList();
            }

            dgvOutPut.DataSource = output.OrderByDescending(o => o.PlanType)./*ThenBy(o => o.Changes).*/ThenBy(o => o.EID).
                ThenBy(o => o.RelationshipCode).ThenBy(o => o.FirstName).ToList();

            foreach (var col in dgvOutPut.Columns) {
                Console.WriteLine(col.ToString());
            }

            RemoveColumns();
        }

        private void btnOutput_Click(object sender, EventArgs e) {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string OutputFile = string.Empty;

            if (cbAutoChanges.Checked == true) {
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
            } else {
                OutputFile = Path.GetDirectoryName(NEWINPUTFILE);
            }

            if (OutputFile == string.Empty)
                return;

            var strTokens = new List<string>();
            string initials = string.Empty;
            string outputInitials = string.Empty;
            var planType = output.Select(o => o.PlanType).Distinct();
            var carriers = output.Select(c => c.Carrier).Distinct();

            foreach (var plan in planType) {
                initials = string.Empty;
                strTokens = plan.Split(' ').ToList();
                foreach(string token in strTokens) {
                    initials += token[0];
                }
                outputInitials += '-' + initials;
            }
            outputInitials += "_";

            string tempStr = string.Empty;
            foreach (var carrier in carriers) {
                tempStr += carrier.Replace(" ", "") + "_";
            }

            OutputFile = OutputFile + @"\Changes_" + outputInitials + tempStr +
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
                    if (cbAutoChanges.Checked == true) {
                        System.Diagnostics.Process.Start(OutputFile);
                    } else {
                        string text = "File Written to: \n" + OutputFile + "\nWould you like to open the file";
                        var answer = MessageBox.Show(text, "File Written, Open?", MessageBoxButtons.YesNo);
                        if(answer == DialogResult.Yes) {
                            System.Diagnostics.Process.Start(OutputFile);
                        }
                    }
                }

                if (cbCSV.Checked) {
                    OutputFile = OutputFile.Replace(".xlsx", ".csv");

                    if (File.Exists(OutputFile))
                        File.Delete(OutputFile);

                    File.Move(tempFile, OutputFile);
                    //MessageBox.Show("File written:\n" + OutputFile, "File written", MessageBoxButtons.OK);

                    if (cbAutoChanges.Checked == true) {
                        System.Diagnostics.Process.Start(OutputFile);
                    } else {
                        string text = "File Written to: \n" + OutputFile + "\nWould you like to open the file";
                        var answer = MessageBox.Show(text, "File Written, Open?", MessageBoxButtons.YesNo);
                        if (answer == DialogResult.Yes) {
                            System.Diagnostics.Process.Start(OutputFile);
                        }
                    }
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

            lBoxPlanType.DataSource = null;
            lBoxPlanType.Items.Clear();

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

        private void btnOutputEDIdata_Click(object sender, EventArgs e) {
            int counter = 0;
            bool useOldRows = false;

            List<CensusRow> newDrops = new List<CensusRow>();
            List<CensusRow> MissingTerms = new List<CensusRow>();

            foreach (var rec in Drops) {
                //if(tempRec == null) {
                var tempRec = OriginalNewRecords.Where(x =>
                    x.EID == rec.EID && x.FirstName == rec.FirstName &&
                    x.SSN == rec.SSN && x.LastName == rec.LastName &&
                    x.Relationship == rec.Relationship && x.PlanType == rec.PlanType).FirstOrDefault();
                // }

                if (tempRec == null) {
                    counter++;
                    string tMsg = string.Empty;
                    //if (!MissingTermEIDs.Contains(rec.EID)) {
                    tMsg += "Could not find term record in new file for\n" + rec.FirstName + " " + rec.LastName + "\n" + rec.PlanType;

                    tempRec = OriginalNewRecords.Where(x =>
                        x.SSN == rec.SSN && x.PlanType == rec.PlanType).FirstOrDefault();

                    if (tempRec != null) {
                        tMsg += "Found Missing Term using SSN.\nProbable EID Change";
                        //MessageBox.Show("Found Missing Term using SSN.\nProbable EID Change");
                    }

                    if (counter < 10 && useOldRows == false) {
                        MessageBox.Show(tMsg);
                    }

                    DialogResult diagRes = DialogResult.No;
                    if(counter == 1) {
                        diagRes = MessageBox.Show("Use Old File Records for Missing TERMS?", "USE OLD DATA", MessageBoxButtons.YesNo);
                        useOldRows = (diagRes == DialogResult.Yes);
                    }

                    if (useOldRows) {
                        tempRec = OldRecords.Where(x => x.EID == rec.EID && x.FirstName == rec.FirstName && 
                                x.SSN == rec.SSN && x.LastName == rec.LastName && x.Relationship == rec.Relationship && 
                                x.PlanType == rec.PlanType).FirstOrDefault();

                        if(tempRec == null) {
                            Console.WriteLine(tMsg);
                            continue;
                        } else {
                            tempRec.Changes = "DROP-OLD_DATA";
                            tempRec.ElectionStatus = "DROP";
                            tempRec.CoverageDetails += " - TERMINATED";
                            tempRec.EffectiveDate = string.Empty;
                            newDrops.Add(tempRec);
                            MissingTerms.Add(tempRec);
                            Console.WriteLine(tMsg + '\n' + "USED OLD DATA");
                           
                            continue;
                        }
                    } else {
                        Console.WriteLine(tMsg);
                        continue;
                    }
                    //}
                }

                //tempRec.PlanEffectiveStartDate = rec.EffectiveDate; //during drops, Plan Effective Start Date is used for plan start and effective date is for term date

                tempRec.PlanEffectiveStartDate = OriginalOldRecords.Where(d => d.EID == rec.EID && d.SSN == rec.SSN).ToList().First().EffectiveDate;
                //tempRec.CoverageDetails = rec.CoverageDetails + " - TERMINATED";
                tempRec.CoverageDetails = rec.CoverageDetails;
                tempRec.Changes = rec.Changes;
                tempRec.ElectionStatus = rec.ElectionStatus;

                newDrops.Add(tempRec);
            }

            if (counter > 0) {
                MessageBox.Show("missing terms = " + counter);
                StreamWriter file = new StreamWriter(Path.GetDirectoryName(NEWINPUTFILE) + "\\MissingTerms.txt");

                foreach (var missing in MissingTerms) {
                        file.WriteLine(missing.ToString());
                }
                file.Flush();
                file.Close();
            }


            var totalOut = NewRecords.Concat(newDrops);
            totalOut = totalOut.OrderBy(r => r.EID).ThenBy(r => r.RelationshipCode).ThenBy(r => r.FirstName).ToList();

            string OutputFile = string.Empty;
            if (cbOpenEDIData.Checked) {
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
            } else {
               OutputFile = Path.GetDirectoryName(NEWINPUTFILE);
            }

            if (OutputFile == string.Empty)
                return;

            OutputFile = OutputFile + @"\DataIn_" +
                DateTime.Now.ToString("MMddyyyy") + ".CSV";

            using (TextWriter writer = new StreamWriter(OutputFile)) {
                DataTable dt = totalOut.ToList().ToDataTable();
                RenameHeaders(dt);
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)) {
                    foreach (DataColumn col in dt.Columns) {
                        csv.WriteField(col.ColumnName);
                    }
                    csv.NextRecord();

                    foreach (DataRow row in dt.Rows) {
                        for (var i = 0; i < dt.Columns.Count; i++) {
                            csv.WriteField(row[i]);
                        }
                        csv.NextRecord();
                    }
                }
            }

            if (cbOpenEDIData.Checked) {
                System.Diagnostics.Process.Start(OutputFile);
            } else {
                string text = "File Written to: \n" + OutputFile + "\nWould you like to open the file";
                var answer = MessageBox.Show(text, "File Written, Open?", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes) {
                    System.Diagnostics.Process.Start(OutputFile);
                }
            }
        }

        public static void RenameHeaders(DataTable dt) {

            for (int i = 0; i < dt.Columns.Count; i++) {//rename to temp to avoid duplicating col names
                //Console.WriteLine(i + "\t" + dt.Columns[i].ColumnName);
                dt.Columns[i].ColumnName = "Column" + i;
            }

            for (int i = 0; i < dt.Rows[1].ItemArray.Length; i++) {
                Console.WriteLine(dt.Rows[1].ItemArray[i]);
            }

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
            dt.Columns[10].ColumnName = "Sex";
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
            dt.Columns[21].ColumnName = "Mailing Address";
            dt.Columns[22].ColumnName = "Personal Phone";
            dt.Columns[23].ColumnName = "Work Phone";
            dt.Columns[24].ColumnName = "Mobile Phone";
            dt.Columns[25].ColumnName = "Email";
            dt.Columns[26].ColumnName = "Personal Email";
            dt.Columns[27].ColumnName = "Employee Type";
            dt.Columns[28].ColumnName = "Employee Status";
            dt.Columns[29].ColumnName = "Hire Date";
            dt.Columns[30].ColumnName = "Termination Date";
            dt.Columns[31].ColumnName = "Termination Type";
            dt.Columns[32].ColumnName = "Department";
            dt.Columns[33].ColumnName = "Division";
            dt.Columns[34].ColumnName = "Job Class";
            dt.Columns[35].ColumnName = "Job Title";
            dt.Columns[36].ColumnName = "Marital Status";
            dt.Columns[37].ColumnName = "Marital Date";
            dt.Columns[38].ColumnName = "Marital Location";
            dt.Columns[39].ColumnName = "Student Status";
            dt.Columns[40].ColumnName = "Scheduled Hours";
            dt.Columns[41].ColumnName = "Sick Hours";
            dt.Columns[42].ColumnName = "Personal Hours";
            dt.Columns[43].ColumnName = "W2 Wages";
            dt.Columns[44].ColumnName = "Pay Cycle";
            dt.Columns[45].ColumnName = "Pay Periods";
            dt.Columns[46].ColumnName = "Payroll Id";
            dt.Columns[47].ColumnName = "Cost Factor";
            dt.Columns[48].ColumnName = "Tobacco User";
            dt.Columns[49].ColumnName = "Disabled";
            dt.Columns[50].ColumnName = "Medicare A Date";
            dt.Columns[51].ColumnName = "Medicare B Date";
            dt.Columns[52].ColumnName = "Medicare C Date";
            dt.Columns[53].ColumnName = "Medicare D Date";
            dt.Columns[54].ColumnName = "Medical PCP Name";
            dt.Columns[55].ColumnName = "Medical PCP ID";
            dt.Columns[56].ColumnName = "Dental PCP Name";
            dt.Columns[57].ColumnName = "Dental PCP ID";
            dt.Columns[58].ColumnName = "IPA Number";
            dt.Columns[59].ColumnName = "OBGYN";
            dt.Columns[60].ColumnName = "Benefit Eligible Date";
            dt.Columns[61].ColumnName = "Unlock Enrollment Date";
            dt.Columns[62].ColumnName = "Original Effective Date Info";
            dt.Columns[63].ColumnName = "Subscriber Key";
            dt.Columns[64].ColumnName = "Plan Type";
            dt.Columns[65].ColumnName = "Plan Effective Start Date";
            dt.Columns[66].ColumnName = "Plan Effective End Date";
            dt.Columns[67].ColumnName = "Plan Admin Name";
            dt.Columns[68].ColumnName = "Plan Display Name";
            dt.Columns[69].ColumnName = "Plan Import ID";
            dt.Columns[70].ColumnName = "Effective Date";
            dt.Columns[71].ColumnName = "Activity Date";
            dt.Columns[72].ColumnName = "Benefit Compensation Amount";
            dt.Columns[73].ColumnName = "Benefit Compensation Type";
            dt.Columns[74].ColumnName = "Coverage Details";
            dt.Columns[75].ColumnName = "Election Status";
            dt.Columns[76].ColumnName = "Processed Date";
            dt.Columns[77].ColumnName = "Rider Codes";
            dt.Columns[78].ColumnName = "Action";
            dt.Columns[79].ColumnName = "Waive Reason";
            dt.Columns[80].ColumnName = "Policy Number";
            dt.Columns[81].ColumnName = "Subgroup Number";
            dt.Columns[82].ColumnName = "Age Determination";
            dt.Columns[83].ColumnName = "Carrier";
            dt.Columns[84].ColumnName = "Total Rate";
            dt.Columns[85].ColumnName = "Employee Rate";
            dt.Columns[86].ColumnName = "Spouse Rate";
            dt.Columns[87].ColumnName = "Children Rate";
            dt.Columns[88].ColumnName = "Employee Contribution";
            dt.Columns[89].ColumnName = "Employee Pre-Tax Cost";
            dt.Columns[90].ColumnName = "Employee Post-Tax Cost";
            dt.Columns[91].ColumnName = "Employee Cost Per Deduction Period";
            dt.Columns[92].ColumnName = "Employer Contribution";
            dt.Columns[93].ColumnName = "Employer Cost Per Deduction Period";
            dt.Columns[94].ColumnName = "Plan Deduction Cycle";
            dt.Columns[95].ColumnName = "Last Modified Date";
            dt.Columns[96].ColumnName = "Last Modified By";
            dt.Columns[97].ColumnName = "E-Sign Date";
            dt.Columns[98].ColumnName = "VSP Code";




            for (int i = 0; i < dt.Rows[1].ItemArray.Length; i++) {
                Console.WriteLine(dt.Columns[i].ColumnName + "\t" + dt.Rows[0].ItemArray[i]);
            }

            Console.WriteLine("End Rename");
        }

        private void cbAutoChanges_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.OpenChangesFile = cbAutoChanges.Checked;
            Properties.Settings.Default.Save();
            Console.WriteLine("Changed cbAutoChanges to " + Properties.Settings.Default.OpenChangesFile);
        }

        private void cbOpenEDIData_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.OpenDataOut = cbOpenEDIData.Checked;
            Properties.Settings.Default.Save();
            Console.WriteLine("Changed cbOpenEDIData to " + Properties.Settings.Default.OpenChangesFile);
        }
    }
}
