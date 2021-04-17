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
    /// 
    /// Done by : sree renjini
    /// 
    /// Interaction logic for SearchByBloodGroup.xaml
    /// 
    /// This page deals the logic for searching a blood group availability 
    /// based on the value user choose from combobox.
    /// </summary>
    public partial class SearchByBloodGroup : Window
    {
        private Dictionary<String, Boolean> BloodAvailibility;//Dictionary to store available blood groups
        private bool isAdmin;
        private BloodBankDBDataContext DC; // for database operations
        private string user;

        public SearchByBloodGroup(bool isAdmin,string username)
        {
            InitializeComponent();
            BloodAvailibility = new Dictionary<string, bool>();
            this.isAdmin = isAdmin;
            user = username;

            BloodBankDBDataContext DC = new BloodBankDBDataContext();
            //Querying db for stored blood groups
            var result = from b in DC.BloodGroups select b;
            foreach(var b in result)
            {
                //for each blood group search in db for for availability 
                var result2 = from d in DC.Donors where d.BloodGroup == b.Id && d.BloodAvailable == 1 select d;
                //store available blood groups in dictionary
                BloodAvailibility.Add(b.Name, result2.Any());
            }

            if (isAdmin)
            {
                LogoutButton.Visibility = Visibility.Hidden;
            }

            var table = from D in DC.BloodRequests
                         join C in DC.Credentials on D.HospitalId equals C.Id
                         join us in DC.Donors on D.DonorId equals us.Id into ps
                         from us in ps.DefaultIfEmpty()
                         join BG in DC.BloodGroups on D.BloodGroupId equals BG.Id                        
                         select new
                         {
                             No = D.Id,
                             HospitalName = C.Username,
                             BloodGroup = BG.Name,
                             D.Status,
                             D.DonarDate,
                             DonorName = us.Name,
                             D.RequestDate
                         };

            DonorsDataGridPending.ItemsSource = table;           
        }

        // validate input and show availibility
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Request.Focusable = false;
            if (BloodGroup.SelectedIndex <= 0)
            {
                resultBox.Text = "Choose a Blood Group to Search";
                return;
            }

            bool available = BloodAvailibility[BloodGroup.Text];
            BloodBankDBDataContext DC = new BloodBankDBDataContext();
           
            BloodRequest bloodRequest = new BloodRequest();
            bloodRequest.Id = Convert.ToInt16(DC.BloodRequests.Max(x => x.Id)) + 1;
            bloodRequest.BloodGroupId = DC.BloodGroups.FirstOrDefault(x=> x.Name == BloodGroup.Text).Id;
            bloodRequest.HospitalId = DC.Credentials.FirstOrDefault(x=>x.Username == user).Id;
            bloodRequest.Status = "REQUESTED";
            bloodRequest.RequestDate = DateTime.UtcNow;
            DC.BloodRequests.InsertOnSubmit(bloodRequest);
            DC.SubmitChanges();
            
            resultBox.Text = "Blood requested.";
            var table = from D in DC.BloodRequests
                        join C in DC.Credentials on D.HospitalId equals C.Id
                        join us in DC.Donors on D.DonorId equals us.Id into ps
                        from us in ps.DefaultIfEmpty()
                        join BG in DC.BloodGroups on D.BloodGroupId equals BG.Id                        
                        select new
                        {
                            No = D.Id,
                            HospitalName = C.Username,
                            BloodGroup = BG.Name,
                            D.Status,
                            D.DonarDate,
                            DonorName = us.Name,
                            D.RequestDate
                        };

            DonorsDataGridPending.ItemsSource = table;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
