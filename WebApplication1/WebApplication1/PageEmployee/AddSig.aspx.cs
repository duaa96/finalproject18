using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PageEmployee
{
    public partial class AddSig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Session["ID"].ToString());
            Employee loginEmp = new Employee();
            DataRow loginE = loginEmp.drSearchEmployeeEmail(ID);
            string sig = loginE["Signature"].ToString();
            if (sig == null || sig==String.Empty)
                fillData();
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('لديك توقيع سابق اذااردت تغيره انتقل الى تجديد التوقيع');window.location ='HomeEmployee.aspx';", true);
            }

        }
        private void fillData()
        {
            int ID = Convert.ToInt32(Session["ID"].ToString());
            Employee loginEmp = new Employee();
            DataRow loginE = loginEmp.drSearchEmployeeEmail(ID);
            labEmail.Text = loginE["Email"].ToString();
        }


        protected void btnSave_Click(object sender, EventArgs e)

        {
            int ID = Convert.ToInt32(Session["ID"].ToString());
            string password = txtPassword.Text.ToString();
            string Email = labEmail.Text.ToString();
            SignatureEmployee objj = new SignatureEmployee();
            objj.CreateSignature(password, Email, ID);
            string pathPub = System.Web.HttpContext.Current.Server.MapPath("../PageEmployee/Sig") + "/" + ID + ".asc";

            string PrivateKey = "Sig/" + ID + "pr" + ".asc";
            GetKey objKey = new GetKey();
            objKey.AddKeyEmployee(pathPub, ID);
            downloadfile(PrivateKey);




        }



        public void downloadfile(string filePath)
        {
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            // System.IO.File.Delete("C:/Users/Dua'a-Orcas/Desktop/WebApplication1/WebApplication1/WebApplication1/" + filePath);
            Response.Flush();
            string pri = System.Web.HttpContext.Current.Server.MapPath("../PageEmployee/") + filePath;
            string pathkey = System.Web.HttpContext.Current.Server.MapPath("../PageEmployee/") + "Sig/key.store";
            string pathkeybak = System.Web.HttpContext.Current.Server.MapPath("../PageEmployee/") + "Sig/key.store.bak";

            System.IO.File.Delete(pri);
            System.IO.File.Delete(pathkey);
            System.IO.File.Delete(pathkeybak);
            Response.End();


        }
    }
}