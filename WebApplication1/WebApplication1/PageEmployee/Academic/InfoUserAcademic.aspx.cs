using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class InfoUserAcademic : System.Web.UI.Page
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
        
          
                labPosition.Text = "مرشد أكاديمي";
            Employee emp = new Employee();
            DataRow EMPP = emp.drSearchEmployeeINfoAll(ID);
            if (EMPP != null)
            {

                labEmpName.Text = EMPP["EmpName"].ToString();
                labNumberEmp.Text = EMPP["EmployeeID"].ToString();
                labCollege.Text = EMPP["CollageName"].ToString();
                labSection.Text = EMPP["SectionName"].ToString();
             

           }
        }
    }
}