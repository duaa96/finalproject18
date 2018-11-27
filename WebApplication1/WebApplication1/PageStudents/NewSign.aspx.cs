﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageStudents
{
    public partial class NewSign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Session["ID"].ToString());
            fillData();
        }

        private void fillData()
        {
            int ID = Convert.ToInt32(Session["ID"].ToString());
            Studnets loginStudent = new Studnets();
            DataRow loginS = loginStudent.drSearchStudentEmail(ID);
            labEmail.Text = loginS["Email"].ToString();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            bool Result = false;
            int ID = Convert.ToInt32(Session["ID"].ToString());
            string Path = "";
            string Data = labEmail.Text.ToString();
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
                string password = txtPassword.Text.ToString();
                string Email = labEmail.Text.ToString();
                SignatureStudents objj = new SignatureStudents();
                objj.CreateSignature(password, Email, ID);
                string pathPub = System.Web.HttpContext.Current.Server.MapPath("../PageStudents/Sig") + "/" + ID + ".asc";

                string PrivateKey = "Sig/" + ID + "pr" + ".asc";
                GetKey objKey = new GetKey();
                objKey.AddKeyStudent(pathPub, ID);
                downloadfile(PrivateKey);
                errorLab.Visible = false;
            }
            else
            {
                errorLab.Text = "التوقيع المدخل خاطئ";
                errorLab.Visible = true;
            }
        }

        public void downloadfile(string filePath)
        {
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            // System.IO.File.Delete("C:/Users/Dua'a-Orcas/Desktop/WebApplication1/WebApplication1/WebApplication1/" + filePath);
            Response.Flush();
            string pri = System.Web.HttpContext.Current.Server.MapPath("../PageStudents/") + filePath;
            string pathkey = System.Web.HttpContext.Current.Server.MapPath("../PageStudents/") + "Sig/key.store";
            string pathkeybak = System.Web.HttpContext.Current.Server.MapPath("../PageStudents/") + "Sig/key.store.bak";

            System.IO.File.Delete(pri);
            System.IO.File.Delete(pathkey);
            System.IO.File.Delete(pathkeybak);
            Response.End();


        }
    }
}