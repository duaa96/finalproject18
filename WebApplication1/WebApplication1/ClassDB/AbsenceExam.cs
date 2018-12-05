using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public class AbsenceExam
{
    private string Connectionstring = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();


    public int AddAbsenceExam(int StudentID,string Date,string Year,string Semester, int Subject1, string Date1, int Subject2, string Date2, int Subject3, string Date3, int Subject4, string Date4,  string Description, string Attachment1, string Attachment2, int DeanAccept,string DeanDescription, int ApplicationID)
    {
        string Query = "INSERT INTO AbsenceExam(StudentID ,Date , Year,Semester, Subject1 , Date1 , Subject2 ,  Date2 ,  Subject3 ,  Date3 ,  Subject4 , Date4, Description, Attachment1, Attachment2,DeanAccept,DeanDescription, ApplicationID )VALUES(@StudentID,@Date  ,@Year,@Semester,  @Subject1 , @Date1 , @Subject2 ,  @Date2 ,  @Subject3 ,  @Date3 ,  @Subject4 , @Date4,  @Description, @Attachment1, @Attachment2,@DeanAccept,@DeanDescription, @ApplicationID) ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@StudentID", StudentID);//This is Parameter
        Command.Parameters.AddWithValue("@Date", Date);//This is Parameter

        Command.Parameters.AddWithValue("@Subject1", Subject1);
        Command.Parameters.AddWithValue("@Date1", Date1);
        Command.Parameters.AddWithValue("@Year", Year);
        Command.Parameters.AddWithValue("@Semester", Semester);
        Command.Parameters.AddWithValue("@Subject2", Subject2);
        Command.Parameters.AddWithValue("@Date2", Date2);
        Command.Parameters.AddWithValue("@Subject3", Subject3);
        Command.Parameters.AddWithValue("@Date3", Date3);
        Command.Parameters.AddWithValue("@Subject4", Subject4);//This is Parameter
        Command.Parameters.AddWithValue("@Date4", Date4);
        
        Command.Parameters.AddWithValue("@Description", Description);
        Command.Parameters.AddWithValue("@Attachment1", Attachment1);
        Command.Parameters.AddWithValue("@Attachment2", Attachment2);
        Command.Parameters.AddWithValue("@DeanAccept", DeanAccept);
        Command.Parameters.AddWithValue("@DeanDescription", DeanDescription);

        Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }






    public int  UpdateAbsenceExam(int ID, int StudentID ,string Year, string Semester, string Date, int Subject1, string Date1, int Subject2, string Date2, int Subject3, string Date3, int Subject4, string Date4,  string Description, string Attachment1, string Attachment2, int ApplicationID)
    {
        string Query = "Update  AbsenceExam set StudentID = @StudentID,Year=@Year,Semester=@Semester,Date=@Date ,Subject1 = @Subject1  , Date1= @Date1 ,Subject2 = @Subject2 ,Date2 =@Date2,Subject3 = @Subject3  , Date3= @Date3 ,Subject4 = @Subject4 ,Date4 =@Date4 ,Description = @Description  , Attachment1= @Attachment1 ,Attachment2 = @Attachment2 ,ApplicationID =@ApplicationID where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.Parameters.AddWithValue("@StudentID", StudentID);//This is Parameter
        Command.Parameters.AddWithValue("@Year", Year);//This is Parameter
        Command.Parameters.AddWithValue("@Semester", Semester);//This is Parameter
        Command.Parameters.AddWithValue("@Date", Date);
        Command.Parameters.AddWithValue("@Subject1", Subject1);
        Command.Parameters.AddWithValue("@Date1", Date1);
        Command.Parameters.AddWithValue("@Subject2", Subject2);
        Command.Parameters.AddWithValue("@Date2", Date2);
        Command.Parameters.AddWithValue("@Subject3", Subject3);
        Command.Parameters.AddWithValue("@Date3", Date3);
        Command.Parameters.AddWithValue("@Subject4", Subject4);
        Command.Parameters.AddWithValue("@Date4", Date4);
       
        Command.Parameters.AddWithValue("@Description", Description);
        Command.Parameters.AddWithValue("@Attachment1", Attachment1);
        Command.Parameters.AddWithValue("@Attachment2 ", Attachment2);
        Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);


      int x=  Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }

    public void DeleteAbsenceExam(int ID)
    {
        string Query = "delete from  AbsenceExam where ID = @ID ";
        SqlConnection Connection = new SqlConnection(Connectionstring);
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        Command.ExecuteNonQuery();
        Connection.Close();
    }

    public int AcceptAbsenceExam(int ID,int DeanAccept, string DeanDescription)
    {
        string Query = "Update  AbsenceExam set DeanAccept = @DeanAccept,DeanDescription=@DeanDescription where ID = @ID ";
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

   

    public DataTable dtNotAcceptApsenceApplication()
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from AbsenceExam,Subjects where AbsenceExam.Subject1 =Subjects.SubjectID  and (DeanAccept = 0 OR DeanAccept IS null ) ", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;

    }


    public DataTable dtViewStudents(int ID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from AbsenceExam where StudentID= " + ID, Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }

    public int DeleteAbsenceExamSelected(int ID)
    {
        string Query = "delete from AbsenceExam where DeanAccept=0 and ID = " + ID;
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.CommandType = CommandType.Text;
        Command.Parameters.AddWithValue("@ID", ID);
        int x = Command.ExecuteNonQuery();
        Connection.Close();
        return x;
    }

    public DataTable dtgetform(int ID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from AbsenceExam where ID=" + ID, Connection);
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

    public DataTable dteditform(int ID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select * from AbsenceExam where DeanAccept=0 and ID=" + ID, Connection);
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

    public DataTable dtNotAcceptDeanAbsenceExamApplication(int CollegeID)
    {
        SqlConnection Connection = new SqlConnection(Connectionstring);
        Connection.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter DA = new SqlDataAdapter("select  Students.UniversityID as UniversityID , Students.StudentName as StudentName,Section.Name as SectionName ,AbsenceExam.Date as DateRequest ,AbsenceExam.ID  as IDFORM from Students,Section,AbsenceExam where Students.SectionID=Section.ID and Section.CollegeID="+ CollegeID+ " and Students.ID=AbsenceExam.StudentID and (AbsenceExam.DeanAccept = 0 OR AbsenceExam.DeanAccept IS null)", Connection);
        DA.Fill(dt);
        Connection.Close();
        return dt;
    }

}