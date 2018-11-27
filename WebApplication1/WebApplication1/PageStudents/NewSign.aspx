<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PageStudents/student.Master" CodeBehind="NewSign.aspx.cs" Inherits="WebApplication1.PageStudents.NewSign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  w3-padding-24 " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'"> تجديد التوقيع</h2>
            
        </div>
       
    </div>
      <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%;  padding-bottom:0;">
      <div class="form-group float-right col-10 " style="direction:rtl; margin-right:3%; padding-right:10%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri' ; font-size:large;">الايميل</label>
          <asp:Label ID="labEmail" runat="server" CssClass="form-control" Text="Label" style="float:left; font-family:'Amiri';" Enabled="false"></asp:Label>
      
    
     </div>  
          </div>
     <div class=" w3-white w3-center navbar navbar-expand-lg   " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%;  padding-bottom:0;">
      <div class="form-group float-right col-10" style="direction:rtl; margin-right:3%;padding-right:10%;" >
        <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri' ; font-size:large;"> كلمة المرور للتوقيع الجديد         <asp:RequiredFieldValidator runat="server" ForeColor="Red" ID="RequiredFieldValidator3" ControlToValidate="txtPassword" ErrorMessage="*"></asp:RequiredFieldValidator>

              </label>
           &nbsp;
          <asp:TextBox ID="txtPassword"  TextMode="Password"  runat="server" CssClass="form-control" style="float:right; font-family:'Amiri';"></asp:TextBox>
      
    
     </div>  
          </div>

    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="form-group float-right col-6" style="direction:rtl; padding-right:13%; " >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;">التوقيع القديم :</label>
         <asp:RequiredFieldValidator runat="server" ForeColor="Red" ID="RequiredFieldValidator2" ControlToValidate="fuSignature" ErrorMessage="*"></asp:RequiredFieldValidator>

      <asp:FileUpload ID="fuSignature" runat="server" width="60%"/>
       <asp:Label ID="errorLab" runat="server" style="float:right;  font-family:'Amiri'; font-size:large;" Visible="False" ForeColor="#FF3300"></asp:Label>
     </div>  
           
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:0.5%; padding-right:4%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;">كلمة المرور للتوقيع:</label>
          <asp:TextBox ID="txtPassSign"  TextMode="Password"  runat="server" CssClass="form-control w3-margin-right" style="float:right; font-family:'Amiri'; " Width="55%"></asp:TextBox>
      
     </div>  
          <div class="col-1">

          </div>
           
      </div>
  

             
   
    
  <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right " style="direction:rtl; float: none;
    margin: 0 auto; " >
          <asp:Button ID="btnSave" runat="server" Text="تجديد التوقيع" class="btn btn-lg btn-primary" align="center" OnClick="btnSave_Click" />
     
      
       
      </div>
    </div>


    



</asp:Content>