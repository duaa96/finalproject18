using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class ProcessRequest2 : System.Web.UI.Page
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
            Position emp = new Position();
            DataRow dr = emp.drSearchEmployeePosition(ID);
            int position = 0;
            if (dr != null)
                position = Convert.ToInt32(dr["Position"].ToString());


            if (position == 1)
            {
                ddlRequest.Items.Insert(0, new ListItem("<اخترالنموذج>", "0"));

                ddlRequest.Items.Insert(1, new ListItem("اسقاط فصل دراسي", "5"));

            }
            else if (position == 2)
            {
                ddlRequest.Items.Insert(0, new ListItem("<اخترالنموذج>", "0"));
                ddlRequest.Items.Insert(1, new ListItem("عرض حال", "1"));
                ddlRequest.Items.Insert(2, new ListItem("اسقاط مادة", "2"));
                ddlRequest.Items.Insert(3, new ListItem("عذر غياب عن امتحان نهائي", "3"));
                ddlRequest.Items.Insert(4, new ListItem("مساق بديل للتخرج", "4"));
                ddlRequest.Items.Insert(5, new ListItem("اسقاط فصل دراسي", "5"));
                ddlRequest.Items.Insert(6, new ListItem("تأجيل فصل دراسي", "6"));


                ddlRequest.AppendDataBoundItems = true;


            }
            else if (position == 3)
            {
                ddlRequest.Items.Insert(0, new ListItem("<اخترالنموذج>", "0"));

                ddlRequest.Items.Insert(1, new ListItem("مساق بديل للتخرج", "4"));
                ddlRequest.Items.Insert(2, new ListItem("اسقاط فصل دراسي", "5"));
                ddlRequest.Items.Insert(3, new ListItem("اسقاط مادة", "2"));
                ddlRequest.Items.Insert(4, new ListItem("عرض حال", "1"));
            }

            else if (position == 5)
            {
                ddlRequest.Items.Insert(0, new ListItem("<اخترالنموذج>", "0"));
                ddlRequest.Items.Insert(1, new ListItem("مساق بديل للتخرج", "4"));
                ddlRequest.Items.Insert(2, new ListItem("اسقاط فصل دراسي", "5"));
                ddlRequest.Items.Insert(3, new ListItem("تأجيل فصل دراسي", "6"));
                ddlRequest.Items.Insert(4, new ListItem("اسقاط مادة", "2"));

            }



        }




        protected void ddlRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Session["ID"].ToString());
            Position emp = new Position();
            DataRow dr = emp.drSearchEmployeePosition(ID);
            int position = Convert.ToInt32(dr["Position"].ToString());

            if (position == 2)
            {
                Employee info = new Employee();
                DataRow section = info.drSearchEmployeeSection(ID);
                int sec = Convert.ToInt32(section["SectionID"].ToString());
                College col = new College();
                DataRow college = col.drSearchColloge(sec);
                int Collegeid = Convert.ToInt32(college["CollegeID"].ToString());
                if (ddlRequest.SelectedIndex != 0 && ddlRequest.SelectedIndex != -1)
                {
                    if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 1)
                    {
                        ShowStatusClass obj = new ShowStatusClass();
                        DataTable dt = obj.dtNotAcceptDeanShowStatusApplication(Collegeid);
                        gvRequest.DataSource = dt;
                        gvRequest.DataBind();
                    }
                    else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 2)
                    {
                        PullCourseClass obj = new PullCourseClass();
                        DataTable dt = obj.dtNotAcceptDeanPullCourseApplication(Collegeid);
                        gvRequest.DataSource = dt;
                        gvRequest.DataBind();
                    }
                    else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 3)
                    {
                        AbsenceExam obj = new AbsenceExam();
                        DataTable dt = obj.dtNotAcceptDeanAbsenceExamApplication(Collegeid);
                        gvRequest.DataSource = dt;
                        gvRequest.DataBind();
                    }
                    else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 4)
                    {
                        AlternativeSub obj = new AlternativeSub();
                        DataTable dt = obj.dtNotAcceptDeanAltSubApplication(Collegeid);
                        gvRequest.DataSource = dt;
                        gvRequest.DataBind();
                    }
                    else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 5)
                    {
                        DropSemester obj = new DropSemester();
                        DataTable dt = obj.dtNotAcceptDeanDropSemesterApplication(Collegeid);
                        gvRequest.DataSource = dt;
                        gvRequest.DataBind();
                    }
                    else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 6)
                    {
                        DelaySemesterClass obj = new DelaySemesterClass();
                        DataTable dt = obj.dtNotAcceptDeanDelaySemesterApplication(Collegeid);
                        gvRequest.DataSource = dt;
                        gvRequest.DataBind();
                    }
                }
            }
            else if (position == 3)
            {
                Employee info = new Employee();
                DataRow section = info.drSearchEmployeeSection(ID);
                int sec = Convert.ToInt32(section["SectionID"].ToString());
                if (ddlRequest.SelectedIndex != 0 && ddlRequest.SelectedIndex != -1)
                {
                    if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 1)
                    {
                        ShowStatusClass obj = new ShowStatusClass();
                        DataTable dt = obj.dtNotAcceptHeadShowStatusApplication(sec);
                        gvRequest.DataSource = dt;
                        gvRequest.DataBind();
                    }
                    else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 2)
                    {
                        PullCourseClass obj = new PullCourseClass();
                        DataTable dt = obj.dtNotAcceptHeadPullCourseApplication(sec);
                        gvRequest.DataSource = dt;
                        gvRequest.DataBind();
                    }

                    else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 4)
                    {
                        AlternativeSub obj = new AlternativeSub();
                        DataTable dt = obj.dtNotAcceptHeadAltSubApplication(sec);
                        gvRequest.DataSource = dt;
                        gvRequest.DataBind();
                    }
                    else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 5)
                    {
                        DropSemester obj = new DropSemester();
                        DataTable dt = obj.dtNotAcceptHeadDropSemesterApplication(sec);
                        gvRequest.DataSource = dt;
                        gvRequest.DataBind();
                    }

                }
            }
            else if (position == 5)
            {
                if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 6)
                {
                    DelaySemesterClass obj = new DelaySemesterClass();
                    DataTable dt = obj.dtNotAcceptRegestDelaySemesterApplication();
                    gvRequest.DataSource = dt;
                    gvRequest.DataBind();
                }
                else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 2)
                {
                    PullCourseClass obj = new PullCourseClass();
                    DataTable dt = obj.dtNotAcceptRegPullCourseApplication();
                    gvRequest.DataSource = dt;
                    gvRequest.DataBind();
                }

                else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 4)
                {
                    AlternativeSub obj = new AlternativeSub();
                    DataTable dt = obj.dtNotAcceptHeadAltSubApplication();
                    gvRequest.DataSource = dt;
                    gvRequest.DataBind();
                }
                else if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 5)
                {
                    DropSemester obj = new DropSemester();
                    DataTable dt = obj.dtNotAcceptRegDropSemesterApplication();
                    gvRequest.DataSource = dt;
                    gvRequest.DataBind();
                }
            }
            else if (position == 1)
            {

                if (Convert.ToInt32(ddlRequest.SelectedValue.ToString()) == 5)
                {
                    DropSemester obj = new DropSemester();
                    DataTable dt = obj.dtNotAcceptDeputyAcademicAcceptDropSemesterApplication();
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
                Position emp = new Position();
                DataRow dr = emp.drSearchEmployeePosition(ID);
                int position = Convert.ToInt32(dr["Position"].ToString());

                if (ddlRequest.SelectedValue.ToString() == "1")
                {
                    if (position == 3)
                        Response.Redirect("processShowStatusHead2.aspx?id=" + val);

                    else if (position == 2)
                        Response.Redirect("processShowStatusDean2.aspx?id=" + val);

                }
                else if (ddlRequest.SelectedValue.ToString() == "2")
                {
                    if (position == 3)
                        Response.Redirect("processPullCourseHead2.aspx?id=" + val);
                    else if (position == 2)
                        Response.Redirect("processPullCourseDean2.aspx?id=" + val);

                    else if (position == 5)
                        Response.Redirect("processPullCourseReg.aspx?id=" + val);


                }
                else if (ddlRequest.SelectedValue.ToString() == "3")
                    Response.Redirect("ProcessAbsenceExam2.aspx?id=" + val);
                else if (ddlRequest.SelectedValue.ToString() == "4")
                {

                    if (position == 3)
                        Response.Redirect("processAltiSubjectHead2.aspx?id=" + val);

                    else if (position == 2)
                        Response.Redirect("processAltiSubjectDean2.aspx?id=" + val);

                    else if (position == 5)
                        Response.Redirect("processAltSubjectReg.aspx?id=" + val);

                }
                else if (ddlRequest.SelectedValue.ToString() == "5")
                {
                    if (position == 3)
                        Response.Redirect("processDropSemesterHead2.aspx?id=" + val);

                    else if (position == 2)
                        Response.Redirect("processDropSemesterDean2.aspx?id=" + val);

                    else if (position == 5)
                        Response.Redirect("processDeopSemesterReg.aspx?id=" + val);

                    else if (position == 1)
                        Response.Redirect("processDropSemesterDeputyAcademic.aspx?id=" + val);

                }
                else if (ddlRequest.SelectedValue.ToString() == "6")
                {
                    if (position == 2)
                        Response.Redirect("processDealySemesterDean2.aspx?id=" + val);

                    else if (position == 5)
                        Response.Redirect("processDelaySemesterReg.aspx?id=" + val);

                }
            }
        }
    }
}