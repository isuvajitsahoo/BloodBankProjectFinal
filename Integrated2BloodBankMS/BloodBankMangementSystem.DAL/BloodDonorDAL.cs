using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBankMangementSystem.Exceptions;
using BloodBankMangementSystem.Entity;
using System.Windows;

namespace BloodBankMangementSystem.DAL
{
    public class BloodDonorDAL
    {


        SqlCommand cmd;
        string Con = @"Data Source=ndamssql\sqlilearn;Initial Catalog=Training_19Sep18_Pune;User ID=sqluser;Password=sqluser";
        SqlConnection con1;

        public bool AddDonor(DonorEntities d) //adding product using stored procedures
        {
            bool DetailsAdded = false;
            try
            {
                con1 = new SqlConnection(Con);
                cmd = new SqlCommand("AddDonorDetails", con1);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@BloodDonerId", d.BloodDonorID);
                cmd.Parameters.AddWithValue("@FirstName", d.FirstName);
                cmd.Parameters.AddWithValue("@LastName", d.LastName);
                cmd.Parameters.AddWithValue("@Address", d.Address);
                cmd.Parameters.AddWithValue("@City", d.City);
                cmd.Parameters.AddWithValue("@MobileNo", d.Mobile);
                cmd.Parameters.AddWithValue("@BloodGroup", d.BloodGroup);


                con1.Open();
                cmd.ExecuteNonQuery();
                DetailsAdded = true;

            }
            catch (BloodBankExceptions)
            {

                MessageBox.Show("Please enter valid entries.");
            }
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
                if (con1.State == ConnectionState.Open)
                {
                    con1.Close();
                }
            }
            return DetailsAdded;

        }

        public bool UpdateDonor(DonorEntities d) //adding product using stored procedures
        {

            bool result = false;
            try
            {

                con1 = new SqlConnection(Con);
                cmd = new SqlCommand("EditDonor", con1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BloodDonerId", d.BloodDonorID);
                cmd.Parameters.AddWithValue("@FirstName", d.FirstName);
                cmd.Parameters.AddWithValue("@LastName", d.LastName);
                cmd.Parameters.AddWithValue("@Address", d.Address);
                cmd.Parameters.AddWithValue("@City", d.City);
                cmd.Parameters.AddWithValue("@MobileNo", d.Mobile);
                cmd.Parameters.AddWithValue("@BloodGroup", d.BloodGroup);


                con1.Open();

                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected == 1)
                {
                    result = true;
                }
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
            finally
            {
                if (con1.State == ConnectionState.Open)
                {
                    con1.Close();
                }
            }
            return result;
        }

        public DataTable GetAllBloodBankID()
        {
            DataTable bloodBankName = null;
            try
            {
                con1 = new SqlConnection(Con);
                cmd = new SqlCommand();
                cmd.CommandText = "BBank.uspGetAllBloodBankID";
                cmd.Connection = con1;
                cmd.CommandType = CommandType.StoredProcedure;
                con1.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    bloodBankName = new DataTable();
                    bloodBankName.Load(dr);
                }



            }
            catch (BloodBankExceptions ex)
            {
                MessageBox.Show("invalid data" + ex);
            }
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
                if (con1.State == ConnectionState.Open)
                {
                    con1.Close();
                }
            }
            return bloodBankName;
        }
    

        public bool DeleteDonor(string donorId)
        {
            bool result = false;
            try
            {
                con1 = new SqlConnection(Con);
                cmd = new SqlCommand("DeleteDonor", con1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BloodDonerId", donorId);

                con1.Open();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected == 1)
                {
                    result = true;
                }
            }
            catch (BloodBankExceptions)
            {
                throw;
            }

            finally
            {
                if (con1.State == ConnectionState.Open)
                {
                    con1.Close();
                }
            }
            return result;
        }

        public DonorEntities Search(string donorId)
        {
            DonorEntities de = null;

            try
            {
                con1 = new SqlConnection(Con);
                cmd = new SqlCommand("SearchDonor", con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BloodDonerId", donorId);

                con1.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    de = new DonorEntities
                    {
                        BloodDonorID = dr["BloodDonerID"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        Address = dr["Address"].ToString(),
                        City = dr["City"].ToString(),
                        Mobile = dr["MobileNo"].ToString(),
                        BloodGroup = dr["BloodGroup"].ToString()
                    };
                    dr.Close();
                }
            }
            catch (BloodBankExceptions) { throw; }

            finally
            {
                if (con1.State == ConnectionState.Open)
                {
                    con1.Close();
                }
            }
            return de;
        }

        public string GetBloodGroup(string donorId)
        {


            string bloodgroup = null;
            try
            {

                con1 = new SqlConnection(Con);

                cmd = new SqlCommand("BBank.uspGetBloodgroup", con1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@bloodonorid", donorId);
                con1.Open();
                bloodgroup = cmd.ExecuteScalar().ToString();

            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (con1.State == ConnectionState.Open)
                {
                    con1.Close();
                }
            }
            return bloodgroup;


            
        }

        public DataTable Display()
        {
            DataTable dt = null;

            try
            {
                con1 = new SqlConnection(Con);
                cmd = new SqlCommand("GetDoners", con1);
                cmd.CommandType = CommandType.StoredProcedure;

                con1.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
            }
            catch (BloodBankExceptions) { throw; }

            finally
            {
                if (con1.State == ConnectionState.Open)
                {
                    con1.Close();
                }
            }
            return dt;
        }
        public DataTable GetCategories()
        {
            DataTable dt = null;
            try
            {
                con1 = new SqlConnection(Con);
                cmd = new SqlCommand("GetBGCategories", con1);
                cmd.CommandType = CommandType.StoredProcedure;

                con1.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
            }
            catch (SqlException ex)
            {
                throw new BloodBankExceptions(ex.Message);
            }
            catch (SystemException ex)
            {
                throw new BloodBankExceptions(ex.Message);
            }
            finally
            {
                if (con1.State == ConnectionState.Open)
                {
                    con1.Close();
                }
            }
            return dt;
        }

        public int VerifyBloodDonorID(string bloodDonorID)
        {
            int idFound = 0;
            try
            {
                con1 = new SqlConnection(Con);
                cmd = new SqlCommand("VerifyBloodDonorID", con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BDID", bloodDonorID);
                con1.Open();
                idFound = int.Parse(cmd.ExecuteScalar().ToString());
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
            finally
            {
                con1.Close();
            }
            return idFound;
        }




        public DataTable GetBloodDonorId()
        {//Load Hospital ID In Combo Box
            DataTable dt = null;
            try
            {
                con1 = new SqlConnection(Con);

                cmd = new SqlCommand("BBank.uspBloodDonerId", con1);

                cmd.CommandType = CommandType.StoredProcedure;

                con1.Open();
                SqlDataReader dr = cmd.ExecuteReader();
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
                if (con1.State == ConnectionState.Open)
                {
                    con1.Close();
                }
            }
            return dt;
        }

        public int AddDonation(BloodDonorDonations pboj)
        {

            int blooddonordonation = 0;
            try
            {
                //con = new SqlConnection();
                //con.ConnectionString = conStr; 
                con1 = new SqlConnection(Con);
                cmd = new SqlCommand();
                cmd.CommandText = "BBank.uspAddDonationwithInventory";
                cmd.Connection = con1;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@BloodDonationId", SqlDbType.Int);
                cmd.Parameters["@BloodDonationId"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@blooddonerid", pboj.BloodDonorID);
                cmd.Parameters.AddWithValue("@donationDate", pboj.BloodDonationDate);
                cmd.Parameters.AddWithValue("@noofbottle", pboj.NumberOfBottles);
                cmd.Parameters.AddWithValue("@wt", pboj.Weight);
                cmd.Parameters.AddWithValue("@hbc", pboj.HBCount);
                cmd.Parameters.AddWithValue("@BloodBankId", pboj.BloodBankId);
                cmd.Parameters.AddWithValue("@BloodGroup", pboj.BloodGroup);

                con1.Open();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                blooddonordonation = int.Parse(cmd.Parameters["@BloodDonationId"].Value.ToString());
            }
            catch (BloodBankExceptions) { throw; }
            catch (SqlException)
            {
                throw;
            }

            finally
            {
                if (con1.State == ConnectionState.Open)
                {
                    con1.Close();
                }
            }
            return blooddonordonation;






        }




        public DataTable DisplayDonations()
        {
            DataTable dt = null;

            try
            {
                con1 = new SqlConnection(Con);
                cmd = new SqlCommand("GetDonations", con1);
                cmd.CommandType = CommandType.StoredProcedure;

                con1.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
            }
            catch (BloodBankExceptions) { throw; }

            finally
            {
                if (con1.State == ConnectionState.Open)
                {
                    con1.Close();
                }
            }
            return dt;
        }














    }
}
