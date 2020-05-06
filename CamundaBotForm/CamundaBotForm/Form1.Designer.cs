namespace CamundaBotForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DefinitionIDTxtBox = new System.Windows.Forms.TextBox();
            this.JSONTxtBox = new System.Windows.Forms.TextBox();
            this.FileNameTxtBox = new System.Windows.Forms.TextBox();
            this.DefinitionKeyTxtBox = new System.Windows.Forms.TextBox();
            this.DefinitionIdLbl = new System.Windows.Forms.Label();
            this.DefinitionKeyLbl = new System.Windows.Forms.Label();
            this.JSONLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StartProcessCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TimesTxtBox = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.FilePathLbl = new System.Windows.Forms.Label();
            this.RunProgramBtn = new System.Windows.Forms.Button();
            this.SuccessLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label6 = new System.Windows.Forms.Label();
            this.DelayInterval = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.ProgressLbl = new System.Windows.Forms.Label();
            this.JSONCbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TimesTxtBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // DefinitionIDTxtBox
            // 
            this.DefinitionIDTxtBox.Location = new System.Drawing.Point(84, 93);
            this.DefinitionIDTxtBox.Name = "DefinitionIDTxtBox";
            this.DefinitionIDTxtBox.Size = new System.Drawing.Size(246, 20);
            this.DefinitionIDTxtBox.TabIndex = 0;
            // 
            // JSONTxtBox
            // 
            this.JSONTxtBox.Enabled = false;
            this.JSONTxtBox.Location = new System.Drawing.Point(215, 229);
            this.JSONTxtBox.Name = "JSONTxtBox";
            this.JSONTxtBox.Size = new System.Drawing.Size(448, 20);
            this.JSONTxtBox.TabIndex = 6;
            // 
            // FileNameTxtBox
            // 
            this.FileNameTxtBox.Location = new System.Drawing.Point(84, 296);
            this.FileNameTxtBox.Name = "FileNameTxtBox";
            this.FileNameTxtBox.Size = new System.Drawing.Size(246, 20);
            this.FileNameTxtBox.TabIndex = 7;
            // 
            // DefinitionKeyTxtBox
            // 
            this.DefinitionKeyTxtBox.Location = new System.Drawing.Point(417, 93);
            this.DefinitionKeyTxtBox.Name = "DefinitionKeyTxtBox";
            this.DefinitionKeyTxtBox.Size = new System.Drawing.Size(246, 20);
            this.DefinitionKeyTxtBox.TabIndex = 1;
            // 
            // DefinitionIdLbl
            // 
            this.DefinitionIdLbl.AutoSize = true;
            this.DefinitionIdLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefinitionIdLbl.Location = new System.Drawing.Point(81, 77);
            this.DefinitionIdLbl.Name = "DefinitionIdLbl";
            this.DefinitionIdLbl.Size = new System.Drawing.Size(78, 13);
            this.DefinitionIdLbl.TabIndex = 20;
            this.DefinitionIdLbl.Text = "Definition ID";
            // 
            // DefinitionKeyLbl
            // 
            this.DefinitionKeyLbl.AutoSize = true;
            this.DefinitionKeyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefinitionKeyLbl.Location = new System.Drawing.Point(414, 77);
            this.DefinitionKeyLbl.Name = "DefinitionKeyLbl";
            this.DefinitionKeyLbl.Size = new System.Drawing.Size(86, 13);
            this.DefinitionKeyLbl.TabIndex = 20;
            this.DefinitionKeyLbl.Text = "Definition Key";
            // 
            // JSONLbl
            // 
            this.JSONLbl.AutoSize = true;
            this.JSONLbl.Enabled = false;
            this.JSONLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JSONLbl.Location = new System.Drawing.Point(212, 213);
            this.JSONLbl.Name = "JSONLbl";
            this.JSONLbl.Size = new System.Drawing.Size(76, 13);
            this.JSONLbl.TabIndex = 20;
            this.JSONLbl.Text = "JSON String";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(81, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Times Started";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(81, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "File Name";
            // 
            // StartProcessCheckBox
            // 
            this.StartProcessCheckBox.AutoSize = true;
            this.StartProcessCheckBox.Checked = true;
            this.StartProcessCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StartProcessCheckBox.Location = new System.Drawing.Point(84, 129);
            this.StartProcessCheckBox.Name = "StartProcessCheckBox";
            this.StartProcessCheckBox.Size = new System.Drawing.Size(89, 17);
            this.StartProcessCheckBox.TabIndex = 2;
            this.StartProcessCheckBox.Text = "Start Process";
            this.StartProcessCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(414, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Save File Path";
            // 
            // TimesTxtBox
            // 
            this.TimesTxtBox.Location = new System.Drawing.Point(84, 165);
            this.TimesTxtBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.TimesTxtBox.Name = "TimesTxtBox";
            this.TimesTxtBox.Size = new System.Drawing.Size(246, 20);
            this.TimesTxtBox.TabIndex = 3;
            this.TimesTxtBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimesTxtBox.ValueChanged += new System.EventHandler(this.TimesTxtBox_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(418, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Select Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FilePathLbl
            // 
            this.FilePathLbl.AutoSize = true;
            this.FilePathLbl.Location = new System.Drawing.Point(510, 299);
            this.FilePathLbl.MaximumSize = new System.Drawing.Size(154, 0);
            this.FilePathLbl.Name = "FilePathLbl";
            this.FilePathLbl.Size = new System.Drawing.Size(57, 13);
            this.FilePathLbl.TabIndex = 17;
            this.FilePathLbl.Text = "File Path...";
            // 
            // RunProgramBtn
            // 
            this.RunProgramBtn.Location = new System.Drawing.Point(288, 347);
            this.RunProgramBtn.Name = "RunProgramBtn";
            this.RunProgramBtn.Size = new System.Drawing.Size(182, 29);
            this.RunProgramBtn.TabIndex = 9;
            this.RunProgramBtn.Text = "Run Camunda Test";
            this.RunProgramBtn.UseVisualStyleBackColor = true;
            this.RunProgramBtn.Click += new System.EventHandler(this.RunProgramBtn_Click);
            // 
            // SuccessLbl
            // 
            this.SuccessLbl.AutoSize = true;
            this.SuccessLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuccessLbl.ForeColor = System.Drawing.Color.DarkGreen;
            this.SuccessLbl.Location = new System.Drawing.Point(487, 347);
            this.SuccessLbl.Name = "SuccessLbl";
            this.SuccessLbl.Size = new System.Drawing.Size(130, 24);
            this.SuccessLbl.TabIndex = 19;
            this.SuccessLbl.Text = "File Created!";
            this.SuccessLbl.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(192, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(365, 42);
            this.label2.TabIndex = 20;
            this.label2.Text = "Camunda Testing Bot";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(400, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Delay between starting each process";
            // 
            // DelayInterval
            // 
            this.DelayInterval.Location = new System.Drawing.Point(417, 165);
            this.DelayInterval.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.DelayInterval.Name = "DelayInterval";
            this.DelayInterval.Size = new System.Drawing.Size(186, 20);
            this.DelayInterval.TabIndex = 4;
            this.DelayInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(609, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "milliseconds";
            // 
            // ProgressLbl
            // 
            this.ProgressLbl.AutoSize = true;
            this.ProgressLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.ProgressLbl.Location = new System.Drawing.Point(496, 347);
            this.ProgressLbl.Name = "ProgressLbl";
            this.ProgressLbl.Size = new System.Drawing.Size(122, 24);
            this.ProgressLbl.TabIndex = 25;
            this.ProgressLbl.Text = "Connecting...";
            this.ProgressLbl.Visible = false;
            // 
            // JSONCbox
            // 
            this.JSONCbox.AutoSize = true;
            this.JSONCbox.Location = new System.Drawing.Point(84, 229);
            this.JSONCbox.Name = "JSONCbox";
            this.JSONCbox.Size = new System.Drawing.Size(125, 17);
            this.JSONCbox.TabIndex = 5;
            this.JSONCbox.Text = "JSON String required";
            this.JSONCbox.UseVisualStyleBackColor = true;
            this.JSONCbox.CheckedChanged += new System.EventHandler(this.JSONCbox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 388);
            this.Controls.Add(this.JSONCbox);
            this.Controls.Add(this.StartProcessCheckBox);
            this.Controls.Add(this.ProgressLbl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DelayInterval);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SuccessLbl);
            this.Controls.Add(this.RunProgramBtn);
            this.Controls.Add(this.FilePathLbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TimesTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.JSONLbl);
            this.Controls.Add(this.DefinitionKeyLbl);
            this.Controls.Add(this.DefinitionIdLbl);
            this.Controls.Add(this.FileNameTxtBox);
            this.Controls.Add(this.DefinitionKeyTxtBox);
            this.Controls.Add(this.JSONTxtBox);
            this.Controls.Add(this.DefinitionIDTxtBox);
            this.Name = "Form1";
            this.Text = "Camunda Testing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TimesTxtBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DefinitionIDTxtBox;
        private System.Windows.Forms.TextBox JSONTxtBox;
        private System.Windows.Forms.TextBox FileNameTxtBox;
        private System.Windows.Forms.TextBox DefinitionKeyTxtBox;
        private System.Windows.Forms.Label DefinitionIdLbl;
        private System.Windows.Forms.Label DefinitionKeyLbl;
        private System.Windows.Forms.Label JSONLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox StartProcessCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown TimesTxtBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label FilePathLbl;
        private System.Windows.Forms.Button RunProgramBtn;
        private System.Windows.Forms.Label SuccessLbl;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown DelayInterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label ProgressLbl;
        private System.Windows.Forms.CheckBox JSONCbox;
    }
}

