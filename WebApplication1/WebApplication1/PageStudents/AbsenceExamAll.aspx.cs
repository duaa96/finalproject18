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

                fillddl();
                fillDataForm(ID);

            }

            else
            {
            }
        }

        public void fillDataForm(int ID)

        {

            
            Studnets objStu = new Studnets();
            DataRow Stu = objStu.drSearchStudent(ID);
            if (Stu != null)
            {
                labCollage.Text = Stu["CollageName"].ToString();
                labStudentName.Text = Stu["StudentName"].ToString();
                labNumberStudent.Text = Stu["UniversityID"].ToString();
                labSectionStudent.Text = Stu["SectionName"].ToString();
            }

            int roww = Convert.ToInt32(Request.QueryString["id"]);

            AbsenceExam obj = new AbsenceExam();
            DataRow dr = obj.drgetform(roww);
            string DeanAccept = dr["DeanAccept"].ToString();
            if (DeanAccept == "1")
                rbtAcceptDean.SelectedValue = "1";
            else if (DeanAccept == "2")
                rbtAcceptDean.SelectedValue = "2";
            txtDescriptionDean.Text = dr["DeanDescription"].ToString();
            txtDateCourse1.Text = dr["Date1"].ToString();
            txtDateCourse3.Text = dr["Date3"].ToString();
            txtDateCourse2.Text = dr["Date2"].ToString();
            txtDateCourse4.Text = dr["Date4"].ToString();
            labDate.Text = dr["Date"].ToString();
            txtReason.Text = dr["Description"].ToString();
            txtCourseNum1.Text = dr["Subject1"].ToString();
            txtCourseNum2.Text = dr["Subject2"].ToString();
            txtCourseNum3.Text = dr["Subject3"].ToString();
            txtCourseNum4.Text = dr["Subject4"].ToString();
            ddlCourse1.SelectedValue = txtCourseNum1.Text.ToString();
            ddlCourse2.SelectedValue = txtCourseNum2.Text.ToString();
            ddlCourse3.SelectedValue = txtCourseNum3.Text.ToString();
            ddlCourse4.SelectedValue = txtCourseNum4.Text.ToString();


            RegistredCourses obj1 = new RegistredCourses();
            int CourseNum1 = Convert.ToInt32(txtCourseNum1.Text.ToString());
            int CourseNum2 = Convert.ToInt32(txtCourseNum2.Text.ToString());
            int CourseNum3 = Convert.ToInt32(txtCourseNum3.Text.ToString());
            int CourseNum4 = Convert.ToInt32(txtCourseNum4.Text.ToString());


            for (int i = 0; i < 4; i++)
            {
                DataRow dr1;
                if (ddlCourse1.SelectedIndex != 0 && ddlCourse1.SelectedIndex != -1)
                {

                    int CourseID = Convert.ToInt32(ddlCourse1.SelectedValue.ToString());
                    dr1 = obj1.drSearchRegisterSubjectTeacher(ID, CourseID);
                    if (dr1 != null)
                    {
                        labTeacher1.Text = dr1["EmployeeName"].ToString();
                    }
                }
                if (ddlCourse2.SelectedIndex != 0 && ddlCourse2.SelectedIndex != -1)
                {

                    int CourseID = Convert.ToInt32(ddlCourse2.SelectedValue.ToString());
                    dr1 = obj1.drSearchRegisterSubjectTeacher(ID, CourseID);
                    if (dr1 != null)
                    {
                        labTeacher2.Text = dr1["EmployeeName"].ToString();
                    }
                }

                if (ddlCourse3.SelectedIndex != 0 && ddlCourse3.SelectedIndex != -1)
                {

                    int CourseID = Convert.ToInt32(ddlCourse3.SelectedValue.ToString());
                    dr1 = obj1.drSearchRegisterSubjectTeacher(ID, CourseID);
                    if (dr1 != null)
                    {
                        labTeacher3.Text = dr1["EmployeeName"].ToString();
                    }
                }
                if (ddlCourse4.SelectedIndex != 0 && ddlCourse4.SelectedIndex != -1)
                {

                    int CourseID = Convert.ToInt32(ddlCourse4.SelectedValue.ToString());
                    dr1 = obj1.drSearchRegisterSubjectTeacher(ID, CourseID);
                    if (dr1 != null)
                    {
                        labTeacher4.Text = dr1["EmployeeName"].ToString();
                    }
                }
            }
        }
        private void fillddl()
        {

            int ID = Convert.ToInt32(Session["ID"].ToString());
            RegistredCourses obj = new RegistredCourses();
            DataTable tbl1 = obj.dtSearchRegisterSubject(ID);
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
    }
}