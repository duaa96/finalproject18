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
    public partial class DelaySemester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Session["ID"].ToString());
                Application validatinTime = new Application();
                DataRow dr = validatinTime.drSearchApplication(DateTime.Today, 6);
                if (dr != null)
                {
                    filldata(ID);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('هذا النموذج غير متاح حاليا');window.location ='HomeStudent.aspx';", true);

                }
            }
        }

        private void filldata(int ID)
        {
            Studnets objStu = new Studnets();
            DataRow Stu = objStu.drSearchStudent(ID);
            if (Stu != null)
            {
                labCollage.Text = Stu["CollageName"].ToString();
                labStudentName.Text = Stu["StudentName"].ToString();
                labStudentNumber.Text = Stu["UniversityID"].ToString();
                labSection.Text = Stu["SectionName"].ToString();
                labMager.Text = Stu["Mager"].ToString();
            }
            labDate.Text = DateTime.UtcNow.ToString("yyyy-MM-dd");
            ddlSemester.Items.Insert(0, new ListItem("<اخترالفصل>", "0"));
         
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool Result = false;
            int ID = Convert.ToInt32(Session["ID"]);
            string Path = "";

            string Data = labDate.Text.ToString()+ txtYear.Text.ToString() ;
            if (fuSignatureStudent.HasFile)
            {
                string Private = fuSignatureStudent.FileName.ToString();
                Path = System.Web.HttpContext.Current.Server.MapPath("Test") + "/" + fuSignatureStudent.FileName.ToString();
                fuSignatureStudent.SaveAs(Server.MapPath("Test") + "/" + fuSignatureStudent.FileName);
                SignatureStudents newSig = new SignatureStudents();
                string Pasword = txtPassSign.Text.ToString();

                 string strencrypt = newSig.encrypet(Data, Path, Pasword);
                Result = newSig.Decreypt(strencrypt, ID);

            }

            if (Result == true)
            {
                string Reason = "";
                string year = "";
                string semester = "";
                if (txtStatus.Text != string.Empty)
                    Reason = txtStatus.Text.ToString();
                if (txtYear.Text != string.Empty)
                    year = txtYear.Text.ToString();
                if (ddlSemester.SelectedIndex != 0 && ddlSemester.SelectedIndex != -1)
                    semester = ddlSemester.Text.ToString();
                DelaySemesterClass obj = new DelaySemesterClass();
                string Datenow = labDate.Text.ToString();
                NowTimeUniversity timee = new NowTimeUniversity();
                DataRow T = timee.drSearchYearANdSemester();
                string nowsemester = T["NowSemester"].ToString();
                string nowYear = T["NowYear"].ToString();
                if (obj.AddDelaySemester(ID, nowYear, nowsemester, year, semester, Reason, Datenow,"",0,"","",0,"",6) == 1)
                {
                    txtStatus.Text = "";
                    ddlSemester.SelectedIndex= 0;
                    txtYear.Text = "";
                    SentMail s = new SentMail();
                    s.sendemailReg();
                    Response.Redirect("HomeStudent.aspx");

                }
                errorLabel.Visible = false;

            }
            else
            {
                errorLabel.Text = " التوقيع المدخل خاطئ أو كلمة المرور";
                errorLabel.Visible = true;
            }

        }
    }
}