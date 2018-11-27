﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public class Position
{
    private string Connectionstring = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

    public int AddPosition(string Position)
    {
        string Query = "INSERT INTO Employees(  Position )VALUES( @Position  ) ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@Position", Position);//This is Parameter


        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }




    public void UpdatePosition(int ID, string Position)
    {
        string Query = "Update  Position set  Position =@Position   where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);

        Command.Parameters.AddWithValue("@Position", Position);



        Command.ExecuteNonQuery();
        Connection.Close();
    }
    public void DeletePosition(int ID)
    {
        string Query = "delete from  Position where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.ExecuteNonQuery();
        Connection.Close();
    }


    public DataTable dtSearchEmployeePosition(int ID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from EmployeePosition where EmployeeID=" + ID + " and Position <> 4", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;

    }


    public DataRow drSearchEmployeePosition(int ID)
    {
        DataRow dr;
        DataTable dt = dtSearchEmployeePosition(ID);
        if (dt !=null)
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