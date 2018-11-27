using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class NowTimeUniversity
    {
        private string Connectionstring = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

        public DataRow drSearchYearANdSemester()
        {
            DataRow dr;
            DataTable dt = dtSearchYearAndSemester();
            if (dt != null)
            {

                dr = dt.Rows[0];
            }
            else
            {
                dr = null;
            }
            return dr;

        }



        public DataTable dtSearchYearAndSemester()
        {
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("select* from Time ", Connection);
            DA.Fill(dt);
            Connection.Close();
            return dt;

        }
        public int UpdateTime( int NowYear, string NowSemester)
        {
            int ID = 1;
            string Query = "Update  Time set NowYear = @NowYear,NowSemester=@NowSemester where ID = @ID ";
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@ID", ID);
            Command.Parameters.AddWithValue("@NowYear", NowYear);//This is Parameter
            Command.Parameters.AddWithValue("@NowSemester", NowSemester);

            int x = Command.ExecuteNonQuery();
            Connection.Close();
            return x;
        }
    }
}