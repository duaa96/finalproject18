﻿<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/PageStudents/student.Master"  CodeBehind="PullCourseDispalyAll.aspx.cs" Inherits="WebApplication1.PageStudents.PullCourseDispalyAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class=" w3-cell-row ">
        <div class="w3-white w3-center navbar navbar-expand-lg w3-margin-top w3-margin-bottom w3-padding-24" style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2 style="float: none;
    margin: 0 auto; font-family:'Amiri'">نموذج تقديم سحب مساق  </h2><br />
            

        </div>
        
    </div>

    <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  w3-padding-24 " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">معلومات الطالب </h2>
            
        </div>
       
    </div>
      <div class=" w3-white w3-center navbar navbar-expand-lg   " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%;  padding-bottom:0;">
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:3%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri' ; font-size:large;">الرقم الجامعي</label>
          <asp:Label ID="labStudentNmuber" runat="server" CssClass="form-control" Text="Label" style="float:right; font-family:'Amiri';"></asp:Label>
      
    
     </div>  
          <div class="col-1">

          </div>
           <div class="form-group float-right col-5" style="direction:rtl; " >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large">اسم الطالب</label>
          <asp:Label ID="labStudentName" runat="server" CssClass="form-control" Text="Label" style="float:right; font-family:'Amiri';"></asp:Label>

      
     </div>  
           <div class="col-1">

          </div>
      </div>
   
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:3%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;">القسم</label>
          <asp:Label ID="labSectionStudent" runat="server" CssClass="form-control" Text="Label" style="float:right; font-family:'Amiri';"></asp:Label>
      
     </div>  
          <div class="col-1">

          </div>
           <div class="form-group float-right col-5" style="direction:rtl; " >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;">الكلية</label>
          <asp:Label ID="labCollage" runat="server" CssClass="form-control" Text="Label" style="float:right; font-family:'Amiri';"></asp:Label>
      
     </div>  
           <div class="col-1">

          </div>
      </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-12" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;">السيد رئيس القسم المحترم ارجو الموافقة على سحب المساق /المساقات المذكورة ادناه:</label>
      
       
      </div>
    </div>
    

    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right  w3-responsive" style="direction:rtl; margin-right:3%;" >
 <table class=" w3-responsive float-right w3-table w3-striped w3-border" style="direction:rtl;float:right;   font-family:'Amiri';">
    <tr class="w3-green  w3-center w3-margin" style="font-size:x-large;">
      <th class="w3-center">الرقم</th>
       
      <th  class="w3-center" style=" float: none; 
    margin: 0 auto;">اسم المساق</th>
        
      <th  class="w3-center"  style=" float: none; 
    margin: 0 auto;">رقم المساق</th>
        
      <th  class="w3-center" style=" float: none; 
    margin: 0 auto;">مدرس المساق</th>
      
      <th  class="w3-center" style=" float: none; 
    margin: 0 auto;">موعدالمساق</th>
    </tr>
    <tr style="font-size:large;">

      <td>1- </td>
      <td><span>
          
          <asp:DropDownList ID="ddlNameCourse1" runat="server" CssClass="form-control w3-margin-right w3-margin-left bg-white" width="200px" AutoPostBack="true" Enabled="False">
          </asp:DropDownList>
          </span></td>
      <td>
          <asp:TextBox ID="txtNumCourse1" runat="server" CssClass="form-control  w3-margin-right bg-white " width="200px"   AutoPostBack="true" Enabled="False"></asp:TextBox>
          
        <td>  <asp:Label ID="labTeacher1"  CssClass="form-control w3-margin-right bg-white " width="200px"  Height="35px" runat="server" Enabled="False" ></asp:Label></td>
      <td>
        <asp:TextBox ID="txtTimeCourse1"   CssClass="form-control w3-margin-right bg-white " width="200px" runat="server" Enabled="False"></asp:TextBox>
      </td>
    </tr>
    <tr  style="font-size:large;">
      <td>2-</td>
      <td>
          <asp:DropDownList ID="ddlNameCourse2" runat="server" CssClass="form-control w3-margin-right bg-white" width="200px"  AutoPostBack="true" Enabled="False">
          </asp:DropDownList>
          </td>

          <td> 
              <asp:TextBox ID="txtNumCourse2" runat="server" CssClass="form-control w3-margin-right bg-white " Rows="2" width="200px" AutoPostBack="true" Enabled="False"></asp:TextBox>
</td>
        <td>  <asp:Label ID="labTeacher2" CssClass="form-control w3-margin-right bg-white " Height="35px" width="200px"   runat="server" Enabled="False"></asp:Label></td>
      <td><asp:TextBox ID="txtTimeCourse2"   CssClass="form-control w3-margin-right bg-white " width="200px" runat="server" Enabled="False">  </asp:TextBox></td>
    </tr>
    <tr  style="font-size:large;">
      <td>3-</td>
      <td>
          

          <asp:DropDownList ID="ddlNameCourse3" runat="server" CssClass="form-control w3-margin-right bg-white" width="200px"  AutoPostBack="true" Enabled="False">
          </asp:DropDownList>
        </td>
      <td>  
          
          <asp:TextBox ID="txtNumCourse3" runat="server" CssClass="form-control w3-margin-right bg-white " Rows="2" width="200px"  AutoPostBack="true" Enabled="False"></asp:TextBox>
</td>
        <td>  <asp:Label ID="labTeacher3" CssClass="form-control w3-margin-right bg-white" Height="35px" width="200px"   runat="server"></asp:Label></td>
      <td><asp:TextBox ID="txtTimeCourse3"   CssClass="form-control w3-margin-right bg-white " width="200px" runat="server" Enabled="False"></asp:TextBox></td>
    </tr>
       
  </table>
       
      </div>


    </div>

    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-5" style="direction:rtl; margin-right:0.5%;" >

      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;">وذلك للأسباب التالية:

          </label>&nbsp;</div>
    </div>
  <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
      <asp:TextBox ID="txtReason" runat="server"   CssClass="form-control w3-margin-right col-12  bg-white" Height="100px"   align="right" Enabled="False"></asp:TextBox>
      
       
      </div>
    </div>
    
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;">عدد الساعات المسجلة:
      
          &nbsp;</label><asp:TextBox ID="txtNmberHours" runat="server" CssClass="w3-margin-right form-control bg-white" style="float:right;   font-family:'Amiri'; font-size:large;" TextMode="Number" Enabled="False"></asp:TextBox>
      
     </div>  
          <div class="col-1">

          </div>
           <div class="form-group float-right col-5" style="direction:rtl; " >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;">عدد الساعات بعد السحب:
          

               </label>
         
               &nbsp;<asp:TextBox ID="txtNumHourAfter" runat="server" CssClass="w3-margin-right form-control bg-white" style="float:right;   font-family:'Amiri'; font-size:large;" TextMode="Number" Enabled="False"></asp:TextBox>
       
     </div>  
           <div class="col-1">

          </div>
      </div>
   
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:0.5%;" >
           <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;">التاريخ:</label>
    
      <asp:Label ID="labDate"  style="float:right;  font-family:'Amiri'; font-size:x-large;" runat="server" Text="Label"></asp:Label>
     </div>  
          <div class="col-1">

          </div>
           
</div>
       <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  w3-padding-24 " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">معلومات رئيس القسم </h2>
            
        </div>
       
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-12" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;"> ملاحظات رئيس القسم:
      
       
          </label>
         &nbsp;</div>
    </div>
 <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
      <asp:TextBox ID="txtDescriptionHead" runat="server"   CssClass="form-control w3-margin-right col-12  bg-white " Height="100px"   align="right" Enabled="False" style="right: 0px"></asp:TextBox>
      
       
      </div>
    </div>
     <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
     
          <asp:RadioButtonList ID="rbtAceptHead" style="float:right;  font-family:'Amiri'; font-size:x-large;" RepeatLayout="Table" CssClass="RBL"  runat="server" RepeatDirection="Horizontal" Enabled="false" >
               <asp:ListItem Text="موافق" Value="1" />
               <asp:ListItem Text="غير موافق" Value="2" />
          </asp:RadioButtonList>
      </div>
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  w3-padding-24 " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">معلومات عميد الكلية </h2>
            
        </div>
    </div>
     <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-12" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;"> ملاحظات عميد الكلية:
      
       
          </label>
         &nbsp;</div>
    </div>
 <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
      <asp:TextBox ID="txtDescriptionDean" runat="server"   CssClass="form-control w3-margin-right col-12 bg-white " Height="100px"   align="right" Enabled="False" ></asp:TextBox>
      
       
      </div>
  </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
     
          <asp:RadioButtonList ID="rbtAcceptDean" style="float:right;  font-family:'Amiri'; font-size:x-large;" RepeatLayout="Table" CssClass="RBL"  runat="server" RepeatDirection="Horizontal" Enabled="False">
               <asp:ListItem Text="موافق" Value="1" />
               <asp:ListItem Text="غير موافق" Value="2" />
          </asp:RadioButtonList>
       
      </div>
    </div>

<div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  w3-padding-24 " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">معلومات دائرة القبول و التسجيل </h2>
            
        </div>
  </div>  
     <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-12" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;" > قرار دائرة القبول و التسجيل:</label>
      
       
      </div>
    </div>
<div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
     
          <asp:RadioButtonList ID="rbtAcceptRegistration" style="float:right;  font-family:'Amiri'; font-size:x-large;" RepeatLayout="Table" CssClass="RBL"  runat="server" RepeatDirection="Horizontal" Enabled="false" >
               <asp:ListItem Text="موافق" Value="1" />
               <asp:ListItem Text="غير موافق" Value="2" />
          </asp:RadioButtonList>
       
      </div>
    </div>
 




</asp:Content>
