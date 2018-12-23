using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class InfoUser1 : System.Web.UI.Page
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
            Position po = new Position();
            DataRow dr = po.drSearchEmployeePosition(ID);
            int position = Convert.ToInt32(dr["Position"].ToString());
            if (position == 2)
            {
                labPosition.Text = " عميد الكلية";
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
            else if (position == 3)
            {
                labPosition.Text = "رئيس القسم";
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
            else if (position == 1)
            {
                Employee emp = new Employee();
                DataRow EMPP = emp.drSearchEmployeeINfoAll(ID);
                if (EMPP != null)
                {

                    labEmpName.Text = EMPP["EmpName"].ToString();
                    labNumberEmp.Text = EMPP["EmployeeID"].ToString();
                    labCollege.Text ="";
                    labSection.Text = "";
                    col.Style.Add("display", "none");
                    sec.Style.Add("display", "none");


                }
                labPosition.Text = "نائب أكاديمي";
            }
            else if (position == 4)
            {
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
}