using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class processDropSemesterDeputyAcademic : System.Web.UI.Page
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

            DropSemester obj = new DropSemester();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataRow dr = obj.drgetform(id);

            if (dr != null)
            {
                int STUid = Convert.ToInt32(dr["StudentID"].ToString());
                Studnets objStu = new Studnets();
                DataRow Stu = objStu.drSearchStudent(STUid);
                if (Stu != null)
                {
                    labNameStudent.Text = Stu["StudentName"].ToString();
                    labNumStudent.Text = Stu["UniversityID"].ToString();
                    labSection.Text = Stu["SectionName"].ToString();
                    labCollage.Text = Stu["CollageName"].ToString();

                }
                labDate.Text = dr["Date"].ToString();
                labDateDep.Text = DateTime.Today.ToString();
                txtNumHours.Text = dr["NumofHourReg"].ToString();
                txtReasons.Text = dr["Description"].ToString();
                string semester = dr["Semester"].ToString();
                string year = dr["Year"].ToString();
                int ID = Convert.ToInt32(dr["StudentID"].ToString());
                RegistredCourses objj = new RegistredCourses();
                DataTable tbl1 = objj.dtSearchRegisterSubjectStu(ID, semester, year);
                gvCourses.DataSource = tbl1;
                gvCourses.DataBind();
                txtDescriptionAcadimic.Text = dr["AcademicAdvisor_Descr"].ToString();
                txtDescriptionHead.Text = dr["HeadDescription"].ToString();
                txtDescriptionDean.Text = dr["DeanDescription"].ToString();
                string Acadimic = dr["AcademicAdvisorAccept"].ToString();
                if (Acadimic == "1")
                    rbtAcceptAcadimic.SelectedValue = "1";
                else if (Acadimic == "2")
                    rbtAcceptAcadimic.SelectedValue = "2";

                string HeadAcept = dr["HeadAccept"].ToString();
                if (HeadAcept == "1")
                    rbtAceptHead.SelectedValue = "1";
                else if (HeadAcept == "2")
                    rbtAceptHead.SelectedValue = "2";
                string DeanAcept = dr["DeanAccept"].ToString();
                if (DeanAcept == "1")
                    rbtDeanAccept.SelectedValue = "1";
                else if (DeanAcept == "2")
                    rbtDeanAccept.SelectedValue = "2";

            }
        }
    }
}