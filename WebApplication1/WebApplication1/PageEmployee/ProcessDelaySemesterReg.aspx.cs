using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class ProcessDelaySemesterReg : System.Web.UI.Page
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
                labDateReg.Text= DateTime.UtcNow.ToString("yyyy-MM-dd");
                txtStatus.Text = dr["Description"].ToString();
                labDate.Text = dr["Date"].ToString();
                ddlSemester.Items.Insert(0, new ListItem(dr["Semester"].ToString(), "0"));
                txtYear.Text = dr["Year"].ToString();

            }
        }

        protected void btnSaveReg_Click(object sender, EventArgs e)
        {
            bool Result = false;
            int ID = Convert.ToInt32(Session["ID"].ToString());
            string Path = "";
            string Data = labDate.Text.ToString() + txtYear.Text.ToString()+rbtAcceptRegistration.SelectedValue.ToString();
            if (fuSignatureReg.HasFile)
            {
                string Private = fuSignatureReg.FileName.ToString();
                Path = System.Web.HttpContext.Current.Server.MapPath("Test") + "/" + Private;
                string Pasword = txtPassSign.Text.ToString();
                fuSignatureReg.SaveAs(Server.MapPath("Test") + "/" + fuSignatureReg.FileName);
                SignatureEmployee newSig = new SignatureEmployee();
                string strencrypt = newSig.encrypet(Data, Path, Pasword);
                Result = newSig.Decreypt(strencrypt, ID);

            }

            if (Result == true)
            {
                DelaySemesterClass obj = new DelaySemesterClass();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int Acceptreg = Convert.ToInt32(rbtAcceptRegistration.SelectedValue.ToString());
                string RegestrationDescr = txtDescriptionReg.Text.ToString();
                if (obj.AcceptRegDelaySemester(id, Acceptreg, RegestrationDescr) == 1)
                {
                    DataRow dr = obj.drgetform(id);
                    int STUid = Convert.ToInt32(dr["StudentID"].ToString());

                    SentMail s = new SentMail();
                    s.sendemailDean(STUid);
                    Response.Redirect("ProcessRequest.aspx");
                }

                errorReg.Visible = false;

            }
            else
            {
                errorReg.Text = "التوقيع المدخل خاطئ او كلمة المرور";
                errorReg.Visible = true;
            }
        }
    }
}