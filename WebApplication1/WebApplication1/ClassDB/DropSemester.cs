using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public class DropSemester
{
    private string Connectionstring = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();


    public int AddDropSemester(int StudentID,string Year,string Semester,string Description,int NumofHourReg, string Date, string AcademicAdvisor_Descr, int AcademicAdvisorAccept, string HeadDescription, int HeadAccept, string DeanDescription, int DeanAccept, string DeputyAcademic_Descr, int DeputyAcademicAccept,int RegestrationAccept, string RegestrationDescr, int ApplicationID)
    {
        string Query = "INSERT INTO DropSemester (  StudentID,Year,Semester,Description,NumofHourReg, Date, AcademicAdvisor_Descr, AcademicAdvisorAccept, HeadDescription, HeadAccept, DeanDescription, DeanAccept, DeputyAcademic_Descr, DeputyAcademicAccept, RegestrationAccept,RegestrationDescr, ApplicationID) VALUES( @StudentID,@Year,@Semester,@Description,@NumofHourReg ,@Date,@AcademicAdvisor_Descr, @AcademicAdvisorAccept, @HeadDescription, @HeadAccept, @DeanDescription, @DeanAccept, @DeputyAcademic_Descr, @DeputyAcademicAccept,@RegestrationAccept ,@RegestrationDescr, @ApplicationID  ) ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@StudentID", StudentID);//This is Parameter
        Command.Parameters.AddWithValue("@Year", Year);//This is Parameter
        Command.Parameters.AddWithValue("@Semester", Semester);//This is Parameter
        Command.Parameters.AddWithValue("@NumofHourReg", NumofHourReg);//This is Parameter

        Command.Parameters.AddWithValue("@Date", Date);//This is Parameter
        Command.Parameters.AddWithValue("@Description", Description);//This is Parameter
        Command.Parameters.AddWithValue("@AcademicAdvisor_Descr", AcademicAdvisor_Descr);//This is Parameter
        Command.Parameters.AddWithValue("@AcademicAdvisorAccept", AcademicAdvisorAccept);//This is Parameter
        Command.Parameters.AddWithValue("@HeadDescription", HeadDescription);//This is Parameter
        Command.Parameters.AddWithValue("@HeadAccept", HeadAccept);//This is Parameter
        Command.Parameters.AddWithValue("@DeanDescription", DeanDescription);//This is Parameter
        Command.Parameters.AddWithValue("@DeanAccept", DeanAccept);//This is Parameter
        Command.Parameters.AddWithValue("@DeputyAcademic_Descr", DeputyAcademic_Descr);//This is Parameter
        Command.Parameters.AddWithValue("@DeputyAcademicAccept", DeputyAcademicAccept);//This is Parameter
        Command.Parameters.AddWithValue("@RegestrationDescr", RegestrationDescr);//This is Parameter
        Command.Parameters.AddWithValue("@RegestrationAccept", RegestrationAccept);//This is Parameter

        Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);//This is Parameter

        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }
    public int  UpdateDropSemester(int ID, int StudentID,string Year, string Semester, string Description,int NumofHourReg, string Date, string AcademicAdvisor_Descr, int AcademicAdvisorAccept, string HeadDescription, int HeadAccept, string DeanDescription, int DeanAccept, string DeputyAcademic_Descr, int DeputyAcademicAccept, int RegestrationAccept, string RegestrationDescr, int ApplicationID)
    {
        string Query = "Update  DropSemester set  StudentID =@StudentID,Year=@Year,Semester=@Semester,Description=@Description,NumofHourReg=@NumofHourReg, Date=@Date,AcademicAdvisor_Descr=@AcademicAdvisor_Descr,AcademicAdvisorAccept=@AcademicAdvisorAccept,HeadDescription=@HeadDescription,HeadAccept=@HeadAccept,DeanDescription=@DeanDescription,DeanAccept=@DeanAccept, DeputyAcademic_Descr=@DeputyAcademic_Descr,DeputyAcademicAccept=@DeputyAcademicAccept,RegestrationAccept=@RegestrationAccept,RegestrationDescr=@RegestrationDescr,ApplicationID=@ApplicationID where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.Parameters.AddWithValue("@StudentID", StudentID);//This is Parameter
        Command.Parameters.AddWithValue("@Year", Year);//This is Parameter
        Command.Parameters.AddWithValue("@Semester", Semester);//This is Parameter
        Command.Parameters.AddWithValue("@Description", Description);//This is Parameter
        Command.Parameters.AddWithValue("@NumofHourReg", NumofHourReg);//This is Parameter
        Command.Parameters.AddWithValue("@Date", Date);//This is Parameter

        Command.Parameters.AddWithValue("@AcademicAdvisor_Descr", AcademicAdvisor_Descr);//This is Parameter
        Command.Parameters.AddWithValue("@AcademicAdvisorAccept", AcademicAdvisorAccept);//This is Parameter
        Command.Parameters.AddWithValue("@HeadDescription", HeadDescription);//This is Parameter
        Command.Parameters.AddWithValue("@HeadAccept", HeadAccept);//This is Parameter
        Command.Parameters.AddWithValue("@DeanDescription", DeanDescription);//This is Parameter
        Command.Parameters.AddWithValue("@DeanAccept", DeanAccept);//This is Parameter
        Command.Parameters.AddWithValue("@DeputyAcademic_Descr", DeputyAcademic_Descr);//This is Parameter
        Command.Parameters.AddWithValue("@DeputyAcademicAccept", DeputyAcademicAccept);//This is Parameter
        Command.Parameters.AddWithValue("@RegestrationDescr", RegestrationDescr);//This is Parameter
        Command.Parameters.AddWithValue("@RegestrationAccept", RegestrationAccept);//This is Parameter

        Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);//This is Parameter



       int x= Command.ExecuteNonQuery();
        Connection.Close();
            return x;
    }
    public void DeleteDropSemester(int ID)
    {
        string Query = "delete from  DropSemester where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.ExecuteNonQuery();
        Connection.Close();
    }

    // Head get data Application
    public DataTable dtNotAcceptDropSemesterHeadApplication()
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from DropSemester where  AcademicAdvisorAccept <> 0 AND AcademicAdvisorAccept IS NOT null AND (HeadAccept = 0 OR HeadAccept IS null)", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }


    public int AcceptHeadDropSemester(int ID,int HeadAccept, string HeadDescription)
    {
        string Query = "Update  DropSemester set HeadAccept =@HeadAccept,HeadDescription=@HeadDescription where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();

        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.Parameters.AddWithValue("@HeadAccept", HeadAccept);
        Command.Parameters.AddWithValue("@HeadDescription", HeadDescription);
        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }

   

    //Regestration GetData Application 
    public DataTable dtNotAcceptDropSemesterRegApplication()
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from DropSemester where  DeputyAcademicAccept <> 0 AND DeputyAcademicAccept IS NOT null AND (RegestrationDescr = 0 OR RegestrationDescr IS null)", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }


    public int AcceptRegDropSemester(int ID,int RegestrationAccept, string RegestrationDescr)
    {
        string Query = "Update  DropSemester set RegestrationAccept =@RegestrationAccept,RegestrationDescr=@RegestrationDescr where ID = @ID ";
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

   



    //DeputyAcademic GetData Application 
    public DataTable dtNotAcceptDropSemesterDeputyAcademicApplication()
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from DropSemester where  DeanAccept <> 0 AND DeanAccept IS NOT null AND (DeputyAcademicAccept = 0 OR DeputyAcademicAccept IS null)", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }


    public int AcceptDeputyAcademicDropSemester(int ID,int DeputyAcademicAccept, string DeputyAcademic_Descr)
    {
        string Query = "Update  DropSemester set DeputyAcademicAccept =@DeputyAcademicAccept,DeputyAcademic_Descr=@DeputyAcademic_Descr where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();

        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.Parameters.AddWithValue("@DeputyAcademicAccept", DeputyAcademicAccept);
        Command.Parameters.AddWithValue("@DeputyAcademic_Descr", DeputyAcademic_Descr);
        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }

    




    //AcademicAdvisorAccept GetData Application 
    public DataTable dtNotAcceptDropSemesterAcademicAdvisorApplication(int ID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select  Students.UniversityID as UniversityID , Students.StudentName as StudentName,Section.Name as SectionName ,DropSemester.Date as DateRequest ,DropSemester.ID  as IDFORM from Students,Section,DropSemester where Students.ID=DropSemester.StudentID and Students.SectionID = Section.ID and Students.AcademicAdvisorID=" + ID+ " and (DropSemester.AcademicAdvisorAccept = 0 OR DropSemester.AcademicAdvisorAccept IS null)", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }


    public int AcceptAcademicAdvisorDropSemester(int ID,int AcademicAdvisorAccept,string AcademicAdvisor_Descr)
    {
        string Query = "Update  DropSemester set AcademicAdvisorAccept =@AcademicAdvisorAccept,AcademicAdvisor_Descr=@AcademicAdvisor_Descr where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();

        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.Parameters.AddWithValue("@AcademicAdvisorAccept", AcademicAdvisorAccept);
        Command.Parameters.AddWithValue("@AcademicAdvisor_Descr", AcademicAdvisor_Descr);
        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }

   



    //Dean get Data Application
    public DataTable dtNotAcceptDropSemesterDeanApplication()
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from DropSemester where  HeadAccept<>0 and HeadAccept IS not Null and (DeanAccept = 0 OR DeanAccept IS null)", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }

    public int AcceptDeanDropSemester(int ID,int DeanAccept, string DeanDescription)
    {
        string Query = "Update  DropSemester set DeanAccept =@DeanAccept,DeanDescription=@DeanDescription where ID = @ID ";
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

   

    public DataTable dtViewStudents(int ID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from DropSemester where StudentID= " + ID, Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;



    }
    public int DeleteDreopSemesterSelected(int ID)
    {
        string Query = "delete from DropSemester where RegestrationAccept=0 and ID = " + ID;
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }



    public DataTable dteditform(int ID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from DropSemester where AcademicAdvisorAccept=0 and ID=" + ID, Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;

    }


    public DataRow dreditform(int ID)
    {
        DataRow dr;
        DataTable dt = dteditform(ID);
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

    public DataTable dtgetform(int ID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from DropSemester where ID=" + ID, Connection);
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


    public DataTable dtNotAcceptDeanDropSemesterApplication(int CollegeID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select  Students.UniversityID as UniversityID , Students.StudentName as StudentName,Section.Name as SectionName ,DropSemester.Date as DateRequest ,DropSemester.ID  as IDFORM from Students,Section,DropSemester where Students.SectionID=Section.ID and Section.CollegeID="+ CollegeID + " and Students.ID=DropSemester.StudentID and ((DropSemester.HeadAccept <> 0 and DropSemester.HeadAccept IS NOT null) and (DropSemester.DeanAccept = 0 OR DropSemester.DeanAccept IS null))", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }

    public DataTable dtNotAcceptHeadDropSemesterApplication(int SectionID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select  Students.UniversityID as UniversityID , Students.StudentName as StudentName,Section.Name as SectionName ,DropSemester.Date as DateRequest ,DropSemester.ID  as IDFORM from Students,Section,DropSemester where Students.SectionID=Section.ID and Students.SectionID=" + SectionID + " and Students.ID=DropSemester.StudentID and ((DropSemester.AcademicAdvisorAccept <> 0 and DropSemester.AcademicAdvisorAccept IS NOT null) and (DropSemester.HeadAccept = 0 OR DropSemester.HeadAccept IS null))", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }

    public DataTable dtNotAcceptRegDropSemesterApplication()
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select  Students.UniversityID as UniversityID , Students.StudentName as StudentName,Section.Name as SectionName ,DropSemester.Date as DateRequest ,DropSemester.ID  as IDFORM from Students,Section,DropSemester where Students.SectionID=Section.ID  and Students.ID=DropSemester.StudentID and ((DropSemester.DeputyAcademicAccept <> 0 and DropSemester.DeputyAcademicAccept IS NOT null) and (DropSemester.RegestrationAccept = 0 OR DropSemester.RegestrationAccept IS null))", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }

    public DataTable dtNotAcceptDeputyAcademicAcceptDropSemesterApplication()
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select  Students.UniversityID as UniversityID , Students.StudentName as StudentName,Section.Name as SectionName ,DropSemester.Date as DateRequest ,DropSemester.ID  as IDFORM from Students,Section,DropSemester where Students.SectionID=Section.ID  and Students.ID=DropSemester.StudentID and ((DropSemester.DeanAccept <> 0 and DropSemester.DeanAccept IS NOT null) and (DropSemester.DeputyAcademicAccept = 0 OR DropSemester.DeputyAcademicAccept IS null))", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }
    
    }

