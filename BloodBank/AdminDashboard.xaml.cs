using System.Windows;
//Admin Dashboard
namespace BloodBank
{   
    public partial class AdminDashboard : Window
    {
        private string user;
        public AdminDashboard(string username)
        {
            user = username;
            InitializeComponent();
        }
        //Redirecting to Add New Donors page
        private void AddDonorsButton_Click(object sender, RoutedEventArgs e)
        {
            AddDonorBtn.Focusable = false;
            AddNewDonor addNewDonor = new AddNewDonor();
            addNewDonor.ShowDialog();
        }

        //Redirecting to View New Donors page
        private void ViewDonorsButton_Click(object sender, RoutedEventArgs e)
        {
            ViewDonorsBtn.Focusable = false;
            ViewDonors viewDonors = new ViewDonors();
            viewDonors.ShowDialog();
        }        
        private void SearchByBloodGroupsButton_Click(object sender, RoutedEventArgs e)
        {
            SearchBGBtn.Focusable = false;           
            RequestList requestList = new RequestList();
            requestList.ShowDialog();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void btn_Appointmnet_Click(object sender, RoutedEventArgs e)
        {
            btn_Appointment.Focusable = false;          
            Appointment appointment = new Appointment();
            appointment.ShowDialog();

        }
    }
}
