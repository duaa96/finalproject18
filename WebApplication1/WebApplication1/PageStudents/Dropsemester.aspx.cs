﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.PageStudents;

namespace WebApplication1
{
    public partial class Dropsemester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Session["ID"].ToString());

                fillDataForm(ID);
                fillddl();
            }

            else
            {
            }
        }

        public void fillDataForm(int ID)

        {
           

            Studnets objStu = new Studnets();
            DataRow Stu = objStu.drSearchStudent(ID);
            if (Stu != null)
            {
                labCollage.Text = Stu["CollageName"].ToString();
                labNameStudent.Text = Stu["StudentName"].ToString();
                labNumStudent.Text = Stu["UniversityID"].ToString();
                labSection.Text = Stu["SectionName"].ToString();

            }
            labDate.Text = DateTime.Today.ToString();
        }


        private void fillddl()
        {

            int ID = Convert.ToInt32(Session["ID"].ToString());
            RegistredCourses obj = new RegistredCourses();
            DataTable tbl1 = obj.dtSearchRegisterSubject(ID);
            gvCourses.DataSource = tbl1;
            gvCourses.DataBind();

        }




        protected void Button1_Click(object sender, EventArgs e)
        {

            bool Result = false;
            int ID = Convert.ToInt32(Session["ID"]);
            string Path = "";

            string Data = DateTime.Today.ToString()+ txtNumHours.Text.ToString(); 
            if (fuSignature.HasFile)
            {
                string Private = fuSignature.FileName.ToString();
                Path = System.Web.HttpContext.Current.Server.MapPath("Test") + "/" + Private;
                string Pasword = txtPassSign.Text.ToString();

                fuSignature.SaveAs(Server.MapPath("Test") + "/" + fuSignature.FileName);
                SignatureStudents newSig = new SignatureStudents();
                string strencrypt = newSig.encrypet(Data, Path, Pasword);
                Result = newSig.Decreypt(strencrypt, ID);

            }
            if (Result == true)
            {
                string date1 = DateTime.Today.ToString();
                string Reason = txtReasons.Text.ToString();
                DropSemester objsem = new DropSemester();
                int NumOFHour = Convert.ToInt32(txtNumHours.Text.ToString());
                NowTimeUniversity timee = new NowTimeUniversity();
                DataRow T = timee.drSearchYearANdSemester();
                string semester = T["NowSemester"].ToString();
                string Year = T["NowYear"].ToString();

                if (objsem.AddDropSemester(ID, Year, semester, Reason, NumOFHour, date1, "", 0, "", 0, "", 0, "", 0,0, "", 2) == 1)
                {
                    txtReasons.Text = "";
                    txtNumHours.Text = "";
                }
                errorLabel.Visible = false;
            }
            else
            {
                errorLabel.Text = "التوقيع المدخل خاطئ";
                errorLabel.Visible = true;
            }
        }
        protected void gvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}