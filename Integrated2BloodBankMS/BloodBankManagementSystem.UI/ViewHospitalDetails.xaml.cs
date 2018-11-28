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
    /// Interaction logic for ViewHospitalDetails.xaml
    /// </summary>
    public partial class ViewHospitalDetails : Window
    {
        public ViewHospitalDetails()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodBank_HospitalBL bankBL = new BloodBank_HospitalBL();
                DataTable dt = bankBL.GetAllHospitalDetailsBL();
                if (dt != null)
                {
                    dgBBDetails.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("There are no details available", "Blood Bank Management System");
                }
            }
            catch (BloodBankExceptions ex) { MessageBox.Show(ex.Message, "Warning"); }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Warning");
            }
        }
    }
}
