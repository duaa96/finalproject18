using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class DropSemesterDisplayAll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Session["ID"].ToString());

                fillDataForm(ID);
                fillGV();
            }


        }
        public void fillDataForm(int ID)

        {


            Studnets objStu = new Studnets();
            DataRow Stu = objStu.drSearchStudent(ID);
            if (Stu != null)
            {
                labCollage.Text = Stu["CollageName"].ToString();
                labNameStudent.Text = Stu["StudentName"].ToString();
                labNumStudent.Text = Stu["UniversityID"].ToString();
                labSection.Text = Stu["SectionName"].ToString();

            }
            DropSemester obj = new DropSemester();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataRow dr = obj.drgetform(id);
            if (dr != null)
            {
                txtNumHours.Text = dr["NumofHourReg"].ToString();
                txtReasons.Text = dr["Description"].ToString();
                labDate.Text = dr["Date"].ToString();
                txtAcademicAdvisor.Text = dr["AcademicAdvisor_Descr"].ToString();
                txtHeadDescription.Text = dr["HeadDescription"].ToString();
                txtDeputyAcademicDesc.Text = dr["DeputyAcademic_Descr"].ToString();
                txtDescriptionDean.Text = dr["DeanDescription"].ToString();
            }

            string Acadimic = dr["AcademicAdvisorAccept"].ToString();
            if (Acadimic == "1")
                rbtAcademicAdvisorAccept.SelectedValue = "1";
            else if (Acadimic == "2")
                rbtAcademicAdvisorAccept.SelectedValue = "2";


            string HeadAccept = dr["HeadAccept"].ToString();
            if (HeadAccept == "1")
                rbtHeadAccept.SelectedValue = "1";
            else if (HeadAccept == "2")
                rbtHeadAccept.SelectedValue = "2";
            string DeanAccept = dr["DeanAccept"].ToString();
            if (DeanAccept == "1")
                rbtAcceptDean.SelectedValue = "1";
            else if (DeanAccept == "2")
                rbtAcceptDean.SelectedValue = "2";
            string DeputyAcademi = dr["DeputyAcademicAccept"].ToString();
            if (DeputyAcademi == "1")
                rbtDeputyAcademicAccept.SelectedValue = "1";
            else if (Acadimic == "2")
                rbtDeputyAcademicAccept.SelectedValue = "2";

            string RegAccept = dr["RegestrationAccept"].ToString();
            if (RegAccept == "1")
                rbtAcceptRegistration.SelectedValue = "1";
            else if (RegAccept == "2")
                rbtAcceptRegistration.SelectedValue = "2";

        }


        private void fillGV()
        {

            int ID = Convert.ToInt32(Session["ID"].ToString());
            RegistredCourses obj = new RegistredCourses();
            DataTable tbl1 = obj.dtSearchRegisterSubject(ID);
            gvCourses.DataSource = tbl1;
            gvCourses.DataBind();

        }




     

    }
}