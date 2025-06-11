using AddressBook.Core.Dtos;
using AddressBook.Core.Interfaces.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AddressBook.WinForms
{
    public partial class EditContactForm : Form
    {
        private readonly IContactService _contactService;
        private readonly ICityService _cityService;
        private readonly int _contactId;
        private ContactDto _contact;

        public EditContactForm(IContactService contactService, ICityService cityService, int contactId)
        {
            InitializeComponent();
            _contactService = contactService;
            _cityService = cityService;
            _contactId = contactId;

            Load += EditContactForm_Load;
            buttonSave.Click += ButtonSave_Click;
            buttonCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        private void EditContactForm_Load(object sender, EventArgs e)
        {
            try
            {
                var cities = _cityService.GetAllCities().ToList();

                comboBoxCity.DataSource = cities;
                comboBoxCity.DisplayMember = "Name";
                comboBoxCity.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load cities: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            _contact = _contactService.GetContactById(_contactId);

            if (_contact == null)
            {
                MessageBox.Show("Contact not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            textBoxFirstName.Text = _contact.FirstName;
            textBoxLastName.Text = _contact.LastName;
            checkBoxIsActive.Checked = _contact.IsActive;
            textBoxPhone.Text = _contact.PhoneNumber;
            dateTimePickerBirthDate.Value = _contact.BirthDate;

            comboBoxCity.SelectedValue = _contact.CityId;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            _contact.FirstName = textBoxFirstName.Text;
            _contact.LastName = textBoxLastName.Text;
            _contact.PhoneNumber = textBoxPhone.Text;
            _contact.BirthDate = dateTimePickerBirthDate.Value;
            _contact.CityId = (int)comboBoxCity.SelectedValue;

            try
            {
                _contactService.UpdateContact(_contact);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating contact: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                MessageBox.Show("First name is required.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                MessageBox.Show("Last name is required.");
                return false;
            }
            if (comboBoxCity.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a city.");
                return false;
            }
            return true;
        }
    }
}