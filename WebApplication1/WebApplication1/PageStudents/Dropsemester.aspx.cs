using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.PageStudents;

namespace WebApplication1
{
    public partial class Dropsemester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Session["ID"].ToString());

                fillDataForm(ID);
                fillddl();
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
                labNameStudent.Text = Stu["StudentName"].ToString();
                labNumStudent.Text = Stu["UniversityID"].ToString();
                labSection.Text = Stu["SectionName"].ToString();

            }
            labDate.Text = DateTime.UtcNow.ToString("yyyy-MM-dd");
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
            int RegHours = 0;
            for (int i = 0; i < tbl1.Rows.Count; i++)
            {
                DataRow dr = tbl1.Rows[i];
                RegHours = RegHours + Convert.ToInt32(dr["Hours"].ToString());

            }

            txtNumHours.Text = RegHours + "";

        }




        protected void Button1_Click(object sender, EventArgs e)
        {

            bool Result = false;
            int ID = Convert.ToInt32(Session["ID"]);
            string Path = "";

            string Data = labDate.Text.ToString()+ txtNumHours.Text.ToString(); 
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
                string date1 = labDate.Text.ToString();
                string Reason = txtReasons.Text.ToString();
                DropSemester objsem = new DropSemester();
                int NumOFHour = Convert.ToInt32(txtNumHours.Text.ToString());
                NowTimeUniversity timee = new NowTimeUniversity();
                DataRow T = timee.drSearchYearANdSemester();
                string semester = T["NowSemester"].ToString();
                string Year = T["NowYear"].ToString();

                if (objsem.AddDropSemester(ID, Year, semester, Reason, NumOFHour, date1, "", 0, "", 0, "", 0, "", 0,0, "", 2) == 1)
                {
                    txtReasons.Text = "";
                    SentMail s = new SentMail();
                    s.sendemailAcadimic(ID);
                }
                errorLabel.Visible = false;
            }
            else
            {
                errorLabel.Text = " التوقيع المدخل خاطئ أو كلمة المرور";
                errorLabel.Visible = true;
            }
        }
        protected void gvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}