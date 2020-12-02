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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BloodBankDBDataContext dc = new BloodBankDBDataContext();
            int bg = 0;
            if (Ap.IsChecked.Equals(true))
            {
                bg = 1;
            }
            else if (Bp.IsChecked.Equals(true))
            {
                bg = 2;
            }
            else if (An.IsChecked.Equals(true))
            {
                bg = 3;
            }
            else if (Bn.IsChecked.Equals(true))
            {
                bg = 4;
            }
            else if (ABp.IsChecked.Equals(true))
            {
                bg = 5;
            }
            else if (ABn.IsChecked.Equals(true))
            {
                bg = 6;
            }
            else if (Op.IsChecked.Equals(true))
            {
                bg = 7;
            }
            else if (On.IsChecked.Equals(true))
            {
                bg = 8;
            }

            var result = from p in dc.Donors where p.BloodGroup == bg && p.BloodAvailable == 1 select p;
            if (result.Any())
            {
                resultBox.Text = "Blood Group is Available";
            }
            else
            {
                resultBox.Text = "Blood Group is Not Available";
            }
        }
    }
}
