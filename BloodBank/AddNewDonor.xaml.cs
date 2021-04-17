using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;


namespace BloodBank
{
    
    public partial class AddNewDonor : Window
    {
        private BloodBankDBDataContext DC; // for database operations
        private Province[] provinceList; // array of provinces
        private BloodGroup[] bloodgroupList; // array of blood groups

        public AddNewDonor()
        {
            InitializeComponent();
            DC = new BloodBankDBDataContext();

            // get all provinces, add into array and show in combobox 
            var provinces = from P in DC.Provinces select P;

            provinceList = new Province[provinces.ToList().Count];
            int i = 0;
            foreach (var p in provinces.ToList())
            {
                provinceList[i] = p;
                i++;
            }
            ProvinceComboBox.ItemsSource = provinces.Distinct();
            ProvinceComboBox.DisplayMemberPath = "ProvinceName";


            // get all blood groups, add into array and show in combobox 
            var bloodGroups = from BG in DC.BloodGroups select BG;

            bloodgroupList = new BloodGroup[bloodGroups.ToList().Count];
            i = 0;
            foreach (var bg in bloodGroups.ToList())
            {
                bloodgroupList[i] = bg;
                i++;
            }
            BloodGroupComboBox.ItemsSource = bloodGroups.Distinct();
            BloodGroupComboBox.DisplayMemberPath = "Name";

            var cities = from P in DC.Cities select P;

            cityList = new City[cities.ToList().Count];
            i = 0;
            foreach (var p in cities.ToList())
            {
                cityList[i] = p;
                i++;
            }
            CityComboBox.ItemsSource = cities.Distinct();
            CityComboBox.DisplayMemberPath = "CityName";


            // show current date-time in form
            DateTime dateTime = DateTime.Now;
            DateTextBox.Text = dateTime.Date.ToShortDateString();
        }

        // On click add button, validate all data and save into database
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Focusable = false;

            if (NameTextBox.Text == null || NameTextBox.Text.Length == 0 ||
                PhoneTextBox.Text == null || PhoneTextBox.Text.Length == 0 ||
                AgeTextBox.Text == null || AgeTextBox.Text.Length == 0 ||
                BloodGroupComboBox.SelectedIndex < 0 ||
                CityComboBox.SelectedIndex < 0 ||
                ProvinceComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            int provinceId = provinceList[ProvinceComboBox.SelectedIndex].Id;
            int bloodGroupId = bloodgroupList[BloodGroupComboBox.SelectedIndex].Id;
            int cityId = cityList[CityComboBox.SelectedIndex].Id;

            Donor Dnrobj = new Donor();
            Dnrobj.Name = NameTextBox.Text;
            Dnrobj.Age = int.Parse(AgeTextBox.Text);
            Dnrobj.Gender = Male.IsChecked.GetValueOrDefault() ? "Male" : "Female";
            Dnrobj.City = cityId;
            Dnrobj.Province = provinceId;
            Dnrobj.Phone = PhoneTextBox.Text;
            Dnrobj.BloodGroup = bloodGroupId;
            Dnrobj.BloodAvailable = Yes.IsChecked.GetValueOrDefault() ? 1 : 0;
            Dnrobj.Date = DateTime.Now;

            DC.Donors.InsertOnSubmit(Dnrobj);
            DC.SubmitChanges();
            MessageBox.Show("Donor is added successfully!");
            Close();
        }

        // On click reset, clear all fields in form
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButton.Focusable = false;

            NameTextBox.Text = "";
            AgeTextBox.Text = "";
            Male.IsChecked = true;
            CityComboBox.SelectedIndex = -1;
            ProvinceComboBox.SelectedIndex = -1;
            PhoneTextBox.Text = "";
            BloodGroupComboBox.SelectedIndex = -1;
            Yes.IsChecked = true;

            NameTextBox.Focus();
        }

        // On click close, close the form
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        int oldPId = -1; // old selected province id
        private City[] cityList; // list of clities loaded in combobox

        // On province selection change, change city options
        private void ProvinceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProvinceComboBox.SelectedIndex != -1)
            {
                int newPId = provinceList[ProvinceComboBox.SelectedIndex].Id;
                if (newPId == oldPId) return;

                oldPId = newPId;

                var city = from c in DC.Cities where c.Province == newPId select c;

                CityComboBox.ItemsSource = city.Distinct();
                CityComboBox.DisplayMemberPath = "CityName";

                cityList = new City[city.ToList().Count];

                int i = 0;
                foreach (var item in city.ToList())
                {
                    cityList[i] = item;
                    i++;
                }
            }
        }

        // allow only numbers for phone
        private void PhoneTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        // allow only numbers for age
        private void AgeTextBox_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }

}
