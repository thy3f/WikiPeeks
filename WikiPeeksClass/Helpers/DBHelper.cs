using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiPeeks.Helpers
{
    class DBHelper
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
                        wikiEntry.Day = Convert.ToInt32(rdr["ID"]);
                        wikiEntry.Month = Convert.ToInt32(rdr["ID"]);
                        wikiEntry.Year = Convert.ToInt32(rdr["ID"]);
                        wikiEntry.Description = Convert.ToString(rdr["ID"]);
                        wikiEntry.Category = Convert.ToString(rdr["ID"]);
                        wikiEntry.DateAdded = Convert.ToDateTime(rdr["ID"]);
                    }
                    con.Close();
                }
                return lstWikiEntries;
            }
            catch
            {
                throw;
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
                        wikiEntry.Day = Convert.ToInt32(rdr["ID"]);
                        wikiEntry.Month = Convert.ToInt32(rdr["ID"]);
                        wikiEntry.Year = Convert.ToInt32(rdr["ID"]);
                        wikiEntry.Description = Convert.ToString(rdr["ID"]);
                        wikiEntry.Category = Convert.ToString(rdr["ID"]);
                        wikiEntry.DateAdded = Convert.ToDateTime(rdr["ID"]);
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
                    cmd.Parameters.AddWithValue("@EmpId", id);
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

        public static void WriteToDB(List<string> list)
        {
            try
            {
                for (int i = 1; i < list.Count; i++)
                {
                    WikiEntry wikiEntry = new WikiEntry();
                    wikiEntry.Day = DateHelper.dayToInt();
                    wikiEntry.Month = DateHelper.monthToInt();
                    var temp = list[i];
                    var first = temp.IndexOf('|');
                    var last = temp.LastIndexOf('|');
                    var year = temp.Substring(first + 1, last - first - 1).Trim();
                    wikiEntry.Year = Int32.Parse(year);
                    wikiEntry.Description = list[i].Substring(last + 1, list[i].Length - last - 1).Trim();
                    wikiEntry.Category = list[i].Substring(0, first - 1).Trim();
                    wikiEntry.DateAdded = DateTime.Now;

                    DBHelper dbHelper = new DBHelper();
                    dbHelper.AddWikiEntry(wikiEntry);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error while inserting in DB {ex.Message}");
            }
        }
    }
}