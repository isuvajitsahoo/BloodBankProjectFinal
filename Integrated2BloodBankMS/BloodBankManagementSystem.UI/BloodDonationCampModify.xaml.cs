using BloodBankMangementSystem.BLL;
using BloodBankMangementSystem.Entity;
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
    /// Interaction logic for BloodDonationCampModify.xaml
    /// </summary>
    public partial class BloodDonationCampModify : Window
    {
        public BloodDonationCampModify()
        {
            InitializeComponent();
        }

        private void btnsearchCamp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodDonationCampBL bb = new BloodDonationCampBL();
                BloodDonationCamp b = bb.SearchCampBLL(txtBloodDonationCampId.Text);
                if (b != null)
                {
                    txtCampName.Text = b.CampName;
                    txtAddress.Text = b.Address;
                    txtCity.Text = b.City;
                    txtBloodBankId.Text = b.BloodBankId.ToString();
                    txtCampStartDate.Text = b.CampStartDate.ToString();
                    txtCampEndDate.Text = b.CampEndDate.ToString();
                    gbModify.Visibility = Visibility.Visible;
                    txtBloodDonationCampId.IsEnabled = false;
                }
                else
                {
                    gbModify.Visibility = Visibility.Hidden;
                    MessageBox.Show
                        (string.Format("Blood Donation camp with id {0} does not exists.", txtBloodDonationCampId.Text));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateCampDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodDonationCampBL bb = new BloodDonationCampBL();
                if (bb.ValidateBloodDonationCampData(txtBloodDonationCampId.Text, txtCampName.Text, txtAddress.Text, txtCity.Text, txtBloodBankId.Text, txtCampStartDate.Text, txtCampEndDate.Text))
                {
                    if (bb.validateCampIdModify(txtBloodDonationCampId.Text))
                    {
                        BloodDonationCamp b = new BloodDonationCamp
                        {
                            BloodDonationCampId = txtBloodDonationCampId.Text,
                            CampName = txtCampName.Text,
                            Address = txtAddress.Text,
                            City = txtCity.Text,
                            CampStartDate = Convert.ToDateTime(txtCampStartDate.Text),
                            CampEndDate = Convert.ToDateTime(txtCampEndDate.Text)
                        };

                        if (bb.ModifyCampBLL(b))
                        {
                            txtBloodDonationCampId.IsEnabled = true;
                            gbModify.Visibility = Visibility.Hidden;
                            MessageBox.Show("Blood Donation Camp Info Saved.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteCampDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodDonationCampBL bd = new BloodDonationCampBL();
                if (bd.validateCampIdDelete(txtBloodDonationCampId.Text))
                {
                    string bloodDonationCampId = txtBloodDonationCampId.Text;
                    BloodDonationCampBL bb = new BloodDonationCampBL();
                    if (bb.DeleteCampBLL(bloodDonationCampId))
                    {
                        gbModify.Visibility = Visibility.Hidden;
                        txtBloodDonationCampId.IsEnabled = true;
                        MessageBox.Show("Blood Donation Camp Id " + bloodDonationCampId + " was deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

