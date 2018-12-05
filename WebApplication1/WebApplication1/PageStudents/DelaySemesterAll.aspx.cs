using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class DelaySemesterAll : System.Web.UI.Page
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
                txtDescriptionDean.Text = dr["DeanDescription"].ToString();
                string Reg = dr["RegestrationAccept"].ToString();
                if (Reg == "1")
                    rbtAcceptRegistration.SelectedValue = "1";
                else if (Reg == "2")
                    rbtAcceptRegistration.SelectedValue = "2";
                string Dean = dr["DeanAccept"].ToString();
                if (Dean == "1")
                    rbtAcceptDean.SelectedValue = "1";
                else if (Dean == "2")
                    rbtAcceptDean.SelectedValue = "2";

            }
        }
    }
}