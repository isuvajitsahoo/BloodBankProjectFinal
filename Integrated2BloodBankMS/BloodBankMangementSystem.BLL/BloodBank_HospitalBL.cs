using BloodBankMangementSystem.DAL;
using BloodBankMangementSystem.Entity;
using BloodBankMangementSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BloodBankMangementSystem.BLL
{
    public class BloodBank_HospitalBL
    {

        public bool DeleteHospitalDetailsBL(string hID)
        {//Delete Hospital Details
            try
            {
                BloodBank_HospitalDL bbDL = new BloodBank_HospitalDL();
                return bbDL.DeleteHospitalDetailsDL(hID);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }

        public bool UpdateHospitalDetailsBL(Hospital hospital)
        {//Update Hospital Details In Hospital Table

            try
            {
                BloodBank_HospitalDL bbDAL = new BloodBank_HospitalDL();
                return bbDAL.UpdateHospitalDetailsDL(hospital);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }

        }

        public Hospital SearchHospitalDetailsBL(string hID)
        {//Search For Hospital Details
            try
            {
                BloodBank_HospitalDL bbDL = new BloodBank_HospitalDL();
                return bbDL.SearchHospitalDetailsDL(hID);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }

        public DataTable GetHospitalIdBL()
        {//Load Hospital ID In Combo Box
            try
            {
                BloodBank_HospitalDL bbDL = new BloodBank_HospitalDL();
                return bbDL.GetHospitalIdDL();
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }

        public DataTable GetAllHospitalDetailsBL()
        {//Load Hospital Details In Data Grid
            try
            {
                BloodBank_HospitalDL bbDL = new BloodBank_HospitalDL();
                return bbDL.GetAllHospitalDetailsDL();
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }

        public bool AddHospitalDetailsBL(Hospital hospital)
        {//Insert Hospital Details Into Blood Bank Table

            try
            {
                BloodBank_HospitalDL bbDAL = new BloodBank_HospitalDL();
                return bbDAL.AddHospitalDetailsDL(hospital);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }

        }

        public bool ValidateHospitalData(string hID, string hName, string hAddress, string hCity, string hContact)
        {//Validate All Data Before Adding It To Hospital Table
            Regex r = new Regex("^[7-9]{1}[0-9]{9}$");

            Regex r2 = new Regex("^[H]{1}[S]{1}[0-9]{5}$");
            BloodBank_HospitalDL bbDL = new BloodBank_HospitalDL();
            StringBuilder sb = new StringBuilder();
            bool valid = true;
            if (hID == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nHospital ID cannot be empty");
            }
            else if (!r2.IsMatch(hID))
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nHospital ID is not in proper format");
            }
            else if(bbDL.VerifyHospitalIDDL(hID)==1)
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nHospital ID already exists");
            }

            if (hName == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nHospital Name cannot be empty");
            }
            if (hAddress == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nAddress cannot be empty");
            }
            if (hCity == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nCity cannot be empty");
            }
            if (!r.IsMatch(hContact))
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nPhone number is not in proper format");
            }
            if (valid == false)
                throw new BloodBankExceptions(sb.ToString());
            return valid;
        }

        public DataTable GetAllBloodBankDetailsBL()
        {//Load Blood Bank Details In Data Grid
            try
            {
                BloodBank_HospitalDL bbDL = new BloodBank_HospitalDL();
                return bbDL.GetAllBloodBankDetailsDL();
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }

        public bool UpdateBloodBankDetailsBL(BloodBankDetails bloodBankDetails)
        {//Update Blood Bank Details In Blood Bank Table

            try
            {
                BloodBank_HospitalDL bbDAL = new BloodBank_HospitalDL();
                return bbDAL.UpdateBloodBankDetailsDL(bloodBankDetails);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }

        }

        public bool DeleteBloodBankDetailsBL(string bbID)
        {//Delete Blood Bank Details
            try
            {
                BloodBank_HospitalDL bbDL = new BloodBank_HospitalDL();
                return bbDL.DeleteBloodBankDetailsDL(bbID);
            }
            catch(BloodBankExceptions)
            {
                throw;
            }
        }

        public BloodBankDetails SearchBloodBankDetailsBL(string bbID)
        {//Search For Blood Bank Details
            try
            {
                BloodBank_HospitalDL bbDL = new BloodBank_HospitalDL();
                return bbDL.SearchBloodBankDetailsDL(bbID);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }

        public DataTable GetBloodBankIdBL()
        {//Load Blood Bank ID In Combo Box
            try
            {
                BloodBank_HospitalDL bbDL = new BloodBank_HospitalDL();
                return bbDL.GetBloodBankIdDL();
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }

        public bool UserLoginBL(string userName, string userPassword)
        {//Authenticate User Using Details From Blood Bank Table
            try
            {
                BloodBank_HospitalDL bbDL = new BloodBank_HospitalDL();
                return bbDL.UserLoginDL(userName, userPassword);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }

        public int SearchForDuplicateUserBL(string userName)
        {//Search For UserID In Blood Bank Table
            try
            {
                BloodBank_HospitalDL bbDAL = new BloodBank_HospitalDL();
                return bbDAL.SearchForDuplicateUserDL(userName);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }

        public bool AddBloodBankDetailsBL(BloodBankDetails bloodBankDetails)
        {//Insert Blood Bank Details Into Blood Bank Table

            try
            {
                 BloodBank_HospitalDL bbDAL = new BloodBank_HospitalDL();
                 return bbDAL.AddBloodBankDetailsDL(bloodBankDetails);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
            
        }

        public bool ValidateBloodBankData(string bbID,string bbName,string bbAddress,string bbCity,string bbContact)
        {//Validate All Data Before Adding It To Blood Bank Table
            Regex r = new Regex("^[7-9]{1}[0-9]{9}$");
            
            Regex r2 = new Regex("^[B]{1}[B]{1}[0-9]{5}$");

            StringBuilder sb = new StringBuilder();
            bool valid = true;
            if (bbID == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nBlood Bank ID cannot be empty");
            }
            else if (!r2.IsMatch(bbID))
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nBlood Bank ID is not in proper format");
            }
            
            if (bbName == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nBlood Bank Name cannot be empty");
            }
            if (bbAddress == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nAddress cannot be empty");
            }
            if (bbCity == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nCity cannot be empty");
            }
            if(!r.IsMatch(bbContact))
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nPhone number is not in proper format");
            }
            if (valid == false)
                throw new BloodBankExceptions(sb.ToString());
            return valid;
        }

        public bool ValidateBloodBankUpdateDetails(string bbName, string bbAddress, string bbCity, string bbContactNo)
        {//Validate Updated Blood Bank Details
            Regex r = new Regex("^[7-9]{1}[0-9]{9}$");
            bool valid = true ;
            StringBuilder sb = new StringBuilder();
            if (bbName == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nName cannot be empty");
            }
            if (bbAddress == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nAddress cannot be empty");
            }
            if (bbCity == "")
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nCity cannot be empty");
            }
            if (!r.IsMatch(bbContactNo))
            {
                valid = false;
                sb.Append(Environment.NewLine + "\nPhone number is not in proper format");
            }
            if (valid == false)
                throw new BloodBankExceptions(sb.ToString());
            return valid;
        }

        public int VerifyBloodBankIDBL(string bloodbankID)
        {//Check For Duplicate Blood Bank ID
            try
            {
                BloodBank_HospitalDL bbDAL = new BloodBank_HospitalDL();
                return bbDAL.VerifyBloodBankIDDL(bloodbankID);
            }
            catch (BloodBankExceptions)
            {
                throw;
            }
        }
            
    }
}
