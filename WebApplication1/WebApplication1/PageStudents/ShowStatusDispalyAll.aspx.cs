using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class ShowStatusDispalyAll : System.Web.UI.Page
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
                txtStatus.Text = dr["Description"].ToString();
                labDate.Text = dr["Date"].ToString();
                txtDescriptionHead.Text = dr["HeadDescription"].ToString();
                string HeadAccept = dr["HeadAccept"].ToString();
                if (HeadAccept == "1")
                    rbtAceptHead.SelectedValue = "1";
                else if (HeadAccept == "2")
                    rbtAceptHead.SelectedValue = "2";
                txtDescriptionDean.Text = dr["DeanDescription"].ToString();
                string DeanAccept = dr["DeanAccept"].ToString();
                if (DeanAccept == "1")
                    rbtAcceptDean.SelectedValue = "1";
                else if (DeanAccept == "2")
                    rbtAcceptDean.SelectedValue = "2";
            }
        }
    }
}