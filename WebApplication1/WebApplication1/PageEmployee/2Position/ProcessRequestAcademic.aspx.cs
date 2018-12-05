using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class ProcessRequestAcademic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Session["ID"].ToString());

                fillddl(ID);
            }

        }
        private void fillddl(int ID)
        {




            ddlRequest.Items.Insert(0, new ListItem("<اخترالنموذج>", "0"));
            ddlRequest.Items.Insert(1, new ListItem("مساق بديل للتخرج", "4"));
            ddlRequest.Items.Insert(2, new ListItem("اسقاط فصل دراسي", "5"));



            ddlRequest.AppendDataBoundItems = true;




        }




        protected void ddlRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Session["ID"].ToString());

            if (ddlRequest.SelectedIndex != 0 && ddlRequest.SelectedIndex != -1)
            {

                if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 4)
                {
                    AlternativeSub obj = new AlternativeSub();
                    DataTable dt = obj.dtNotAcceptAliSubAcademicAdvisorApplication(ID);
                    gvRequest.DataSource = dt;
                    gvRequest.DataBind();
                }
                else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 5)
                {
                    DropSemester obj = new DropSemester();
                    DataTable dt = obj.dtNotAcceptDropSemesterAcademicAdvisorApplication(ID);
                    gvRequest.DataSource = dt;
                    gvRequest.DataBind();
                }

            }
        }




        protected void gvRequest_RowCommand(object sender, GridViewCommandEventArgs e)
        {



            GridView grid = sender as GridView;

            if (e.CommandName == "process")
            {

                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int val = (int)this.gvRequest.DataKeys[rowIndex]["IDFORM"];
                int ID = Convert.ToInt32(Session["ID"].ToString());


                if (ddlRequest.SelectedValue.ToString() == "4")
                {

                    Response.Redirect("processAltiSubjectAcadimicAdvisor.aspx?id=" + val);



                }
                else if (ddlRequest.SelectedValue.ToString() == "5")
                {

                    Response.Redirect("processDropSemesterAcadimicAdvisor.aspx?id=" + val);

                }

            }
        }

    }
}

