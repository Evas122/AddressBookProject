using AddressBook.Core.Dtos;
using AddressBook.Core.Interfaces.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AddressBook.WinForms
{
    public partial class AddContactForm : Form
    {
        private readonly IContactService _contactService;
        private readonly ICityService _cityService;

        public AddContactForm(IContactService contactService, ICityService cityService)
        {
            InitializeComponent();
            _contactService = contactService;
            _cityService = cityService;

            Load += AddContactForm_Load;
            buttonSave.Click += ButtonSave_Click;
            buttonCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        private void AddContactForm_Load(object sender, EventArgs e)
        {
            try
            {
                var cities = _cityService.GetAllCities().ToList();

                comboBoxCity.DataSource = cities;
                comboBoxCity.DisplayMember = "Name";
                comboBoxCity.ValueMember = "Id";

                comboBoxCity.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load cities: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            var newContact = new ContactDto
            {
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                IsActive = checkBoxIsActive.Checked,
                PhoneNumber = textBoxPhone.Text.Trim(),
                BirthDate = dateTimePickerBirthDate.Value,
                CityId = (int)comboBoxCity.SelectedValue
            };

            try
            {
                _contactService.AddContact(newContact);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding contact: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                MessageBox.Show("First name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFirstName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                MessageBox.Show("Last name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLastName.Focus();
                return false;
            }
            if (comboBoxCity.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a city.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxCity.Focus();
                return false;
            }
            return true;
        }
    }
}