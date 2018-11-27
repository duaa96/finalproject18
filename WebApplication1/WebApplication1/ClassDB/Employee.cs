using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public class Employee
{
    private string Connectionstring = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();


    public int AddEmployee(string EmployeeName, string password, int EmployeeID, string Signature, string mager, int SectionID, string Phone)
    {
        string Query = "INSERT INTO Employees(EmployeeName,password,EmployeeID,Signature,mager,SectionID,Phone)VALUES(@EmployeeName,@password,@EmployeeID,@Signature,@mager,@SectionID,@Phone) ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@EmployeeName", EmployeeName);//This is Parameter
        Command.Parameters.AddWithValue("@password", password);
        Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
        Command.Parameters.AddWithValue("@Signature", Signature);
        Command.Parameters.AddWithValue("@mager", mager);
        Command.Parameters.AddWithValue("@SectionID", SectionID);
        Command.Parameters.AddWithValue("@Phone", Phone);
        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }

    public void UpdateEmployees(int ID, string EmployeeName, string password, int EmployeeID, string Signature, string mager, int SectionID, string Phone)
    {
        string Query = "Update  Employee set EmployeeName = @EmployeeName ,password = @password  , EmployeeID= @EmployeeID ,Signature = @Signature ,mager =@mager ,SectionID =@SectionID,Phone =@Phone where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.Parameters.AddWithValue("@EmployeeName", EmployeeName);
        Command.Parameters.AddWithValue("@password", password);//This is Parameter
        Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
        Command.Parameters.AddWithValue("@Signature", Signature);

        Command.Parameters.AddWithValue("@mager", mager);
        Command.Parameters.AddWithValue("@SectionID", SectionID);
        Command.Parameters.AddWithValue("@Phone", Phone);
        Command.ExecuteNonQuery();
        Connection.Close();
    }
    public void DeleteEmployees(int ID)
    {
        string Query = "delete from  Employee where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.ExecuteNonQuery();
        Connection.Close();
    }

    public DataTable dtSearchEmployeeLogin(int username, string Password)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from Employees where EmployeeID='" + username + "' and password='" + Password + "'", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;

    }


    public DataRow drSearchEmployeeLogin(int username, string Password)
    {
        DataRow dr;
        DataTable dt = dtSearchEmployeeLogin(username, Password);
        if (dt.Rows.Count > 0)
        {

            dr = dt.Rows[0];
        }
        else
        {
            dr = null;
        }
        return dr;

    }

    public DataTable dtSearchEmployeeSection(int ID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from Employees where ID="+ID, Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;

    }


    public DataRow drSearchEmployeeSection(int ID)
    {
        DataRow dr;
        DataTable dt = dtSearchEmployeeSection(ID);
        if (dt!=null)
        {

            dr = dt.Rows[0];
        }
        else
        {
            dr = null;
        }
        return dr;

    }
    public DataTable dtSearchEmployeeEmail(int ID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select Email from Employees Where Employees.ID =" + ID + "", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;

    }


    public DataRow drSearchEmployeeEmail(int ID)
    {
        DataRow dr;
        DataTable dt = dtSearchEmployeeEmail(ID);
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