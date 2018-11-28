using BloodBankMangementSystem.BLL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BloodBankManagementSystem.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BloodBank_HospitalBL bankBL = new BloodBank_HospitalBL();
                if (bankBL.SearchForDuplicateUserBL(txtUser.Text) == 1)
                {
                    if (bankBL.UserLoginBL(txtUser.Text, pwbPassword.Password.ToString()))
                    {
                        HomePage homePage = new HomePage();
                        homePage.Show();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Password is incorrect", "Blood Bank Management System");
                }
                else
                    MessageBox.Show("Username does not exist", "Blood Bank Management System");

            }catch(BloodBankExceptions ex) { MessageBox.Show(ex.Message, "Warning"); }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Warning");
            }
        }
    }
}
