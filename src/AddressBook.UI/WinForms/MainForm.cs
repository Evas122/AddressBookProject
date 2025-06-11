using AddressBook.Core.Dtos;
using AddressBook.Core.Interfaces.Services;
using AddressBook.WinForms;
using AdressBook.WinForms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdressBook
{
    public partial class MainForm : Form
    {
        private readonly IContactService _contactService;
        private readonly ICityService _cityService;
        private int? _selectedContactId = null;

        public MainForm(IContactService contactService, ICityService cityService)
        {
            InitializeComponent();
            _contactService = contactService;
            _cityService = cityService;

            filterTextBox.TextChanged += FilterTextBox_TextChanged;

            contactsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            contactsDataGridView.MultiSelect = false;
            contactsDataGridView.CellClick += ContactsDataGridView_CellClick;

            btnAddContact.Click += BtnAddContact_Click;
            btnEditContact.Click += BtnEditContact_Click;
            btnDeleteContact.Click += BtnDeleteContact_Click;

            btnEditContact.Enabled = false;
            btnDeleteContact.Enabled = false;

            LoadContacts();
        }

        private void LoadContacts(string filter = null)
        {
            try
            {
                var contacts = string.IsNullOrWhiteSpace(filter)
                    ? _contactService.GetAllContacts()
                    : _contactService.GetAllContacts(filter);

                contactsDataGridView.DataSource = null;
                contactsDataGridView.DataSource = contacts.ToList();

                _selectedContactId = null;
                btnEditContact.Enabled = false;
                btnDeleteContact.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading contacts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadContacts(filterTextBox.Text);
        }

        private void ContactsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = contactsDataGridView.Rows[e.RowIndex];
                if (row.DataBoundItem is ContactViewDto contact)
                {
                    _selectedContactId = contact.Id;
                    btnEditContact.Enabled = true;
                    btnDeleteContact.Enabled = true;
                }
            }
        }

        private void BtnAddContact_Click(object sender, EventArgs e)
        {
            var addForm = new AddContactForm(_contactService, _cityService);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadContacts();
            }
        }

        private void BtnEditContact_Click(object sender, EventArgs e)
        {
            if (_selectedContactId.HasValue)
            {
                var editForm = new EditContactForm(_contactService,_cityService, _selectedContactId.Value);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadContacts();
                }
            }
        }

        private void BtnDeleteContact_Click(object sender, EventArgs e)
        {
            if (_selectedContactId.HasValue)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected contact?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _contactService.RemoveContact(_selectedContactId.Value);
                        LoadContacts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting contact: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            var addCityForm = new AddCityForm(_cityService);
            addCityForm.ShowDialog();
        }

        private void btnEditCity_Click(object sender, EventArgs e)
        {
            var editCityForm = new EditCityForm(_cityService);
            editCityForm.ShowDialog();
        }
    }
}