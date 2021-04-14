
namespace TemperatureTask
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.entryLabel = new System.Windows.Forms.Label();
            this.entryTextField = new System.Windows.Forms.TextBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.resulLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Celsius",
            "Kelvin",
            "Fahrenheit"});
            this.comboBox1.Location = new System.Drawing.Point(11, 197);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Fahrenheit",
            "Kelvin",
            "Celsius"});
            this.comboBox2.Location = new System.Drawing.Point(151, 197);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // entryLabel
            // 
            this.entryLabel.AutoSize = true;
            this.entryLabel.Location = new System.Drawing.Point(12, 9);
            this.entryLabel.Name = "entryLabel";
            this.entryLabel.Size = new System.Drawing.Size(88, 13);
            this.entryLabel.TabIndex = 3;
            this.entryLabel.Text = "Enter temperate: ";
            // 
            // entryTextField
            // 
            this.entryTextField.Location = new System.Drawing.Point(11, 35);
            this.entryTextField.Name = "entryTextField";
            this.entryTextField.Size = new System.Drawing.Size(261, 20);
            this.entryTextField.TabIndex = 4;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(86, 148);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 13);
            this.resultLabel.TabIndex = 5;
            // 
            // resulLabel
            // 
            this.resulLabel.AutoSize = true;
            this.resulLabel.Location = new System.Drawing.Point(8, 78);
            this.resulLabel.Name = "resulLabel";
            this.resulLabel.Size = new System.Drawing.Size(35, 13);
            this.resulLabel.TabIndex = 6;
            this.resulLabel.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 240);
            this.Controls.Add(this.resulLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.entryTextField);
            this.Controls.Add(this.entryLabel);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Temperature converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label entryLabel;
        private System.Windows.Forms.TextBox entryTextField;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label resulLabel;
    }
}

