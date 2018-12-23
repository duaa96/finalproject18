using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
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
            Employee emp = new Employee();
            int ID = Convert.ToInt32(Session["ID"].ToString());
            DataRow EMPP = emp.drSearchEmployeeINfoAll(ID);
            if (EMPP != null)
            {

                labEmpName.Text = EMPP["EmpName"].ToString();
                labNumberEmp.Text = EMPP["EmployeeID"].ToString();

                labPosition.Text = "التسجيل ";
            }
        }
    }
}