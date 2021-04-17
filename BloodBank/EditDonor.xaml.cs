using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BloodBank
{
    /// <summary>
    /// Interaction logic for EditDonor.xaml
    /// </summary>
    public partial class EditDonor : Window
    {
        private BloodBankDBDataContext DC; // for database operations
        Donor donor;
        private Province[] provinceList; // array of provinces
        private City[] cityList; // array of city
        public EditDonor(Donor donor)
        {
            InitializeComponent();
            this.donor = donor;
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
            ddlProvince.ItemsSource = provinces.Distinct();
            ddlCity.DisplayMemberPath = "ProvinceName";
            var cities = from P in DC.Cities select P;

            cityList = new City[cities.ToList().Count];
             i = 0;
            foreach (var p in cities.ToList())
            {
                cityList[i] = p;
                i++;
            }
            ddlCity.ItemsSource = cities.Distinct();
            ddlCity.DisplayMemberPath = "CityName";
            if (donor != null)
            {
                NameTextBox.Text = donor.Name;
                txtPhone.Text = donor.Phone;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var DC = new BloodBankDBDataContext();
            var donordb = DC.Donors.First(x => x.Id == donor.Id);
            int provinceId = provinceList[ddlProvince.SelectedIndex].Id;           
            int cityId = cityList[ddlCity.SelectedIndex].Id;
            donordb.City = cityId;
            donordb.Province = provinceId;
            donordb.Phone = txtPhone.Text;
            donordb.BloodAvailable =  Yes.IsChecked.GetValueOrDefault() ? 1 : 0;
            MessageBox.Show("Donor is added successfully!");
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
