using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class DropSemesterUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Session["ID"].ToString());

                fillDataForm(ID);
                fillddl();
            }
        }

        public void fillDataForm(int ID)

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
             
                labDate.Text = DateTime.UtcNow.ToString("yyyy-MM-dd");
                txtNumHours.Text = dr["NumofHourReg"].ToString();
                txtReasons.Text = dr["Description"].ToString();
                string semester = dr["Semester"].ToString();
                string year = dr["Year"].ToString();
              
                RegistredCourses objj = new RegistredCourses();
                DataTable tbl1 = objj.dtSearchRegisterSubjectStu(ID, semester, year);
                gvCourses.DataSource = tbl1;
                gvCourses.DataBind();
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
            gvCourses.DataSource = tbl1;
            gvCourses.DataBind();

        }




        protected void Button1_Click(object sender, EventArgs e)
        {

            bool Result = false;
            int ID = Convert.ToInt32(Session["ID"]);
            string Path = "";

            string Data = DateTime.Today.ToString() + txtNumHours.Text.ToString();
            if (fuSignature.HasFile)
            {
                string Private = fuSignature.FileName.ToString();
                Path = System.Web.HttpContext.Current.Server.MapPath("Test") + "/" + Private;
                string Pasword = txtPassSign.Text.ToString();
                fuSignature.SaveAs(Server.MapPath("Test") + "/" + fuSignature.FileName);
                SignatureStudents newSig = new SignatureStudents();
                string strencrypt = newSig.encrypet(Data, Path, Pasword);
                Result = newSig.Decreypt(strencrypt, ID);


            }
            if (Result == true)
            {
                string date1 = DateTime.Today.ToString();
                string Reason = txtReasons.Text.ToString();
                DropSemester objsem = new DropSemester();
                int NumOFHour = Convert.ToInt32(txtNumHours.Text.ToString());
                int roww = Convert.ToInt32(Request.QueryString["id"]);
                NowTimeUniversity timee = new NowTimeUniversity();
                DataRow T = timee.drSearchYearANdSemester();
                string year = T["NowYear"].ToString();
                string Semester = T["NowSemester"].ToString();
                if (objsem.UpdateDropSemester(roww, ID, year, Semester, Reason, NumOFHour, date1, "", 0, "", 0, "", 0, "", 0, 0,"", 2) == 1)
                {
                    Response.Redirect("DropSemesterDisplay.aspx");
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