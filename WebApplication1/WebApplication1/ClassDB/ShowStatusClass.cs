using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public class ShowStatusClass
{
    private string Connectionstring = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

    public int AddShowStatus(int StudentID, string Year, string semester, string Date, string Description, string HeadDescription, int HeadAccept, string HeadDate, string DeanDescription, int DeanAccept, string DeanDate, int ApplicationID)
    {
        string Query = "INSERT INTO ShowStatus( StudentID, Year  ,  semester , Date ,Description,HeadDescription,  HeadAccept, HeadDate , DeanDescription, DeanAccept, DeanDate,ApplicationID)VALUES(@StudentID,@Year,@semester,@Date ,@Description,@HeadDescription,@HeadAccept,@HeadDate ,@DeanDescription,@DeanAccept,@DeanDate, @ApplicationID) ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@StudentID", StudentID);//This is Parameter
        Command.Parameters.AddWithValue("@Year", Year);
        Command.Parameters.AddWithValue("@semester", semester);
        Command.Parameters.AddWithValue("@Date", Date);
        Command.Parameters.AddWithValue("@Description", Description);
        Command.Parameters.AddWithValue("@HeadDescription", HeadDescription);
        Command.Parameters.AddWithValue("@HeadAccept", HeadAccept);
        Command.Parameters.AddWithValue("@HeadDate", HeadDate);
        Command.Parameters.AddWithValue("@DeanDescription", DeanDescription);
        Command.Parameters.AddWithValue("@DeanAccept", DeanAccept);
        Command.Parameters.AddWithValue("@DeanDate", DeanDate);
        Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

       int x= Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }


    public void UpdateShowStatus(int ID, int StudentID, string Year, string semester, string Date, string Description, string HeadDescription, int HeadAccept, string HeadDate, string DeanDescription, int DeanAccept, string DeanDate, int ApplicationID)
    {
        string Query = "Update ShowStatus set StudentID=@StudentID, Year=@Year  ,  semester=@semester , Date=@Date ,Description=@Description,HeadDescription=@HeadDescription,  HeadAccept=@HeadAccept, HeadDate=@HeadDate , DeanDescription=@DeanDescription, DeanAccept=@DeanAccept, DeanDate=@DeanDate,ApplicationID=@ApplicationID where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);

        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);//This is Parameter
        Command.Parameters.AddWithValue("@StudentID", StudentID);//This is Parameter
        Command.Parameters.AddWithValue("@Year", Year);
        Command.Parameters.AddWithValue("@semester", semester);
        Command.Parameters.AddWithValue("@Date", Date);
        Command.Parameters.AddWithValue("@Description", Description);
        Command.Parameters.AddWithValue("@HeadAccept", HeadAccept);
        Command.Parameters.AddWithValue("@HeadDate", HeadDate);
        Command.Parameters.AddWithValue("@DeanDescription", DeanDescription);
        Command.Parameters.AddWithValue("@DeanAccept", DeanAccept);
        Command.Parameters.AddWithValue("@DeanDate", DeanDate);
        Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

        Command.ExecuteNonQuery();
        Connection.Close();
    }


    public void DeleteShowStatus(int ID)
    {
        string Query = "delete from ShowStatus where ID = @ID  ";
        SqlConnection Connection = new SqlConnection(Connectionstring);

        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.ExecuteNonQuery();
        Connection.Close();
    }

    // Head GetData Application
    public DataTable dtNotShowStatusHeadApplication()
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from ShowStatus where HeadAccept=0 OR HeadAccept IS null", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }
    public int AcceptHeadShowStatus(int ID)
    {
        string Query = "Update  ShowStatus set HeadAccept =1 where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();

        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }

    public int NotAcceptHeadShowStatus(int ID)
    {
        string Query = "Update  ShowStatus set HeadAccept =2 where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }

    //Dean GetData Application
    public DataTable dtNotAcceptDeanShowStatusApplication( int CollegeID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select  Students.UniversityID as UniversityID , Students.StudentName as StudentName,Section.Name as SectionName ,ShowStatus.Date as DateRequest ,ShowStatus.ID  as IDFORM from Students,Section,ShowStatus where Students.SectionID=Section.ID and Section.CollegeID="+ CollegeID + " and Students.ID=ShowStatus.StudentID and(( ShowStatus.HeadAccept<>0 and ShowStatus.HeadAccept IS not null) and (ShowStatus.DeanAccept = 0 OR ShowStatus.DeanAccept IS null))", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }

    public int AcceptDeanShowStatus(int ID)
    {
        string Query = "Update  ShowStatus set DeanAccept =1 where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();

        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }

    public int NotAcceptDeanShowStatus(int ID)
    {
        string Query = "Update  ShowStatus set DeanAccept =2 where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }


    public DataTable dtNotAcceptHeadShowStatusApplication(int SectionID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select  Students.UniversityID as UniversityID , Students.StudentName as StudentName,Section.Name as SectionName ,ShowStatus.Date as DateRequest ,ShowStatus.ID  as IDFORM from Students,Section,ShowStatus where Students.SectionID="+SectionID+ " and Section.ID=Students.SectionID and Students.ID=ShowStatus.StudentID and(ShowStatus.HeadAccept = 0 OR ShowStatus.HeadAccept IS null)", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }

    public DataTable dtgetform(int ID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from ShowStatus where ID=" + ID, Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;

    }


    public DataRow drgetform(int ID)
    {
        DataRow dr;
        DataTable dt = dtgetform(ID);
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
}