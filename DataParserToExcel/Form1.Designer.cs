namespace DataParserToExcel
{
    partial class TTEP
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnChooseImportFile = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose import file";
            // 
            // btnChooseImportFile
            // 
            this.btnChooseImportFile.Location = new System.Drawing.Point(10, 67);
            this.btnChooseImportFile.Name = "btnChooseImportFile";
            this.btnChooseImportFile.Size = new System.Drawing.Size(58, 23);
            this.btnChooseImportFile.TabIndex = 2;
            this.btnChooseImportFile.Text = "Choose";
            this.btnChooseImportFile.UseVisualStyleBackColor = true;
            this.btnChooseImportFile.Click += new System.EventHandler(this.btnChooseImportFile_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(124, 67);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(58, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 23);
            this.textBox1.TabIndex = 6;
            // 
            // TTEP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 161);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnChooseImportFile);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(210, 200);
            this.MinimumSize = new System.Drawing.Size(210, 200);
            this.Name = "TTEP";
            this.Text = "TTEP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btnChooseImportFile;
        private Button btnExport;
        private TextBox textBox1;
    }
}