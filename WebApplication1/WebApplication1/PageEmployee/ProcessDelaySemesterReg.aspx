<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/PageEmployee/Reg.Master"  CodeBehind="ProcessDelaySemesterReg.aspx.cs" Inherits="WebApplication1.PageEmployee.ProcessDelaySemesterReg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" w3-cell-row ">
        <div class="w3-white w3-center navbar navbar-expand-lg w3-margin-top w3-margin-bottom w3-padding-24" style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2 style="float: none;
    margin: 0 auto; font-family:'Amiri'">نموذج تقديم تأجيل فصل  </h2><br />
            

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
          <asp:Label ID="labStudentNumber" runat="server" CssClass="form-control" Text="Label" style="float:right; font-family:'Amiri';"></asp:Label>
      
    
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

    <div class=" w3-white w3-center navbar navbar-expand-lg   " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%;  padding-bottom:0;">
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:3%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri' ; font-size:large;">التخصص :</label>
          <asp:Label ID="labMager" runat="server" CssClass="form-control" Text="Label" style="float:right; font-family:'Amiri';"></asp:Label>
      
    
     </div>  
          <div class="col-1">

          </div>
           <div class="form-group float-right col-5" style="direction:rtl; " >

         <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri' ; font-size:large;">أرغب بتأجيل الفصل:

               </label>
               &nbsp;<asp:DropDownList ID="ddlSemester" CssClass="form-control bg-white" style="float:right; font-family:'Amiri';" Enabled="false" runat="server">
                   <asp:ListItem>الأول</asp:ListItem>
                   <asp:ListItem>الثاني</asp:ListItem>
               </asp:DropDownList>

               
          <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri' ; font-size:large;">من العام الجامعي
      
               </label>

          &nbsp;<asp:TextBox ID="txtYear" CssClass="form-control bg-white"  style="float:right; font-family:'Amiri';" runat="server" Enabled="false"></asp:TextBox>
      
     </div>  
           <div class="col-1">

          </div>
      </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-5" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:xx-large;">و ذلك للأسباب التالية:
      
       
          </label>
         &nbsp;</div>
    </div>
    
  <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
      <asp:TextBox ID="txtStatus" runat="server"   CssClass="form-control w3-margin-right col-12 bg-white " Height="100px"   align="right" Enabled="false"></asp:TextBox>
      
       
      </div>
    </div>
    
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;">التاريخ: </label>
      <asp:Label ID="labDate" runat="server" CssClass="w3-margin-right" Text="Label" style="float:right;   font-family:'Amiri'; font-size:x-large;"></asp:Label>
      
     </div>  
          <div class="col-1">

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
         
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;"> ملاحظات دائرة القبول و التسجيل:<asp:RequiredFieldValidator runat="server" ForeColor="Red" ID="RequiredFieldValidator1" ControlToValidate="txtDescriptionReg" ErrorMessage="*"></asp:RequiredFieldValidator></label>
      
       
      </div>
    </div>
        <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
      <asp:TextBox ID="txtDescriptionReg" runat="server"   CssClass="form-control w3-margin-right col-12 bg-white " Height="100px"   align="right"  ></asp:TextBox>
      
       
      </div>
  </div>
<div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
         <asp:RequiredFieldValidator runat="server" ForeColor="Red" ID="RequiredFieldValidator10" ControlToValidate="rbtAcceptRegistration" ErrorMessage="*"></asp:RequiredFieldValidator>

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
     
          <asp:RadioButtonList ID="rbtAcceptRegistration" style="float:right;  font-family:'Amiri'; font-size:x-large;" RepeatLayout="Table" CssClass="RBL"  runat="server" RepeatDirection="Horizontal" >
               <asp:ListItem Text="موافق" Value="1" />
               <asp:ListItem Text="غير موافق" Value="2" />
          </asp:RadioButtonList>
       
      </div>
    </div>
     <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:0.5%;" id="DateReg" >
      <asp:Label ID="dfDateReg"  style="float:right;  font-family:'Amiri'; font-size:large;" runat="server" Text="Label">التاريخ:</asp:Label>
    
      <asp:Label ID="labDateReg"  style="float:right;  font-family:'Amiri'; font-size:x-large;" runat="server" Text="Label"></asp:Label>
     </div>  
          <div class="col-1">

          </div>
           <div class="form-group float-right col-5" style="direction:rtl; " id="SigReg"  >
       <asp:Label ID="dfinfoReg" runat="server"  style="float:right;  font-family:'Amiri'; font-size:large;" >التوقيع:</asp:Label>

         <asp:RequiredFieldValidator runat="server" ForeColor="Red" ID="RequiredFieldValidator6" ControlToValidate="fuSignatureReg" ErrorMessage="*"></asp:RequiredFieldValidator>

      <asp:FileUpload ID="fuSignatureReg" runat="server" />
       <asp:Label ID="errorReg" runat="server" style="float:right;  font-family:'Amiri'; font-size:large;" Visible="False" ForeColor="#FF3300"></asp:Label>
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
         <asp:RequiredFieldValidator runat="server" ForeColor="Red" ID="RequiredFieldValidator3" ControlToValidate="txtPassSign" ErrorMessage="*"></asp:RequiredFieldValidator>

      </label>
          <asp:TextBox ID="txtPassSign"  TextMode="Password"  runat="server" CssClass="form-control w3-margin-right" style="float:right; font-family:'Amiri'; " Width="40%"></asp:TextBox>
      
     </div>
        
           <div class="col-1">

          </div>
  </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right " style="direction:rtl; float: none;
    margin: 0 auto; " >
          <asp:Button ID="btnSaveReg" runat="server" Text="حفظ" class="btn btn-lg w3-green " align="center" Width="100" OnClick="btnSaveReg_Click"  />
      
       
      </div>
    </div>
</asp:Content>