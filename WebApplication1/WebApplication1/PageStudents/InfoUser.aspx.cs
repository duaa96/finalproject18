using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class InfoUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Session["ID"].ToString());


                fillDataForm(ID);


            }
        }
            private void fillDataForm(int iD)
            {

            int ID = Convert.ToInt32(Session["ID"].ToString());

            Studnets objStu = new Studnets();
                DataRow Stu = objStu.drSearchStudent(ID);
                if (Stu != null)
                {
                    labCollage.Text = Stu["CollageName"].ToString();
                    labStudentName.Text = Stu["StudentName"].ToString();
                    labNumberStudent.Text = Stu["UniversityID"].ToString();
                    labSectionStudent.Text = Stu["SectionName"].ToString();
                }

            }
        }

        
    }