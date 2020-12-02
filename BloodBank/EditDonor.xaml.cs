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
        Donor donor;
        public EditDonor(Donor donor)
        {
            InitializeComponent();
            this.donor = donor;

            if (donor != null)
            {
                NameTextBox.Text = donor.Name;
            }
        }
    }
}
