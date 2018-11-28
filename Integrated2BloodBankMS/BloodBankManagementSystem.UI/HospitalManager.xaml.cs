using BloodBankMangementSystem.BLL;
using BloodBankMangementSystem.Entity;
using BloodBankMangementSystem.Exceptions;
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

namespace BloodBankManagementSystem.UI
{
    /// <summary>
    /// Interaction logic for HospitalManager.xaml
    /// </summary>
    public partial class HospitalManager : Window
    {
        public HospitalManager()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodBank_HospitalBL bbBL = new BloodBank_HospitalBL();
                if (bbBL.ValidateHospitalData(txthID.Text, txthName.Text, txthAddress.Text, txthCity.Text, txthContactNo.Text))
                {
                    Hospital hospital = new Hospital
                    {
                        HospitalID = txthID.Text,
                        HospitalName = txthName.Text,
                        Address = txthAddress.Text,
                        City = txthCity.Text,
                        ContactNo = long.Parse(txthContactNo.Text),

                    };
                    if (bbBL.AddHospitalDetailsBL(hospital))
                    {
                        MessageBox.Show("Details Added", "Blood Bank Management System");
                    }
                    else
                    {
                        MessageBox.Show("Details could not be added", "Blood Bank Management System");
                    }
                }
            }
            catch (BloodBankExceptions ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
        
        }
    }
}
