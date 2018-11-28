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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void MenuBBDetails_Click(object sender, RoutedEventArgs e)
        {
            BloodBank bloodBank = new BloodBank();
            bloodBank.ShowDialog();
        }

        private void MenuModBBDetails_Click(object sender, RoutedEventArgs e)
        {
            BloodBankModify bloodBankModify = new BloodBankModify();
            bloodBankModify.ShowDialog();
        }

        private void MenuViewBBDetails_Click(object sender, RoutedEventArgs e)
        {
            ViewBloodBankDetails viewBloodBank = new ViewBloodBankDetails();
            viewBloodBank.ShowDialog();
        }

        private void MenuHDetails_Click(object sender, RoutedEventArgs e)
        {
            HospitalManager hospitalManager = new HospitalManager();
            hospitalManager.ShowDialog();
        }

        private void MenuModHDetails_Click(object sender, RoutedEventArgs e)
        {
            HospitalModify hospitalModify = new HospitalModify();
            hospitalModify.ShowDialog();
        }

        private void MenuViewHDetails_Click(object sender, RoutedEventArgs e)
        {
            ViewHospitalDetails viewHospitalDetails = new ViewHospitalDetails();
            viewHospitalDetails.ShowDialog();
        }

        private void MenuBDDetails_Click(object sender, RoutedEventArgs e)
        {
            AddBloodDonor Ad = new AddBloodDonor();
            Ad.ShowDialog();
        }

        private void MenuModBDDetails_Click(object sender, RoutedEventArgs e)
        {
            UpdateBloodDonor ubd = new UpdateBloodDonor();
            ubd.ShowDialog();
            
        }

        private void MenuViewBDDetails_Click(object sender, RoutedEventArgs e)
        {
            DisplayBloodDonorList Dbd = new DisplayBloodDonorList();
            Dbd.ShowDialog();
        }

        private void MenuBDCDetails_Click(object sender, RoutedEventArgs e)
        {
            BloodDonationCampAdd bloodDonationCampAdd = new BloodDonationCampAdd();
            bloodDonationCampAdd.ShowDialog();
        }

        private void MenuModBDCDetails_Click(object sender, RoutedEventArgs e)
        {
            BloodDonationCampModify bloodDonationCampModify = new BloodDonationCampModify();
            bloodDonationCampModify.ShowDialog();
        }

        private void MenuViewBDCDetails_Click(object sender, RoutedEventArgs e)
        {
            BloodDonationCampViewDetails bloodDonationCampViewDetails = new BloodDonationCampViewDetails();
            bloodDonationCampViewDetails.ShowDialog();
        }

        private void MenuIDetails_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuModIDetails_Click(object sender, RoutedEventArgs e)
        {
            BloodInventoryDelete bid = new BloodInventoryDelete();
            bid.ShowDialog();
        }

        private void MenuViewIDetails_Click(object sender, RoutedEventArgs e)
        {
            BloodInventoryDisplay b = new BloodInventoryDisplay();
            b.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
