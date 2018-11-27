﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PageEmployee/employee.Master"  CodeBehind="ProcessRequest.aspx.cs" Inherits="WebApplication1.PageEmployee.ProcessRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class=" w3-cell-row ">
        <div class="w3-white w3-center navbar navbar-expand-lg w3-margin-top w3-margin-bottom w3-padding-24" style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2 style="float: none;
    margin: 0 auto; font-family:'Amiri'">الطلبات التي لم يتم معالجتها </h2><br />
            

        </div>
        
    </div>


    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;">اختر الطلب </label>
          <asp:DropDownList ID="ddlRequest" runat="server" CssClass="form-control" style="float:right; font-family:'Amiri';" OnSelectedIndexChanged="ddlRequest_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList>
      
     </div>  
          <div class="col-1">

          </div>
          
      </div>

    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; margin-top:5%; ">
      <div class="form-group float-right row w3-responsive" style="direction:rtl; margin-right:3%; width:100%;" >
               <asp:Label ID="errorLabel" runat="server" style="float:right;  float:none; margin:0 auto;  font-family:'Amiri'; font-size:large;" Visible="False" ForeColor="#FF3300"></asp:Label>
    <asp:GridView ID="gvRequest"    style="width:1100px; padding-top:5%; " runat="server"    AutoGenerateColumns="False" DataKeyNames="IDFORM" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvRequest_RowCommand">



        <AlternatingRowStyle BackColor="White" ForeColor="#284775" /> 
        <Columns >
            <asp:BoundField  DataField="IDFORM" HeaderText="رقم الطلب" SortExpression="IDFORM" />
            <asp:BoundField DataField="DateRequest" HeaderText="تاريخ تقديم الطلب" SortExpression="DateRequest" />
            <asp:BoundField DataField="StudentName" HeaderText="اسم الطالب " SortExpression="StudentName" />
            <asp:BoundField DataField="UniversityID" HeaderText="رقم الطالب " SortExpression="UniversityID" />
                                        

             <asp:TemplateField ShowHeader="False">
                   <ItemTemplate>
                       <asp:Button ID="btnedit" runat="server" Text="معالجة" CommandName="process" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'/>
                   </ItemTemplate>          
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                </EditItemTemplate>
                 <ItemStyle Width="24px" />
                                           
            </asp:TemplateField>
            </Columns>
       
        <EditRowStyle BackColor="#999999" />
         <EmptyDataTemplate>
               <asp:Label ID="lblNoUser" runat="server" Font-Bold="True" ForeColor="Red">لا يوجد طلبات مقدمة </asp:Label>
        </EmptyDataTemplate>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
        
    </div>
  </div>
    

</asp:Content>