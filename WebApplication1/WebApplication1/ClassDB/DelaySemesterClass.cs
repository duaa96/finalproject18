using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using WebApplication1;

public class DelaySemesterClass
{
    private string Connectionstring = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

    public int  AddDelaySemester(int StudentID,string NowYear, string NowSemester, string Year, string Semester, string Description, string Date, string RegestrationDescr,int RegestrationAccept, string RegestrationDate, string DeanDescription,int DeanAccept, string Decision, int ApplicationID)
    {
        string Query = "INSERT INTO DelaySemester(StudentID ,NowYear,NowSemester ,Year , Semester ,  Description ,  Date ,   RegestrationDescr , RegestrationAccept, RegestrationDate ,   DeanDescription ,DeanAccept, Decision, ApplicationID )VALUES(@StudentID ,@NowYear,@NowSemester,  @Year , @Semester , @Description ,  @Date ,  @RegestrationDescr ,@RegestrationAccept,  @RegestrationDate ,  @DeanDescription ,@DeanAccept, @Decision, @ApplicationID) ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@StudentID", StudentID);//This is Parameter
        Command.Parameters.AddWithValue("@NowYear", NowYear);//This is Parameter
        Command.Parameters.AddWithValue("@NowSemester", NowSemester);//This is Parameter
        Command.Parameters.AddWithValue("@Year", Year);
        Command.Parameters.AddWithValue("@Semester", Semester);
        Command.Parameters.AddWithValue("@Description", Description);
        Command.Parameters.AddWithValue("@Date", Date);
        Command.Parameters.AddWithValue("@RegestrationDescr", RegestrationDescr);
        Command.Parameters.AddWithValue("@RegestrationAccept", RegestrationAccept);

        Command.Parameters.AddWithValue("@RegestrationDate", RegestrationDate);

        Command.Parameters.AddWithValue("@DeanDescription", DeanDescription);
        Command.Parameters.AddWithValue("@DeanAccept", DeanAccept);

        Command.Parameters.AddWithValue("@Decision", Decision);
        Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);


        int x=Command.ExecuteNonQuery();
        Connection.Close();
        return x;

    }




    public int UpdateDelaySemester(int ID, int StudentID, string NowYear, string NowSemester, string Year, string Semester, string Description, string Date)

    {
        string Query = "Update  DelaySemester set  StudentID=@StudentID ,NowYear=@NowYear,NowSemester=@NowSemester,Year =@Year ,Semester=@Semester ,Description =@Description,Date=@Date where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.Parameters.AddWithValue("@StudentID", StudentID);//This is Parameter
        Command.Parameters.AddWithValue("@NowYear", NowYear);
        Command.Parameters.AddWithValue("@NowSemester", NowSemester);
        Command.Parameters.AddWithValue("@Year", Year);
        Command.Parameters.AddWithValue("@Semester", Semester);
        Command.Parameters.AddWithValue("@Description", Description);
        Command.Parameters.AddWithValue("@Date", Date);
      



       int x= Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }
    public void DeleteDelaySemester(int ID)
    {
        string Query = "delete from  DelaySemester where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.ExecuteNonQuery();
        Connection.Close();
    }
    public int DeleteDelaySemesterID(int ID)
    {
        string Query = "delete from  DelaySemester where ID = @ID and RegestrationAccept=0 ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        int x=Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }

    public DataTable dtNotAcceptDeanDelaySemesterApplication(int CollegeID)
    {
        NowTimeUniversity timee = new NowTimeUniversity();
        DataRow T = timee.drSearchYearANdSemester();
        string semester = T["NowSemester"].ToString();
        string Year = T["NowYear"].ToString();
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select  Students.UniversityID as UniversityID , Students.StudentName as StudentName,Section.Name as SectionName ,DelaySemester.Date as DateRequest ,DelaySemester.ID  as IDFORM from Students,Section,DelaySemester where Students.SectionID=Section.ID and Section.CollegeID="+ CollegeID + " and Students.ID=DelaySemester.StudentID and ((DelaySemester.RegestrationAccept <> 0 and DelaySemester.RegestrationAccept IS NOT null) and (DelaySemester.DeanAccept = 0 OR DelaySemester.DeanAccept IS null))and DelaySemester.NowYear=" + Year + " and DelaySemester.NowSemester=N" + "'" + semester + "'", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }

    public DataTable dtNotAcceptRegestDelaySemesterApplication()
    {
        NowTimeUniversity timee = new NowTimeUniversity();
        DataRow T = timee.drSearchYearANdSemester();
        string semester = T["NowSemester"].ToString();
        string Year = T["NowYear"].ToString();
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select  Students.UniversityID as UniversityID , Students.StudentName as StudentName,Section.Name as SectionName ,DelaySemester.Date as DateRequest ,DelaySemester.ID  as IDFORM from Students,Section,DelaySemester where Students.SectionID=Section.ID  and Students.ID=DelaySemester.StudentID and (DelaySemester.RegestrationAccept = 0 OR DelaySemester.RegestrationAccept IS null) and DelaySemester.NowYear=" + Year + " and DelaySemester.NowSemester=N" + "'" + semester + "'", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }
    public DataTable dtgetform(int ID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from DelaySemester where ID=" + ID, Connection);
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

    public DataTable dtEditgetform(int ID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from DelaySemester where (RegestrationAccept =0 OR RegestrationAccept IS null) and ID=" + ID, Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;

    }


    public DataRow drEditgetform(int ID)
    {
        DataRow dr;
        DataTable dt = dtEditgetform(ID);
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

    public DataTable dtgetformStudents(int ID)
    {
        NowTimeUniversity timee = new NowTimeUniversity();
        DataRow T = timee.drSearchYearANdSemester();
        string semester = T["NowSemester"].ToString();
        string Year = T["NowYear"].ToString();
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from DelaySemester where NowYear=" + Year + " and NowSemester=N" + "'" + semester + "'" +" and StudentID =" + ID, Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;

    }


    public DataRow drgetformStudents(int ID)
    {
        DataRow dr;
        DataTable dt = dtgetformStudents(ID);
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


    public int AcceptRegDelaySemester(int ID, int RegestrationAccept,string RegestrationDescr)
    {
        string Query = "Update  DelaySemester set RegestrationAccept =@RegestrationAccept,RegestrationDescr =@RegestrationDescr  where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();

        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.Parameters.AddWithValue("@RegestrationAccept", RegestrationAccept);
        Command.Parameters.AddWithValue("@RegestrationDescr", RegestrationDescr);
        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }
    public int AcceptDeanDelaySemester(int ID, int DeanAccept, string DeanDescription)
    {
        string Query = "Update  DelaySemester set DeanAccept =@DeanAccept,DeanDescription =@DeanDescription  where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();

        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.Parameters.AddWithValue("@DeanAccept", DeanAccept);
        Command.Parameters.AddWithValue("@DeanDescription", DeanDescription);
        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }
}