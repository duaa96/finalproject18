using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
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

            Employee loginStudent = new Employee();
            DataRow loginS = loginStudent.drSearchEmployeeEmail(ID);
            labEmail.Text = loginS["Email"].ToString();
        }
        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Session["ID"].ToString());
            Employee loginEmp = new Employee();
            DataRow loginS = loginEmp.drSearchEmployeeEmail(ID);
            string email = loginS["Email"].ToString();
            SentMail S = new SentMail();
            S.sendemailNewSignatureEmp(email, ID);
        }
    }
}