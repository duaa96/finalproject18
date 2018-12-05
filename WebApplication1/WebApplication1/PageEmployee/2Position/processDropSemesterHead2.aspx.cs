using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class processDropSemesterHead2 : System.Web.UI.Page
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
                labDateHead.Text = DateTime.UtcNow.ToString("yyyy-MM-dd");
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
                string Acadimic = dr["AcademicAdvisorAccept"].ToString();
                if (Acadimic == "1")
                    rbtAcceptAcadimic.SelectedValue = "1";
                else if (Acadimic == "2")
                    rbtAcceptAcadimic.SelectedValue = "2";



            }
        }

        protected void btnSaveHead_Click(object sender, EventArgs e)
        {
            bool Result = false;
            int ID = Convert.ToInt32(Session["ID"].ToString());
            string Path = "";
            string Data = DateTime.Today.ToString() + txtNumHours.Text.ToString() + labDate.Text.ToString()+rbtAceptHead.SelectedValue.ToString()+rbtAcceptAcadimic.SelectedValue.ToString();
            if (fuSignatureHead.HasFile)
            {
                string Private = fuSignatureHead.FileName.ToString();
                Path = System.Web.HttpContext.Current.Server.MapPath("Test") + "/" + Private;
                string Pasword = txtPassSign.Text.ToString();
                fuSignatureHead.SaveAs(Server.MapPath("Test") + "/" + fuSignatureHead.FileName);
                SignatureEmployee newSig = new SignatureEmployee();
                string strencrypt = newSig.encrypet(Data, Path, Pasword);
                Result = newSig.Decreypt(strencrypt, ID);

            }

            if (Result == true)
            {
                DropSemester obj = new DropSemester();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int AcceptHead = Convert.ToInt32(rbtAceptHead.SelectedValue.ToString());
                string HeadDec = txtDescriptionHead.Text.ToString();
                if (obj.AcceptHeadDropSemester(id, AcceptHead, HeadDec) == 1)
                {
                    DataRow dr = obj.drgetform(id);
                    int STUid = Convert.ToInt32(dr["StudentID"].ToString());

                    SentMail s = new SentMail();
                    s.sendemailDean(STUid);
                    Response.Redirect("ProcessRequest2.aspx");
                }

                errorHead.Visible = false;

            }
            else
            {
                errorHead.Text = "التوقيع المدخل خاطئ او كلمة المرور";
                errorHead.Visible = true;
            }
        }
    }
}
