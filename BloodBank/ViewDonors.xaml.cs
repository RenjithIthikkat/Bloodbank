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
    /// Interaction logic for ViewDonors.xaml
    /// </summary>
    public partial class ViewDonors : Window
    {
        BloodBankDBDataContext dc;
        public ViewDonors()
        {
            InitializeComponent();
            dc = new BloodBankDBDataContext();

            DonorsDataGrid.ItemsSource = dc.Donors;

        }



     
    }
}
