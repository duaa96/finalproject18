using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class employee : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int ID = Convert.ToInt32(Session["ID"].ToString());
            //Position emp = new Position();
            //DataRow dr = emp.drSearchEmployeePositionAcadimic(ID);
            //int position=0;
            //if (dr!=null)
            //   position = Convert.ToInt32(dr["Position"].ToString());

            //if(position==4)
            // Academic.Style.Add("display", "block");
           
            // dr = emp.drSearchEmployeePosition(ID);
            //int otherposition = 0;
            //if (dr!=null)
            //    otherposition = Convert.ToInt32(dr["Position"].ToString());
            //if(otherposition==0)
            //{
            //    position2.Style.Add("display", "none");
            //}
        }
    }
}