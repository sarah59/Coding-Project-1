namespace EVIC_GUI
{
    partial class Form
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.listViewBox = new System.Windows.Forms.ListView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(314, 102);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(202, 30);
            this.textBox.TabIndex = 0;
            // 
            // listViewBox
            // 
            this.listViewBox.Location = new System.Drawing.Point(12, 12);
            this.listViewBox.Name = "listViewBox";
            this.listViewBox.Size = new System.Drawing.Size(296, 175);
            this.listViewBox.TabIndex = 1;
            this.listViewBox.UseCompatibleStateImageBehavior = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "System Status",
            "Warning Messages",
            "Personal Settings",
            "Temperature Information",
            "Trip Information"});
            this.comboBox1.Location = new System.Drawing.Point(314, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(199, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Please select from below...";
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(372, 57);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(83, 29);
            this.button.TabIndex = 3;
            this.button.Text = "Enter";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(372, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "Enter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 201);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listViewBox);
            this.Controls.Add(this.textBox);
            this.Name = "Form";
            this.Text = "EVIC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ListView listViewBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Button button2;
    }
}

