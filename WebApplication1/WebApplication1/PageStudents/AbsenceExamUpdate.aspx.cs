using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class AbsenceExamUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Session["ID"].ToString());
                fillddl();

                fillData();

            }

            else
            {
            }
        }
        private void fillData()
        {

            AbsenceExam obj = new AbsenceExam();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataRow dr = obj.drgetform(id);

            if (dr != null)
            {
                int STUid = Convert.ToInt32(dr["StudentID"].ToString());
                Studnets objStu = new Studnets();
                DataRow Stu = objStu.drSearchStudent(STUid);
                if (Stu != null)
                {
                    labStudentName.Text = Stu["StudentName"].ToString();
                    labNumberStudent.Text = Stu["UniversityID"].ToString();
                    labSectionStudent.Text = Stu["SectionName"].ToString();
                    labCollage.Text = Stu["CollageName"].ToString();

                }

                labDate.Text = DateTime.UtcNow.ToString("yyyy-MM-dd");
                txtDateCourse1.Text = dr["Date1"].ToString();
                txtDateCourse2.Text = dr["Date2"].ToString();
                txtDateCourse3.Text = dr["Date3"].ToString();
                txtDateCourse3.Text = dr["Date4"].ToString();
                txtReason.Text = dr["Description"].ToString();
                txtCourseNum1.Text = dr["Subject1"].ToString();
                txtCourseNum2.Text = dr["Subject2"].ToString();
                txtCourseNum3.Text = dr["Subject3"].ToString();
                txtCourseNum4.Text = dr["Subject4"].ToString();
                
                string Year = dr["Year"].ToString();
                string Semester = dr["Semester"].ToString();
                RegistredCourses Subj = new RegistredCourses();

                if (Convert.ToInt32(txtCourseNum1.Text.ToString()) != 0)
                {
                    int Course1 = Convert.ToInt32(txtCourseNum1.Text.ToString());
                    DataRow Sub = Subj.drSearchRegisterSubjectID(Course1, Year, Semester);
                    labTeacher1.Text = Sub["EmployeeName"].ToString();
                    //ddlCourse1.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));
                    ddlCourse1.SelectedValue = dr["Subject1"].ToString();
                   
                }
                if (Convert.ToInt32(txtCourseNum2.Text.ToString()) != 0)
                {
                    int Course2 = Convert.ToInt32(txtCourseNum2.Text.ToString());
                    DataRow Sub = Subj.drSearchRegisterSubjectID(Course2, Year, Semester);
                    labTeacher2.Text = Sub["EmployeeName"].ToString();
                    // ddlCourse2.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));
                    ddlCourse2.SelectedValue = dr["Subject2"].ToString();

                }
                if (Convert.ToInt32(txtCourseNum3.Text.ToString()) != 0)
                {
                    int Course3 = Convert.ToInt32(txtCourseNum3.Text.ToString());
                    DataRow Sub = Subj.drSearchRegisterSubjectID(Course3, Year, Semester);
                    labTeacher3.Text = Sub["EmployeeName"].ToString();
                    //ddlCourse3.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));
                    ddlCourse3.SelectedValue = dr["Subject3"].ToString();

                }
                if (Convert.ToInt32(txtCourseNum4.Text.ToString()) != 0)
                {
                    int Course4 = Convert.ToInt32(txtCourseNum4.Text.ToString());
                    DataRow Sub = Subj.drSearchRegisterSubjectID(Course4, Year, Semester);
                    labTeacher3.Text = Sub["EmployeeName"].ToString();
                    //ddlCourse4.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));
                    ddlCourse4.SelectedValue = dr["Subject4"].ToString();

                }






            }
        }

        

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool Result = false;


            int ID = Convert.ToInt32(Session["ID"].ToString());
            string Path = "";
            string Data = labNumberStudent.Text.ToString() + txtCourseNum1.Text.ToString() + txtCourseNum2.Text.ToString() +
                 txtCourseNum3.Text.ToString() + txtCourseNum4.Text.ToString() + txtDateCourse1.Text.ToString() + txtDateCourse2.Text.ToString() + txtDateCourse3.Text.ToString()
             + txtDateCourse4.Text.ToString();
            if (fuSignatureStudent.HasFile)
            {
                string Private = fuSignatureStudent.FileName.ToString();
                Path = System.Web.HttpContext.Current.Server.MapPath("Test") + "/" + Private;
                string Pasword = txtPassSign.Text.ToString();
                fuSignatureStudent.SaveAs(Server.MapPath("Test") + "/" + fuSignatureStudent.FileName);
                SignatureStudents newSig = new SignatureStudents();
                string strencrypt = newSig.encrypet(Data, Path, Pasword);
                Result = newSig.Decreypt(strencrypt, ID);

            }

            if (Result == true)
            {
                int row = Convert.ToInt32(Request.QueryString["id"]);

                int CourseNum1 = 0;
                int CourseNum2 = 0;
                int CourseNum3 = 0;
                int CourseNum4 = 0;

                if (txtCourseNum1.Text != string.Empty)
                    CourseNum1 = Convert.ToInt32(txtCourseNum1.Text.ToString());

                if (txtCourseNum2.Text != string.Empty)
                    CourseNum2 = Convert.ToInt32(txtCourseNum2.Text.ToString());

                if (txtCourseNum3.Text != string.Empty)
                    CourseNum3 = Convert.ToInt32(txtCourseNum3.Text.ToString());

                if (txtCourseNum4.Text != string.Empty)
                    CourseNum4 = Convert.ToInt32(txtCourseNum4.Text.ToString());

                string ExamCourse1Date = txtDateCourse1.Text.ToString();

                string ExamCourse2Date = txtDateCourse2.Text.ToString();
                string ExamCourse3Date = txtDateCourse3.Text.ToString();
                string ExamCourse4Date = txtDateCourse4.Text.ToString();

                string Reason = txtReason.Text.ToString();

                string strReasonFile = "";
                string strReasonFile2 = "";
                if (fuDetiels1.HasFile)
                {
                    strReasonFile = fuDetiels1.FileName.ToString();
                    fuDetiels1.SaveAs(Server.MapPath("../UploadFiles") + "/" + fuDetiels1.FileName);
                }

                if (fuDetiels2.HasFile)
                {
                    strReasonFile2 = fuDetiels2.FileName.ToString();

                    fuDetiels2.SaveAs(Server.MapPath("../UploadFiles") + "/" + fuDetiels2.FileName);
                }
                string date = labDate.Text.ToString();
                AbsenceExam obj11 = new AbsenceExam();

                NowTimeUniversity timee = new NowTimeUniversity();
                DataRow T = timee.drSearchYearANdSemester();
                string semester = T["NowSemester"].ToString();
                string Year = T["NowYear"].ToString();

                if (obj11.UpdateAbsenceExam(row, ID, date, Year, semester, CourseNum1, ExamCourse1Date, CourseNum2, ExamCourse2Date, CourseNum3, ExamCourse3Date, CourseNum4, ExamCourse4Date, Reason, strReasonFile, strReasonFile2, 1) == 1)
                {
                    txtReason.Text = "";
                    txtCourseNum1.Text = "";
                    ddlCourse1.SelectedIndex = -1;
                    ddlCourse2.SelectedIndex = -1;
                    ddlCourse3.SelectedIndex = -1;
                    ddlCourse4.SelectedIndex = -1;
                    labTeacher1.Text = "";
                    labTeacher2.Text = "";
                    labTeacher3.Text = "";
                    labTeacher4.Text = "";

                    SentMail s = new SentMail();
                    s.sendemailDean(ID);
                }
                errorLabel.Visible = false;



            }



            else
            {
                errorLabel.Text = "التوقيع المدخل خاطئ";
                errorLabel.Visible = true;
            }






        }



        protected void txtCourseNum1_TextChanged(object sender, EventArgs e)
        {
            if (txtCourseNum1.Text != string.Empty)
                ddlCourse1.SelectedValue = txtCourseNum1.Text;
            else
                ddlCourse1.SelectedIndex = -1;


        }

        private void fillddl()
        {

            int ID = Convert.ToInt32(Session["ID"].ToString());
            RegistredCourses obj = new RegistredCourses();
            NowTimeUniversity timee = new NowTimeUniversity();
            DataRow T = timee.drSearchYearANdSemester();
            string year = T["NowYear"].ToString();
            string Semester = T["NowSemester"].ToString();
            DataTable tbl1 = obj.dtSearchRegisterSubject(ID, year, Semester);
            
            ddlCourse1.DataSource = tbl1;
            ddlCourse1.DataTextField = "SubjectName";
            ddlCourse1.DataValueField = "SubjectID";
            ddlCourse1.DataBind();

            ddlCourse2.DataSource = tbl1;
            ddlCourse2.DataTextField = "SubjectName";
            ddlCourse2.DataValueField = "SubjectID";
            ddlCourse2.DataBind();

            ddlCourse3.DataSource = tbl1;
            ddlCourse3.DataTextField = "SubjectName";
            ddlCourse3.DataValueField = "SubjectID";
            ddlCourse3.DataBind();

            ddlCourse4.DataSource = tbl1;
            ddlCourse4.DataTextField = "SubjectName";
            ddlCourse4.DataValueField = "SubjectID";
            ddlCourse4.DataBind();
            ddlCourse1.Items.Insert(0, new ListItem("<اختر مادة>", "0"));
            ddlCourse2.Items.Insert(0, new ListItem("<اختر مادة>", "0"));
            ddlCourse3.Items.Insert(0, new ListItem("<اختر مادة>", "0"));
            ddlCourse4.Items.Insert(0, new ListItem("<اختر مادة>", "0"));
        

        }


        protected void ddlCourse1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCourse1.SelectedIndex != 0 && ddlCourse1.SelectedIndex != -1)
            {
                txtCourseNum1.Text = ddlCourse1.SelectedValue.ToString();

                RegistredCourses obj1 = new RegistredCourses();
                int ID = Convert.ToInt32(Session["ID"].ToString());
                int CourseID = Convert.ToInt32(ddlCourse1.SelectedValue.ToString());
                DataRow dr1;
                dr1 = obj1.drSearchRegisterSubjectTeacher(ID, CourseID);
                if (dr1 != null)
                {
                    labTeacher1.Text = dr1["EmployeeName"].ToString();
                }
            }

        }

        protected void ddlCourse2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCourse2.SelectedIndex != 0 && ddlCourse2.SelectedIndex != -1)
            {
                txtCourseNum2.Text = ddlCourse2.SelectedValue.ToString();

                RegistredCourses obj1 = new RegistredCourses();
                int ID = Convert.ToInt32(Session["ID"].ToString());
                int CourseID = Convert.ToInt32(ddlCourse2.SelectedValue.ToString());
                DataRow dr1;
                dr1 = obj1.drSearchRegisterSubjectTeacher(ID, CourseID);
                if (dr1 != null)
                {
                    labTeacher2.Text = dr1["EmployeeName"].ToString();
                }
            }
        }

        protected void ddlCourse3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCourse3.SelectedIndex != 0 && ddlCourse3.SelectedIndex != -1)
            {
                txtCourseNum3.Text = ddlCourse3.SelectedValue.ToString();
                RegistredCourses obj1 = new RegistredCourses();
                int ID = Convert.ToInt32(Session["ID"].ToString());
                int CourseID = Convert.ToInt32(ddlCourse3.SelectedValue.ToString());
                DataRow dr1;
                dr1 = obj1.drSearchRegisterSubjectTeacher(ID, CourseID);
                if (dr1 != null)
                {
                    labTeacher3.Text = dr1["EmployeeName"].ToString();
                }
            }
        }

        protected void ddlCourse4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCourse4.SelectedIndex != 0 && ddlCourse4.SelectedIndex != -1)
            {
                txtCourseNum4.Text = ddlCourse4.SelectedValue.ToString();
                RegistredCourses obj1 = new RegistredCourses();
                int ID = Convert.ToInt32(Session["ID"].ToString());
                int CourseID = Convert.ToInt32(ddlCourse4.SelectedValue.ToString());
                DataRow dr1;
                dr1 = obj1.drSearchRegisterSubjectTeacher(ID, CourseID);
                if (dr1 != null)
                {
                    labTeacher4.Text = dr1["EmployeeName"].ToString();
                }
            }
        }

        protected void txtCourseNum2_TextChanged(object sender, EventArgs e)
        {
            if (txtCourseNum2.Text != string.Empty)
                ddlCourse2.SelectedValue = txtCourseNum2.Text;
            else
                ddlCourse2.SelectedIndex = -1;
        }

        protected void txtCourseNum3_TextChanged(object sender, EventArgs e)
        {
            if (txtCourseNum3.Text != string.Empty)
                ddlCourse3.SelectedValue = txtCourseNum3.Text;
            else
                ddlCourse3.SelectedIndex = -1;
        }

        protected void txtCourseNum4_TextChanged(object sender, EventArgs e)
        {
            if (txtCourseNum4.Text != string.Empty)
                ddlCourse4.SelectedValue = txtCourseNum4.Text;
            else
                ddlCourse4.SelectedIndex = -1;
        }
    }
}