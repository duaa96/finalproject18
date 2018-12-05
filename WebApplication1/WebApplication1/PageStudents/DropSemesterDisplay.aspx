<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/PageStudents/student.Master"  CodeBehind="DropSemesterDisplay.aspx.cs" Inherits="WebApplication1.PageStudents.DropSemesterDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; margin-top:10%; ">
      <div class="form-group float-right row w3-responsive" style="direction:rtl; margin-right:3%; width:100%;" >
               <asp:Label ID="errorLabel" runat="server" style="float:right;  float:none; margin:0 auto;  font-family:'Amiri'; font-size:large;" Visible="False" ForeColor="#FF3300"></asp:Label>
    <asp:GridView ID="gvDropSemester"    style="width:1100px; " runat="server"   OnRowDeleting="gvDropSemesterdelete_RowDeleting" AutoGenerateColumns="False" DataKeyNames="ID" CellPadding="3" OnRowCommand="gvDropSemesterView_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowDataBound="gvDropSemester_Data">



        <Columns >
            <asp:BoundField  DataField="ID" HeaderText="رقم الطلب" SortExpression="ID" />
            <asp:BoundField DataField="Date" HeaderText="تاريخ تقديم الطلب" SortExpression="Date" />
            <asp:BoundField DataField="AcademicAdvisorAccept" HeaderText="المرشد الأكاديمي" SortExpression="AcademicAdvisorAccept" />
            <asp:BoundField DataField="HeadAccept" HeaderText="رئيس القسم" SortExpression="HeadAccept" />
            <asp:BoundField DataField="DeanAccept" HeaderText="عميد الكلية" SortExpression="DeanAccept" />
            <asp:BoundField DataField="DeputyAcademicAccept" HeaderText="النائب الأكاديمي" SortExpression="DeputyAcademicAccept" />

            <asp:BoundField DataField="RegestrationAccept" HeaderText="دائرة القبول و التسجيل" SortExpression="RegestrationAccept" />
                                        

             <asp:TemplateField ShowHeader="False">
                   <ItemTemplate>
                       <asp:Button ID="btnedit" runat="server" Text="عرض" CommandName="dispaly1" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'/>
                   </ItemTemplate>          
             </asp:TemplateField> 
             <asp:TemplateField ShowHeader="False">
                   <ItemTemplate>
                         <asp:Button ID="btnedit1" runat="server" Text="تعديل" CommandName="edit1" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'/>
                   </ItemTemplate>          
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                   <ItemTemplate>
                         <asp:Button ID="btnedit2" runat="server" Text="حذف" CommandName="delete" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'/>
                   </ItemTemplate>          
            </asp:TemplateField>
            
            </Columns>
       
         <EmptyDataTemplate>
               <asp:Label ID="lblNoUser" runat="server" Font-Bold="True" ForeColor="Red">لا يوجد طلبات مقدمة </asp:Label>
        </EmptyDataTemplate>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066"  />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
          <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </div>
  </div>
    
</asp:Content>