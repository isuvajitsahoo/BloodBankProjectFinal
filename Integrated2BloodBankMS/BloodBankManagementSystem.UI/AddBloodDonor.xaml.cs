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
using BloodBankMangementSystem.Exceptions;
using BloodBankMangementSystem.Entity;
using BloodBankMangementSystem.BLL;
using System.Data;

namespace BloodBankManagementSystem.UI
{
    /// <summary>
    /// Interaction logic for AddBloodDonor.xaml
    /// </summary>
    public partial class AddBloodDonor : Window
    {
        public AddBloodDonor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                DonorBL donor = new DonorBL();

                if (donor.ValidateBloodDonorData(txtDonorID.Text, txtDonorFName.Text, txtDonorLName.Text, txtDonorAdd.Text, txtDonorCity.Text, txtDonorMobile.Text))
                {
                    DonorEntities donorEntities = new DonorEntities()
                    {

                        BloodDonorID = txtDonorID.Text,

                        FirstName = txtDonorFName.Text,
                        LastName = txtDonorLName.Text,
                        Address = txtDonorAdd.Text,
                        City = txtDonorCity.Text,
                        Mobile = txtDonorMobile.Text,
                        BloodGroup = cmbBG.SelectedValue.ToString()
                    };

                    DonorBL dbl = new DonorBL();
                    if (donor.AddDonor(donorEntities))
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BloodDonorDonation BDD = new BloodDonorDonation();
            BDD.ShowDialog();



        }

        private void window(object sender, RoutedEventArgs e)
        {

        }

        private void window_loaded(object sender, RoutedEventArgs e)
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
