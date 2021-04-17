using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
namespace BloodBank
{ 

   
    //  DateTextBox.Text = donor.Date.ToString();
    ///// <summary>
    ///// Interaction logic for EditDonor.xaml
    ///// </summary>
    public partial class RequestApproval : Window
    {
        private BloodBankDBDataContext DC; // for database operations
        BloodRequest request;  // instance of Donor type
        List<Donor> availabledonors = null;
        

       
        public RequestApproval(BloodRequest bloodRequest)
        {
            InitializeComponent();
            DC = new BloodBankDBDataContext();

            this.request = bloodRequest;

            txt_requestNumber.Text = bloodRequest.Id.ToString();
            txt_HospitalName.Text = request.HospitalId.ToString();          
            availabledonors = DC.Donors.Where(x => x.Date > DateTime.Now.AddMonths(+3) 
            && x.BloodGroup == request.BloodGroupId).ToList();
            if(availabledonors!= null && availabledonors.Count > 0)
            {
                btn_Approve.Visibility = Visibility.Visible;
                btn_Reject.Visibility = Visibility.Hidden;
                ddl_donors.ItemsSource = availabledonors;
                ddl_donors.DisplayMemberPath = "Name";
                lbl_Donor.Visibility = Visibility.Visible;
                lbl_Donor_Date.Visibility = Visibility.Visible;
                ddl_donors.Visibility = Visibility.Visible;
                dtp_date.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No Donors available");
                btn_Approve.Visibility = Visibility.Hidden;
                btn_Reject.Visibility = Visibility.Visible;
                lbl_Donor.Visibility = Visibility.Hidden;
                lbl_Donor_Date.Visibility = Visibility.Hidden;
                ddl_donors.Visibility = Visibility.Hidden;
                dtp_date.Visibility = Visibility.Hidden;
            }          
        }      

        private void btn_Approve_Click(object sender, RoutedEventArgs e)
        {
            if (dtp_date.SelectedDate == null || dtp_date.SelectedDate < DateTime.Now)
            {
                MessageBox.Show("Please Enter Valid Date");

            }
            else
            {
                int donorId = availabledonors[ddl_donors.SelectedIndex].Id;
                var DC = new BloodBankDBDataContext();
                var donor = DC.Donors.First(x => x.Id == donorId);
                donor.Date = dtp_date.SelectedDate;
                var requests = DC.BloodRequests.First(x => x.Id == request.Id);
                requests.Status = "APPROVED";
                requests.DonorId = donor.Id;
                requests.DonarDate = dtp_date.SelectedDate;
                DC.SubmitChanges();
                RequestList requestList = new RequestList();
                requestList.ShowDialog();
            }
        }

        private void btn_Reject_Click(object sender, RoutedEventArgs e)
        {
            var DC = new BloodBankDBDataContext();
            var requests = DC.BloodRequests.First(x => x.Id == request.Id);
            requests.Status = "REJECTED";         
            DC.SubmitChanges();
            RequestList requestList = new RequestList();
            requestList.ShowDialog();

        }
    }
    }
