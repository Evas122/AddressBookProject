using AddressBook.Core.Dtos;
using AddressBook.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdressBook.WinForms
{
    public partial class EditCityForm : Form
    {
        private readonly ICityService _cityService;
        private List<CityDto> _cities;
        private CityDto _selectedCity;

        public EditCityForm(ICityService cityService)
        {
            InitializeComponent();
            _cityService = cityService;

            Load += EditCityForm_Load;
            comboBoxCities.SelectedIndexChanged += ComboBoxCities_SelectedIndexChanged;
            buttonSave.Click += ButtonSave_Click;
            buttonCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        private void EditCityForm_Load(object sender, EventArgs e)
        {
            _cities = new List<CityDto>(_cityService.GetAllCities());

            comboBoxCities.DisplayMember = "Name";
            comboBoxCities.ValueMember = "Id";
            comboBoxCities.DataSource = _cities;
        }

        private void ComboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCities.SelectedItem is CityDto city)
            {
                _selectedCity = city;
                textBoxName.Text = city.Name;
                textBoxZipCode.Text = city.ZipCode;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (_selectedCity == null)
            {
                MessageBox.Show("Please select a city.");
                return;
            }

            if (!ValidateForm()) return;

            _selectedCity.Name = textBoxName.Text.Trim();
            _selectedCity.ZipCode = textBoxZipCode.Text.Trim();

            try
            {
                _cityService.UpdateCity(_selectedCity);
                MessageBox.Show("City updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating city: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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