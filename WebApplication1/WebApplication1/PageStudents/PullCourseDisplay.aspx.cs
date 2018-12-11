using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class PullCourseDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                fillGv();
            }
            else
            {
                errorLabel.Visible = false;
            }
        }

        private void fillGv()
        {
            int ID = Convert.ToInt32(Session["ID"].ToString());
            PullCourseClass obj = new PullCourseClass();
            DataTable TBL1 = obj.dtViewStudents(ID);
            gvPullCourse.DataSource = TBL1;
            gvPullCourse.DataBind();
            
           
        }





        protected void gvPullCourse_Data(Object sender, GridViewRowEventArgs e)
        {
            for (int i = 2; i < 5; i++)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.Cells[i].Text == "1")
                    {
                        e.Row.Cells[i].Text = "موافق";
                    }
                    else if (e.Row.Cells[i].Text == "2")
                    {
                        e.Row.Cells[i].Text = " غير موافق";
                    }
                    else if (e.Row.Cells[i].Text == "0" || e.Row.Cells[i].Text is null)
                    {
                        e.Row.Cells[i].Text = "لم يتم النظر فيه بعد";
                    }

                }
            }
        }

        protected void gvPullCourseView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            

            GridView grid = sender as GridView;

            if (e.CommandName == "dispaly1")
            {

                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int val = (int)this.gvPullCourse.DataKeys[rowIndex]["ID"];
                Response.Redirect("PullCourseDispalyAll.aspx?id=" + val);


            }
            else if (e.CommandName == "edit1")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int val = (int)this.gvPullCourse.DataKeys[rowIndex]["ID"];
                PullCourseClass obj = new PullCourseClass();
                DataRow dr = obj.dreditform(val);
                if (dr ==null)
                {
                    fillGv();
                    errorLabel.Text = "لا يمكن تعديل هذا الطلب";
                    errorLabel.Visible = true;
                    errorLabel.ForeColor = Color.Red;
                }
                else
                {
                    Response.Redirect("PullCourseUpdate.aspx?id="+val);


                }

            }
            else if (e.CommandName == "delete")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int val = (int)this.gvPullCourse.DataKeys[rowIndex]["ID"];
                PullCourseClass obj = new PullCourseClass();
               int del= obj.DeletePullCourseSelected(val);
                errorLabel.Text = del+"";
                errorLabel.Visible = true;
                if (del == 0)
                {
                    errorLabel.Text = "لا يمكن حذف هذا الطلب لأنه  مكتمل";
                    errorLabel.Visible = true;
                    errorLabel.ForeColor = Color.Red;
                }
                if (del == 1)
                {
                    errorLabel.Text = "تمت العملية بنجاح";
                    errorLabel.Visible = true;
                    errorLabel.ForeColor =Color.DarkGreen;
                }
            }

        }
        public void gvPullCoursedelete_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            fillGv();
            
        }

    }
}