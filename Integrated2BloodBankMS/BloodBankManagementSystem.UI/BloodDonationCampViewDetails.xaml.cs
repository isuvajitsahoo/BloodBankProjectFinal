using BloodBankMangementSystem.BLL;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace BloodBankManagementSystem.UI
{
    /// <summary>
    /// Interaction logic for BloodDonationCampViewDetails.xaml
    /// </summary>
    public partial class BloodDonationCampViewDetails : Window
    {
        public BloodDonationCampViewDetails()
        {
            InitializeComponent();
        }

        private void dgViewCampDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BloodDonationCampBL viewCamp = new BloodDonationCampBL();
            DataTable dt = viewCamp.ViewCampDetailsBLL();
            if (dt != null)
            {
                dgViewCampDetails.ItemsSource = dt.DefaultView;
            }
            else
            {
                MessageBox.Show("Table is empty");
            }
        }
    }
}
