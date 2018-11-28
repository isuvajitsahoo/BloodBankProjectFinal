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
    /// Interaction logic for BloodDonationCampAdd.xaml
    /// </summary>
    public partial class BloodDonationCampAdd : Window
    {
        public BloodDonationCampAdd()
        {
            InitializeComponent();
        }

        private void btnArrange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodDonationCampBL bl = new BloodDonationCampBL();
                if (bl.ValidateBloodDonationCampData(txtBloodDonationCampId.Text, txtCampName.Text, txtAddress.Text, txtCity.Text, txtBloodBankId.Text, txtCampStartDate.Text, txtCampEndDate.Text))
                {
                    if (bl.validateCampIdArrange(txtBloodDonationCampId.Text))
                    {
                        BloodDonationCamp arrange = new BloodDonationCamp()
                        {
                            BloodDonationCampId = txtBloodDonationCampId.Text,
                            CampName = txtCampName.Text,
                            Address = txtAddress.Text,
                            City = txtCity.Text,
                            BloodBankId = txtBloodBankId.Text,
                            CampStartDate = Convert.ToDateTime(txtCampStartDate.Text),
                            CampEndDate = Convert.ToDateTime(txtCampEndDate.Text)
                        };


                        if (bl.ArrangeCampBLL(arrange))
                        {
                            MessageBox.Show(" Blood Donation Camp Arranged Successfully");


                        }
                        else
                        {
                            MessageBox.Show("Details Not Added");
                        }

                    }
                }
            }
            catch 
            {
                throw;
            }
        }
    }
}

