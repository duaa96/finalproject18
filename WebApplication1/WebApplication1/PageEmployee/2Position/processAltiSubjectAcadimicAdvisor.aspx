<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="employee2.Master" CodeBehind="processAltiSubjectAcadimicAdvisor.aspx.cs" Inherits="WebApplication1.PageEmployee.processAltiSubjectAcadimicAdvisor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
     <div class=" w3-cell-row ">
        <div class="w3-white w3-center navbar navbar-expand-lg w3-margin-top w3-margin-bottom w3-padding-24" style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2 style="float: none;
    margin: 0 auto; font-family:'Amiri'">نموذج مساق بديل للتخرج   </h2><br />
            

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
          <asp:Label ID="labNumStudent" runat="server" CssClass="form-control" Text="Label" style="float:right; font-family:'Amiri';"></asp:Label>
      
    
     </div>  
          <div class="col-1">

          </div>
           <div class="form-group float-right col-5" style="direction:rtl; " >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large">اسم الطالب</label>
          <asp:Label ID="labNameStudent" runat="server" CssClass="form-control" Text="Label" style="float:right; font-family:'Amiri';"></asp:Label>

      
     </div>  
           <div class="col-1">

          </div>
      </div>
   
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:3%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;">القسم</label>
          <asp:Label ID="labSection" runat="server" CssClass="form-control" Text="Label" style="float:right; font-family:'Amiri';"></asp:Label>
      
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
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:3%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;">التخصص</label>
          <asp:Label ID="labMager" runat="server" CssClass="form-control" Text="Label" style="float:right; font-family:'Amiri';"></asp:Label>
      
     </div>  
          <div class="col-1">

          </div>
           <div class="form-group float-right col-5" style="direction:rtl; " >
      
     </div>  
           <div class="col-1">

          </div>
      </div>
   
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-5" style="direction:rtl; margin-right:0.5%;" >

      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;">معلومات المساق الأصيل:</label>
      
       
      </div>
    </div>

    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right  w3-responsive" style="direction:rtl; margin-right:3%;" >
 <table class=" w3-responsive float-right w3-table w3-striped w3-border" style="direction:rtl;float:right;   font-family:'Amiri';">
    <tr class="w3-green  w3-center w3-margin" style="font-size:x-large;">
      <th class="w3-center">الرقم</th>
       
      <th  class="w3-center" style=" float: none; 
    margin: 0 auto;"> اسم المساق الأصيل</th>
        
      <th  class="w3-center"  style=" float: none; 
    margin: 0 auto;">رقم المساق الأصيل</th>
        
      <th  class="w3-center" style=" float: none; 
    margin: 0 auto;">نوع المساق الأصيل</th>
      
      <th  class="w3-center" style=" float: none; 
    margin: 0 auto;">الساعات المعتمدة للأصيل</th>
    </tr>
    <tr style="font-size:large;">

      <td>1- </td>
      <td><span>
          <asp:DropDownList ID="ddlCourse1" runat="server" CssClass="form-control  w3-margin-right bg-white" width="200px"  AutoPostBack="true" Enabled="False">
          </asp:DropDownList>
         </span></td>
      <td>
          <asp:TextBox ID="txtNumberCourse1" runat="server" CssClass="form-control  w3-margin-right bg-white" width="200px"   AutoPostBack="true" Enabled="False"></asp:TextBox>
        <td>  
            <asp:Label ID="labTypeCourse1"  CssClass="form-control w3-margin-right " width="200px" runat="server"  Height="35px" Text=""></asp:Label>
      <td>
          <asp:Label ID="labHoursCourse1" CssClass="form-control w3-margin-right " width="200px" runat="server" Height="35px" Text=""></asp:Label>
      </td>
    </tr>

  </table>
       
      </div>


    </div>

    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-5" style="direction:rtl; margin-right:0.5%;" >

      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;">معلومات المساق البديل:</label>
      
       
      </div>
    </div>


    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right  w3-responsive" style="direction:rtl; margin-right:3%;" >
 <table class=" w3-responsive float-right w3-table w3-striped w3-border" style="direction:rtl;float:right;   font-family:'Amiri';">
    <tr class="w3-green  w3-center w3-margin" style="font-size:x-large;">
      <th class="w3-center">الرقم</th>
       
      <th  class="w3-center" style=" float: none; 
    margin: 0 auto;">اسم المساق البديل</th>
        
      <th  class="w3-center"  style=" float: none; 
    margin: 0 auto;">رقم المساق البديل</th>
      
      <th  class="w3-center" style=" float: none; 
    margin: 0 auto;">الساعات المعتمدة للبديل</th>
    </tr>
    <tr style="font-size:large;">

      <td>1- </td>
      <td><span>

          <asp:DropDownList ID="ddlAlternativeCourse1" runat="server"  CssClass="form-control  w3-margin-right bg-white" width="250px" Enabled="False"  AutoPostBack="true">
          </asp:DropDownList>

          
         </span></td>
      <td>
          <asp:TextBox ID="txtAlternativeNum1C1" runat="server"  CssClass="form-control  w3-margin-right bg-white " width="250px" Enabled="False" AutoPostBack="true" ></asp:TextBox>
        <td>  
            
                <asp:Label ID="labHoursAlternative" runat="server" CssClass="form-control w3-margin-right " width="250px" Hight="35px"></asp:Label>
     
    </tr>

  </table>
       
      </div>


    </div>
    
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-5" style="direction:rtl; margin-right:0.5%;" >

      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;">وذلك للأسباب التالية:</label>
      
       
      </div>
    </div>
  <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
      <asp:TextBox ID="txtReason" runat="server"   CssClass="form-control w3-margin-right col-12 bg-white" Height="100px" Enabled="False"  align="right"></asp:TextBox>
      
       
      </div>
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:0.5%;"  >
      <asp:Label ID="Label1"  style="float:right;  font-family:'Amiri'; font-size:large;" runat="server" Text="Label">التاريخ:</asp:Label>
    
      <asp:Label ID="labDateS"  style="float:right;  font-family:'Amiri'; font-size:x-large;" runat="server" Text="Label"></asp:Label>
     </div>  
          <div class="col-1">

          </div>
        </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  w3-padding-24 " style=" float: none;direction:rtl;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">معلومات المرشد الأكاديمي </h2>
            
        </div>
       
    </div>

    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <asp:RequiredFieldValidator runat="server" ForeColor="Red" ID="RequiredFieldValidator2" ControlToValidate="rbtAcademic" ErrorMessage="*"></asp:RequiredFieldValidator>
      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
         
     
          <asp:RadioButtonList ID="rbtAcademic" style="float:right;  font-family:'Amiri'; font-size:x-large;" RepeatLayout="Table" CssClass="RBL"  runat="server"  RepeatDirection="Horizontal"  >
               <asp:ListItem Text="موافق" Value="1" />
               <asp:ListItem Text="غير موافق" Value="2" />
          </asp:RadioButtonList>
      </div>
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:0.5%;"  >
      <asp:Label ID="dfDateAcadimic"  style="float:right;  font-family:'Amiri'; font-size:large;" runat="server" Text="Label">التاريخ:</asp:Label>
    
      <asp:Label ID="labDateAcadimic"  style="float:right;  font-family:'Amiri'; font-size:x-large;" runat="server" Text="Label"></asp:Label>
     </div>  
          <div class="col-1">

          </div>
           <div class="form-group float-right col-5" style="direction:rtl; "  >
       <asp:Label ID="dfinfoAcadimic" runat="server"  style="float:right;  font-family:'Amiri'; font-size:large;" >التوقيع:</asp:Label>

         <asp:RequiredFieldValidator runat="server" ForeColor="Red" ID="RequiredFieldValidator11" ControlToValidate="fuSignatureAcadimic" ErrorMessage="*"></asp:RequiredFieldValidator>

      <asp:FileUpload ID="fuSignatureAcadimic" runat="server" />
       <asp:Label ID="errorAcadimic" runat="server" style="float:right;  font-family:'Amiri'; font-size:large;" Visible="False" ForeColor="#FF3300"></asp:Label>
     </div>  
           <div class="col-1">

          </div>
      </div> 

    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:0.5%;" >
      
     </div>  
          <div class="col-1">

          </div>
      
   <div class="form-group float-right col-5" style="direction:rtl; margin-right:0.4%; " >

      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;">كلمة المرور للتوقيع:
         <asp:RequiredFieldValidator runat="server" ForeColor="Red" ID="RequiredFieldValidator1" ControlToValidate="txtPassSign" ErrorMessage="*"></asp:RequiredFieldValidator>

      </label>
          <asp:TextBox ID="txtPassSign"  TextMode="Password"  runat="server" CssClass="form-control w3-margin-right" style="float:right; font-family:'Amiri'; " Width="40%"></asp:TextBox>
      
     </div>
        
           <div class="col-1">

          </div>
  </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg w3-margin-bottom " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right " style="direction:rtl; float: none;
    margin: 0 auto; " >
          <asp:Button ID="btnSaveAcadimic" runat="server" Text="حفظ" class="btn btn-lg w3-green " align="center" Width="100" OnClick="btnSaveAcadimic_Click"  />
      
       
      </div>
    </div>
    </asp:Content>
