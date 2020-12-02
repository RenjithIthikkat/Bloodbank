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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Linq;

namespace BloodBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isValidAdmin(txtUsername.Text, txtPassword.Text))
            {
                AdminDashboard adminDashboard = new AdminDashboard();
                adminDashboard.Show();

            }
            else if (isValidHospital(txtUsername.Text, txtPassword.Text))
            {
                Window1 searchBloodGroup = new Window1();
                searchBloodGroup.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Credentials", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private bool isValidHospital(string username, string password)
        {
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
