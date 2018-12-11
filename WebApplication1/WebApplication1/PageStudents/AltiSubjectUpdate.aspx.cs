using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class AltiSubjectUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Session["ID"].ToString());

                fillddl();
                fillData();
            }
        }
        private void fillddl()
        {
            RegistredCourses obj1 = new RegistredCourses();
            int ID = Convert.ToInt32(Session["ID"].ToString());
            DataTable tb1 = obj1.dtSearchNotRegisterSubject(ID);

            Subjects obj2 = new Subjects();
            DataTable tb2 = obj2.dtSearchStudentSubjectNotRegester(ID);

            ddlAlternativeCourse1.DataSource = tb2;
            ddlAlternativeCourse1.DataTextField = "SubjectName";
            ddlAlternativeCourse1.DataValueField = "SubjectID";
            ddlAlternativeCourse1.DataBind();


            ddlCourse1.DataSource = tb1;
            ddlCourse1.DataTextField = "SubjectName";
            ddlCourse1.DataValueField = "SubjectID";
            ddlCourse1.DataBind();

            ddlCourse1.Items.Insert(0, new ListItem("<اختر مادة>", "0"));
            ddlAlternativeCourse1.Items.Insert(0, new ListItem("<اختر مادة>", "0"));
        }
        private void fillData()
        {

            AlternativeSub obj = new AlternativeSub();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataRow dr = obj.drgetform(id);

            if (dr != null)
            {
                int STUid = Convert.ToInt32(dr["StudentID"].ToString());
                Studnets objStu = new Studnets();
                DataRow Stu = objStu.drSearchStudent(STUid);
                if (Stu != null)
                {
                    labCollage.Text = Stu["CollageName"].ToString();
                    labNameStudent.Text = Stu["StudentName"].ToString();
                    labNumStudent.Text = Stu["UniversityID"].ToString();
                    labSection.Text = Stu["SectionName"].ToString();
                    labMager.Text = Stu["Mager"].ToString();

                }
                labDate.Text = DateTime.UtcNow.ToString("yyyy-MM-dd");

                txtNumberCourse1.Text = dr["Subject1ID"].ToString();
                labTypeCourse1.Text = dr["Subject2Type"].ToString();
                txtReason.Text = dr["Description"].ToString();
                txtAlternativeNum1C1.Text = dr["NewSubject"].ToString();
                string Year = dr["Year"].ToString();
                string Semester = dr["Semester"].ToString();
                Subjects sub = new Subjects();
                if (Convert.ToInt32(txtNumberCourse1.Text.ToString()) != 0)
                {
                    int Course1 = Convert.ToInt32(txtNumberCourse1.Text.ToString());
                    DataRow Sub = sub.drSearchSubject(Course1);
                    labHoursCourse1.Text = Sub["Hours"].ToString();

                    // ddlCourse1.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));
                    ddlCourse1.SelectedValue = txtNumberCourse1.Text;

                }
                if (Convert.ToInt32(txtAlternativeNum1C1.Text.ToString()) != 0)
                {
                    int Course1 = Convert.ToInt32(txtAlternativeNum1C1.Text.ToString());
                    DataRow Sub = sub.drSearchSubject(Course1);
                    labHoursAlternative.Text = Sub["Hours"].ToString();
                    //ddlAlternativeCourse1.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));
                    ddlAlternativeCourse1.SelectedValue = txtAlternativeNum1C1.Text;

                }

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool Result = false;
            //Define Avariable 
            int CourseNum1 = 0;
            int AlternativeCourseNum1 = 0;
            string TypeCouseNum1 = "";
            string Reason = "";
            int row = Convert.ToInt32(Request.QueryString["id"]);

            int ID = Convert.ToInt32(Session["ID"].ToString());
            string Path = "";

            string Data = txtNumberCourse1.Text.ToString() + txtAlternativeNum1C1.Text.ToString() +
            labHoursCourse1.Text.ToString() + labHoursAlternative.Text.ToString();
            if (fuSignature.HasFile)
            {
                string Private = fuSignature.FileName.ToString();
                Path = System.Web.HttpContext.Current.Server.MapPath("Test") + "/" + Private;
                string Pasword = txtPassSign.Text.ToString();
                fuSignature.SaveAs(Server.MapPath("Test") + "/" + fuSignature.FileName);
                //  Path = "/Test/" + fuSignatureStudent.FileName;
                SignatureStudents newSig = new SignatureStudents();
                string strencrypt = newSig.encrypet(Data, Path, Pasword);
                Result = newSig.Decreypt(strencrypt, ID);

            }

            if (Result == true)
            {
                //Check input Data
                if (txtNumberCourse1.Text != String.Empty)
                    CourseNum1 = Convert.ToInt32(txtNumberCourse1.Text.ToString());

                if (txtAlternativeNum1C1.Text != String.Empty)
                    AlternativeCourseNum1 = Convert.ToInt32(txtAlternativeNum1C1.Text.ToString());
                if (labTypeCourse1.Text != String.Empty)
                    TypeCouseNum1 = labTypeCourse1.Text.ToString();

                if (txtReason.Text != String.Empty)
                    Reason = txtReason.Text.ToString();
                AlternativeSub obj = new AlternativeSub();
                NowTimeUniversity timee = new NowTimeUniversity();
                DataRow T = timee.drSearchYearANdSemester();
                string semester = T["NowSemester"].ToString();
                string Year = T["NowYear"].ToString();
                string Date1 = labDate.Text.ToString();
                if (obj.UpdateAlternativeSubject(row,ID, Year, semester, Date1, CourseNum1, TypeCouseNum1, AlternativeCourseNum1, Reason) == 1)
                {
                    ddlCourse1.SelectedIndex = -1;
                    ddlAlternativeCourse1.SelectedIndex = -1;
                    txtReason.Text = "";
                    ddlAlternativeCourse1.SelectedIndex = -1;
                    txtAlternativeNum1C1.Text = "";
                    txtNumberCourse1.Text = "";
                    labTypeCourse1.Text = "";
                    labHoursCourse1.Text = "";
                    labHoursAlternative.Text = "";
                    SentMail s = new SentMail();
                    s.sendemailAcadimic(ID);

                }
                errorLabel.Visible = false;
            }
            else
            {
                errorLabel.Text = "التوقيع المدخل خاطئ أو كلمة المرور";
                errorLabel.Visible = true;
            }

        }



        protected void ddlCourse1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCourse1.SelectedIndex != 0 && ddlCourse1.SelectedIndex != -1)
            {
                txtNumberCourse1.Text = ddlCourse1.SelectedValue.ToString();


                Subjects obj = new Subjects();
                int SubjectID = Convert.ToInt32(txtNumberCourse1.Text.ToString());
                DataRow dr = obj.drSearchStudentSubjectTypAndHours(SubjectID);
                if (dr != null)
                {
                    labTypeCourse1.Text = dr["Type"].ToString();
                    labHoursCourse1.Text = dr["Hours"].ToString();
                }

            }
        }

        protected void ddlAlternativeCourse1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAlternativeCourse1.SelectedIndex != 0 && ddlAlternativeCourse1.SelectedIndex != -1)
            {
                txtAlternativeNum1C1.Text = ddlAlternativeCourse1.SelectedValue.ToString();

                Subjects obj = new Subjects();
                int SubjectID = Convert.ToInt32(txtAlternativeNum1C1.Text.ToString());
                DataRow dr = obj.drSearchStudentSubjectTypAndHours(SubjectID);
                if (dr != null)
                {
                    labHoursAlternative.Text = dr["Hours"].ToString();
                }
            }

        }

        protected void txtNumberCourse1_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberCourse1.Text != string.Empty)
            {
                ddlCourse1.SelectedValue = txtNumberCourse1.Text;

            }
            else
                ddlCourse1.SelectedIndex = -1;


        }

        protected void txtAlternativeNum1C1_TextChanged(object sender, EventArgs e)
        {
            if (txtAlternativeNum1C1.Text != string.Empty)
                ddlAlternativeCourse1.SelectedValue = txtAlternativeNum1C1.Text;
            else
                ddlAlternativeCourse1.SelectedIndex = -1;
        }

    }

}