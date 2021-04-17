
namespace TemperatureTask
{
    partial class MainForm
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.calculateButton = new System.Windows.Forms.Button();
            this.temperatureValueLabel = new System.Windows.Forms.Label();
            this.fromScaleLabel = new System.Windows.Forms.Label();
            this.toScaleLabel = new System.Windows.Forms.Label();
            this.fromScaleComboBox = new System.Windows.Forms.ComboBox();
            this.toScaleComboBox = new System.Windows.Forms.ComboBox();
            this.entryTextField = new System.Windows.Forms.TextBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(162)))));
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.calculateButton, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.temperatureValueLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.fromScaleLabel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.toScaleLabel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.fromScaleComboBox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.toScaleComboBox, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.entryTextField, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.resultLabel, 1, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(281, 213);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // calculateButton
            // 
            this.calculateButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.calculateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calculateButton.FlatAppearance.BorderSize = 0;
            this.calculateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculateButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculateButton.ForeColor = System.Drawing.Color.Sienna;
            this.calculateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.calculateButton.Location = new System.Drawing.Point(3, 167);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(89, 38);
            this.calculateButton.TabIndex = 0;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // temperatureValueLabel
            // 
            this.temperatureValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.temperatureValueLabel.AutoSize = true;
            this.temperatureValueLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperatureValueLabel.ForeColor = System.Drawing.Color.Sienna;
            this.temperatureValueLabel.Location = new System.Drawing.Point(3, 5);
            this.temperatureValueLabel.Name = "temperatureValueLabel";
            this.temperatureValueLabel.Size = new System.Drawing.Size(103, 42);
            this.temperatureValueLabel.TabIndex = 1;
            this.temperatureValueLabel.Text = "Temperature value: ";
            this.temperatureValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fromScaleLabel
            // 
            this.fromScaleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fromScaleLabel.AutoSize = true;
            this.fromScaleLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromScaleLabel.ForeColor = System.Drawing.Color.Sienna;
            this.fromScaleLabel.Location = new System.Drawing.Point(3, 69);
            this.fromScaleLabel.Name = "fromScaleLabel";
            this.fromScaleLabel.Size = new System.Drawing.Size(60, 21);
            this.fromScaleLabel.TabIndex = 2;
            this.fromScaleLabel.Text = "From: ";
            this.fromScaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toScaleLabel
            // 
            this.toScaleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.toScaleLabel.AutoSize = true;
            this.toScaleLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toScaleLabel.ForeColor = System.Drawing.Color.Sienna;
            this.toScaleLabel.Location = new System.Drawing.Point(3, 122);
            this.toScaleLabel.Name = "toScaleLabel";
            this.toScaleLabel.Size = new System.Drawing.Size(40, 21);
            this.toScaleLabel.TabIndex = 3;
            this.toScaleLabel.Text = "To: ";
            this.toScaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fromScaleComboBox
            // 
            this.fromScaleComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fromScaleComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fromScaleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromScaleComboBox.ForeColor = System.Drawing.Color.Black;
            this.fromScaleComboBox.FormattingEnabled = true;
            this.fromScaleComboBox.Location = new System.Drawing.Point(143, 69);
            this.fromScaleComboBox.Name = "fromScaleComboBox";
            this.fromScaleComboBox.Size = new System.Drawing.Size(132, 21);
            this.fromScaleComboBox.TabIndex = 4;
            // 
            // toScaleComboBox
            // 
            this.toScaleComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.toScaleComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toScaleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toScaleComboBox.DropDownWidth = 132;
            this.toScaleComboBox.ForeColor = System.Drawing.Color.Black;
            this.toScaleComboBox.FormattingEnabled = true;
            this.toScaleComboBox.Location = new System.Drawing.Point(143, 122);
            this.toScaleComboBox.Name = "toScaleComboBox";
            this.toScaleComboBox.Size = new System.Drawing.Size(132, 21);
            this.toScaleComboBox.TabIndex = 5;
            // 
            // entryTextField
            // 
            this.entryTextField.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.entryTextField.Location = new System.Drawing.Point(143, 16);
            this.entryTextField.Name = "entryTextField";
            this.entryTextField.Size = new System.Drawing.Size(132, 20);
            this.entryTextField.TabIndex = 6;
            // 
            // resultLabel
            // 
            this.resultLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.resultLabel.Location = new System.Drawing.Point(143, 174);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 23);
            this.resultLabel.TabIndex = 7;
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 213);
            this.Controls.Add(this.tableLayoutPanel);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temperature converter";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label temperatureValueLabel;
        private System.Windows.Forms.Label fromScaleLabel;
        private System.Windows.Forms.Label toScaleLabel;
        private System.Windows.Forms.ComboBox fromScaleComboBox;
        private System.Windows.Forms.ComboBox toScaleComboBox;
        private System.Windows.Forms.TextBox entryTextField;
        private System.Windows.Forms.Label resultLabel;
    }
}

