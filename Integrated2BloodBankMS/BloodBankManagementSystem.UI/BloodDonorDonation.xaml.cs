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
using BloodBankMangementSystem.BLL;
using BloodBankMangementSystem.DAL;
using BloodBankMangementSystem.Entity;
using BloodBankMangementSystem.Exceptions;

namespace BloodBankManagementSystem.UI
{
    /// <summary>
    /// Interaction logic for BloodDonorDonation.xaml
    /// </summary>
    public partial class BloodDonorDonation : Window
    {
        public BloodDonorDonation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            DonationDetails dd = new DonationDetails();
            dd.ShowDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {




            try
            {
                DonorBL b = new DonorBL();
                if (b.ValidateBloodDonationDetails(txtBloodDonorId.Text, dateChoose.Text.ToString(), txtnoofbottle.Text.ToString(), textweight.Text, txtHB.Text))
                {

                    BloodDonorDonations p = new BloodDonorDonations
                    {
                        BloodDonorID = txtBloodDonorId.Text,
                        BloodDonationDate = DateTime.Parse(dateChoose.Text),
                        NumberOfBottles = int.Parse(txtnoofbottle.Text),
                        Weight = int.Parse(textweight.Text),
                        HBCount = decimal.Parse(txtHB.Text),
                        BloodGroup=lblbloodgroup.Content.ToString(),
                        BloodBankId=cmbBloodBankId.SelectedValue.ToString()
                    };

                    DonorBL pb = new DonorBL();
                    int pid = pb.AddDonation(p);
                    BloodDonationLabel.Content = pid.ToString();
                    
                    MessageBox.Show(string.Format("New donation added.\ndonation id Id:{0}", pid),
                        "BBMS");
                    clearall();
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

        public void clearall()
        {
            BloodDonationLabel.Content = null;
            txtBloodDonorId.Text = null;
            txtHB.Text = null;
            txtnoofbottle.Text = null;
            textweight.Text = null;




        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DonorBL bi = new DonorBL();
            GetAllBloodBankID();





        }

        public void GetAllBloodBankID()
        {
            DonorBL bi = new DonorBL();
            DataTable bloodBankName = bi.GetAllBloodBankID();
            if (bloodBankName == null)
            {
                MessageBox.Show("nothing to show");
            }
            else
            {
                string[] result = new string[bloodBankName.Rows.Count];


                for (int i = 0; i < bloodBankName.Rows.Count; i++)
                {
                    for (int j = 0; j < bloodBankName.Columns.Count; j++)
                    {
                        result[i] = bloodBankName.Rows[i][j].ToString();
                       cmbBloodBankId.Items.Remove(result[i]);
                        
                    }
                }
                for (int i = 0; i < bloodBankName.Rows.Count; i++)
                {
                    for (int j = 0; j < bloodBankName.Columns.Count; j++)
                    {
                        result[i] = bloodBankName.Rows[i][j].ToString();
                        cmbBloodBankId.Items.Add(result[i]);
                        
                    }
                }
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            DonorBL Bb = new DonorBL();
            string bloodgroup=(string )Bb.GetBloodGroup(txtBloodDonorId.Text);

            lblbloodgroup.Content = bloodgroup;




        }
    }
}
