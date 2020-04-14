namespace EaseEnrollCompare {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnLoadOld = new System.Windows.Forms.Button();
            this.btnLoadNew = new System.Windows.Forms.Button();
            this.lblOldFile = new System.Windows.Forms.Label();
            this.lblNewFile = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.dgvOutPut = new System.Windows.Forms.DataGridView();
            this.cbOldWaive = new System.Windows.Forms.CheckBox();
            this.cbOldTerm = new System.Windows.Forms.CheckBox();
            this.cbNewTerm = new System.Windows.Forms.CheckBox();
            this.cbNewWavied = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutPut)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadOld
            // 
            this.btnLoadOld.Location = new System.Drawing.Point(31, 26);
            this.btnLoadOld.Name = "btnLoadOld";
            this.btnLoadOld.Size = new System.Drawing.Size(164, 23);
            this.btnLoadOld.TabIndex = 0;
            this.btnLoadOld.Text = "Load Old File";
            this.btnLoadOld.UseVisualStyleBackColor = true;
            this.btnLoadOld.Click += new System.EventHandler(this.btnLoadOld_Click);
            // 
            // btnLoadNew
            // 
            this.btnLoadNew.Location = new System.Drawing.Point(31, 96);
            this.btnLoadNew.Name = "btnLoadNew";
            this.btnLoadNew.Size = new System.Drawing.Size(164, 23);
            this.btnLoadNew.TabIndex = 1;
            this.btnLoadNew.Text = "Load New File";
            this.btnLoadNew.UseVisualStyleBackColor = true;
            this.btnLoadNew.Click += new System.EventHandler(this.btnLoadNew_Click);
            // 
            // lblOldFile
            // 
            this.lblOldFile.AutoSize = true;
            this.lblOldFile.Location = new System.Drawing.Point(216, 31);
            this.lblOldFile.Name = "lblOldFile";
            this.lblOldFile.Size = new System.Drawing.Size(91, 13);
            this.lblOldFile.TabIndex = 2;
            this.lblOldFile.Text = "Waiting for old file";
            // 
            // lblNewFile
            // 
            this.lblNewFile.AutoSize = true;
            this.lblNewFile.Location = new System.Drawing.Point(216, 101);
            this.lblNewFile.Name = "lblNewFile";
            this.lblNewFile.Size = new System.Drawing.Size(97, 13);
            this.lblNewFile.TabIndex = 3;
            this.lblNewFile.Text = "Waiting for new file";
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(31, 155);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(164, 23);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "Run Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(219, 155);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(164, 23);
            this.btnOutput.TabIndex = 5;
            this.btnOutput.Text = "Output File";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // dgvOutPut
            // 
            this.dgvOutPut.AllowUserToAddRows = false;
            this.dgvOutPut.AllowUserToDeleteRows = false;
            this.dgvOutPut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutPut.Location = new System.Drawing.Point(13, 204);
            this.dgvOutPut.Name = "dgvOutPut";
            this.dgvOutPut.ReadOnly = true;
            this.dgvOutPut.Size = new System.Drawing.Size(775, 484);
            this.dgvOutPut.TabIndex = 6;
            // 
            // cbOldWaive
            // 
            this.cbOldWaive.AutoSize = true;
            this.cbOldWaive.Checked = true;
            this.cbOldWaive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOldWaive.Location = new System.Drawing.Point(31, 3);
            this.cbOldWaive.Name = "cbOldWaive";
            this.cbOldWaive.Size = new System.Drawing.Size(106, 17);
            this.cbOldWaive.TabIndex = 7;
            this.cbOldWaive.Text = "Remove Wavied";
            this.cbOldWaive.UseVisualStyleBackColor = true;
            this.cbOldWaive.CheckedChanged += new System.EventHandler(this.cbOldWaive_CheckedChanged);
            // 
            // cbOldTerm
            // 
            this.cbOldTerm.AutoSize = true;
            this.cbOldTerm.Checked = true;
            this.cbOldTerm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOldTerm.Location = new System.Drawing.Point(173, 3);
            this.cbOldTerm.Name = "cbOldTerm";
            this.cbOldTerm.Size = new System.Drawing.Size(122, 17);
            this.cbOldTerm.TabIndex = 8;
            this.cbOldTerm.Text = "Remove Terminated";
            this.cbOldTerm.UseVisualStyleBackColor = true;
            // 
            // cbNewTerm
            // 
            this.cbNewTerm.AutoSize = true;
            this.cbNewTerm.Checked = true;
            this.cbNewTerm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNewTerm.Location = new System.Drawing.Point(173, 73);
            this.cbNewTerm.Name = "cbNewTerm";
            this.cbNewTerm.Size = new System.Drawing.Size(122, 17);
            this.cbNewTerm.TabIndex = 10;
            this.cbNewTerm.Text = "Remove Terminated";
            this.cbNewTerm.UseVisualStyleBackColor = true;
            // 
            // cbNewWavied
            // 
            this.cbNewWavied.AutoSize = true;
            this.cbNewWavied.Checked = true;
            this.cbNewWavied.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNewWavied.Location = new System.Drawing.Point(31, 73);
            this.cbNewWavied.Name = "cbNewWavied";
            this.cbNewWavied.Size = new System.Drawing.Size(106, 17);
            this.cbNewWavied.TabIndex = 9;
            this.cbNewWavied.Text = "Remove Wavied";
            this.cbNewWavied.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(411, 155);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cbNewTerm);
            this.Controls.Add(this.cbNewWavied);
            this.Controls.Add(this.cbOldTerm);
            this.Controls.Add(this.cbOldWaive);
            this.Controls.Add(this.dgvOutPut);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.lblNewFile);
            this.Controls.Add(this.lblOldFile);
            this.Controls.Add(this.btnLoadNew);
            this.Controls.Add(this.btnLoadOld);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutPut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadOld;
        private System.Windows.Forms.Button btnLoadNew;
        private System.Windows.Forms.Label lblOldFile;
        private System.Windows.Forms.Label lblNewFile;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.DataGridView dgvOutPut;
        private System.Windows.Forms.CheckBox cbOldWaive;
        private System.Windows.Forms.CheckBox cbOldTerm;
        private System.Windows.Forms.CheckBox cbNewTerm;
        private System.Windows.Forms.CheckBox cbNewWavied;
        private System.Windows.Forms.Button btnReset;
    }
}

