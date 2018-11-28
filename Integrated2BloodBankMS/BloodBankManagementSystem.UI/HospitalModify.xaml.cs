using BloodBankMangementSystem.BLL;
using BloodBankMangementSystem.Entity;
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
    /// Interaction logic for HospitalModify.xaml
    /// </summary>
    public partial class HospitalModify : Window
    {
        public HospitalModify()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodBank_HospitalBL bbBL = new BloodBank_HospitalBL();
                DataTable dt = bbBL.GetHospitalIdBL();
                if (dt != null)
                {
                    cmbHospitalID.ItemsSource = dt.DefaultView;
                    cmbHospitalID.DisplayMemberPath = "HospitalID";
                    cmbHospitalID.SelectedValuePath = "HospitalID";
                }
                else
                    MessageBox.Show("No Hospital ID available", "Blood Bank Management System");
            }
            catch (BloodBankExceptions ex) { MessageBox.Show(ex.Message, "Warning"); }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Warning");
            }
        }

        

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodBank_HospitalBL bbBL = new BloodBank_HospitalBL();
                if (bbBL.ValidateBloodBankUpdateDetails(txtHName.Text, txtHAddress.Text, txtHCity.Text, txtHContactNo.Text))
                {
                    Hospital details = new Hospital
                    {
                        HospitalID = cmbHospitalID.SelectedValue.ToString(),
                        HospitalName = txtHName.Text,
                        Address = txtHAddress.Text,
                        City = txtHCity.Text,
                        ContactNo = long.Parse(txtHContactNo.Text)
                    };
                    if (bbBL.UpdateHospitalDetailsBL(details))
                    {
                        gb.Visibility = Visibility.Hidden;
                        MessageBox.Show("Hospital Details Updated", "Blood Bank Management System");
                    }
                    else
                    {
                        gb.Visibility = Visibility.Hidden;
                        MessageBox.Show("Hospital Details Could Not Be Updated", "Blood Bank Management System");
                    }
                }
            }
            catch (BloodBankExceptions ex) { MessageBox.Show(ex.Message, "Warning"); }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Warning");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string bbID = cmbHospitalID.SelectedValue.ToString();
                BloodBank_HospitalBL bbBL = new BloodBank_HospitalBL();
                if (bbBL.DeleteHospitalDetailsBL(bbID))
                {
                    gb.Visibility = Visibility.Hidden;
                    MessageBox.Show("Details Deleted", "Blood Bank Management System");
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

        private void CmbHospitalID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BloodBank_HospitalBL bbBL = new BloodBank_HospitalBL();
                Hospital hospitalDetails = bbBL.SearchHospitalDetailsBL(cmbHospitalID.SelectedValue.ToString());
                if (hospitalDetails != null)
                {
                    txtHName.Text = hospitalDetails.HospitalName;
                    txtHAddress.Text = hospitalDetails.Address;
                    txtHCity.Text = hospitalDetails.City;
                    txtHContactNo.Text = (hospitalDetails.ContactNo).ToString();
                    gb.Visibility = Visibility.Visible;
                }
                else
                {
                    gb.Visibility = Visibility.Hidden;
                    MessageBox.Show("Hospital Details Do Not Exist", "Blood Bank Management System");
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
