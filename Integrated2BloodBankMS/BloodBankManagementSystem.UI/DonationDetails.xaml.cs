using BloodBankMangementSystem.BLL;
using BloodBankMangementSystem.Exceptions;
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
    /// Interaction logic for DonationDetails.xaml
    /// </summary>
    public partial class DonationDetails : Window
    {
        public DonationDetails()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DonorBL db = new DonorBL();
                DataTable dt = db.DisplayDonations();
                if (dt != null)
                {
                    dataGridDonation.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("Table is empty", "Blood Bank Management System");
                }
            }
            catch (BloodBankExceptions ex)
            {
                MessageBox.Show(ex.Message, "Blood Bank Management System");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Blood Bank Management System");
            }
        }
    }
}
