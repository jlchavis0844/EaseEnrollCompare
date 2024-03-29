﻿namespace EaseEnrollCompare {
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
            this.cbOldWaived = new System.Windows.Forms.CheckBox();
            this.cbOldTerm = new System.Windows.Forms.CheckBox();
            this.cbNewTerm = new System.Windows.Forms.CheckBox();
            this.cbNewWaived = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.cbActiveOld = new System.Windows.Forms.CheckBox();
            this.cbActiveNew = new System.Windows.Forms.CheckBox();
            this.dpActiveDateOld = new System.Windows.Forms.DateTimePicker();
            this.cbExcel = new System.Windows.Forms.CheckBox();
            this.cbCSV = new System.Windows.Forms.CheckBox();
            this.btnOutputEDIdata = new System.Windows.Forms.Button();
            this.dpActiveDateNew = new System.Windows.Forms.DateTimePicker();
            this.cbBasic = new System.Windows.Forms.CheckBox();
            this.lBoxPlanType = new System.Windows.Forms.ListBox();
            this.lblPlanLimit = new System.Windows.Forms.Label();
            this.cbFlagged = new System.Windows.Forms.CheckBox();
            this.cbAutoChanges = new System.Windows.Forms.CheckBox();
            this.cbOpenEDIData = new System.Windows.Forms.CheckBox();
            this.cbEmpOnly = new System.Windows.Forms.CheckBox();
            this.btnCopy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutPut)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadOld
            // 
            this.btnLoadOld.Location = new System.Drawing.Point(31, 36);
            this.btnLoadOld.Name = "btnLoadOld";
            this.btnLoadOld.Size = new System.Drawing.Size(164, 23);
            this.btnLoadOld.TabIndex = 0;
            this.btnLoadOld.Text = "Load Old File";
            this.btnLoadOld.UseVisualStyleBackColor = true;
            this.btnLoadOld.Click += new System.EventHandler(this.btnLoadOld_Click);
            // 
            // btnLoadNew
            // 
            this.btnLoadNew.Location = new System.Drawing.Point(31, 106);
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
            this.lblOldFile.Location = new System.Drawing.Point(28, 62);
            this.lblOldFile.Name = "lblOldFile";
            this.lblOldFile.Size = new System.Drawing.Size(91, 13);
            this.lblOldFile.TabIndex = 2;
            this.lblOldFile.Text = "Waiting for old file";
            // 
            // lblNewFile
            // 
            this.lblNewFile.AutoSize = true;
            this.lblNewFile.Location = new System.Drawing.Point(28, 128);
            this.lblNewFile.Name = "lblNewFile";
            this.lblNewFile.Size = new System.Drawing.Size(97, 13);
            this.lblNewFile.TabIndex = 3;
            this.lblNewFile.Text = "Waiting for new file";
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(31, 205);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(164, 23);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "Run Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Enabled = false;
            this.btnOutput.Location = new System.Drawing.Point(219, 205);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(164, 23);
            this.btnOutput.TabIndex = 5;
            this.btnOutput.Text = "Output Changes File";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // dgvOutPut
            // 
            this.dgvOutPut.AllowUserToAddRows = false;
            this.dgvOutPut.AllowUserToDeleteRows = false;
            this.dgvOutPut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOutPut.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvOutPut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutPut.Location = new System.Drawing.Point(13, 243);
            this.dgvOutPut.Name = "dgvOutPut";
            this.dgvOutPut.ReadOnly = true;
            this.dgvOutPut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOutPut.Size = new System.Drawing.Size(1397, 798);
            this.dgvOutPut.TabIndex = 6;
            // 
            // cbOldWaived
            // 
            this.cbOldWaived.AutoSize = true;
            this.cbOldWaived.Checked = true;
            this.cbOldWaived.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOldWaived.Location = new System.Drawing.Point(31, 14);
            this.cbOldWaived.Name = "cbOldWaived";
            this.cbOldWaived.Size = new System.Drawing.Size(106, 17);
            this.cbOldWaived.TabIndex = 7;
            this.cbOldWaived.Text = "Remove Waived";
            this.cbOldWaived.UseVisualStyleBackColor = true;
            this.cbOldWaived.CheckedChanged += new System.EventHandler(this.cbOldWaive_CheckedChanged);
            // 
            // cbOldTerm
            // 
            this.cbOldTerm.AutoSize = true;
            this.cbOldTerm.Checked = true;
            this.cbOldTerm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOldTerm.Location = new System.Drawing.Point(173, 14);
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
            this.cbNewTerm.Location = new System.Drawing.Point(173, 83);
            this.cbNewTerm.Name = "cbNewTerm";
            this.cbNewTerm.Size = new System.Drawing.Size(122, 17);
            this.cbNewTerm.TabIndex = 10;
            this.cbNewTerm.Text = "Remove Terminated";
            this.cbNewTerm.UseVisualStyleBackColor = true;
            this.cbNewTerm.CheckedChanged += new System.EventHandler(this.cbNewTerm_CheckedChanged);
            // 
            // cbNewWaived
            // 
            this.cbNewWaived.AutoSize = true;
            this.cbNewWaived.Checked = true;
            this.cbNewWaived.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNewWaived.Location = new System.Drawing.Point(31, 83);
            this.cbNewWaived.Name = "cbNewWaived";
            this.cbNewWaived.Size = new System.Drawing.Size(106, 17);
            this.cbNewWaived.TabIndex = 9;
            this.cbNewWaived.Text = "Remove Waived";
            this.cbNewWaived.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(595, 205);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cbActiveOld
            // 
            this.cbActiveOld.AutoSize = true;
            this.cbActiveOld.Location = new System.Drawing.Point(339, 14);
            this.cbActiveOld.Name = "cbActiveOld";
            this.cbActiveOld.Size = new System.Drawing.Size(107, 17);
            this.cbActiveOld.TabIndex = 12;
            this.cbActiveOld.Text = "Use Only Actives";
            this.cbActiveOld.UseVisualStyleBackColor = true;
            this.cbActiveOld.CheckedChanged += new System.EventHandler(this.cbActiveOld_CheckedChanged);
            // 
            // cbActiveNew
            // 
            this.cbActiveNew.AutoSize = true;
            this.cbActiveNew.Location = new System.Drawing.Point(339, 83);
            this.cbActiveNew.Name = "cbActiveNew";
            this.cbActiveNew.Size = new System.Drawing.Size(107, 17);
            this.cbActiveNew.TabIndex = 13;
            this.cbActiveNew.Text = "Use Only Actives";
            this.cbActiveNew.UseVisualStyleBackColor = true;
            this.cbActiveNew.CheckedChanged += new System.EventHandler(this.cbActiveNew_CheckedChanged);
            // 
            // dpActiveDateOld
            // 
            this.dpActiveDateOld.Enabled = false;
            this.dpActiveDateOld.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpActiveDateOld.Location = new System.Drawing.Point(452, 14);
            this.dpActiveDateOld.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dpActiveDateOld.Name = "dpActiveDateOld";
            this.dpActiveDateOld.Size = new System.Drawing.Size(109, 20);
            this.dpActiveDateOld.TabIndex = 14;
            // 
            // cbExcel
            // 
            this.cbExcel.AutoSize = true;
            this.cbExcel.Checked = true;
            this.cbExcel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbExcel.Location = new System.Drawing.Point(31, 149);
            this.cbExcel.Name = "cbExcel";
            this.cbExcel.Size = new System.Drawing.Size(87, 17);
            this.cbExcel.TabIndex = 15;
            this.cbExcel.Text = "Output Excel";
            this.cbExcel.UseVisualStyleBackColor = true;
            // 
            // cbCSV
            // 
            this.cbCSV.AutoSize = true;
            this.cbCSV.Location = new System.Drawing.Point(135, 149);
            this.cbCSV.Name = "cbCSV";
            this.cbCSV.Size = new System.Drawing.Size(82, 17);
            this.cbCSV.TabIndex = 16;
            this.cbCSV.Text = "Output CSV";
            this.cbCSV.UseVisualStyleBackColor = true;
            // 
            // btnOutputEDIdata
            // 
            this.btnOutputEDIdata.Enabled = false;
            this.btnOutputEDIdata.Location = new System.Drawing.Point(407, 205);
            this.btnOutputEDIdata.Name = "btnOutputEDIdata";
            this.btnOutputEDIdata.Size = new System.Drawing.Size(164, 23);
            this.btnOutputEDIdata.TabIndex = 17;
            this.btnOutputEDIdata.Text = "Output EDI Data";
            this.btnOutputEDIdata.UseVisualStyleBackColor = true;
            this.btnOutputEDIdata.Click += new System.EventHandler(this.btnOutputEDIdata_Click);
            // 
            // dpActiveDateNew
            // 
            this.dpActiveDateNew.Enabled = false;
            this.dpActiveDateNew.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpActiveDateNew.Location = new System.Drawing.Point(452, 83);
            this.dpActiveDateNew.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dpActiveDateNew.Name = "dpActiveDateNew";
            this.dpActiveDateNew.Size = new System.Drawing.Size(109, 20);
            this.dpActiveDateNew.TabIndex = 18;
            // 
            // cbBasic
            // 
            this.cbBasic.AutoSize = true;
            this.cbBasic.Location = new System.Drawing.Point(193, 176);
            this.cbBasic.Name = "cbBasic";
            this.cbBasic.Size = new System.Drawing.Size(213, 17);
            this.cbBasic.TabIndex = 19;
            this.cbBasic.Text = "Basic Mode (EID, Type, Coverage only)";
            this.cbBasic.UseVisualStyleBackColor = true;
            // 
            // lBoxPlanType
            // 
            this.lBoxPlanType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lBoxPlanType.FormattingEnabled = true;
            this.lBoxPlanType.Location = new System.Drawing.Point(1148, 29);
            this.lBoxPlanType.Name = "lBoxPlanType";
            this.lBoxPlanType.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lBoxPlanType.Size = new System.Drawing.Size(262, 160);
            this.lBoxPlanType.TabIndex = 20;
            // 
            // lblPlanLimit
            // 
            this.lblPlanLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlanLimit.AutoSize = true;
            this.lblPlanLimit.Location = new System.Drawing.Point(1145, 9);
            this.lblPlanLimit.Name = "lblPlanLimit";
            this.lblPlanLimit.Size = new System.Drawing.Size(145, 13);
            this.lblPlanLimit.TabIndex = 21;
            this.lblPlanLimit.Text = "Limit Compare To Only Below";
            this.lblPlanLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbFlagged
            // 
            this.cbFlagged.AutoSize = true;
            this.cbFlagged.Location = new System.Drawing.Point(31, 176);
            this.cbFlagged.Name = "cbFlagged";
            this.cbFlagged.Size = new System.Drawing.Size(139, 17);
            this.cbFlagged.TabIndex = 22;
            this.cbFlagged.Text = "Important Changes Only";
            this.cbFlagged.UseVisualStyleBackColor = true;
            // 
            // cbAutoChanges
            // 
            this.cbAutoChanges.AutoSize = true;
            this.cbAutoChanges.Checked = global::EaseEnrollCompare.Properties.Settings.Default.OpenChangesFile;
            this.cbAutoChanges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoChanges.Location = new System.Drawing.Point(429, 176);
            this.cbAutoChanges.Name = "cbAutoChanges";
            this.cbAutoChanges.Size = new System.Drawing.Size(141, 17);
            this.cbAutoChanges.TabIndex = 23;
            this.cbAutoChanges.Text = "Auto Open Changes File";
            this.cbAutoChanges.UseVisualStyleBackColor = true;
            this.cbAutoChanges.CheckedChanged += new System.EventHandler(this.cbAutoChanges_CheckedChanged);
            // 
            // cbOpenEDIData
            // 
            this.cbOpenEDIData.AutoSize = true;
            this.cbOpenEDIData.Checked = global::EaseEnrollCompare.Properties.Settings.Default.OpenDataOut;
            this.cbOpenEDIData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOpenEDIData.Location = new System.Drawing.Point(593, 176);
            this.cbOpenEDIData.Name = "cbOpenEDIData";
            this.cbOpenEDIData.Size = new System.Drawing.Size(143, 17);
            this.cbOpenEDIData.TabIndex = 24;
            this.cbOpenEDIData.Text = "Auto Open EDI Data File";
            this.cbOpenEDIData.UseVisualStyleBackColor = true;
            this.cbOpenEDIData.CheckedChanged += new System.EventHandler(this.cbOpenEDIData_CheckedChanged);
            // 
            // cbEmpOnly
            // 
            this.cbEmpOnly.AutoSize = true;
            this.cbEmpOnly.Location = new System.Drawing.Point(236, 149);
            this.cbEmpOnly.Name = "cbEmpOnly";
            this.cbEmpOnly.Size = new System.Drawing.Size(96, 17);
            this.cbEmpOnly.TabIndex = 25;
            this.cbEmpOnly.Text = "Employee Only";
            this.cbEmpOnly.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(1334, 214);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 26;
            this.btnCopy.Text = "Copy Data";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 1053);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.cbEmpOnly);
            this.Controls.Add(this.cbOpenEDIData);
            this.Controls.Add(this.cbAutoChanges);
            this.Controls.Add(this.cbFlagged);
            this.Controls.Add(this.lblPlanLimit);
            this.Controls.Add(this.lBoxPlanType);
            this.Controls.Add(this.cbBasic);
            this.Controls.Add(this.dpActiveDateNew);
            this.Controls.Add(this.btnOutputEDIdata);
            this.Controls.Add(this.cbCSV);
            this.Controls.Add(this.cbExcel);
            this.Controls.Add(this.dpActiveDateOld);
            this.Controls.Add(this.cbActiveNew);
            this.Controls.Add(this.cbActiveOld);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cbNewTerm);
            this.Controls.Add(this.cbNewWaived);
            this.Controls.Add(this.cbOldTerm);
            this.Controls.Add(this.cbOldWaived);
            this.Controls.Add(this.dgvOutPut);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.lblNewFile);
            this.Controls.Add(this.lblOldFile);
            this.Controls.Add(this.btnLoadNew);
            this.Controls.Add(this.btnLoadOld);
            this.Name = "Form1";
            this.Text = "Ease Enrollment Comparison Tool";
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
        private System.Windows.Forms.CheckBox cbOldWaived;
        private System.Windows.Forms.CheckBox cbOldTerm;
        private System.Windows.Forms.CheckBox cbNewTerm;
        private System.Windows.Forms.CheckBox cbNewWaived;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox cbActiveOld;
        private System.Windows.Forms.CheckBox cbActiveNew;
        private System.Windows.Forms.DateTimePicker dpActiveDateOld;
        private System.Windows.Forms.CheckBox cbExcel;
        private System.Windows.Forms.CheckBox cbCSV;
        private System.Windows.Forms.Button btnOutputEDIdata;
        private System.Windows.Forms.DateTimePicker dpActiveDateNew;
        private System.Windows.Forms.CheckBox cbBasic;
        private System.Windows.Forms.ListBox lBoxPlanType;
        private System.Windows.Forms.Label lblPlanLimit;
        private System.Windows.Forms.CheckBox cbFlagged;
        private System.Windows.Forms.CheckBox cbAutoChanges;
        private System.Windows.Forms.CheckBox cbOpenEDIData;
        private System.Windows.Forms.CheckBox cbEmpOnly;
        private System.Windows.Forms.Button btnCopy;
    }
}

