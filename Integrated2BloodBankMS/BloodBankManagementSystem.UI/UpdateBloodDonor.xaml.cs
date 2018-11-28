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
    /// Interaction logic for UpdateBloodDonor.xaml
    /// </summary>
    public partial class UpdateBloodDonor : Window
    {
        public UpdateBloodDonor()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DonorBL db = new DonorBL();
                DonorEntities de = db.Search(txtDID.Text);
                if (de != null)
                {
                    txtFName.Text = de.FirstName;
                    txtLName.Text = de.LastName;
                    txtAdd.Text = de.Address;
                    txtCity.Text = de.City;
                    txtMob.Text = de.Mobile;
                    cmbBG.SelectedValue = de.BloodGroup.ToString();
                    gb1.Visibility = Visibility.Visible;
                }
                else
                {
                    gb1.Visibility = Visibility.Hidden;
                    MessageBox.Show
                        (string.Format("Donor with id {0} does not exists.", txtDID.Text),
                        "Blood Bank Management System");
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DonorEntities de = new DonorEntities
                {
                    BloodDonorID = txtDID.Text,
                    FirstName = txtFName.Text,
                    LastName = txtLName.Text,
                    Address = txtAdd.Text,
                    City = txtCity.Text,
                    Mobile = txtMob.Text,
                    BloodGroup = cmbBG.SelectedValue.ToString()
                };
                DonorBL db = new DonorBL();
                if (db.EditDonor(de))
                {
                    gb1.Visibility = Visibility.Hidden;
                    MessageBox.Show("Donor Info Saved.", "Blood Bank Management System");
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

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string did = txtDID.Text;
                DonorBL pb = new DonorBL();
                if (pb.DeleteDonor(did))
                {
                    gb1.Visibility = Visibility.Hidden;
                    MessageBox.Show("Donor Id " + did + " was deleted.");
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DonorBL db = new DonorBL();
                DataTable dt = db.GetCategories();
                if (dt != null)
                {
                    cmbBG.ItemsSource = dt.DefaultView;
                    cmbBG.DisplayMemberPath = "BG";
                    cmbBG.SelectedValuePath = "BG";
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
