using AddressBook.Core.Dtos;
using AddressBook.Core.Interfaces.Services;
using System;
using System.Windows.Forms;

namespace AdressBook.WinForms
{
    public partial class AddCityForm : Form
    {
        private readonly ICityService _cityService;

        public AddCityForm(ICityService cityService)
        {
            InitializeComponent();
            _cityService = cityService;

            buttonSave.Click += ButtonSave_Click;
            buttonCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var city = new CityDto
            {
                Name = textBoxName.Text.Trim(),
                ZipCode = textBoxZipCode.Text.Trim()
            };

            try
            {
                _cityService.AddCity(city);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding city: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("City name is required.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxZipCode.Text))
            {
                MessageBox.Show("Zip code is required.");
                return false;
            }
            return true;
        }
    }
}