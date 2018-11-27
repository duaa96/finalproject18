using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class processPullCourseReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Session["ID"].ToString());
                Position emp = new Position();
                DataRow dr = emp.drSearchEmployeePosition(ID);
                int position = Convert.ToInt32(dr["Position"].ToString());

                fillData(position);
            }
        }
        private void fillData(int p)
        {

            PullCourseClass obj = new PullCourseClass();
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
                    labStudentNmuber.Text = Stu["UniversityID"].ToString();
                    labSectionStudent.Text = Stu["SectionName"].ToString();
                    labCollage.Text = Stu["CollageName"].ToString();

                }

                labDate.Text = dr["Date"].ToString();
                txtTimeCourse1.Text = dr["Course1time"].ToString();
                txtTimeCourse2.Text = dr["Course2time"].ToString();
                txtTimeCourse3.Text = dr["Course3time"].ToString();
                txtReason.Text = dr["Description"].ToString();
                txtNmberHours.Text = dr["NumHourRegester"].ToString();
                txtNumHourAfter.Text = dr["NumAfterPull"].ToString();
                txtNumCourse1.Text = dr["Subject1ID"].ToString();
                txtNumCourse2.Text = dr["Subject2ID"].ToString();
                txtNumCourse3.Text = dr["Subject3ID"].ToString();

                string Year = dr["Year"].ToString();
                string Semester = dr["Semester"].ToString();
                RegistredCourses Subj = new RegistredCourses();

                if (Convert.ToInt32(txtNumCourse1.Text.ToString()) != 0)
                {
                    int Course1 = Convert.ToInt32(txtNumCourse1.Text.ToString());
                    DataRow Sub = Subj.drSearchRegisterSubjectID(Course1, Year, Semester);
                    labTeacher1.Text = Sub["EmployeeName"].ToString();
                    ddlNameCourse1.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));

                }
                if (Convert.ToInt32(txtNumCourse2.Text.ToString()) != 0)
                {
                    int Course2 = Convert.ToInt32(txtNumCourse2.Text.ToString());
                    DataRow Sub = Subj.drSearchRegisterSubjectID(Course2, Year, Semester);
                    labTeacher2.Text = Sub["EmployeeName"].ToString();
                    ddlNameCourse2.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));

                }
                if (Convert.ToInt32(txtNumCourse3.Text.ToString()) != 0)
                {
                    int Course3 = Convert.ToInt32(txtNumCourse3.Text.ToString());
                    DataRow Sub = Subj.drSearchRegisterSubjectID(Course3, Year, Semester);
                    labTeacher3.Text = Sub["EmployeeName"].ToString();
                    ddlNameCourse3.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));

                }


                txtDescriptionHead.Text = dr["HeadDescription"].ToString();
                string HeadAccept = dr["HeadAccept"].ToString();
                if (HeadAccept == "1")
                    rbtAceptHead.SelectedValue = "1";
                else if (HeadAccept == "2")
                    rbtAceptHead.SelectedValue = "2";
                string DeanAccept = dr["DeanAccept"].ToString();
                if (DeanAccept == "1")
                    rbtAcceptDean.SelectedValue = "1";
                else if (DeanAccept == "2")
                    rbtAcceptDean.SelectedValue = "2";

                string RegAccept = dr["RegestrationAccept"].ToString();
                if (RegAccept == "1")
                    rbtAcceptRegistration.SelectedValue = "1";
                else if (RegAccept == "2")
                    rbtAcceptRegistration.SelectedValue = "2";
                txtDescriptionDean.Text = dr["DeanDescription"].ToString();


            }
        }
        }
    }