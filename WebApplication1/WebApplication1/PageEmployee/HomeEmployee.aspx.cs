using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class HomeEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Session["ID"].ToString());
            Position emp = new Position();
            DataRow dr = emp.drSearchEmployeePosition(ID);
            int position = 0;
            if (dr!=null)
             position = Convert.ToInt32(dr["Position"].ToString());
           
            if (position==5)
            {
                Response.Redirect("HomeReg.aspx");
            }

            
            DataRow dr2 = emp.drSearchEmployeePositionAcadimic(ID);
            int position2=0;
            if (dr2!=null)
             position2 = Convert.ToInt32(dr2["Position"].ToString());

            if(position2==4)
            {
                if (position == 2)
                {
                    Response.Redirect("2Position/HomeEmployee2.aspx");
                }
                else if (position == 3)
                {
                    Response.Redirect("2Position/HomeEmployee2.aspx");
                }
                
                else
                {
                    Response.Redirect("Academic/HomeAcademic.aspx");

                }
            }
            

        }
    }
}