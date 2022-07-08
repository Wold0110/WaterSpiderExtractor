namespace WaterSpiderExtractor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.connStatusPanel = new System.Windows.Forms.Panel();
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.timelimitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connStatusPanel
            // 
            this.connStatusPanel.Location = new System.Drawing.Point(131, 12);
            this.connStatusPanel.Name = "connStatusPanel";
            this.connStatusPanel.Size = new System.Drawing.Size(18, 15);
            this.connStatusPanel.TabIndex = 0;
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Location = new System.Drawing.Point(12, 56);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(200, 23);
            this.fromDatePicker.TabIndex = 1;
            // 
            // toDatePicker
            // 
            this.toDatePicker.Location = new System.Drawing.Point(12, 105);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(200, 23);
            this.toDatePicker.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tól";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ig";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Csatlakozás Állapota";
            // 
            // downloadBtn
            // 
            this.downloadBtn.Location = new System.Drawing.Point(12, 146);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(200, 23);
            this.downloadBtn.TabIndex = 7;
            this.downloadBtn.Text = "Letöltés";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // timelimitBtn
            // 
            this.timelimitBtn.Location = new System.Drawing.Point(12, 175);
            this.timelimitBtn.Name = "timelimitBtn";
            this.timelimitBtn.Size = new System.Drawing.Size(200, 26);
            this.timelimitBtn.TabIndex = 8;
            this.timelimitBtn.Text = "Időben/Túlment";
            this.timelimitBtn.UseVisualStyleBackColor = true;
            this.timelimitBtn.Click += new System.EventHandler(this.timelimitBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 227);
            this.Controls.Add(this.timelimitBtn);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toDatePicker);
            this.Controls.Add(this.fromDatePicker);
            this.Controls.Add(this.connStatusPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Letöltő";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel connStatusPanel;
        private DateTimePicker fromDatePicker;
        private DateTimePicker toDatePicker;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button downloadBtn;
        private Button timelimitBtn;
    }
}