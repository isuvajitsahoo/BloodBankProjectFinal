using BloodBankMangementSystem.Entity;
using BloodBankMangementSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankMangementSystem.DAL
{
    public class BloodBank_HospitalDL
    {
        //string conStr = @"data source=(LocalDB)\SoumickLocalDB;initial catalog=BloodBankDB";
        string conStr = @"data source=ndamssql\sqlilearn;user id=sqluser;password=sqluser;initial catalog=Training_19Sep18_Pune";
        SqlConnection con;
        SqlCommand com;

        public bool DeleteHospitalDetailsDL(string hID)
        {//Delete Hospital Details
            bool result = false;
            try
            {
                con = new SqlConnection(conStr);

                com = new SqlCommand("BBank.uspDeleteHospitalDetails", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@hID", hID);

                con.Open();
                int noOfRowsAffected = com.ExecuteNonQuery();
                if (noOfRowsAffected == 1)
                {
                    result = true;
                }
            }
            catch (BloodBankExceptions)
            { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return result;
        }

        public bool UpdateHospitalDetailsDL(Hospital hospital)
        {//Update Hospital Details In Hospital Table
            bool DetailsUpdated = false;
            try
            {
                con = new SqlConnection(conStr);

                com = new SqlCommand("BBank.uspUpdateHospitalDetails", con);

                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@hID", hospital.HospitalID);

                com.Parameters.AddWithValue("@hName", hospital.HospitalName);

                com.Parameters.AddWithValue("@hAddress", hospital.Address);

                com.Parameters.AddWithValue("@hCity", hospital.City);

                com.Parameters.AddWithValue("@hContactNo", hospital.ContactNo);

                con.Open();

                com.ExecuteNonQuery();
                DetailsUpdated = true;
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return DetailsUpdated;
        }


        public Hospital SearchHospitalDetailsDL(string hID)
        {//Search For Hospital Details
            Hospital hospital = null;

            try
            {
                con = new SqlConnection(conStr);

                com = new SqlCommand("BBank.uspSearchHospitalDetails", con);


                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@hID", hID);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    hospital = new Hospital
                    {
                        HospitalName = dr["HospitalName"].ToString(),
                        Address = dr["Address"].ToString(),
                        City = dr["City"].ToString(),
                        ContactNo = long.Parse(dr["ContactNumber"].ToString()),

                    };
                    dr.Close();
                }
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return hospital;
        }

        public DataTable GetHospitalIdDL()
        {//Load Hospital ID In Combo Box
            DataTable dt = null;
            try
            {
                con = new SqlConnection(conStr);

                com = new SqlCommand("BBank.uspHospitalID", con);

                com.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return dt;
        }

        public DataTable GetAllHospitalDetailsDL()
        {//Load All Hospital Details In Data Grid
            DataTable dt = null;
            try
            {
                con = new SqlConnection(conStr);

                com = new SqlCommand("BBank.uspDisplayAllHospitalDetails", con);

                com.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return dt;
        }

        public bool AddHospitalDetailsDL(Hospital hospital)
        {//Insert Hospital Details Into Blood Bank Table
            bool DetailsAdded = false;
            try
            {
                con = new SqlConnection(conStr);

                com = new SqlCommand("BBank.uspAddHospitalDetails", con);

                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@hID", hospital.HospitalID);

                com.Parameters.AddWithValue("@hName", hospital.HospitalName);

                com.Parameters.AddWithValue("@hAddress", hospital.Address);

                com.Parameters.AddWithValue("@hCity", hospital.City);

                com.Parameters.AddWithValue("@hContactNo", hospital.ContactNo);

                con.Open();

                com.ExecuteNonQuery();
                DetailsAdded = true;
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return DetailsAdded;
        }

        public int VerifyHospitalIDDL(string hospitalID)
        {//Check For Duplicate Hospital ID
            int idFound = 0;

            try
            {
                con = new SqlConnection(conStr);

                com = new SqlCommand("BBank.uspVerifyHospitalID", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@hID", hospitalID);

                con.Open();
                idFound = int.Parse(com.ExecuteScalar().ToString());
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return idFound;
        }

        public DataTable GetAllBloodBankDetailsDL()
        {//Load All Blood Bank Details In Data Grid
            DataTable dt = null;
            try
            {
                con = new SqlConnection(conStr);

                com = new SqlCommand("BBank.uspDisplayAllBloodBankDetails", con);

                com.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return dt;
        }


        public bool UpdateBloodBankDetailsDL(BloodBankDetails bbDetails)
        {//Update Blood Bank Details In Blood Bank Table
            bool DetailsUpdated = false;
            try
            {
                con = new SqlConnection(conStr);

                com = new SqlCommand("BBank.uspUpdateBloodBankDetails", con);

                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@bbID", bbDetails.BloodBankID);

                com.Parameters.AddWithValue("@bbName", bbDetails.BloodBankName);

                com.Parameters.AddWithValue("@bbAddress", bbDetails.Address);

                com.Parameters.AddWithValue("@bbCity", bbDetails.City);

                com.Parameters.AddWithValue("@bbContactNo", bbDetails.ContactNumber);

                //com.Parameters.AddWithValue("@bbPassword", bbDetails.Password);

                con.Open();

                com.ExecuteNonQuery();
                DetailsUpdated = true;
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return DetailsUpdated;
        }

        public bool DeleteBloodBankDetailsDL(string bbID)
        {//Delete Blood Bank Details
            bool result = false;
            try
            {
                con = new SqlConnection(conStr);
                
                com = new SqlCommand("BBank.uspDeleteBloodBankDetails",con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@bbID", bbID);

                con.Open();
                int noOfRowsAffected = com.ExecuteNonQuery();
                if (noOfRowsAffected == 1)
                {
                    result = true;
                }
            }
            catch (BloodBankExceptions)
            { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return result;
        }

        public BloodBankDetails SearchBloodBankDetailsDL(string bbID)
        {//Search For Blood Bank Details
            BloodBankDetails p = null;

            try
            {
                con = new SqlConnection(conStr);
                
                com = new SqlCommand("BBank.uspSearchBloodBankDetails",con);


                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@bbID", bbID);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    p = new BloodBankDetails
                    {
                        BloodBankName = dr["BloodBankName"].ToString(),
                        Address = dr["Address"].ToString(),
                        City = dr["City"].ToString(),
                        ContactNumber = long.Parse(dr["ContactNumber"].ToString()),
                        
                    };
                    dr.Close();
                }
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return p;
        }

        public DataTable GetBloodBankIdDL()
        {//Load Blood Bank ID In Combo Box
            DataTable dt = null;
            try
            {
                con = new SqlConnection(conStr);
                
                com = new SqlCommand("BBank.uspBloodBankID",con);
                
                com.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return dt;
        }

        public int SearchForDuplicateUserDL(string userName)
        {//Search For UserID In Blood Bank Table
            int userFound = 0;

            try
            {
                con = new SqlConnection(conStr);

                com = new SqlCommand("BBank.uspSearchForDuplicateUser", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@bbUserID", userName);

                con.Open();
                userFound = int.Parse(com.ExecuteScalar().ToString());
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return userFound;
        }

        public bool UserLoginDL(string UserName, string UserPassword)
        {//Authenticate User Using Details From Blood Bank Table
            bool login = false;
            try
            {
                con = new SqlConnection(conStr);

                com = new SqlCommand("BBank.uspUserLogin", con);

                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@bbUserID", UserName);

                con.Open();
                string Password = com.ExecuteScalar().ToString();
                if (Password == UserPassword)
                    login = true;
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return login;
        }

        public bool AddBloodBankDetailsDL(BloodBankDetails bbDetails)
        {//Insert Blood Bank Details Into Blood Bank Table
            bool DetailsAdded = false;
            try
            {
                con = new SqlConnection(conStr);

                com = new SqlCommand("BBank.uspAddBloodBankDetails2", con);

                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@bbID", bbDetails.BloodBankID);

                com.Parameters.AddWithValue("@bbName", bbDetails.BloodBankName);

                com.Parameters.AddWithValue("@bbAddress", bbDetails.Address);

                com.Parameters.AddWithValue("@bbCity", bbDetails.City);

                com.Parameters.AddWithValue("@bbContactNo", bbDetails.ContactNumber);

                //com.Parameters.AddWithValue("@bbUserID", bbDetails.UserID);

                //com.Parameters.AddWithValue("@bbPassword", bbDetails.Password);

                con.Open();

                com.ExecuteNonQuery();
                DetailsAdded = true;
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return DetailsAdded;
        }

        public int VerifyBloodBankIDDL(string bloodBankID)
        {//Check For Duplicate Blood Bank ID
            int idFound = 0;

            try
            {
                con = new SqlConnection(conStr);

                com = new SqlCommand("BBank.uspVerifyBloodBankID", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@bbID", bloodBankID);

                con.Open();
                idFound = int.Parse(com.ExecuteScalar().ToString());
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return idFound;
        }
    }
}
