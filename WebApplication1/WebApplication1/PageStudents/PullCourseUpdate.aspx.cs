﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class PullCourseUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                int ID = Convert.ToInt32(Session["ID"].ToString());

                fillDataForm(ID);
                fillddl();
            }
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
                    ddlNameCourse1.SelectedValue = txtNumCourse1.Text.ToString();
                    //ddlNameCourse1.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));

                }
                if (Convert.ToInt32(txtNumCourse2.Text.ToString()) != 0)
                {
                    int Course2 = Convert.ToInt32(txtNumCourse2.Text.ToString());
                    DataRow Sub = Subj.drSearchRegisterSubjectID(Course2, Year, Semester);
                    labTeacher2.Text = Sub["EmployeeName"].ToString();
                    //ddlNameCourse2.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));
                    ddlNameCourse2.SelectedValue = txtNumCourse2.Text.ToString();

                }
                if (Convert.ToInt32(txtNumCourse3.Text.ToString()) != 0)
                {
                    int Course3 = Convert.ToInt32(txtNumCourse3.Text.ToString());
                    DataRow Sub = Subj.drSearchRegisterSubjectID(Course3, Year, Semester);
                    labTeacher3.Text = Sub["EmployeeName"].ToString();
                    //ddlNameCourse3.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));
                    ddlNameCourse3.SelectedValue = txtNumCourse3.Text.ToString();

                }

            }
       }

        protected void ddlNameCourse1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNameCourse1.SelectedIndex != 0 && ddlNameCourse1.SelectedIndex != -1)
            {
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
        }
        

       protected void ddlNameCourse2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNameCourse2.SelectedIndex != 0 && ddlNameCourse2.SelectedIndex != -1)
            {
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
        }

        protected void ddlNameCourse3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNameCourse3.SelectedIndex != 0 && ddlNameCourse3.SelectedIndex != -1)
            {
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

        protected void btnSave_Click(object sender, EventArgs e)
        {


            bool Result = false;
            int ID = Convert.ToInt32(Session["ID"]);
            string Path = "";
            string Data = txtNumCourse1.Text.ToString() + txtNumCourse2.Text.ToString() + txtNumCourse3.Text.ToString() +
             txtNmberHours.Text.ToString() + txtNumHourAfter.Text.ToString() + DateTime.Today.ToString();
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

                string Reson = "";
                int NumHoursResginter;
                int NumpullHours;
                int CourseNum1 = 0;
                int CourseNum2 = 0;
                int CourseNum3 = 0;


                if (txtNumCourse1.Text != string.Empty)
                    CourseNum1 = Convert.ToInt32(txtNumCourse1.Text.ToString());

                if (txtNumCourse2.Text != string.Empty)
                    CourseNum2 = Convert.ToInt32(txtNumCourse2.Text.ToString());

                if (txtNumCourse3.Text != string.Empty)
                    CourseNum3 = Convert.ToInt32(txtNumCourse3.Text.ToString());
                if (txtNmberHours.Text != string.Empty)
                    NumHoursResginter = Convert.ToInt32(txtNmberHours.Text.ToString());
                if (txtNumHourAfter.Text != string.Empty)
                    NumpullHours = Convert.ToInt32(txtNumHourAfter.Text.ToString());
                if (txtReason.Text != string.Empty)
                    Reson = txtReason.Text.ToString();

                string Course1time = txtTimeCourse1.Text.ToString();

                string Course2time = txtTimeCourse2.Text.ToString();
                string Course3time = txtTimeCourse3.Text.ToString();
                int NumHourREG = Convert.ToInt32(txtNmberHours.Text.ToString());
                int NumHourAFpull = Convert.ToInt32(txtNumHourAfter.Text.ToString());
                string DateNow = DateTime.Today.ToString();
                int roww = Convert.ToInt32(Request.QueryString["id"]);
                PullCourseClass obj = new PullCourseClass();
                if (obj.UpdatePullCourse(roww, ID, CourseNum1, CourseNum2, CourseNum3, DateNow, Reson, Course1time, Course2time, Course3time, NumHourREG, NumHourAFpull, "", "", 0, "", "", 0, 0, 5)==1)
                {

                    Response.Redirect("PullCourseDisplay.aspx");


                }
                errorLabel.Visible = false;

            }
            else
            {
                errorLabel.Text = "التوقيع المدخل خاطئ";
                errorLabel.Visible = true;
            }

        }
    }
}