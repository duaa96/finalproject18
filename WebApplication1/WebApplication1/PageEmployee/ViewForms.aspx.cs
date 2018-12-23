using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class ViewForms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Session["ID"].ToString());

                fillddl(ID);
            }
        }

        private void fillddl(int iD)
        {
            ddlRequest.Items.Insert(0, new ListItem("<اخترالنموذج>", "0"));
            ddlRequest.Items.Insert(1, new ListItem("عرض حال", "1"));
            ddlRequest.Items.Insert(2, new ListItem("اسقاط مادة", "2"));
            ddlRequest.Items.Insert(3, new ListItem("عذر غياب عن امتحان نهائي", "3"));
            ddlRequest.Items.Insert(4, new ListItem("مساق بديل للتخرج", "4"));
            ddlRequest.Items.Insert(5, new ListItem("اسقاط فصل دراسي", "5"));
            ddlRequest.Items.Insert(6, new ListItem("تأجيل فصل دراسي", "6"));
        }

        protected void ddlRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRequest.SelectedIndex != 0 && ddlRequest.SelectedIndex != -1)
            {
                if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 1)
                {
                  //  ShowStatusClass obj = new ShowStatusClass();
                   // DataTable dt = obj.dtGetAll();
                   // gvRequest.DataSource = dt;
                  //  gvRequest.DataBind();
                }
                else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 2)
                {
                    //PullCourseClass obj = new PullCourseClass();
                    //DataTable dt = obj.dtNotAcceptDeanPullCourseApplication(Collegeid);
                    //gvRequest.DataSource = dt;
                    //gvRequest.DataBind();
                }
                else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 3)
                {
                    //AbsenceExam obj = new AbsenceExam();
                    //DataTable dt = obj.dtNotAcceptDeanAbsenceExamApplication(Collegeid);
                    //gvRequest.DataSource = dt;
                    //gvRequest.DataBind();
                }
                else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 4)
                {
                    //AlternativeSub obj = new AlternativeSub();
                    //DataTable dt = obj.dtNotAcceptDeanAltSubApplication(Collegeid);
                    //gvRequest.DataSource = dt;
                    //gvRequest.DataBind();
                }
                else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 5)
                {
                    DropSemester obj = new DropSemester();
                    DataTable dt = obj.dtGetAll();
                    gvRequest.DataSource = dt;
                    gvRequest.DataBind();
                }
                else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 6)
                {
                    //DelaySemesterClass obj = new DelaySemesterClass();
                    //DataTable dt = obj.dtNotAcceptDeanDelaySemesterApplication(Collegeid);
                    //gvRequest.DataSource = dt;
                    //gvRequest.DataBind();
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
                Position emp = new Position();
                DataRow dr = emp.drSearchEmployeePosition(ID);
                int position = Convert.ToInt32(dr["Position"].ToString());

                if (ddlRequest.SelectedValue.ToString() == "1")
                {


                }
                else if (ddlRequest.SelectedValue.ToString() == "2")
                {


                }
                else if (ddlRequest.SelectedValue.ToString() == "3")
                {

                }
                else if (ddlRequest.SelectedValue.ToString() == "4")
                {

                   

                }
                else if (ddlRequest.SelectedValue.ToString() == "5")
                {
                    Response.Redirect("PdfForm/DropSemesterpdf.aspx?id=" + val);
                    

                }
                else if (ddlRequest.SelectedValue.ToString() == "6")
                {

                }
            }
        }
    }
}