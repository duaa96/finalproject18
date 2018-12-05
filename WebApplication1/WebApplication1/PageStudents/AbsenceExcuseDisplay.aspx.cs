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
    public partial class AbsenceExcuseDisplay : System.Web.UI.Page
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
            AbsenceExam obj = new AbsenceExam();
            DataTable TBL1 = obj.dtViewStudents(ID);
            gvAbsenseExam.DataSource = TBL1;
            gvAbsenseExam.DataBind();


        }

        protected void gvAbsenseExam_RowCommand(object sender, GridViewCommandEventArgs e)
        {



            GridView grid = sender as GridView;

            if (e.CommandName == "dispaly1")
            {

                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int val = (int)this.gvAbsenseExam.DataKeys[rowIndex]["ID"];
                Response.Redirect("AbsenceExamAll.aspx?id=" + val);


            }
            else if (e.CommandName == "edit1")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int val = (int)this.gvAbsenseExam.DataKeys[rowIndex]["ID"];
                AbsenceExam obj = new AbsenceExam();
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
                    Response.Redirect("AbsenceExamUpdate.aspx?id=" + val);


                }

            }
            else if (e.CommandName == "delete")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int val = (int)this.gvAbsenseExam.DataKeys[rowIndex]["ID"];
                AbsenceExam obj = new AbsenceExam();
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
        public void gvAbsenseExam_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            fillGv();

        }
        protected void gvAbsenseExam_Data(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text == "1")
                {
                    e.Row.Cells[2].Text = "موافق";
                }
                else if (e.Row.Cells[2].Text == "2")
                {
                    e.Row.Cells[2].Text = " غير موافق";
                }
                else if (e.Row.Cells[2].Text == "0"|| e.Row.Cells[2].Text is null)
                {
                    e.Row.Cells[2].Text = "لم يتم النظر فيه بعد";
                }

            }
        }

    }
}