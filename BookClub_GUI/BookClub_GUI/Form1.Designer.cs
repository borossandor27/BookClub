
namespace BookClub_GUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_Osszeg = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Bevitel = new System.Windows.Forms.Button();
            this.dateTimePicker_Datum = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Nev = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Osszeg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Név";
            // 
            // numericUpDown_Osszeg
            // 
            this.numericUpDown_Osszeg.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_Osszeg.Location = new System.Drawing.Point(110, 130);
            this.numericUpDown_Osszeg.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Osszeg.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_Osszeg.Name = "numericUpDown_Osszeg";
            this.numericUpDown_Osszeg.Size = new System.Drawing.Size(179, 20);
            this.numericUpDown_Osszeg.TabIndex = 3;
            this.numericUpDown_Osszeg.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Összeg";
            // 
            // button_Bevitel
            // 
            this.button_Bevitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button_Bevitel.ForeColor = System.Drawing.Color.White;
            this.button_Bevitel.Location = new System.Drawing.Point(34, 184);
            this.button_Bevitel.Name = "button_Bevitel";
            this.button_Bevitel.Size = new System.Drawing.Size(255, 41);
            this.button_Bevitel.TabIndex = 5;
            this.button_Bevitel.Text = "Rögzít";
            this.button_Bevitel.UseVisualStyleBackColor = false;
            this.button_Bevitel.Click += new System.EventHandler(this.button_Bevitel_Click);
            // 
            // dateTimePicker_Datum
            // 
            this.dateTimePicker_Datum.Enabled = false;
            this.dateTimePicker_Datum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Datum.Location = new System.Drawing.Point(110, 91);
            this.dateTimePicker_Datum.Name = "dateTimePicker_Datum";
            this.dateTimePicker_Datum.Size = new System.Drawing.Size(179, 20);
            this.dateTimePicker_Datum.TabIndex = 6;
            // 
            // comboBox_Nev
            // 
            this.comboBox_Nev.FormattingEnabled = true;
            this.comboBox_Nev.Location = new System.Drawing.Point(110, 42);
            this.comboBox_Nev.Name = "comboBox_Nev";
            this.comboBox_Nev.Size = new System.Drawing.Size(179, 21);
            this.comboBox_Nev.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 280);
            this.Controls.Add(this.comboBox_Nev);
            this.Controls.Add(this.dateTimePicker_Datum);
            this.Controls.Add(this.button_Bevitel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_Osszeg);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Befizetés";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Osszeg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Osszeg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Bevitel;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Datum;
        private System.Windows.Forms.ComboBox comboBox_Nev;
    }
}

