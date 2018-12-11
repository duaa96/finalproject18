using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class processDeopSemesterReg : System.Web.UI.Page
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
                labDateReg.Text = DateTime.UtcNow.ToString("yyyy-MM-dd");
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
                txtDescriptionReg.Text = dr["RegestrationDescr"].ToString();
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
                string RegAcept = dr["DeanAccept"].ToString();
                if (RegAcept == "1")
                    rbtAcceptRegistration.SelectedValue = "1";
                else if (RegAcept == "2")
                    rbtAcceptRegistration.SelectedValue = "2";
            }
        }

        protected void btnSaveReg_Click(object sender, EventArgs e)
        {
            bool Result = false;
            int ID = Convert.ToInt32(Session["ID"].ToString());
            string Path = "";
            string Data = DateTime.Today.ToString() + txtNumHours.Text.ToString() + labDate.Text.ToString() + rbtAceptHead.SelectedValue.ToString() + rbtAcceptAcadimic.SelectedValue.ToString()
                + rbtDeanAccept.SelectedValue.ToString() + rbtDepAcept.SelectedValue.ToString()+rbtAcceptRegistration.SelectedValue.ToString();
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
                DropSemester obj = new DropSemester();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int AcceptReg = Convert.ToInt32(rbtAcceptRegistration.SelectedValue.ToString());
                string RegDec = txtDescriptionReg.Text.ToString();
                if (obj.AcceptRegDropSemester(id, AcceptReg, RegDec) == 1)
                {
                    DataRow dr = obj.drgetform(id);
                    int STUid = Convert.ToInt32(dr["StudentID"].ToString());
                    SentMail s = new SentMail();
                    s.sendemailStudent(STUid);
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