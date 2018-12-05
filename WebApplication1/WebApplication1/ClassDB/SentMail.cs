using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebApplication1
{
    public class SentMail
    {

        public void sendemailHead(int ID)
        {

            Studnets stu = new Studnets();
           DataRow dr= stu.drSearchStudentaLL(ID);
           int section = Convert.ToInt32(dr["SectionID"].ToString());
           Employee emp = new Employee();
            dr = emp.drSearchEmployeeHead(section);
            string tomail = dr["email"].ToString();
            sendemail(tomail);



        }

        public void sendemailDean(int ID)
        {

            Studnets stu = new Studnets();
            DataRow dr = stu.drSearchStudentaLL(ID);
            int section = Convert.ToInt32(dr["SectionID"].ToString());
            Employee emp = new Employee();
            dr = emp.drSearchEmployeeColloge(section);
            int Colloge= Convert.ToInt32(dr["CollegeID"].ToString());
            dr = emp.drSearchEmployeeDean(Colloge);
            int EmployeeID = Convert.ToInt32(dr["EmployeeID"].ToString());
            dr = emp.drSearchEmployeeINfo(EmployeeID);
            string tomail = dr["email"].ToString();
            sendemail(tomail);
        }



        public void sendemailAcadimic(int ID)
        {

            Studnets stu = new Studnets();
            DataRow dr = stu.drSearchStudentaLL(ID);
            int AcdemicID = Convert.ToInt32(dr["AcademicAdvisorID"].ToString());
            Employee emp = new Employee();
            dr = emp.drSearchEmployeeINfo(AcdemicID);
            string tomail = dr["email"].ToString();
            sendemail(tomail);
        }
        public void sendemailDep()
        {

           
            Employee emp = new Employee();
            DataRow dr = emp.drSearchEmployeeDep();
            int EmployeeID = Convert.ToInt32(dr["EmployeeID"].ToString());
            dr = emp.drSearchEmployeeINfo(EmployeeID);
            string tomail = dr["email"].ToString();
            sendemail(tomail);
        }

        public void sendemailReg()
        {


            Employee emp = new Employee();
            DataRow dr = emp.drSearchEmployeeReg();
            int EmployeeID = Convert.ToInt32(dr["EmployeeID"].ToString());
            dr = emp.drSearchEmployeeINfo(EmployeeID);
            string tomail = dr["email"].ToString();
            sendemail(tomail);
        }


        public void sendemail(string tomail)
        {
           
            SmtpClient client = new SmtpClient();

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            MailMessage mail = new MailMessage("portal.hebronuni@gmail.com", "21411841@students.hebron.edu");
            client.Credentials = new System.Net.NetworkCredential("portal.hebronuni@gmail.com", "123456PPheb");

   
            mail.Subject = "Portal hebron Univarsity";
            mail.Body = "تم تقديم طلب جديد بحاجة لمراجعة يرجى  مراجعة البوابة الأكاديمية";
            client.Send(mail);
        }
    }
}