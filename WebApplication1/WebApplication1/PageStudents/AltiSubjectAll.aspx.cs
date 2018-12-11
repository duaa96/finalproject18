using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class AltiSubjectAll : System.Web.UI.Page
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
                labDateS.Text = dr["Date"].ToString();
               
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

                    ddlCourse1.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));

                }
                if (Convert.ToInt32(txtAlternativeNum1C1.Text.ToString()) != 0)
                {
                    int Course1 = Convert.ToInt32(txtAlternativeNum1C1.Text.ToString());
                    DataRow Sub = sub.drSearchSubject(Course1);
                    labHoursAlternative.Text = Sub["Hours"].ToString();
                    ddlAlternativeCourse1.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));
                }
                string AcademicAccept = dr["AcademicAdvisorAccept"].ToString();
                if (AcademicAccept == "1")
                    rbtAcademic.SelectedValue = "1";
                else if (AcademicAccept == "2")
                    rbtAcademic.SelectedValue = "2";

                string HeadAccept = dr["HeadAccept"].ToString();
                if (HeadAccept == "1")
                    rbtAceptHead.SelectedValue = "1";
                else if (HeadAccept == "2")
                    rbtAceptHead.SelectedValue = "2";
                string DeanAccept = dr["DeanAccept"].ToString();
                if (DeanAccept == "1")
                    rbtDeanAccept.SelectedValue = "1";
                else if (DeanAccept == "2")
                    rbtDeanAccept.SelectedValue = "2";
                string RegAccept = dr["RegestrationAccept"].ToString();
                if (RegAccept == "1")
                    rbtRegAccept.SelectedValue = "1";
                else if (RegAccept == "2")
                    rbtRegAccept.SelectedValue = "2";
            }
        }
    }
}