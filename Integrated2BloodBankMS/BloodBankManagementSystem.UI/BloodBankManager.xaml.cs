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
    /// Interaction logic for BloodBank.xaml
    /// </summary>
    public partial class BloodBank : Window
    {
        public BloodBank()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodBank_HospitalBL bloodBankBL = new BloodBank_HospitalBL();
                if (bloodBankBL.ValidateBloodBankData(txtbbID.Text,txtbbName.Text,txtbbAddress.Text,txtbbCity.Text,txtbbContactNo.Text))
                {
                    if (bloodBankBL.VerifyBloodBankIDBL(txtbbID.Text) == 0)
                    {
                        BloodBankDetails bbDetails = new BloodBankDetails
                        {
                            BloodBankID = txtbbID.Text,
                            BloodBankName = txtbbName.Text,
                            Address = txtbbAddress.Text,
                            City = txtbbCity.Text,
                            ContactNumber = long.Parse(txtbbContactNo.Text),
                            //UserID = txtbbUserName.Text,
                            //Password = pwbbbPassword.Password.ToString()
                        };
                        if (bloodBankBL.AddBloodBankDetailsBL(bbDetails))
                        {
                            MessageBox.Show("Details Added", "Blood Bank Management System");
                        }
                        else
                        {
                            MessageBox.Show("Details could not be added", "Blood Bank Management System");
                        }
                    }
                    else
                        MessageBox.Show("Blood Bank ID already exists", "Blood Bank Management System");
                }

            }
            catch (BloodBankExceptions ex)
            {
                MessageBox.Show(ex.Message,"Warning");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Warning");
            }
        }
    }
}
