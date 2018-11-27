using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class AlternativeSub
    {

        private string Connectionstring = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

        public int AddAlternativeSubject(int StudentID,string Date, string Year,string Semester, int Subject1ID, string Subject2Type, int NewSubject, string Description, int AcademicAdvisorAccept, int HeadAccept, int DeanAccept, int RegestrationAccept, int ApplicationID)
        {
            string Query = "INSERT INTO AlternativeSubject( StudentID ,Year,Semester, Subject1ID , Subject2Type ,NewSubject ,Description , AcademicAdvisorAccept ,  HeadAccept , DeanAccept,RegestrationAccept, ApplicationID )VALUES(@StudentID  , @Year,@Semester, @Subject1ID , @Subject2Type , @NewSubject ,  @Description ,  @AcademicAdvisorAccept ,  @HeadAccept, @DeanAccept,@RegestrationAccept, @ApplicationID ) ";
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@StudentID", StudentID);//This is Parameter
            Command.Parameters.AddWithValue("@Year", Year);//This is Parameter
            Command.Parameters.AddWithValue("@Semester", Semester);//This is Parameter
            Command.Parameters.AddWithValue("@Date", Date);//This is Parameter
            Command.Parameters.AddWithValue("@Subject1ID", Subject1ID);
            Command.Parameters.AddWithValue("@Subject2Type", Subject2Type);
            Command.Parameters.AddWithValue("@NewSubject", NewSubject);
            Command.Parameters.AddWithValue("@Description", Description);
            Command.Parameters.AddWithValue("@AcademicAdvisorAccept", AcademicAdvisorAccept);
            Command.Parameters.AddWithValue("@HeadAccept", HeadAccept);
            Command.Parameters.AddWithValue("@DeanAccept", DeanAccept);//This is Parameter
            Command.Parameters.AddWithValue("@RegestrationAccept", RegestrationAccept);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            int x = Command.ExecuteNonQuery();
            Connection.Close();
            return x;
        }




        public void UpdateAlternativeSubject(int ID, int StudentID, int Subject1ID, string Subject2Type, int NewSubject, string Description, int AcademicAdvisorAccept, int HeadAccept, int DeanAccept, int RegestrationAccept, int ApplicationID)
        {
            string Query = "Update  AlternativeSubject  set StudentID = @StudentID ,Subject1ID = @Subject1ID  , Subject2Type= @Subject2Type ,NewSubject = @NewSubject ,Description =@Description ,AcademicAdvisorAccept =@AcademicAdvisorAccept ,HeadAccept = @HeadAccept ,DeanAccept =@DeanAccept ,RegestrationAccept =@RegestrationAccept,ApplicationID =@ApplicationID where ID = @ID ";
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@ID", ID);
            Command.Parameters.AddWithValue("@StudentID", StudentID);
            Command.Parameters.AddWithValue("@Subject1ID", Subject1ID);//This is Parameter
            Command.Parameters.AddWithValue("@Subject2Type", Subject2Type);
            Command.Parameters.AddWithValue("@NewSubject", NewSubject);

            Command.Parameters.AddWithValue("@Description", Description);
            Command.Parameters.AddWithValue("@AcademicAdvisorAccept", AcademicAdvisorAccept);
            Command.Parameters.AddWithValue("@HeadAccept", HeadAccept);
            Command.Parameters.AddWithValue("@DeanAccept", DeanAccept);
            Command.Parameters.AddWithValue("@RegestrationAccept", RegestrationAccept);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.ExecuteNonQuery();
            Connection.Close();
        }
        public void DeleteAlternativeSubject(int ID)
        {
            string Query = "delete from  AlternativeSubject where ID = @ID ";
            SqlConnection Connection = new SqlConnection(Connectionstring);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@ID", ID);
            Command.ExecuteNonQuery();
            Connection.Close();
        }


        ///  Head get data Application
        public DataTable dtNotAcceptAliSubHeadApplication()
        {
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("select * from AlternativeSubject,Subjects where AlternativeSubject.Subject1ID =Subjects.SubjectID  and AcademicAdvisorAccept <> 0 AND AcademicAdvisorAccept IS NOT null and (HeadAccept=0 OR HeadAccept IS null)", Connection);
            DA.Fill(dt);
            Connection.Close();
            return dt;
        }


        public int AcceptHeadAltiSubj(int ID,int HeadAccept)
        {
            string Query = "Update  AlternativeSubject set HeadAccept =@HeadAccept where ID = @ID ";
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@ID", ID);
            Command.Parameters.AddWithValue("@HeadAccept", HeadAccept);
            int x = Command.ExecuteNonQuery();
            Connection.Close();
            return x;
        }

      

        // Regestration get data Application

        public DataTable dtNotAcceptAliSubRegApplication()
        {
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("select * from AlternativeSubject,Subjects where AlternativeSubject.Subject1ID =Subjects.SubjectID  and DeanAccept <> 0 AND DeanAccept IS NOT null and (RegestrationAccept=0 OR RegestrationAccept IS null)", Connection);
            DA.Fill(dt);
            Connection.Close();
            return dt;
        }


        public int AcceptRegAltiSubj(int ID, int RegestrationAccept)
        {
            string Query = "Update  AlternativeSubject set RegestrationAccept =@RegestrationAccept where ID = @ID ";
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@ID", ID);
            Command.Parameters.AddWithValue("@RegestrationAccept", RegestrationAccept);
            int x = Command.ExecuteNonQuery();
            Connection.Close();
            return x;
        }

        public int NotAcceptRegAltiSubj(int ID)
        {
            string Query = "Update  AlternativeSubject set RegestrationAccept =2 where ID = @ID ";
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@ID", ID);
            int x = Command.ExecuteNonQuery();
            Connection.Close();
            return x;
        }




        ///  AcademicAdvisor get data Application
        public DataTable dtNotAcceptAliSubAcademicAdvisorApplication()
        {
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("select * from AlternativeSubject,Subjects where AlternativeSubject.Subject1ID =Subjects.SubjectID  and (AcademicAdvisorAccept=0 OR AcademicAdvisorAccept IS null)", Connection);
            DA.Fill(dt);
            Connection.Close();
            return dt;
        }


        public int AcceptAcademicAdvisorAltiSubj(int ID, int AcademicAdvisorAccept)
        {
            string Query = "Update  AlternativeSubject set AcademicAdvisorAccept =@AcademicAdvisorAccept where ID = @ID ";
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@ID", ID);
            Command.Parameters.AddWithValue("@AcademicAdvisorAccept", AcademicAdvisorAccept);
            int x = Command.ExecuteNonQuery();
            Connection.Close();
            return x;
        }

        public int NotAcceptAcademicAdvisorAltiSubj(int ID)
        {
            string Query = "Update  AlternativeSubject set AcademicAdvisorAccept =2 where ID = @ID ";
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@ID", ID);
            int x = Command.ExecuteNonQuery();
            Connection.Close();
            return x;
        }



        //Dean get data Application
        public DataTable dtNotAcceptAliSubDeanApplication()
        {
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("select * from AlternativeSubject,Subjects where AlternativeSubject.Subject1ID =Subjects.SubjectID  and HeadAccept <> 0 AND HeadAccept IS NOT null and (DeanAccept=0 OR DeanAccept IS null)", Connection);
            DA.Fill(dt);
            Connection.Close();
            return dt;
        }

        public int AcceptDeanAltiSubj(int ID,int DeanAccept)
        {
            string Query = "Update  AlternativeSubject set DeanAccept =@DeanAccept where ID = @ID ";
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@ID", ID);
            Command.Parameters.AddWithValue("@DeanAccept", DeanAccept);
            int x = Command.ExecuteNonQuery();
            Connection.Close();
            return x;
        }

        



        public DataTable dtNotAcceptDeanAltSubApplication(int CollegeID)
        {
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("select  Students.UniversityID as UniversityID , Students.StudentName as StudentName,Section.Name as SectionName ,AlternativeSubject.Date as DateRequest ,AlternativeSubject.ID  as IDFORM from Students,Section,AlternativeSubject where Students.SectionID=Section.ID and Section.CollegeID="+ CollegeID + " and Students.ID=AlternativeSubject.StudentID and ((AlternativeSubject.HeadAccept <> 0 and AlternativeSubject.HeadAccept IS NOT null) and (AlternativeSubject.DeanAccept = 0 OR AlternativeSubject.DeanAccept IS null))", Connection);
            DA.Fill(dt);
            Connection.Close();
            return dt;
        }

        public DataTable dtNotAcceptHeadAltSubApplication(int SectionID)
        {
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("select  Students.UniversityID as UniversityID , Students.StudentName as StudentName,Section.Name as SectionName ,AlternativeSubject.Date as DateRequest ,AlternativeSubject.ID  as IDFORM from Students,Section,AlternativeSubject where Students.SectionID=Section.ID and Students.SectionID =" + SectionID + " and Students.ID=AlternativeSubject.StudentID and ((AlternativeSubject.AcademicAdvisorAccept <> 0 and AlternativeSubject.AcademicAdvisorAccept IS NOT null) and (AlternativeSubject.HeadAccept = 0 OR AlternativeSubject.HeadAccept IS null))", Connection);
            DA.Fill(dt);
            Connection.Close();
            return dt;
        }


        public DataTable dtNotAcceptHeadAltSubApplication()
        {
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("select  Students.UniversityID as UniversityID , Students.StudentName as StudentName,Section.Name as SectionName ,AlternativeSubject.Date as DateRequest ,AlternativeSubject.ID  as IDFORM from Students,Section,AlternativeSubject where Students.SectionID=Section.ID  and Students.ID=AlternativeSubject.StudentID and ((AlternativeSubject.DeanAccept <> 0 and AlternativeSubject.DeanAccept IS NOT null) and (AlternativeSubject.RegestrationAccept = 0 OR AlternativeSubject.RegestrationAccept IS null))", Connection);
            DA.Fill(dt);
            Connection.Close();
            return dt;
        }


        public DataTable dtgetform(int ID)
        {
            SqlConnection Connection = new SqlConnection(Connectionstring);
            Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("select * from AlternativeSubject where ID=" + ID, Connection);
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







}