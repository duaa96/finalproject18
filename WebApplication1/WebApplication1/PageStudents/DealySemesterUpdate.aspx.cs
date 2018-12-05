using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class DealySemesterUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Session["ID"].ToString());
                filldata(ID);
            }
        }
        private void filldata(int ID)
        {

            DelaySemesterClass obj = new DelaySemesterClass();
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
                    labStudentNumber.Text = Stu["UniversityID"].ToString();
                    labSection.Text = Stu["SectionName"].ToString();
                    labCollage.Text = Stu["CollageName"].ToString();
                    labMager.Text = Stu["mager"].ToString();

                }

                txtStatus.Text = dr["Description"].ToString();
                labDate.Text = dr["Date"].ToString();
                ddlSemester.SelectedValue = dr["Semester"].ToString();
                txtYear.Text = dr["Year"].ToString();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool Result = false;
            int ID = Convert.ToInt32(Session["ID"]);
            string Path = "";

            string Data = labDate.Text.ToString() + txtYear.Text.ToString();
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
                int row = Convert.ToInt32(Request.QueryString["id"]);
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
                if (obj.UpdateDelaySemester(row, ID, nowYear, nowsemester, year, semester, Reason, Datenow) == 1)
                {
                    txtStatus.Text = "";
                    ddlSemester.SelectedIndex = 0;
                    txtYear.Text = "";
                    SentMail s = new SentMail();
                    s.sendemailReg();
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