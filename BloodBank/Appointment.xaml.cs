using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
namespace BloodBank
{
    /// <summary>
    /// Interaction logic for ViewDonors.xaml
    /// </summary>
    /// 

    public partial class Appointment : Window
    {
        private BloodBankDBDataContext DC;
        private List<int> IdList;
        private int FilterApplied = -1;
        private String FilterText;

        public Appointment()
        {
            InitializeComponent();
            
            DC = new BloodBankDBDataContext();
            IdList = new List<int>();

            LoadData();
        }

        private void LoadData()
        {
            var table = from D in DC.Donors
                        join C in DC.Cities on D.City equals C.Id
                        join P in DC.Provinces on D.Province equals P.Id
                        join BG in DC.BloodGroups on D.BloodGroup equals BG.Id
                        select new
                        {
                            No = D.Id,
                            D.Name,
                            D.Phone,
                            D.Age,
                            D.Gender,
                            City = C.CityName,
                            Province = P.ProvinceName,
                            BloodGroup = BG.Name,
                            BloodAvailable = D.BloodAvailable == 1 ? "Yes" : "No",
                            D.Date
                        };
         

            DonorsDataGrid.ItemsSource = table;

            IdList.Clear();
            foreach (var item in table.ToList())
            {
                IdList.Add(item.No);
            }
        }

        private void EditDonor_Click(object sender, RoutedEventArgs e)
        {
            if (DonorsDataGrid.CurrentItem == null)
            {
                return;
            }
            DC = new BloodBankDBDataContext();
            int selectedRowIndex = DonorsDataGrid.Items.IndexOf(DonorsDataGrid.CurrentItem);
            int Id = IdList[selectedRowIndex];
            var Donor = (from D in DC.Donors where D.Id == Id select D).Single();

            AppointmentApproval form = new AppointmentApproval(Donor);
            form.ShowDialog();
            ApplyFilter();

            DonorsDataGrid.UnselectAll();
        }

        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            Boolean bloodFilterChecked =  CheckBoxBloodAvailable.IsChecked.GetValueOrDefault();
            String FilterText = TextBoxFilter.Text.Trim();

            if (!bloodFilterChecked)
            {
                if (ComboBoxFilterBy.SelectedIndex < 0)
                {
                    MessageBox.Show("Select Filter By");
                    return;
                }

                if (FilterText.Length == 0)
                {
                    MessageBox.Show("Enter Filter Text");
                    return;
                }
            } 
            else if (FilterText.Length > 0 && ComboBoxFilterBy.SelectedIndex < 0)
            {
                MessageBox.Show("Select Filter By");
                return;
            }
            else if (FilterText.Length == 0 && ComboBoxFilterBy.SelectedIndex >= 0)
            {
                MessageBox.Show("Select Filter Text");
                return;
            }

            FilterApplied = ComboBoxFilterBy.SelectedIndex;
            this.FilterText = FilterText;
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            bool bloodAvailable = CheckBoxBloodAvailable.IsChecked.GetValueOrDefault();

            if (!bloodAvailable && (FilterText == null || FilterText.Length == 0))
            {
                FilterApplied = -1;
                LoadData();
                return;
            }


            switch (FilterApplied)
            {
                case 0:
                    FilterByName(FilterText, bloodAvailable);
                    break;
                case 1:
                    FilterByPhone(FilterText, bloodAvailable);
                    break;
                case 2:
                    FilterByBloodGroup(FilterText, bloodAvailable);
                    break;
                case 3:
                    FilterByCity(FilterText, bloodAvailable);
                    break;
                case 4:
                    FilterByProvince(FilterText, bloodAvailable);
                    break;
                default:
                    if (bloodAvailable)
                    {
                        FilterByBloodAvailable();
                    }
                    else
                    {
                        LoadData();
                    }
                    break;
            }
        }

        private void FilterByName(string name, bool bloodAvailable)
        {
            var table = from D in DC.Donors
                        where D.Name.Contains(name) 
                        && (bloodAvailable ? D.BloodAvailable == 1 : (D.BloodAvailable == 1 || D.BloodAvailable == 0))
                         join C in DC.Cities on D.City equals C.Id
                         join P in DC.Provinces on D.Province equals P.Id
                         join BG in DC.BloodGroups on D.BloodGroup equals BG.Id
                         select new
                         {
                             No = D.Id,
                             D.Name,
                             D.Phone,
                             D.Age,
                             D.Gender,
                             City = C.CityName,
                             Province = P.ProvinceName,
                             BloodGroup = BG.Name,                            
                             D.Date
                         };

            DonorsDataGrid.ItemsSource = table;

            IdList.Clear();
            foreach (var item in table.ToList())
            {
                IdList.Add(item.No);
            }
        }

        private void FilterByPhone(string phone, bool bloodAvailable)
        {
            var table = from D in DC.Donors
                        where D.Phone.Contains(phone) 
                        && (bloodAvailable ? D.BloodAvailable == 1 : (D.BloodAvailable == 1 || D.BloodAvailable == 0))
                        join C in DC.Cities on D.City equals C.Id
                        join P in DC.Provinces on D.Province equals P.Id
                        join BG in DC.BloodGroups on D.BloodGroup equals BG.Id
                        select new
                        {
                            No = D.Id,
                            D.Name,
                            D.Phone,
                            D.Age,
                            D.Gender,
                            City = C.CityName,
                            Province = P.ProvinceName,
                            BloodGroup = BG.Name,                            
                            D.Date
                        };
            DonorsDataGrid.ItemsSource = table;

            IdList.Clear();
            foreach (var item in table.ToList())
            {
                IdList.Add(item.No);
            }
        }

        private void FilterByBloodGroup(string bloodGroup, bool bloodAvailable)
        {
            var whereQuery = from BG in DC.BloodGroups where BG.Name == bloodGroup select BG.Id;
            var table = from D in DC.Donors
                        where whereQuery.ToArray().Contains(D.BloodGroup)
                        && (bloodAvailable ? D.BloodAvailable == 1 : (D.BloodAvailable == 1 || D.BloodAvailable == 0))
                        join C in DC.Cities on D.City equals C.Id
                        join P in DC.Provinces on D.Province equals P.Id
                        join BG in DC.BloodGroups on D.BloodGroup equals BG.Id
                        select new
                        {
                            No = D.Id,
                            D.Name,
                            D.Phone,
                            D.Age,
                            D.Gender,
                            City = C.CityName,
                            Province = P.ProvinceName,
                            BloodGroup = BG.Name,
                            BloodAvailable = D.BloodAvailable == 1 ? "Yes" : "No",
                            D.Date
                        };
            DonorsDataGrid.ItemsSource = table;

            IdList.Clear();
            foreach (var item in table.ToList())
            {
                IdList.Add(item.No);
            }
        }

        private void FilterByCity(string city, bool bloodAvailable)
        {
            var whereQuery = from C in DC.Cities where C.CityName.Contains(city) select C.Id;
            var table = from D in DC.Donors
                        where whereQuery.ToArray().Contains(D.City)
                        && (bloodAvailable ? D.BloodAvailable == 1 : (D.BloodAvailable == 1 || D.BloodAvailable == 0))
                        join C in DC.Cities on D.City equals C.Id
                        join P in DC.Provinces on D.Province equals P.Id
                        join BG in DC.BloodGroups on D.BloodGroup equals BG.Id
                        select new
                        {
                            No = D.Id,
                            D.Name,
                            D.Phone,
                            D.Age,
                            D.Gender,
                            City = C.CityName,
                            Province = P.ProvinceName,
                            BloodGroup = BG.Name,
                            BloodAvailable = D.BloodAvailable == 1 ? "Yes" : "No",
                            D.Date
                        };
            DonorsDataGrid.ItemsSource = table;

            IdList.Clear();
            foreach (var item in table.ToList())
            {
                IdList.Add(item.No);
            }
        }

        private void FilterByProvince(string province, bool bloodAvailable)
        {
            var whereQuery = from P in DC.Provinces where P.ProvinceName.Contains(province) select P.Id;
            var table = from D in DC.Donors
                        where whereQuery.ToArray().Contains(D.Province)
                        && (bloodAvailable ? D.BloodAvailable == 1 : (D.BloodAvailable == 1 || D.BloodAvailable == 0))
                        join C in DC.Cities on D.City equals C.Id
                        join P in DC.Provinces on D.Province equals P.Id
                        join BG in DC.BloodGroups on D.BloodGroup equals BG.Id
                        select new
                        {
                            No = D.Id,
                            D.Name,
                            D.Phone,
                            D.Age,
                            D.Gender,
                            City = C.CityName,
                            Province = P.ProvinceName,
                            BloodGroup = BG.Name,                           
                            D.Date
                        };
            DonorsDataGrid.ItemsSource = table;

            IdList.Clear();
            foreach (var item in table.ToList())
            {
                IdList.Add(item.No);
            }
        }

        private void FilterByBloodAvailable()
        {
            var table = from D in DC.Donors
                        where D.BloodAvailable == 1
                        join C in DC.Cities on D.City equals C.Id
                        join P in DC.Provinces on D.Province equals P.Id
                        join BG in DC.BloodGroups on D.BloodGroup equals BG.Id
                        select new
                        {
                            No = D.Id,
                            D.Name,
                            D.Phone,
                            D.Age,
                            D.Gender,
                            City = C.CityName,
                            Province = P.ProvinceName,
                            BloodGroup = BG.Name,                          
                            D.Date
                        };
            DonorsDataGrid.ItemsSource = table;

            IdList.Clear();
            foreach (var item in table.ToList())
            {
                IdList.Add(item.No);
            }
        }

        private void ButtonFilterClear_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxFilterBy.SelectedIndex = -1;
            TextBoxFilter.Text = null;
            FilterApplied = -1;
            FilterText = null;
            CheckBoxBloodAvailable.IsChecked = false;
            LoadData();
        }
    }
}
