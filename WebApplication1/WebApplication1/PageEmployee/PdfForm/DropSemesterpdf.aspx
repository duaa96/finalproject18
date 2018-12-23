<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropSemesterpdf.aspx.cs" Inherits="WebApplication1.PageEmployee.DropSemesterpdf" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DropSemesterPDF</title>
    <link rel="stylesheet" type="text/css" media="screen" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" media="screen" href="../css/w3.css" />
    <link rel="stylesheet" type="text/css" media="screen" href="../css/w3pro.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    
    <link rel="stylesheet" href="../css/cssCoustem.css">
</head>
<body>
    <form id="form1" runat="server">

        <asp:Panel ID="Panel1" runat="server"> 
 <div class=" w3-cell-row " runat="server">
        <div class="w3-white w3-center navbar navbar-expand-lg " style="direction:rtl;">
            <h3 >نموذج تقديم سحب فصل دراسي  </h3>
            

        </div>
        
    </div>

    <div class=" w3-white w3-center navbar navbar-expand-lg " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin-right:7%; margin-left:3%; left: 0px; top: -29px; height: 40px; margin-top: 0; margin-bottom: 0;">
            <h3  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">معلومات الطالب </h3>
            
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
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;">عدد الساعات المسجلة:
          </label>
          
          &nbsp;<asp:TextBox ID="txtNumHours" runat="server" CssClass="form-control bg-white" style="float:right; font-family:'Amiri';" TextMode="Number" Enabled="False"></asp:TextBox>
            
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
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;">المساقات التي سجلها الطالب:</label>
      
       
      </div>
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; ">
      <div class="form-group float-right row w3-responsive" style="direction:rtl; margin-right:3%;" >
       <asp:GridView  ID="gvCourses" class="w3-table w3-border w3-center"   style=" font-family:'Amiri';"   runat="server" AutoGenerateColumns="False" DataKeyNames="SubjectID" width="900px" CellPadding="3"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" >
                                    <Columns >
                                        <asp:BoundField DataField="SubjectID" ItemStyle-CssClass="w3-center"  HeaderStyle-CssClass="w3-center" HeaderText="رقم المساق" SortExpression="SubjectID" />

                                        <asp:BoundField  DataField="SubjectName" ItemStyle-CssClass="w3-center"  HeaderStyle-CssClass="w3-center" HeaderText="اسم المساق" SortExpression="SubjectName" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <asp:Label ID="lblNoUser" runat="server" Font-Bold="True" ForeColor="Red">لا يوجد مواد مسجلة للطالب  </asp:Label>
                                    </EmptyDataTemplate>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#4CAF50" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#dc3545" />
                                    <SortedAscendingHeaderStyle BackColor="#dc3545" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#dc3545" />
                                </asp:GridView>
     </div>  
        </div>
 
  

    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-5" style="direction:rtl; margin-right:0.5%;" >

      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;">أرغب بسحب الفصل و ذلك للأسباب التالية:

          </label>
      
       
      &nbsp;</div>
    </div>

  <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
      <asp:TextBox ID="txtReasons" runat="server"   CssClass="form-control w3-margin-right col-12 bg-white " Height="100px"   align="right" Enabled="False"></asp:TextBox>
      
       
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
    
       <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h3  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">معلومات المرشد الأكاديمي: </h3>
            
        </div>
       
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-12" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;"> ملاحظات  المرشد الأكاديمي:
      
       
          </label>
         &nbsp;</div>
    </div>
 <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
      <asp:TextBox ID="txtDescriptionAcadimic" runat="server"   CssClass="form-control w3-margin-right col-12  bg-white " Height="100px"   align="right"  style="right: 0px" Enabled="False"></asp:TextBox>
      
       
      </div>
    </div>
     <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
     
          <asp:RadioButtonList ID="rbtAcceptAcadimic" runat="server" style="float:right;  font-family:'Amiri'; font-size:medium;" RepeatLayout="Table" CssClass="RBL"   RepeatDirection="Horizontal" Enabled="False" >
               <asp:ListItem Text="موافق" Value="1" />
               <asp:ListItem Text="غير موافق" Value="2" />
          </asp:RadioButtonList>
      </div>
    </div>
      <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h3  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">معلومات رئيس القسم : </h3>
            
        </div>
       
    </div>
      <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-12" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;"> ملاحظات رئيس القسم:
      
       
          </label>
         &nbsp;</div>
    </div>
 <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
      <asp:TextBox ID="txtDescriptionHead" runat="server"   CssClass="form-control w3-margin-right col-12  bg-white " Height="100px"   align="right"  style="right: 0px" Enabled="false"></asp:TextBox>
      
       
      </div>
    </div>
     <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
     
          <asp:RadioButtonList ID="rbtAceptHead" style="float:right;  font-family:'Amiri'; font-size:medium;" RepeatLayout="Table" CssClass="RBL"  runat="server" RepeatDirection="Horizontal" Enabled="false" Visible="true">
               <asp:ListItem Text="موافق" Value="1" />
               <asp:ListItem Text="غير موافق" Value="2" />
          </asp:RadioButtonList>
      </div>
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h3  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">معلومات عميد الكلية </h3>
            
        </div>
       
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-12" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;"> ملاحظات عميد الكلية:
      
       
          </label>
         &nbsp;</div>
    </div>
 <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
      <asp:TextBox ID="txtDescriptionDean" runat="server"   CssClass="form-control w3-margin-right col-12  bg-white " Height="100px"   align="right" Enabled="false" style="right: 0px"></asp:TextBox>
      
       
      </div>
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
     
          <asp:RadioButtonList ID="rbtDeanAccept" style="float:right;  font-family:'Amiri'; font-size:medium;" RepeatLayout="Table" CssClass="RBL"  runat="server" RepeatDirection="Horizontal" Enabled="false" >
               <asp:ListItem Text="موافق" Value="1" />
               <asp:ListItem Text="غير موافق" Value="2" />
          </asp:RadioButtonList>
      </div>
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h3  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">معلومات النائب الأكاديمي </h3>
            
        </div>
       
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-12" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;"> ملاحظات النائب الأكاديمي:

      
       
          </label>
         &nbsp;</div>
    </div>
 <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
      <asp:TextBox ID="txtDescriptinDep" runat="server"   CssClass="form-control w3-margin-right col-12  bg-white " Height="100px"   align="right" Enabled="False" style="right: 0px"></asp:TextBox>
      
       
      </div>
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
     
          <asp:RadioButtonList ID="rbtDepAcept" style="float:right;  font-family:'Amiri'; font-size:medium;" RepeatLayout="Table" CssClass="RBL"  runat="server" RepeatDirection="Horizontal" Enabled="false" >
               <asp:ListItem Text="موافق" Value="1" />
               <asp:ListItem Text="غير موافق" Value="2" />
          </asp:RadioButtonList>
      </div>
    </div>
   
 <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h3  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">معلومات دائرة القبول و التسجيل </h3>
            
        </div>
  </div>  
     <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-12" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:large;"> ملاحظات دائرة القبول و التسجيل:</label></div>
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
         

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
      <asp:TextBox ID="txtDescriptionReg" runat="server"   CssClass="form-control w3-margin-right col-12  bg-white " Height="100px"   align="right"  style="right: 0px" Enabled="false"></asp:TextBox>
      
       
      </div>
    </div>
<div class=" w3-white w3-center navbar navbar-expand-lgpadding-16" style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
     
          <asp:RadioButtonList ID="rbtAcceptRegistration" style="float:right;  font-family:'Amiri'; font-size:medium;" RepeatLayout="Table" CssClass="RBL"  runat="server" RepeatDirection="Horizontal" Enabled="false">
               <asp:ListItem Text="موافق" Value="1" />
               <asp:ListItem Text="غير موافق" Value="2" />
          </asp:RadioButtonList>
       
      </div>
    </div>
     </asp:Panel>
    </form>
</body>
</html>
