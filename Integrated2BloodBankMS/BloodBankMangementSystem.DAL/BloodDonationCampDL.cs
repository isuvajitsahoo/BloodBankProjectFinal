using BloodBankMangementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BloodBankMangementSystem.DAL
{
    public class BloodDonationCampDL
    {

        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;

        static BloodDonationCampDL()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }

        public BloodDonationCampDL()
        {
            con = new SqlConnection(conStr);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool ArrangeCampDAL(BloodDonationCamp arrange)
        {
            bool arrangeCamp = false;
            try
            {

                cmd = new SqlCommand();
                cmd.CommandText = "BBank.ArrangeCamp";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BloodDonationCampId", arrange.BloodDonationCampId);
                cmd.Parameters.AddWithValue("@CampName", arrange.CampName);
                cmd.Parameters.AddWithValue("@Address", arrange.Address);
                cmd.Parameters.AddWithValue("@City", arrange.City);
                cmd.Parameters.AddWithValue("@BloodBankId", arrange.BloodBankId);
                cmd.Parameters.AddWithValue("@CampStartDate", arrange.CampStartDate);
                cmd.Parameters.AddWithValue("@CampEndDate", arrange.CampEndDate);


                con.Open();
                int noOfRowsAffected = cmd.ExecuteNonQuery();

                if (noOfRowsAffected == 1)
                {
                    arrangeCamp = true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid entries.");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return arrangeCamp;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool ModifyCampDAL(BloodDonationCamp modify)
        {
            bool result = false;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "BBank.ModifyCamp";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BloodDonationCampId", modify.BloodDonationCampId);
                cmd.Parameters.AddWithValue("@CampName", modify.CampName);
                cmd.Parameters.AddWithValue("@Address", modify.Address);
                cmd.Parameters.AddWithValue("@City", modify.City);
                cmd.Parameters.AddWithValue("@CampStartDate", modify.CampStartDate);
                cmd.Parameters.AddWithValue("@CampEndDate", modify.CampEndDate);

                con.Open();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected == 1)
                {
                    result = true;
                }
            }
            catch
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

        public bool DeleteCampDAL(string bloodDonationCampID)
        {
            bool result = false;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "BBank.DeleteCamp";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BloodDonationCampId", bloodDonationCampID);

                con.Open();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected == 1)
                {
                    result = true;
                }
            }
            catch
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

        public BloodDonationCamp SearchCampDAL(string bloodDonationCampID)
        {
            BloodDonationCamp p = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "BBank.SearchCamp";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BloodDonationCampId", bloodDonationCampID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    p = new BloodDonationCamp
                    {
                        BloodDonationCampId = dr["BloodDonationCampId"].ToString(),
                        CampName = dr["CampName"].ToString(),
                        Address = dr["Address"].ToString(),
                        City = dr["City"].ToString(),
                        BloodBankId = dr["BloodBankId"].ToString(),
                        CampStartDate = DateTime.Parse(dr["CampStartDate"].ToString()),
                        CampEndDate = DateTime.Parse(dr["CampEndDate"].ToString())
                    };
                    dr.Close();
                }
            }
            catch
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

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public DataTable ViewCampDetailsDAL()
        {
            DataTable dt = null;

            try
            {

                cmd = new SqlCommand();
                cmd.CommandText = "select * from BBank.BloodDonationCamp";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
            }
            catch
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

        public int VerifyBloodDonationCampID(string bloodDonationId)
        {
            int idFound = 0;
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand("VerifyBloodDonationCampId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BloodDonationCampId", bloodDonationId);
                con.Open();
                idFound = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (SqlException)
            {
                MessageBox.Show("Id is null.");
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return idFound;

        }
    }
}
