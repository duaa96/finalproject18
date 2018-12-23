using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class processAltiSubjectDean2 : System.Web.UI.Page
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

            AlternativeSub obj = new AlternativeSub();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataRow dr = obj.drgetform(id);

            if (dr != null)
            {
                int STUid = Convert.ToInt32(dr["StudentID"].ToString());
                Studnets objStu = new Studnets();
                DataRow Stu = objStu.drSearchStudent(STUid);
                if (Stu != null)
                {
                    labCollage.Text = Stu["CollageName"].ToString();
                    labNameStudent.Text = Stu["StudentName"].ToString();
                    labNumStudent.Text = Stu["UniversityID"].ToString();
                    labSection.Text = Stu["SectionName"].ToString();
                    labMager.Text = Stu["Mager"].ToString();

                }
                labDateS.Text = dr["Date"].ToString();
                labDateDean.Text = DateTime.UtcNow.ToString("yyyy-MM-dd");
                txtNumberCourse1.Text = dr["Subject1ID"].ToString();
                labTypeCourse1.Text = dr["Subject2Type"].ToString();
                txtReason.Text = dr["Description"].ToString();
                txtAlternativeNum1C1.Text = dr["NewSubject"].ToString();
                string Year = dr["Year"].ToString();
                string Semester = dr["Semester"].ToString();
                Subjects sub = new Subjects();
                if (Convert.ToInt32(txtNumberCourse1.Text.ToString()) != 0)
                {
                    int Course1 = Convert.ToInt32(txtNumberCourse1.Text.ToString());
                    DataRow Sub = sub.drSearchSubject(Course1);
                    labHoursCourse1.Text = Sub["Hours"].ToString();

                    ddlCourse1.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));

                }
                if (Convert.ToInt32(txtAlternativeNum1C1.Text.ToString()) != 0)
                {
                    int Course1 = Convert.ToInt32(txtAlternativeNum1C1.Text.ToString());
                    DataRow Sub = sub.drSearchSubject(Course1);
                    labHoursAlternative.Text = Sub["Hours"].ToString();
                    ddlAlternativeCourse1.Items.Insert(0, new ListItem(Sub["SubjectName"].ToString(), "0"));
                }
                string AcademicAccept = dr["AcademicAdvisorAccept"].ToString();
                if (AcademicAccept == "1")
                    rbtAcademic.SelectedValue = "1";
                else if (AcademicAccept == "2")
                    rbtAcademic.SelectedValue = "2";

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
            string Data = txtNumberCourse1.Text.ToString() + txtAlternativeNum1C1.Text.ToString() +
             labHoursCourse1.Text.ToString() + labHoursAlternative.Text.ToString() + labDateDean.Text.ToString() + rbtDeanAccept.SelectedValue.ToString();
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
                AlternativeSub obj = new AlternativeSub();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int AcceptDean = Convert.ToInt32(rbtDeanAccept.SelectedValue.ToString());
                if (obj.AcceptDeanAltiSubj(id, AcceptDean) == 1)
                {
                    SentMail s = new SentMail();
                    s.sendemailReg();
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