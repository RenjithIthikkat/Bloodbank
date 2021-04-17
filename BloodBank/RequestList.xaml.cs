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

    public partial class RequestList : Window
    {
        private BloodBankDBDataContext DC;
        private List<int> IdList;
        private int FilterApplied = -1;
        private String FilterText;

        public RequestList()
        {
            InitializeComponent();
            
            DC = new BloodBankDBDataContext();
            IdList = new List<int>();

            LoadData();
        }

        private void LoadData()
        {
            var table = from D in DC.BloodRequests
                        join C in DC.Credentials on D.HospitalId equals C.Id                       
                        join BG in DC.BloodGroups on D.BloodGroupId equals BG.Id
                        where D.Status == "REQUESTED"
                        select new
                        {
                            No = D.Id,
                            HospitalName = C.Username,
                            BloodGroup =  BG.Name, 
                            D.Status,
                            D.RequestDate
                        };



            var table1 = from D in DC.BloodRequests
                        join C in DC.Credentials on D.HospitalId equals C.Id
                         join us in DC.Donors on D.DonorId equals us.Id  into ps
                         from us in ps.DefaultIfEmpty()
                         join BG in DC.BloodGroups on D.BloodGroupId equals BG.Id
                        where (D.Status == "APPROVED" || D.Status == "REJECTED")
                        select new
                        {
                            No = D.Id,
                            HospitalName = C.Username,
                            BloodGroup = BG.Name,
                            D.Status,
                            D.DonarDate,
                            DonorName  = us.Name,
                            D.RequestDate                            
                        };

            DonorsDataGridPending.ItemsSource = table;
            DonorsDataUpdated.ItemsSource = table1;

            IdList.Clear();
            foreach (var item in table.ToList())
            {
                IdList.Add(item.No);
            }
        }

        private void EditDonor_Click(object sender, RoutedEventArgs e)
        {
            if (DonorsDataGridPending.CurrentItem == null)
            {
                return;
            }
            DC = new BloodBankDBDataContext();
            int selectedRowIndex = DonorsDataGridPending.Items.IndexOf(DonorsDataGridPending.CurrentItem);
            int Id = IdList[selectedRowIndex];
            var bloodrequests = (from D in DC.BloodRequests where D.Id == Id select D).Single();

            RequestApproval form = new RequestApproval(bloodrequests);
            form.ShowDialog();
            Close();        

            DonorsDataGridPending.UnselectAll();
        }

      
    }
}
