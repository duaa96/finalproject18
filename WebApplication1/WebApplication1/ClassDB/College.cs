using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public class College
{
    private string Connectionstring = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

    public int AddCollege(string Name)
    {
        string Query = "INSERT INTO College(  Name )VALUES( @Name  ) ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@Name", Name);//This is Parameter


        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }



    public void UpdateCollege(int ID, string Name)
    {
        string Query = "Update  College set  Name =@Name   where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);

        Command.Parameters.AddWithValue("@Name", Name);



        Command.ExecuteNonQuery();
        Connection.Close();
    }
    public void DeleteCollege(int ID)
    {
        string Query = "delete from  College where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.ExecuteNonQuery();
        Connection.Close();
    }

    public DataTable dtSearchColloge(int ID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select CollegeID from Section where Section.ID=" + ID, Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;

    }


    public DataRow drSearchColloge(int ID)
    {
        DataRow dr;
        DataTable dt = dtSearchColloge(ID);
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
}