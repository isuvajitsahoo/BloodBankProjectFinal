using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankMangementSystem.Exceptions;
using BloodBankMangementSystem.Entity;
using BloodBankMangementSystem.DAL;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace BloodBankMangementSystem.BLL
{
   public  class DonorBL
    {
        public bool AddDonor(DonorEntities de)
        {
            try
            {

                BloodDonorDAL pdl = new BloodDonorDAL();
                return pdl.AddDonor(de);


            }
            catch (BloodBankExceptions)
            {

                throw;
            }
        }
        public DataTable GetBloodDonorId()
        {//Load Hospital ID In Combo Box
            try
            {
                BloodDonorDAL bbDL = new BloodDonorDAL();
                return bbDL.GetBloodDonorId();
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }

        public bool ValidateBloodDonorData(string BloodDonorID, string FirstName, string LastName, string Address, string City, string Mobile)
        {


            Regex r = new Regex("^[7-9]{1}[0-9]{9}$");

            Regex r2 = new Regex("^[B]{1}[D]{1}[0-9]{5}$");

            BloodDonorDAL bbDL = new BloodDonorDAL();

            StringBuilder sb = new StringBuilder();

            bool valid = true;
            if (BloodDonorID == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nDonor ID cannot be empty");
            }
            else if (!r2.IsMatch(BloodDonorID))
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nDonor ID is not in proper format");
            }
            else if (bbDL.VerifyBloodDonorID(BloodDonorID) == 1)
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nDonor ID already exists");
            }

            if (FirstName == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nDonor First Name cannot be empty");
            }
            if (LastName == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nDonor Last Name cannot be empty");
            }
            if (Address == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nAddress cannot be empty");
            }
            if (City == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nCity cannot be empty");
            }
            if (!r.IsMatch(Mobile))
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nPhone number is not in proper format");
            }
            if (valid == false)
                throw new BloodBankExceptions(sb.ToString());
            return valid;
        }

        public DataTable GetAllBloodBankID()
        {
            BloodDonorDAL bid = new BloodDonorDAL();
            return bid.GetAllBloodBankID();
        }

        public bool ValidateBloodDonationDetails(string bloodDonerId, string date, string noofbottles, string weight, string hbc)
        {

            DonorBL bbBL = new DonorBL();
            DataTable dt = bbBL.GetBloodDonorId();
            Regex r = new Regex("^[7-9]{1}[0-9]{9}$");

            Regex r2 = new Regex("^[B]{1}[D]{1}[0-9]{5}$");

            BloodDonorDAL bbDL = new BloodDonorDAL();

            StringBuilder sb = new StringBuilder();

            bool valid = true;
            if (bloodDonerId == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nDonor ID cannot be empty");
            }
            else if (!r2.IsMatch(bloodDonerId))
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nDonor ID is not in proper format");
            }



            if (dt != null)
            {
                foreach (DataRow t in dt.Rows)
                {
                    if (bloodDonerId == t["BloodDonerId"].ToString())
                    {
                        valid = true;
                        break;

                    }
                    else
                    {
                        valid = false;

                    }

                }


            }
            if (date.ToString() == "")
            {
                valid = false;
                sb.Append(Environment.NewLine +"\nDate not selected");

            }
            if (noofbottles.ToString() == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nBlood Bottles not selected");

            }
            if (valid == false)
            {
                sb.Append(Environment.NewLine + "\nDonor ID doesn't exists");
            }

            if (weight.ToString() == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\n Check weight");
            }
            if (hbc.ToString() == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nCheck HBC amount ");
            }

            //if ()
            //{
            //    valid = false;
            //    sb.Append(Environment.NewLine + "\nhbc amount should be number");
            //}
            if (valid == false)
                throw new BloodBankExceptions(sb.ToString());

            return valid;



        }

        public string GetBloodGroup(string DonorId)
        {
            BloodDonorDAL Bd = new BloodDonorDAL();
            return Bd.GetBloodGroup(DonorId);
        }

        public int AddDonation(BloodDonorDonations pobj)
        {
            try
            {
                BloodDonorDAL pd = new BloodDonorDAL();
                return pd.AddDonation(pobj);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }





        public bool EditDonor(DonorEntities pobj)
        {
            BloodDonorDAL pd = new BloodDonorDAL();
            try
            {
                return pd.UpdateDonor(pobj);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
        }

        public bool DeleteDonor(string donorId)
        {
            try
            {
                BloodDonorDAL pd = new BloodDonorDAL();
                return pd.DeleteDonor(donorId);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
        }

        public DonorEntities Search(string donorId)
        {
            try
            {
                BloodDonorDAL pd = new BloodDonorDAL();
                return pd.Search(donorId);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
        }

        public DataTable Display()
        {
            try
            {
                BloodDonorDAL pd = new BloodDonorDAL();
                return pd.Display();
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
        }

        public DataTable GetCategories()
        {
            try
            {
                BloodDonorDAL pd = new BloodDonorDAL();
                return pd.GetCategories();
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
        }

        public DataTable DisplayDonations()
        {
            try
            {
                BloodDonorDAL pd = new BloodDonorDAL();
                return pd.DisplayDonations();
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
        }



    }
}
