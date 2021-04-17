
using System.Linq;
using System.Windows;
namespace BloodBank
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isValidAdmin(txtUsername.Text, txtPassword.Password))
            {
                //if admin credentials are validated successfuly , transfer admin to admindashboard
                AdminDashboard adminDashboard = new AdminDashboard(txtUsername.Text);
                adminDashboard.ShowDialog();
                Close();
            }
            else if (isValidHospital(txtUsername.Text, txtPassword.Password))
            {
                //if hospital credentials are validated successfuly , transfer hospital to search bloodgroup page
                SearchByBloodGroup searchBloodGroup = new SearchByBloodGroup(false,txtUsername.Text);
                searchBloodGroup.ShowDialog();
                Close();
            }
            else if (txtUsername.Text == "")
            {
                //if username is empty give alert message
                MessageBox.Show("Please enter username", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (txtPassword.Password == "")
            {
                //if password is empty give alert message
                MessageBox.Show("Please enter password", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                txtPassword.Password = "";
                txtUsername.Text = "";
                //if credentails entered are wrong give alert message
                MessageBox.Show("Invalid Credentials", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private bool isValidHospital(string username, string password)
        {
            //querying db for validating hospital credentials
            BloodBankDBDataContext dc = new BloodBankDBDataContext();
            var q = from p in dc.Credentials where p.Username == username && p.Password == password && p.Type == "hospital" select p;
            if (q.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isValidAdmin(string username, string password)
        {
            //querying db for validating admin credentials
            BloodBankDBDataContext dc = new BloodBankDBDataContext();
            var q = from p in dc.Credentials where p.Username == username && p.Password == password && p.Type == "admin" select p;
            if (q.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
