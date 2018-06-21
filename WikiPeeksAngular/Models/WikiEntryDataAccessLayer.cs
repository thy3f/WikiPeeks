using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiPeeksAngular.Models
{
    class WikiEntryDataAccessLayer
    {
        string connectionString = "Data Source=DESKTOP-9NV5BD3\\SQLEXPRESS2012;Initial Catalog=localTest;User ID=sa;Password=12345678";

        public IEnumerable<WikiEntry> GetAllWikiEntries()
        {
            try
            {
                List<WikiEntry> lstWikiEntries = new List<WikiEntry>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllWikiEntries", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        WikiEntry wikiEntry = new WikiEntry();
                        wikiEntry.ID = Convert.ToInt32(rdr["ID"]);
                        wikiEntry.Day = Convert.ToInt32(rdr["Day"]);
                        wikiEntry.Month = Convert.ToInt32(rdr["Month"]);
                        wikiEntry.Year = Convert.ToInt32(rdr["Year"]);
                        wikiEntry.Description = Convert.ToString(rdr["Description"]);
                        wikiEntry.Category = Convert.ToString(rdr["Category"]);
                        wikiEntry.DateAdded = Convert.ToDateTime(rdr["DateAdded"]);
                        lstWikiEntries.Add(wikiEntry);
                    }
                    con.Close();
                }
                return lstWikiEntries;
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
        //To Add new employee record 
        public int AddWikiEntry(WikiEntry wikiEntry)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddWikiEntry", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Day", wikiEntry.Day);
                    cmd.Parameters.AddWithValue("@Month", wikiEntry.Month);
                    cmd.Parameters.AddWithValue("@Year", wikiEntry.Year);
                    cmd.Parameters.AddWithValue("@Description", wikiEntry.Description);
                    cmd.Parameters.AddWithValue("@Category", wikiEntry.Category);
                    cmd.Parameters.AddWithValue("@DateAdded", wikiEntry.DateAdded);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar employee
        public int UpdateWikiEntry(WikiEntry wikiEntry)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateWikiEntry", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Day", wikiEntry.Day);
                    cmd.Parameters.AddWithValue("@Month", wikiEntry.Month);
                    cmd.Parameters.AddWithValue("@Year", wikiEntry.Year);
                    cmd.Parameters.AddWithValue("@Description", wikiEntry.Description);
                    cmd.Parameters.AddWithValue("@Category", wikiEntry.Category);
                    cmd.Parameters.AddWithValue("@DateAdded", wikiEntry.DateAdded);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular employee
        public WikiEntry GetWikiEntryData(int id)
        {
            try
            {
                WikiEntry wikiEntry = new WikiEntry();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        wikiEntry.ID = Convert.ToInt32(rdr["ID"]);
                        wikiEntry.Day = Convert.ToInt32(rdr["Day"]);
                        wikiEntry.Month = Convert.ToInt32(rdr["Month"]);
                        wikiEntry.Year = Convert.ToInt32(rdr["Year"]);
                        wikiEntry.Description = Convert.ToString(rdr["Description"]);
                        wikiEntry.Category = Convert.ToString(rdr["Category"]);
                        wikiEntry.DateAdded = Convert.ToDateTime(rdr["DateAdded"]);
                    }
                }
                return wikiEntry;
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record on a particular employee
        public int DeleteWikiEntry(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteWikiEntry", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}