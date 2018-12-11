<%@ Page Title="" Language="C#" MasterPageFile="~/PageStudents/student.Master" AutoEventWireup="true" CodeBehind="AddSign.aspx.cs" Inherits="WebApplication1.AddSign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
   <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  w3-padding-64 " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">إنشاء توقيع </h2>
            
        </div>
       
    </div>
      <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%;  padding-bottom:0;">
      <div class="form-group float-right col-10 " style="direction:rtl; margin-right:3%; padding-right:10%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri' ; font-size:large;">الايميل</label>
          <asp:Label ID="labEmail" runat="server" CssClass="form-control" Text="Label" style="float:right; direction:ltr;font-family:'Amiri';" Enabled="false"></asp:Label>
      
    
     </div>  
          </div>
     <div class=" w3-white w3-center navbar navbar-expand-lg   " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%;  padding-bottom:0;">
      <div class="form-group float-right col-10" style="direction:rtl; margin-right:3%;padding-right:10%;" >
        <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri' ; font-size:large;">كلمة المرور للتوقيع         <asp:RequiredFieldValidator runat="server" ForeColor="Red" ID="RequiredFieldValidator3" ControlToValidate="txtPassword" ErrorMessage="*"></asp:RequiredFieldValidator>

              </label>
           &nbsp;
          <asp:TextBox ID="txtPassword"  TextMode="Password"  runat="server" CssClass="form-control" style="float:right; font-family:'Amiri';"></asp:TextBox>
      
    
     </div>  
          </div>
   
         
    
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%;  padding-bottom:10%; padding-top:5%;">
      <div class=" w3-row form-group float-right " style="direction:rtl; float: none;
    margin: 0 auto; " >
             <asp:Button ID="Button2" runat="server" OnClick="btnSave_Click" Text="انشاء توقيع " class="btn w3-green btn-lg w3-margin-top" align="center" style="float: none; margin: 0 auto;" />
     
      
       
      </div>
    </div>

    






</asp:Content>
