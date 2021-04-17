using System.Windows;
using System.Linq;
using System;

namespace BloodBank
{
    /// <summary>
    /// Interaction logic for EditDonor.xaml
    /// </summary>
    public partial class AppointmentApproval : Window
    {
        private BloodBankDBDataContext DC;
        Donor donor;
        public AppointmentApproval(Donor donor)
        {
            InitializeComponent();
            this.donor = donor;
            DC = new BloodBankDBDataContext();           

            if (donor != null )
            {
                txt_Name.Text = donor.Name;
                txt_bloodGroup.Text = DC.BloodGroups.First(d => d.Id == donor.BloodGroup).Name;
                txt_Donor_No.Text = donor.Id.ToString();
                if (donor.Date > DateTime.UtcNow)
                {
                    MessageBox.Show("Donor already have an appointment");
                    btn_Submit.Visibility = Visibility.Hidden;
                }
                else
                {
                    btn_Submit.Visibility = Visibility.Visible;
                }
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dtpDonorDate.SelectedDate > DateTime.UtcNow.AddMonths(+3))
            {
                MessageBox.Show("Donor not able to donate blood on this Date");
            }
            else if(dtpDonorDate.SelectedDate < DateTime.UtcNow)
            {
                MessageBox.Show("Please Select Future Date");
            }
            else
            {
                var DC = new BloodBankDBDataContext();
                var donordb = DC.Donors.First(x => x.Id == donor.Id);
                donordb.Date = dtpDonorDate.SelectedDate;
                DC.SubmitChanges();
                this.Close();
               
            }

        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
