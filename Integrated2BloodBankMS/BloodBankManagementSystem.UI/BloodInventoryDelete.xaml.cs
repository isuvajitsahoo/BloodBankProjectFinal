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
    /// Interaction logic for BloodInventoryDelete.xaml
    /// </summary>
    public partial class BloodInventoryDelete : Window
    {
        public BloodInventoryDelete()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodInventoryBLL pb = new BloodInventoryBLL();
                BloodInventory p = pb.Search(int.Parse(SearchtextBox.Text));
                if (p != null)
                {
                    BloodGrouptextBox.Text = p.BloodGroup;
                    txtBloodBankId.Text = p.BloodBankID.ToString();
                    txtNoOfBottles.Text = p.NumberOfBottles.ToString();
                    txtExpiryDate.Text = p.ExpiryDate.ToShortDateString();
                   // txtHospitalId.Text = p.HospitalID.ToString();
                    groupBox.Visibility = Visibility.Visible;
                }
                else
                {
                    groupBox.Visibility = Visibility.Hidden;
                    MessageBox.Show
                        (string.Format("Blood Inventory with id {0} does not exists.",SearchtextBox.Text),
                        "Blood Inventory Management System");
                }
            }
            catch (BloodBankExceptions ex)
            {
                MessageBox.Show(ex.Message, "Blood Inventory Management System");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Blood Inventory Management System");
            }
        }

        private void Updatebutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodInventory p = new BloodInventory()
                {
                    BloodInvenoryID = (SearchtextBox.Text),
                    BloodGroup = BloodGrouptextBox.Text,
                    NumberOfBottles = int.Parse(txtNoOfBottles.Text),
                    BloodBankID = (txtBloodBankId.Text),
                    ExpiryDate = Convert.ToDateTime(txtExpiryDate.Text),
                    //HospitalID = int.Parse(txtHospitalId.Text)
                };
                BloodInventoryBLL pb = new BloodInventoryBLL();
                if (pb.EditBloodInventory(p))
                {
                    groupBox.Visibility = Visibility.Hidden;
                    MessageBox.Show("Inventory data updated.", "BBMS");
                }
            }
            catch (BloodBankExceptions ex)
            {
                MessageBox.Show(ex.Message, "BBMS");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "BBMS");
            }


        }

        private void Deletebutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime pid = DateTime.Parse(txtExpiryDate.Text);
                BloodInventoryBLL pb = new BloodInventoryBLL();
                if (pb.DeleteBloodInventory(pid))
                {
                    groupBox.Visibility = Visibility.Hidden;
                    MessageBox.Show("Blood Inventory Id " + pid + " was deleted.");
                }
            }
            catch (BloodBankExceptions ex)
            {
                MessageBox.Show(ex.Message, "Product Management System");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Product Management System");
            }
        }
    }
}
