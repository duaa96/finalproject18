using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());


        protected void Page_Load(object sender, EventArgs e)
        {

        }
       

        protected void btnLogin_Click1(object sender, EventArgs e)
        {

            if (txtUsername.Text != string.Empty && txtPassword.Text != string.Empty && (rdbEmployee.Checked == true || rdbStudent.Checked == true))
            {

                if (rdbEmployee.Checked == true)
                {
                    try
                    {
                        int strUsername = Convert.ToInt32(txtUsername.Text);
                        string strPassword = txtPassword.Text;
                       
                        Employee Emp1 = new Employee();
                        DataRow drEmployee = Emp1.drSearchEmployeeLogin(strUsername, strPassword);

                       
                        if (drEmployee is null)
                        {
                            lbWrong.Text = "خطأ في كلمة اسم المستخدم او كلمة السر";
                            lbWrong.Visible = true;
                        }
                        else
                        {
                            Session["ID"] = drEmployee["ID"];
                            Response.Redirect("~/PageEmployee/HomeEmployee.aspx");
                            lbWrong.Text = "Login Sucess......!!";
                            lbWrong.Visible = true;
                         

                        }
                    


                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }



                }
                else
                {
                    try
                    {

                        int strUsername = Convert.ToInt32(txtUsername.Text);
                        string strPassword = txtPassword.Text;


                        Studnets stu1 = new Studnets();
                        DataRow drStudent = stu1.drSearchStudentLogin(strUsername, strPassword);
                       if (drStudent is null)
                        {

                            lbWrong.Text = "خطأ في كلمة اسم المستخدم او كلمة السر";
                            lbWrong.Visible = true;

                        }
                       else
                        {
                            Session["ID"] = drStudent["ID"];
                            Response.Redirect("~/PageStudents/HomeStudent.aspx");
                            lbWrong.Text = "Login Sucess......!!";
                            lbWrong.Visible = true;
                        }



                       


                    }

                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }



                }

            }





            else
            {
                lbWrong.Text = "يرجى تعبئة جميع البيانات ";
                lbWrong.Visible = true;

            }
        }
    }
}