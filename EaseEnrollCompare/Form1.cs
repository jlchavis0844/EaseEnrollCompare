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
            dpActiveDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            // Log the exception, display it, etc
            MessageBox.Show((e.ExceptionObject as Exception).Message,"UNHANDLED EXCEPTION", MessageBoxButtons.OK);
        }

        private void btnLoadOld_Click(object sender, EventArgs e) {
            btnLoadOld.Enabled = false;
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = "CSV File (*.csv) | *.csv";
                ofd.RestoreDirectory = true;
                ofd.FilterIndex = 1;

                if(ofd.ShowDialog() == DialogResult.OK) {
                    OLDINPUTFILE = ofd.FileName;
                    this.lblOldFile.Text = OLDINPUTFILE;

                    var loadedFile = File.Open(OLDINPUTFILE, FileMode.Open, FileAccess.Read, 
                        FileShare.ReadWrite);

                    using(var reader = new StreamReader(loadedFile)) {
                        using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {
                            csv.Configuration.HeaderValidated = null;
                            csv.Configuration.HasHeaderRecord = true;
                            csv.Configuration.MissingFieldFound = null;
                            csv.Configuration.RegisterClassMap<CensusRowClassMap>();

                            try {
                                OriginalOldRecords = OldRecords = csv.GetRecords<CensusRow>().ToList();
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
                                OriginalNewRecords = NewRecords = csv.GetRecords<CensusRow>().ToList();
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
            foreach(var t in list) {
                Console.WriteLine(t.ToString());
            }
        }

        private void RemoveColumns() {
            foreach(DataGridViewColumn col in dgvOutPut.Columns) {
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
            NewRecords = (from rec in NewRecords
                         orderby rec.EID, rec.RelationshipCode, rec.FirstName
                         select rec).ToList();

            OldRecords = (from rec in OldRecords
                          orderby rec.EID, rec.RelationshipCode, rec.FirstName
                          select rec).ToList();

            foreach(var rec in OldRecords) {
                List<CensusRow> matches = NewRecords.Where(x => 
                x.EID == rec.EID && x.FirstName == rec.FirstName &&
                x.MiddleName == rec.MiddleName && x.LastName == rec.LastName &&
                x.Relationship == rec.Relationship && x.PlanType == rec.PlanType).ToList();

                if(matches.Count == 0) {
                    rec.Changes = "DROP";
                    Drops.Add(rec);
                } else if(matches.Count > 1){
                    MessageBox.Show("possible duplicate\n" + rec.ToString(), "Duplicate entry?", MessageBoxButtons.OK);
                } else {
                    if(!rec.Compare(matches.First())) {
                        Changes.Add(matches.First());
                    }
                }
            }

            foreach (var rec in NewRecords) {
                List<CensusRow> matches = OldRecords.Where(x =>
                x.EID == rec.EID && x.FirstName == rec.FirstName &&
                x.MiddleName == rec.MiddleName && x.LastName == rec.LastName &&
                x.Relationship == rec.Relationship && x.PlanType == rec.PlanType).ToList();

                if (matches.Count == 0) {
                    rec.Changes = "ADD";
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

            foreach(var col in dgvOutPut.Columns) {
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


                    package.Save();
                }

                if (File.Exists(tempFile)) {
                    File.Delete(tempFile);
                }

                MessageBox.Show("File written:\n" + OutputFile, "File written", MessageBoxButtons.OK);
                System.Diagnostics.Process.Start(OutputFile);

            } catch(Exception exc) {
                MessageBox.Show("Could not write file:" + OutputFile + "\n" + exc.Message, "Write Error", MessageBoxButtons.OK);

            }

        }

        private bool ShouldBeRemovedOld(CensusRow row) {
            if (cbOldTerm.Checked) {
                if (row.ElectionStatus == "Terminated")
                    return true;
            }

            if (cbOldWaived.Checked) {
                if(row.ElectionStatus == "Waived") {
                    return true;
                }
            }

            if (cbActiveOld.Checked) {
                if (row.ElectionStatus == "Waived") {
                    return true;
                } else if(row.ElectionStatus == "Terminated"){
                    if(DateTime.Parse(row.EffectiveDate)<= dpActiveDate.Value) {
                        return true;
                    }
                } else {
                    if (DateTime.Parse(row.EffectiveDate) > dpActiveDate.Value) {
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
                    if (DateTime.Parse(row.EffectiveDate) <= dpActiveDate.Value) {
                        return true;
                    }
                } else {
                    if (DateTime.Parse(row.EffectiveDate) > dpActiveDate.Value) {
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

            dpActiveDate.Enabled = false;
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
            if (!cbActiveOld.Checked) {//fires before changing, logic based on pre-click
                this.cbOldTerm.Checked = true;
                this.cbOldTerm.Enabled = true;
                this.cbOldTerm.Checked = true;
                this.cbOldTerm.Enabled = true;
                this.cbOldWaived.Checked = true;
                this.cbOldWaived.Enabled = true;
                this.dpActiveDate.Enabled = false;
            } else {
                this.cbOldTerm.Checked = false;
                this.cbOldTerm.Enabled = false;
                this.cbOldTerm.Checked = false;
                this.cbOldTerm.Enabled = false;
                this.cbOldWaived.Checked = false;
                this.cbOldWaived.Enabled = false;
                this.dpActiveDate.Enabled = true;
            }
        }

        private void cbActiveNew_CheckedChanged(object sender, EventArgs e) {
            if (!cbActiveNew.Checked) {//fires before changing, logic based on pre-click
                this.cbNewTerm.Checked = true;
                this.cbNewTerm.Enabled = true;
                this.cbNewTerm.Checked = true;
                this.cbNewTerm.Enabled = true;
                this.cbNewWaived.Checked = true;
                this.cbNewWaived.Enabled = true;
                this.dpActiveDate.Enabled = false;
            } else {
                this.cbNewTerm.Checked = false;
                this.cbNewTerm.Enabled = false;
                this.cbNewTerm.Checked = false;
                this.cbNewTerm.Enabled = false;
                this.cbNewWaived.Checked = false;
                this.cbNewWaived.Enabled = false;
                this.dpActiveDate.Enabled = true;
            }
        }
    }
}
