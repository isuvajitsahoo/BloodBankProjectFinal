using BloodBankMangementSystem.DAL;
using BloodBankMangementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BloodBankMangementSystem.BLL
{
    public class BloodDonationCampBL
    {
        BloodDonationCampDL bbDL = new BloodDonationCampDL();
        StringBuilder sb = new StringBuilder();

        public bool validateCampIdArrange(string BloodDonationCampId)
        {
            bool valid = true;
            if (bbDL.VerifyBloodDonationCampID(BloodDonationCampId) == 1)
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nBlood Donation Camp ID already exists");
            }
            if (valid == false)
                throw new SystemException(sb.ToString());
            return valid;
        }
        public bool validateCampIdModify(string BloodDonationCampId)
        {
            bool valid = true;
            if (bbDL.VerifyBloodDonationCampID(BloodDonationCampId) == 0)
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nBlood Donation Camp ID not found");
            }
            if (valid == false)
                throw new SystemException(sb.ToString());
            return valid;
        }

        public bool validateCampIdDelete(string BloodDonationCampId)
        {
            Regex r1 = new Regex("^[D]{1}[C]{1}[0-9]{5}$");
            bool valid = true;
            if (BloodDonationCampId == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nBlood Donation Camp ID cannot be empty");
            }
            else if (!r1.IsMatch(BloodDonationCampId))
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nBlood Donation Camp ID is not valid");
            }
            if (valid == false)
                throw new SystemException(sb.ToString());
            return valid;
        }


        public bool ValidateBloodDonationCampData(string BloodDonationCampId, string CampName, string Address, string City, string BloodBankId, string CampStartDate, string CampEndDate)
        {
            Regex r1 = new Regex("^[D]{1}[C]{1}[0-9]{5}$");
            Regex r2 = new Regex("^[B]{1}[B]{1}[0-9]{5}$");

            bool valid = true;
            if (BloodDonationCampId == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nBlood Donation Camp ID cannot be empty");
            }
            else if (!r1.IsMatch(BloodDonationCampId))
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nBlood Donation Camp ID is not valid");
            }

            if (CampName == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nBlood Donation Camp Name cannot be empty");
            }
            if (BloodBankId == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nBlood Donation Last Name cannot be empty");
            }
            else if (!r2.IsMatch(BloodBankId))
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nBlood Donation Camp ID is not in proper format");
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
            if (Convert.ToDateTime(CampStartDate) > Convert.ToDateTime(CampEndDate))
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nCamp start date cannot be greater than Camp end date");
            }
            if (valid == false)
                throw new SystemException(sb.ToString());
            return valid;
        }

        public bool ArrangeCampBLL(BloodDonationCamp arrange)
        {
            bool arrangeCamp = false;
            try
            {
                BloodDonationCampDL bBMSDAL = new BloodDonationCampDL();
                arrangeCamp = bBMSDAL.ArrangeCampDAL(arrange);
            }
            catch
            {
                throw;
            }

            return arrangeCamp;
        }

        public DataTable ViewCampDetailsBLL()
        {
            try
            {
                BloodDonationCampDL bBMSDAL = new BloodDonationCampDL();
                return bBMSDAL.ViewCampDetailsDAL();
            }
            catch
            {
                throw;
            }
        }

        public bool ModifyCampBLL(BloodDonationCamp modify)
        {
            try
            {
                BloodDonationCampDL bd = new BloodDonationCampDL();
                return bd.ModifyCampDAL(modify);
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteCampBLL(string bloodDonationCampID)
        {
            try
            {
                BloodDonationCampDL bd = new BloodDonationCampDL();
                return bd.DeleteCampDAL(bloodDonationCampID);
            }
            catch
            {
                throw;
            }
        }

        public BloodDonationCamp SearchCampBLL(string bloodDonationCampID)
        {
            try
            {
                BloodDonationCampDL bd = new BloodDonationCampDL();
                return bd.SearchCampDAL(bloodDonationCampID);
            }
            catch
            {
                throw;
            }
        }
    }
}
