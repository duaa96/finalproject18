﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="employee2.Master" CodeBehind="NSig2.aspx.cs" Inherits="WebApplication1.PageEmployee.NSig2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class=" w3-cell-row  " runat="server" id="error" style="display:none;">
        <div class=" w3-center navbar navbar-expand-lg w3-margin-top  w3-green" style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <asp:Label ID="labError" runat="server" style="float: none;
    margin: 0 auto; font-family:'Amiri'" Text="يرجى مراجعة البريد الالكتروني الخاص بك" Font-Size="large" ForeColor="white" Visible="false"></asp:Label>   

        </div>
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  w3-padding-64" style=" float: none;
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

   

        
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; padding-bottom:5%;padding-top:5%; ">
      <div class=" w3-row form-group float-right " style="direction:rtl; float: none;
    margin: 0 auto; " >
          <asp:Button ID="btnResetPass" runat="server" Text="تجديد التوقيع" class="btn btn-lg w3-green" align="center" OnClick="btnResetPass_Click"   />
     
      
       
      </div>
    </div>

</asp:Content>
