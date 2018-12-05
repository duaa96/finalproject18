using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1.PageEmployee
{
    public partial class ManageRequest : System.Web.UI.Page
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
            Application objj = new Application();
            DataTable tbl1 = objj.dtApplication();
            gvRequest.DataSource = tbl1;
            gvRequest.DataBind();
        }
        protected void gvRequest_Data(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text == "1")
                {
                    e.Row.Cells[2].Text = "مفعل";
                }
                else
                {
                    e.Row.Cells[2].Text = " غير مفعل";
                }


            }
        }
        protected void gvRequest_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "save")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int val = (int)this.gvRequest.DataKeys[rowIndex]["ApplicationID"];
                Application app = new Application();
                string date1 = ((TextBox)gvRequest.Rows[rowIndex].FindControl("txtdate")).Text;
                int n=0;
                DateTime date2 = Convert.ToDateTime(date1);
                DateTime datenow = Convert.ToDateTime(DateTime.UtcNow.ToString("yyyy-MM-dd"));
               
                if( date2> datenow)
                {
                    n = 1;
                }
                else
                {
                    n = 2;
                }
                if (app.UpdateApplicationtime(val, n, date1) == 1)
                {
                    gvRequest.EditIndex = -1;
                    fillData();

                }
            }
        }

        protected void gvRequest_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvRequest.EditIndex = e.NewEditIndex;
            fillData();
        }

        protected void btnSaveDean_Click(object sender, EventArgs e)
        {
            if(txtYear.Text.ToString()!="" && ddlSemester.SelectedIndex != 0 && ddlSemester.SelectedIndex != -1)
            {
                string semester = ddlSemester.SelectedItem.ToString();
                int  year =Convert.ToInt32( txtYear.Text.ToString());
                NowTimeUniversity time = new NowTimeUniversity();
                if(time.UpdateTime(year, semester) == 1)
                {
                    ddlSemester.SelectedIndex = 0;
                    txtYear.Text = "";
                }
            } 
            else
            {
                string snackbarScript= GenerateSnackbarJS();
                Snack.Text = "Here's the snackbar";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "snackbar", snackbarScript, true);
            }
        }
        private string GenerateSnackbarJS()
        {
            var sb = new StringBuilder();
            sb.AppendLine("var x = document.getElementById('snackbar');");
            sb.AppendLine("x.className = 'show';");
            sb.AppendLine("setTimeout(function(){ x.className = x.className.replace('show', ''); }, 3000);");
            return sb.ToString();
        }
    }
}