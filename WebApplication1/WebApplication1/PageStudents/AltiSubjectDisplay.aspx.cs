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
    public partial class AltiSubjectDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                fillGv();
            }
            else
            {
                
            }
        }
        private void fillGv()
        {
            int ID = Convert.ToInt32(Session["ID"].ToString());
            AlternativeSub obj = new AlternativeSub();
            DataTable TBL1 = obj.dtViewStudents(ID);
            gvAltiSubject.DataSource = TBL1;
            gvAltiSubject.DataBind();


        }
        protected void gvAltiSubject_RowCommand(object sender, GridViewCommandEventArgs e)
        {



            GridView grid = sender as GridView;

            if (e.CommandName == "dispaly1")
            {

                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int val = (int)this.gvAltiSubject.DataKeys[rowIndex]["ID"];
                Response.Redirect("AltiSubjectAll.aspx?id=" + val);


            }
            else if (e.CommandName == "edit1")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int val = (int)this.gvAltiSubject.DataKeys[rowIndex]["ID"];
                AlternativeSub obj = new AlternativeSub();
                DataRow dr = obj.dreditform(val);
                if (dr == null)
                {
                    fillGv();
                    errorLabel.Text = "لا يمكن تعديل هذا الطلب";
                    errorLabel.Visible = true;
                    errorLabel.ForeColor = Color.Red;
                }
                else
                {
                    Response.Redirect("AltiSubjectUpdate.aspx?id=" + val);


                }

            }
            else if (e.CommandName == "delete")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int val = (int)this.gvAltiSubject.DataKeys[rowIndex]["ID"];
                AlternativeSub obj = new AlternativeSub();
                int del = obj.DeleteAbsenceExamSelected(val);
                errorLabel.Text = del + "";
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
                    errorLabel.ForeColor = Color.DarkGreen;
                }
            }

        }
        public void gvAltiSubject_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            fillGv();
            

        }
        protected void gvAltiSubject_Data(Object sender, GridViewRowEventArgs e)
        {
            for (int i = 2; i <6; i++)
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

    }
}