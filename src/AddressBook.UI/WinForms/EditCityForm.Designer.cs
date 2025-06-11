namespace AdressBook.WinForms
{
    partial class EditCityForm
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
            this.comboBoxCities = new System.Windows.Forms.ComboBox();
            this.labelSelectCity = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelZipCode = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxZipCode = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // labelSelectCity
            this.labelSelectCity.AutoSize = true;
            this.labelSelectCity.Location = new System.Drawing.Point(30, 30);
            this.labelSelectCity.Name = "labelSelectCity";
            this.labelSelectCity.Size = new System.Drawing.Size(60, 13);
            this.labelSelectCity.Text = "Select City:";

            // comboBoxCities
            this.comboBoxCities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCities.FormattingEnabled = true;
            this.comboBoxCities.Location = new System.Drawing.Point(100, 27);
            this.comboBoxCities.Size = new System.Drawing.Size(220, 21);

            // labelName
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(30, 70);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.Text = "Name:";

            // textBoxName
            this.textBoxName.Location = new System.Drawing.Point(100, 67);
            this.textBoxName.Size = new System.Drawing.Size(220, 20);
            this.textBoxName.TabIndex = 1;

            // labelZipCode
            this.labelZipCode.AutoSize = true;
            this.labelZipCode.Location = new System.Drawing.Point(30, 105);
            this.labelZipCode.Name = "labelZipCode";
            this.labelZipCode.Size = new System.Drawing.Size(53, 13);
            this.labelZipCode.Text = "Zip Code:";

            // textBoxZipCode
            this.textBoxZipCode.Location = new System.Drawing.Point(100, 102);
            this.textBoxZipCode.Size = new System.Drawing.Size(220, 20);
            this.textBoxZipCode.TabIndex = 2;

            // buttonSave
            this.buttonSave.Location = new System.Drawing.Point(100, 150);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(90, 30);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;

            // buttonCancel
            this.buttonCancel.Location = new System.Drawing.Point(230, 150);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 30);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;

            // EditCityForm
            this.ClientSize = new System.Drawing.Size(370, 210);
            this.Controls.Add(this.labelSelectCity);
            this.Controls.Add(this.comboBoxCities);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelZipCode);
            this.Controls.Add(this.textBoxZipCode);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCityForm";
            this.Text = "Edit City";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelSelectCity;
        private System.Windows.Forms.ComboBox comboBoxCities;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelZipCode;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxZipCode;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}