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

namespace EaseEnrollCompare {
    public partial class Form1 : Form {
        public static string OLDINPUTFILE;
        public static string NEWINPUTFILE;
        public static bool OldLoaded = false;
        public static bool NewLoaded = false;

        public static List<CensusRow> OldRecords = new List<CensusRow>();
        public static List<CensusRow> NewRecords = new List<CensusRow>();
        public static List<CensusRow> Drops = new List<CensusRow>();
        public static List<CensusRow> Adds = new List<CensusRow>();
        public static List<CensusRow> Changes = new List<CensusRow>();
        public static List<CensusRow> output = new List<CensusRow>();

        public Form1() {
            InitializeComponent();
        }

        private void btnLoadOld_Click(object sender, EventArgs e) {

            using(OpenFileDialog ofd = new OpenFileDialog()) {
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
                            csv.Configuration.RegisterClassMap<CensusRowClassMap>();

                            try {
                                OldRecords = csv.GetRecords<CensusRow>().ToList();
                                btnLoadOld.Text = "Loaded " + OldRecords.Count + " Records";
                                btnLoadOld.Enabled = false;
                            } catch (Exception ex) {
                                Console.WriteLine(ex);
                            }
                        }
                    }
                } else {
                    MessageBox.Show("No File loaded, Please try again", "NO FILE", MessageBoxButtons.OK);
                }
            }

        }

        private void btnLoadNew_Click(object sender, EventArgs e) {

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
                            csv.Configuration.RegisterClassMap<CensusRowClassMap>();

                            try {
                                NewRecords = csv.GetRecords<CensusRow>().ToList();
                                btnLoadNew.Text = "Loaded " + NewRecords.Count + " Records";
                                btnLoadNew.Enabled = false;
                            } catch (Exception ex) {
                                Console.WriteLine(ex);
                            }
                        }
                    }
                } else {
                    MessageBox.Show("No File loaded, Please try again", "NO FILE", MessageBoxButtons.OK);
                }
            }
        }

        private void PrintList<T>(List<T> list) {
            foreach(var t in list) {
                Console.WriteLine(t.ToString());
            }
        }

        private void btnCompare_Click(object sender, EventArgs e) {

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
            PrintList(Adds);
            PrintList(Drops);
            PrintList(Changes);

            output.AddRange(Adds);
            output.AddRange(Drops);
            output.AddRange(Changes);


            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = Adds;
            dgvOutPut.DataSource = output;
        }

        private void btnOutput_Click(object sender, EventArgs e) {
            string OutputFile = string.Empty;
            using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                fbd.Description = "Select the directory to output files to";
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
                DateTime.Now.ToString("MMddyyyy") + ".csv";

           using(TextWriter writer = new StreamWriter(OutputFile)) {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)) {
                    csv.WriteRecords(output);
                }
            }

        }
    }
}
