using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class NSig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Session["ID"].ToString());
            fillData();
        }
        private void fillData()
        {
            int ID = Convert.ToInt32(Session["ID"].ToString());

            Studnets loginStudent = new Studnets();
            DataRow loginS = loginStudent.drSearchStudentEmail(ID);
            labEmail.Text = loginS["Email"].ToString();
        }
        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Session["ID"].ToString());
            Studnets loginStudent = new Studnets();
            DataRow loginS = loginStudent.drSearchStudentEmail(ID);
            string email = loginS["Email"].ToString();
            SentMail S = new SentMail();
            S.sendemailNewSignature(email, ID);
        }
    }
}