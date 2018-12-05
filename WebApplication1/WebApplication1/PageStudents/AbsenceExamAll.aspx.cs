using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class AbsenceExamAll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Session["ID"].ToString());


                fillData();
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

                labDate.Text = dr["Date"].ToString();
                txtDateCourse1.Text = dr["Date1"].ToString();
                txtDateCourse2.Text = dr["Date2"].ToString();
                txtDateCourse3.Text = dr["Date3"].ToString();
                txtDateCourse3.Text = dr["Date4"].ToString();
                txtReason.Text = dr["Description"].ToString();
                txtCourseNum1.Text = dr["Subject1"].ToString();
                txtCourseNum2.Text = dr["Subject2"].ToString();
                txtCourseNum3.Text = dr["Subject3"].ToString();
                txtCourseNum4.Text = dr["Subject4"].ToString();
             
                LinkButton1.Text = dr["Attachment1"].ToString();
                LinkButton2.Text = dr["Attachment2"].ToString();
                string Year = dr["Year"].ToString();
                string Semester = dr["Semester"].ToString();
                RegistredCourses Subj = new RegistredCourses();

                if (Convert.ToInt32(txtCourseNum1.Text.ToString()) != 0)
                {
                    int Course1 = Convert.ToInt32(txtCourseNum1.Text.ToString());
                    DataRow Sub = Subj.drSearchRegisterSubjectID(Course1, Year, Semester);
                    labTeacher1.Text = Sub["EmployeeName"].ToString();
                    ddlCourse1.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));

                }
                if (Convert.ToInt32(txtCourseNum2.Text.ToString()) != 0)
                {
                    int Course2 = Convert.ToInt32(txtCourseNum2.Text.ToString());
                    DataRow Sub = Subj.drSearchRegisterSubjectID(Course2, Year, Semester);
                    labTeacher2.Text = Sub["EmployeeName"].ToString();
                    ddlCourse2.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));

                }
                if (Convert.ToInt32(txtCourseNum3.Text.ToString()) != 0)
                {
                    int Course3 = Convert.ToInt32(txtCourseNum3.Text.ToString());
                    DataRow Sub = Subj.drSearchRegisterSubjectID(Course3, Year, Semester);
                    labTeacher3.Text = Sub["EmployeeName"].ToString();
                    ddlCourse3.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));

                }
                if (Convert.ToInt32(txtCourseNum4.Text.ToString()) != 0)
                {
                    int Course4 = Convert.ToInt32(txtCourseNum4.Text.ToString());
                    DataRow Sub = Subj.drSearchRegisterSubjectID(Course4, Year, Semester);
                    labTeacher3.Text = Sub["EmployeeName"].ToString();
                    ddlCourse4.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));

                }



                txtDescriptionDean.Text = dr["DeanDescription"].ToString();
                string DeanAccept = dr["DeanAccept"].ToString();
                if (DeanAccept == "1")
                    rbtAcceptDean.SelectedValue = "1";
                else if (DeanAccept == "2")
                    rbtAcceptDean.SelectedValue = "2";


            }
        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string filePath = LinkButton1.Text.ToString();
            filePath = "../uploadFiles/" + filePath;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string filePath = LinkButton2.Text.ToString();
            filePath = "../uploadFiles/" + filePath;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + (filePath));
            Response.WriteFile(filePath);
            Response.End();
        }
    }
}