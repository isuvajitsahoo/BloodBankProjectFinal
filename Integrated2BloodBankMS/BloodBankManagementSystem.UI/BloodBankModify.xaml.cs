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
    /// Interaction logic for BloodBankModify.xaml
    /// </summary>
    public partial class BloodBankModify : Window
    {
        public BloodBankModify()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodBank_HospitalBL bbBL = new BloodBank_HospitalBL();
                DataTable dt = bbBL.GetBloodBankIdBL();
                if (dt != null)
                {
                    cmbBloodBankID.ItemsSource = dt.DefaultView;
                    cmbBloodBankID.DisplayMemberPath = "BloodBankID";
                    cmbBloodBankID.SelectedValuePath = "BloodBankID";
                }
                else
                    MessageBox.Show("No Blood Bank ID available", "Blood Bank Management System");
            }catch(BloodBankExceptions ex) { MessageBox.Show(ex.Message,"Warning"); }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Warning");
            }
        }

        
        private void cmbBloodBankID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BloodBank_HospitalBL bbBL = new BloodBank_HospitalBL();
                BloodBankDetails bankDetails = bbBL.SearchBloodBankDetailsBL(cmbBloodBankID.SelectedValue.ToString());
                if (bankDetails != null)
                {
                    txtBBName.Text = bankDetails.BloodBankName;
                    txtBBAddress.Text = bankDetails.Address;
                    txtBBCity.Text = bankDetails.City;
                    txtBBContactNo.Text = (bankDetails.ContactNumber).ToString();
                    gb.Visibility = Visibility.Visible;
                }
                else
                {
                    gb.Visibility = Visibility.Hidden;
                    MessageBox.Show("Blood Bank Details Do Not Exist", "Blood Bank Management System");
                }
            }
            catch (BloodBankExceptions ex)
            {
                MessageBox.Show(ex.Message,"Warning");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string bbID = cmbBloodBankID.SelectedValue.ToString();
                BloodBank_HospitalBL bbBL = new BloodBank_HospitalBL();
                if (bbBL.DeleteBloodBankDetailsBL(bbID))
                {
                    gb.Visibility = Visibility.Hidden;
                    MessageBox.Show("Details Deleted","Blood Bank Management System");
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodBank_HospitalBL bbBL = new BloodBank_HospitalBL();
                if (bbBL.ValidateBloodBankUpdateDetails(txtBBName.Text, txtBBAddress.Text, txtBBCity.Text, txtBBContactNo.Text))
                {
                    BloodBankDetails details = new BloodBankDetails
                    {
                        BloodBankID = cmbBloodBankID.SelectedValue.ToString(),
                        BloodBankName = txtBBName.Text,
                        Address = txtBBAddress.Text,
                        City = txtBBCity.Text,
                        ContactNumber = long.Parse(txtBBContactNo.Text)
                    };
                    if (bbBL.UpdateBloodBankDetailsBL(details))
                    {
                        gb.Visibility = Visibility.Hidden;
                        MessageBox.Show("Blood Bank Details Updated", "Blood Bank Management System");
                    }
                    else
                    {
                        gb.Visibility = Visibility.Hidden;
                        MessageBox.Show("Blood Bank Details Could Not Be Updated", "Blood Bank Management System");
                    }
                }
            }catch(BloodBankExceptions ex) { MessageBox.Show(ex.Message,"Warning"); }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Warning");
            }
        }
    }
}
