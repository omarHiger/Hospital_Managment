using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Patients_Info.Data
{
    class DBHandler      
    {
        static SqlConnection con;
        public static bool dbconnect()
        {
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["Patients"].ConnectionString;
                con = new SqlConnection(connectionString);
                con.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int exeChanges(string sql)
        {
            try
            {
                if (!dbconnect()) return -1;
                SqlCommand cmd = new SqlCommand(sql, con);
                return cmd.ExecuteNonQuery();
            }
            catch { return -1; }
            finally { if (con != null) con.Close(); }
        }

        public static DataTable exeQuery(string sql)
        {
            try
            {
                if (!dbconnect()) return null;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                return dt;
            }
            catch { return null; }
            finally { if (con != null) con.Close(); }
        }
        public static object exeOneValue(String sql)
        {
            try
            {
                if (!dbconnect()) return null;
                SqlCommand cmd = new SqlCommand(sql, con);
                return cmd.ExecuteScalar();
            }
            catch { return null; }
            finally { if (con != null) con.Close(); }
        }
    }



}
