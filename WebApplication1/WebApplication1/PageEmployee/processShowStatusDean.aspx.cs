using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class processShowStatusDean : System.Web.UI.Page
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

            ShowStatusClass obj = new ShowStatusClass();
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
                labDateDean.Text= DateTime.UtcNow.ToString("yyyy-MM-dd");
                txtStatus.Text = dr["Description"].ToString();
                labDate.Text = dr["Date"].ToString();
                txtDescriptionHead.Text = dr["HeadDescription"].ToString();
                string HeadAccept = dr["HeadAccept"].ToString();
                if (HeadAccept == "1")
                    rbtAceptHead.SelectedValue = "1";
                else if (HeadAccept == "2")
                    rbtAceptHead.SelectedValue = "2";
            }
        }

        protected void btnSaveDean_Click(object sender, EventArgs e)
        {
            bool Result = false;
            int ID = Convert.ToInt32(Session["ID"].ToString());
            string Path = "";
            string Data = labDate.Text.ToString() + labStudentNumber.Text.ToString()+rbtAceptHead.SelectedValue.ToString()+rbtAcceptDean.SelectedValue.ToString();
            if (fuSignatureDean.HasFile)
            {
                string Private = fuSignatureDean.FileName.ToString();
                Path = System.Web.HttpContext.Current.Server.MapPath("Test") + "/" + Private;
                string Pasword = txtPassSign.Text.ToString();
                fuSignatureDean.SaveAs(Server.MapPath("Test") + "/" + fuSignatureDean.FileName);
                SignatureEmployee newSig = new SignatureEmployee();
                string strencrypt = newSig.encrypet(Data, Path, Pasword);
                Result = newSig.Decreypt(strencrypt, ID);

            }

            if (Result == true)
            {
                ShowStatusClass obj = new ShowStatusClass();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int AcceptDean = Convert.ToInt32(rbtAcceptDean.SelectedValue.ToString());
                string DeanDec = txtDescriptionDean.Text.ToString();
                if (obj.AcceptDeanShowStatus(id, AcceptDean, DeanDec) == 1)
                {
                    DataRow dr = obj.drgetform(id);
                    int STUid = Convert.ToInt32(dr["StudentID"].ToString());
                    SentMail s = new SentMail();
                    s.sendemailStudent(STUid);
                    Response.Redirect("ProcessRequest.aspx");
                }

                errorDean.Visible = false;

            }
            else
            {
                errorDean.Text = "التوقيع المدخل خاطئ او كلمة المرور";
                errorDean.Visible = true;
            }
        }
    }
}