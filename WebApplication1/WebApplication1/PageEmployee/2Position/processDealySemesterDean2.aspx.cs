using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class processDealySemesterDean2 : System.Web.UI.Page
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
                txtStatus.Text = dr["Description"].ToString();
                labDate.Text = dr["Date"].ToString();
                ddlSemester.Items.Insert(0, new ListItem(dr["Semester"].ToString(), "0"));
                txtYear.Text = dr["Year"].ToString();
                txtDescriptionReg.Text = dr["RegestrationDescr"].ToString();
                
                labDateDean.Text= DateTime.UtcNow.ToString("yyyy-MM-dd");
                string Reg = dr["RegestrationAccept"].ToString();
                if (Reg == "1")
                    rbtAcceptRegistration.SelectedValue = "1";
                else if (Reg == "2")
                    rbtAcceptRegistration.SelectedValue = "2";

            }
        }

        protected void btnSaveDean_Click(object sender, EventArgs e)
        {
            bool Result = false;
            int ID = Convert.ToInt32(Session["ID"].ToString());
            string Path = "";
            string Data = labDate.Text.ToString() + txtYear.Text.ToString() + rbtAcceptRegistration.SelectedValue.ToString() + rbtAcceptDean.SelectedValue.ToString();
            if (fuSignatureDean.HasFile)
            {
                string Private = fuSignatureDean.FileName.ToString();
                Path = System.Web.HttpContext.Current.Server.MapPath("../Test") + "/" + Private;
                string Pasword = txtPassSign.Text.ToString();
                fuSignatureDean.SaveAs(Server.MapPath("../Test") + "/" + fuSignatureDean.FileName);
                SignatureEmployee newSig = new SignatureEmployee();
                string strencrypt = newSig.encrypet(Data, Path, Pasword);
                Result = newSig.Decreypt(strencrypt, ID);

            }

            if (Result == true)
            {
                DelaySemesterClass obj = new DelaySemesterClass();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int AcceptDean = Convert.ToInt32(rbtAcceptDean.SelectedValue.ToString());
                string DeanDescription = txtDescriptionDean.Text.ToString();
                if (obj.AcceptDeanDelaySemester(id, AcceptDean, DeanDescription) == 1)
                {
                    Response.Redirect("ProcessRequest2.aspx");
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