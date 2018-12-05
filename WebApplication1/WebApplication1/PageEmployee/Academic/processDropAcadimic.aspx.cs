using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class processDropAcadimic : System.Web.UI.Page
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
                txtReasons.Text = dr["Description"].ToString();
                labDateAcadimic.Text = DateTime.UtcNow.ToString("yyyy-MM-dd");
                txtNumHours.Text = dr["NumofHourReg"].ToString();
                string semester = dr["Semester"].ToString();
                string year = dr["Year"].ToString();
                int ID = Convert.ToInt32(dr["StudentID"].ToString());
                RegistredCourses objj = new RegistredCourses();
                DataTable tbl1 = objj.dtSearchRegisterSubjectStu(ID, semester, year);
                gvCourses.DataSource = tbl1;
                gvCourses.DataBind();




            }
        }

        protected void btnSaveHead_Click(object sender, EventArgs e)
        {
            bool Result = false;
            int ID = Convert.ToInt32(Session["ID"].ToString());
            string Path = "";
            string Data = DateTime.Today.ToString() + txtNumHours.Text.ToString() + labDate.Text.ToString();
            if (fuSignatureAcadimic.HasFile)
            {
                string Private = fuSignatureAcadimic.FileName.ToString();
                Path = System.Web.HttpContext.Current.Server.MapPath("Test") + "/" + Private;
                string Pasword = txtPassSign.Text.ToString();
                fuSignatureAcadimic.SaveAs(Server.MapPath("Test") + "/" + fuSignatureAcadimic.FileName);
                SignatureEmployee newSig = new SignatureEmployee();
                string strencrypt = newSig.encrypet(Data, Path, Pasword);
                Result = newSig.Decreypt(strencrypt, ID);

            }

            if (Result == true)
            {
                DropSemester obj = new DropSemester();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int AcceptAcadimic = Convert.ToInt32(rbtAcceptAcadimic.SelectedValue.ToString());
                string AcadimicDec = txtDescriptionAcadimic.Text.ToString();
                if (obj.AcceptAcademicAdvisorDropSemester(id, AcceptAcadimic, AcadimicDec) == 1)
                {
                    DataRow dr = obj.drgetform(id);
                    int STUid = Convert.ToInt32(dr["StudentID"].ToString());

                    SentMail s = new SentMail();
                    s.sendemailHead(STUid);
                    Response.Redirect("ProcessRequest.aspx");
                }

                errorAcadimic.Visible = false;

            }
            else
            {
                errorAcadimic.Text = "التوقيع المدخل خاطئ او كلمة المرور";
                errorAcadimic.Visible = true;
            }
        }
    }
}