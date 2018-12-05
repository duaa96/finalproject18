<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PageEmployee/Reg.Master"  CodeBehind="ManageRequest.aspx.cs" Inherits="WebApplication1.PageEmployee.ManageRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  w3-padding-64 " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'"> ادارة الخدمات الأكاديمية الطلابية</h2>
            
        </div>
       
    </div>
    <div class=" w3-white  navbar navbar-expand-lg  w3-padding-64 " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto;  margin-left:3%; margin-right:3%; ">
            <h2  style="float: right; align-items:center; margin: 0 auto; font-family:'Amiri';font-size:20px;"> :حدد وقت انتهاء كل طلب</h2>
            
        </div>
       
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%;  ">
      <div class="form-group float-right row w3-responsive" style="direction:rtl; margin-right:3%; width:100%;" >
            
            <asp:GridView ID="gvRequest" style="width:1100px; padding-top:5%; " runat="server"    AutoGenerateColumns="False" OnRowEditing="gvRequest_RowEditing" OnRowDataBound="gvRequest_Data" OnRowCommand="gvRequest_RowCommand"  DataKeyNames="ApplicationID" CellPadding="3"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" >



        <Columns >
            <asp:BoundField  DataField="ApplicationID" HeaderText="رقم الطلب" SortExpression="ApplicationID" ReadOnly="True" />
            <asp:BoundField DataField="ApplicationName" HeaderText="اسم الطلب" SortExpression="ApplicationName" ReadOnly="True" />
            <asp:BoundField DataField="Enable" HeaderText="حالة الطلب" SortExpression="Enable" ReadOnly="True" />
            <asp:TemplateField HeaderText="تاريخ انتهاء الطلب" SortExpression="ExpireDate">
                <EditItemTemplate>
                    <asp:TextBox ID="txtdate" runat="server" Text='<%# Bind("ExpireDate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ExpireDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
                                        
            <asp:TemplateField ShowHeader="False">
                   
                   <ItemTemplate>
                       <asp:Button ID="btnedit1" runat="server" Text="تعديل" class="btn btn-danger" CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'/>
                   </ItemTemplate>          
            </asp:TemplateField>
           <asp:TemplateField ShowHeader="False">
                   <ItemTemplate>
                       <asp:Button ID="btnsave" runat="server" Text="حفظ التغيرات" class="btn btn-danger" CommandName="save" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'/>
                   </ItemTemplate>          
            </asp:TemplateField>
            
           
            </Columns>
       
         <EmptyDataTemplate>
               <asp:Label ID="lblNoUser" runat="server" Font-Bold="True" ForeColor="Red">لا يوجد طلبات مقدمة </asp:Label>
        </EmptyDataTemplate>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066"  />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
        </div>
       
    </div>

    <div class=" w3-white  navbar navbar-expand-lg  w3-padding-64 " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto;  margin-left:3%; margin-right:3%; ">
            <h2  style="float: right; align-items:center; margin: 0 auto; font-family:'Amiri';font-size:20px;"> :حدد وقت بالجامعة </h2>
            
        </div>
       
    </div>
     <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:0.5%;" >
          

      <asp:Label ID="labSemester"  style="font-family:'Amiri'; font-size:large;" runat="server" CssClass="float-left" Width="153px" >الفصل الدراسي الحالي :
      </asp:Label>
          <asp:DropDownList ID="ddlSemester" runat="server" CssClass="form-control" style="float:right;  font-family:'Amiri'; font-size:large;">
              <asp:ListItem Value="0">اختر الفصل</asp:ListItem>
              <asp:ListItem Value="1">الاول</asp:ListItem>
              <asp:ListItem Value="2">الثاني</asp:ListItem>
              <asp:ListItem Value="3">الصيفي</asp:ListItem>
          </asp:DropDownList>
     </div>
      </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right col-5" style="direction:rtl; margin-right:0.5%;" >
          <asp:Label ID="Label2" runat="server" style="font-family:'Amiri'; font-size:large;" CssClass="float-left" Width="133px" >السنة الدراسة الحالية</asp:Label>
          <asp:TextBox ID="txtYear" runat="server" CssClass="form-control" style="float:right;  font-family:'Amiri'; font-size:x-large;" TextMode="Number"  ></asp:TextBox>
     </div>
      </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg w3-margin-bottom " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right " style="direction:rtl; float: none;
    margin: 0 auto; " >
          <asp:Button ID="btnSaveDean"  runat="server" Text="حفظ" class="btn btn-lg btn-danger" align="center" OnClick="btnSaveDean_Click"   />
     <div id="snackbar">
            <asp:Label runat="server" ID="Snack" />
        </div>
       
      </div>
    </div>
   
    </asp:Content>

