using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class PullCourseDispalyAll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                int ID = Convert.ToInt32(Session["ID"].ToString());

                fillDataForm(ID);
                fillddl();
                fillEditddl();
            }

        }
        private void fillddl()
        {

            int ID = Convert.ToInt32(Session["ID"].ToString());
            RegistredCourses obj = new RegistredCourses();
            DataTable tbl1 = obj.dtSearchRegisterSubject(ID);
            ddlNameCourse1.DataSource = tbl1;
            ddlNameCourse1.DataTextField = "SubjectName";
            ddlNameCourse1.DataValueField = "SubjectID";
            ddlNameCourse1.DataBind();

            ddlNameCourse2.DataSource = tbl1;
            ddlNameCourse2.DataTextField = "SubjectName";
            ddlNameCourse2.DataValueField = "SubjectID";
            ddlNameCourse2.DataBind();

            ddlNameCourse3.DataSource = tbl1;
            ddlNameCourse3.DataTextField = "SubjectName";
            ddlNameCourse3.DataValueField = "SubjectID";
            ddlNameCourse3.DataBind();

            ddlNameCourse1.Items.Insert(0, new ListItem("<اختر مادة>", "0"));
            ddlNameCourse2.Items.Insert(0, new ListItem("<اختر مادة>", "0"));
            ddlNameCourse3.Items.Insert(0, new ListItem("<اختر مادة>", "0"));

        }

        private void fillDataForm(int ID)
        {

            Studnets objStu = new Studnets();
            DataRow Stu = objStu.drSearchStudent(ID);
            if (Stu != null)
            {
                labStudentName.Text = Stu["StudentName"].ToString();
                labStudentNmuber.Text = Stu["UniversityID"].ToString();
                labSectionStudent.Text = Stu["SectionName"].ToString();
                labCollage.Text = Stu["CollageName"].ToString();

            }
            PullCourseClass obj = new PullCourseClass();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataRow dr = obj.drgetform(id);
            if (dr != null)
            {
                labDate.Text = dr["Date"].ToString();
                txtTimeCourse1.Text = dr["Course1time"].ToString();
                txtTimeCourse2.Text = dr["Course2time"].ToString();
                txtTimeCourse3.Text = dr["Course3time"].ToString();
                txtReason.Text = dr["Description"].ToString();
                txtNmberHours.Text = dr["NumHourRegester"].ToString();
                txtNumHourAfter.Text = dr["NumAfterPull"].ToString();
                txtDescriptionHead.Text = dr["HeadDescription"].ToString();
               string HeadAccept= dr["HeadAccept"].ToString();
                if (HeadAccept == "1")
                    rbtAceptHead.SelectedValue = "1";
                else if(HeadAccept=="2")
                    rbtAceptHead.SelectedValue = "2";
                string DeanAccept = dr["DeanAccept"].ToString();
                if (DeanAccept == "1")
                    rbtAcceptDean.SelectedValue = "1";
                else if( DeanAccept == "2")
                    rbtAcceptDean.SelectedValue = "2";

                string RegAccept = dr["RegestrationAccept"].ToString();
                if (RegAccept == "1")
                    rbtAcceptRegistration.SelectedValue = "1";
                else if (RegAccept == "2")
                    rbtAcceptRegistration.SelectedValue = "2";
                txtDescriptionDean.Text = dr["DeanDescription"].ToString();

            }



        }

        protected void ddlNameCourse1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNameCourse1.SelectedIndex != 0 && ddlNameCourse1.SelectedIndex != -1)
                txtNumCourse1.Text = ddlNameCourse1.SelectedValue.ToString();

            RegistredCourses obj1 = new RegistredCourses();
            int ID = Convert.ToInt32(Session["ID"].ToString());
            int CourseID = Convert.ToInt32(ddlNameCourse1.SelectedValue.ToString());
            DataRow dr1;
            dr1 = obj1.drSearchRegisterSubjectTeacher(ID, CourseID);
            if (dr1 != null)
            {
                labTeacher1.Text = dr1["EmployeeName"].ToString();
            }
        }
        protected void fillEditddl()
        {
            PullCourseClass obj = new PullCourseClass();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataRow dr = obj.drgetform(id);
            RegistredCourses obj1 = new RegistredCourses();
            int ID = Convert.ToInt32(Session["ID"].ToString());
            int CourseID = 0;
            DataRow dr1;
            if (dr != null)
            {
                ddlNameCourse1.SelectedValue = dr["Subject1ID"].ToString();
                ddlNameCourse2.SelectedValue = dr["Subject2ID"].ToString();
                ddlNameCourse3.SelectedValue = dr["Subject3ID"].ToString();
                if (ddlNameCourse1.SelectedIndex != 0 && ddlNameCourse1.SelectedIndex != -1)
                {
                    txtNumCourse1.Text = ddlNameCourse1.SelectedValue.ToString();
                    CourseID = Convert.ToInt32(ddlNameCourse1.SelectedValue.ToString());
                    dr1 = obj1.drSearchRegisterSubjectTeacher(ID, CourseID);
                    if (dr1 != null)
                    {
                        labTeacher1.Text = dr1["EmployeeName"].ToString();
                    }
                }
                if (ddlNameCourse3.SelectedIndex != 0 && ddlNameCourse3.SelectedIndex != -1)
                {
                    txtNumCourse3.Text = ddlNameCourse3.SelectedValue.ToString();
                    CourseID = Convert.ToInt32(ddlNameCourse3.SelectedValue.ToString());
                    dr1 = obj1.drSearchRegisterSubjectTeacher(ID, CourseID);
                    if (dr1 != null)
                    {
                        labTeacher3.Text = dr1["EmployeeName"].ToString();
                    }
                }
                if (ddlNameCourse2.SelectedIndex != 0 && ddlNameCourse2.SelectedIndex != -1)
                {
                    txtNumCourse2.Text = ddlNameCourse2.SelectedValue.ToString();
                    ID = Convert.ToInt32(Session["ID"].ToString());
                    CourseID = Convert.ToInt32(ddlNameCourse2.SelectedValue.ToString());

                    dr1 = obj1.drSearchRegisterSubjectTeacher(ID, CourseID);
                    if (dr1 != null)
                    {
                        labTeacher2.Text = dr1["EmployeeName"].ToString();
                    }
                }




            }
        }

        protected void ddlNameCourse2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNameCourse2.SelectedIndex != 0 && ddlNameCourse2.SelectedIndex != -1)
                txtNumCourse2.Text = ddlNameCourse2.SelectedValue.ToString();

            RegistredCourses obj1 = new RegistredCourses();
            int ID = Convert.ToInt32(Session["ID"].ToString());
            int CourseID = Convert.ToInt32(ddlNameCourse2.SelectedValue.ToString());
            DataRow dr1;
            dr1 = obj1.drSearchRegisterSubjectTeacher(ID, CourseID);
            if (dr1 != null)
            {
                labTeacher2.Text = dr1["EmployeeName"].ToString();
            }
        }

        protected void ddlNameCourse3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNameCourse3.SelectedIndex != 0 && ddlNameCourse3.SelectedIndex != -1)
                txtNumCourse3.Text = ddlNameCourse3.SelectedValue.ToString();
            RegistredCourses obj1 = new RegistredCourses();
            int ID = Convert.ToInt32(Session["ID"].ToString());
            int CourseID = Convert.ToInt32(ddlNameCourse3.SelectedValue.ToString());
            DataRow dr1;
            dr1 = obj1.drSearchRegisterSubjectTeacher(ID, CourseID);
            if (dr1 != null)
            {
                labTeacher3.Text = dr1["EmployeeName"].ToString();

            }
        }

        protected void txtNumCourse1_TextChanged(object sender, EventArgs e)
        {
            if (txtNumCourse1.Text != string.Empty)
                ddlNameCourse1.SelectedValue = txtNumCourse1.Text;
            else
                ddlNameCourse1.SelectedIndex = -1;

        }

        protected void txtNumCourse2_TextChanged(object sender, EventArgs e)
        {
            if (txtNumCourse2.Text != string.Empty)
                ddlNameCourse2.SelectedValue = txtNumCourse2.Text;
            else
                ddlNameCourse2.SelectedIndex = -1;
        }

        protected void txtNumCourse3_TextChanged(object sender, EventArgs e)
        {
            if (txtNumCourse3.Text != string.Empty)
                ddlNameCourse3.SelectedValue = txtNumCourse3.Text;
            else
                ddlNameCourse3.SelectedIndex = -1;
        }
    }
}