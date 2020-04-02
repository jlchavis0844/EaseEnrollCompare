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
            this.btnLoadNew.Location = new System.Drawing.Point(31, 71);
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
            this.lblNewFile.Location = new System.Drawing.Point(216, 76);
            this.lblNewFile.Name = "lblNewFile";
            this.lblNewFile.Size = new System.Drawing.Size(91, 13);
            this.lblNewFile.TabIndex = 3;
            this.lblNewFile.Text = "Waiting for old file";
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(31, 114);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(164, 23);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "Run Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(219, 114);
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
            this.dgvOutPut.Location = new System.Drawing.Point(13, 152);
            this.dgvOutPut.Name = "dgvOutPut";
            this.dgvOutPut.ReadOnly = true;
            this.dgvOutPut.Size = new System.Drawing.Size(775, 536);
            this.dgvOutPut.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 700);
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
    }
}

