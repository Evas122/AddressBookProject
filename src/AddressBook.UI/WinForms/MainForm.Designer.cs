namespace AdressBook
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
            this.contactsDataGridView = new System.Windows.Forms.DataGridView();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.btnEditContact = new System.Windows.Forms.Button();
            this.btnDeleteContact = new System.Windows.Forms.Button();
            this.btnAddCity = new System.Windows.Forms.Button();
            this.btnEditCity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.contactsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // contactsDataGridView
            // 
            this.contactsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contactsDataGridView.Location = new System.Drawing.Point(12, 105);
            this.contactsDataGridView.Name = "contactsDataGridView";
            this.contactsDataGridView.Size = new System.Drawing.Size(776, 192);
            this.contactsDataGridView.TabIndex = 0;
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(262, 63);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(244, 20);
            this.filterTextBox.TabIndex = 1;
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(12, 315);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(82, 23);
            this.btnAddContact.TabIndex = 2;
            this.btnAddContact.Text = "Add Contact";
            this.btnAddContact.UseVisualStyleBackColor = true;
            // 
            // btnEditContact
            // 
            this.btnEditContact.Location = new System.Drawing.Point(100, 315);
            this.btnEditContact.Name = "btnEditContact";
            this.btnEditContact.Size = new System.Drawing.Size(100, 23);
            this.btnEditContact.TabIndex = 3;
            this.btnEditContact.Text = "Update Contact";
            this.btnEditContact.UseVisualStyleBackColor = true;
            // 
            // btnDeleteContact
            // 
            this.btnDeleteContact.Location = new System.Drawing.Point(206, 315);
            this.btnDeleteContact.Name = "btnDeleteContact";
            this.btnDeleteContact.Size = new System.Drawing.Size(90, 23);
            this.btnDeleteContact.TabIndex = 4;
            this.btnDeleteContact.Text = "Delete Contact";
            this.btnDeleteContact.UseVisualStyleBackColor = true;
            // 
            // btnAddCity
            // 
            this.btnAddCity.Location = new System.Drawing.Point(706, 415);
            this.btnAddCity.Name = "btnAddCity";
            this.btnAddCity.Size = new System.Drawing.Size(82, 23);
            this.btnAddCity.TabIndex = 5;
            this.btnAddCity.Text = "Add City";
            this.btnAddCity.UseVisualStyleBackColor = true;
            this.btnAddCity.Click += new System.EventHandler(this.btnAddCity_Click);
            // 
            // btnEditCity
            // 
            this.btnEditCity.Location = new System.Drawing.Point(618, 415);
            this.btnEditCity.Name = "btnEditCity";
            this.btnEditCity.Size = new System.Drawing.Size(82, 23);
            this.btnEditCity.TabIndex = 6;
            this.btnEditCity.Text = "Edit City";
            this.btnEditCity.UseVisualStyleBackColor = true;
            this.btnEditCity.Click += new System.EventHandler(this.btnEditCity_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEditCity);
            this.Controls.Add(this.btnAddCity);
            this.Controls.Add(this.btnDeleteContact);
            this.Controls.Add(this.btnEditContact);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.filterTextBox);
            this.Controls.Add(this.contactsDataGridView);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.contactsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView contactsDataGridView;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Button btnEditContact;
        private System.Windows.Forms.Button btnDeleteContact;
        private System.Windows.Forms.Button btnAddCity;
        private System.Windows.Forms.Button btnEditCity;
    }
}