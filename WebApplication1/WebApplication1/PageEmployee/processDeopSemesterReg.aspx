<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/PageEmployee/Reg.Master"  CodeBehind="processDeopSemesterReg.aspx.cs" Inherits="WebApplication1.PageEmployee.processDeopSemesterReg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" w3-cell-row ">
        <div class="w3-white w3-center navbar navbar-expand-lg w3-margin-top w3-margin-bottom w3-padding-24" style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2 style="float: none;
    margin: 0 auto; font-family:'Amiri'">نموذج تقديم سحب فصل دراسي  </h2><br />
            

        </div>
        
    </div>

    <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  w3-padding-24 " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " stle=" float: none;
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
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;">المساقات التي سجلها الطالب:</label>
      
       
      </div>
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class="form-group float-right row w3-responsive" style="direction:rtl; margin-right:3%;" >
       <asp:GridView ID="gvCourses" class="w3-table w3-border w3-center"   style=" font-family:'Amiri';"   runat="server" AutoGenerateColumns="False" DataKeyNames="SubjectID" width="900px" CellPadding="3"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
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

      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;">أرغب بسحب الفصل و ذلك للأسباب التالية:

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
    
       <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  w3-padding-24 " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">معلومات المرشد الأكاديمي </h2>
            
        </div>
       
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-12" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;"> ملاحظات  المرشد الأكاديمي:
      
       
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
     
          <asp:RadioButtonList ID="rbtAcceptAcadimic" style="float:right;  font-family:'Amiri'; font-size:x-large;" RepeatLayout="Table" CssClass="RBL"  runat="server" RepeatDirection="Horizontal" Enabled="False" >
               <asp:ListItem Text="موافق" Value="1" />
               <asp:ListItem Text="غير موافق" Value="2" />
          </asp:RadioButtonList>
      </div>
    </div>
      <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  w3-padding-24 " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">معلومات رئيس القسم  </h2>
            
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
      <asp:TextBox ID="txtDescriptionHead" runat="server"   CssClass="form-control w3-margin-right col-12  bg-white " Height="100px"   align="right"  style="right: 0px" Enabled="false"></asp:TextBox>
      
       
      </div>
    </div>
     <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
     
          <asp:RadioButtonList ID="rbtAceptHead" style="float:right;  font-family:'Amiri'; font-size:x-large;" RepeatLayout="Table" CssClass="RBL"  runat="server" RepeatDirection="Horizontal" Enabled="false" Visible="true">
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
      <asp:TextBox ID="txtDescriptionDean" runat="server"   CssClass="form-control w3-margin-right col-12  bg-white " Height="100px"   align="right" Enabled="false" style="right: 0px"></asp:TextBox>
      
       
      </div>
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
     
          <asp:RadioButtonList ID="rbtDeanAccept" style="float:right;  font-family:'Amiri'; font-size:x-large;" RepeatLayout="Table" CssClass="RBL"  runat="server" RepeatDirection="Horizontal" Enabled="false" >
               <asp:ListItem Text="موافق" Value="1" />
               <asp:ListItem Text="غير موافق" Value="2" />
          </asp:RadioButtonList>
      </div>
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  w3-margin-top  w3-padding-24 " style=" float: none;
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
        <div class="w3-cell-row w3-white w3-center navbar navbar-expand-lg  " style=" float: none;
                                                margin: 0 auto; margin-right:7%; margin-left:3%; ">
            <h2  style="float: none; align-items:center; margin: 0 auto; font-family:'Amiri'">معلومات النائب الأكاديمي </h2>
            
        </div>
       
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
      <div class=" w3-row form-group float-right col-12" style="direction:rtl; margin-right:0.5%;" >
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;"> ملاحظات النائب الأكاديمي:

      
       
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
     
          <asp:RadioButtonList ID="rbtDepAcept" style="float:right;  font-family:'Amiri'; font-size:x-large;" RepeatLayout="Table" CssClass="RBL"  runat="server" RepeatDirection="Horizontal" Enabled="false" >
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
      <label for="exampleInpuStudentsNum"  style="float:right;  font-family:'Amiri'; font-size:x-large;"> ملاحظات دائرة القبول و التسجيل:<asp:RequiredFieldValidator runat="server" ForeColor="Red" ID="RequiredFieldValidator1" ControlToValidate="txtDescriptionReg" ErrorMessage="*"></asp:RequiredFieldValidator></label>
      
       
      </div>
    </div>
    <div class=" w3-white w3-center navbar navbar-expand-lg  " style=" float: none; direction:rtl; 
    margin: 0 auto; margin-right:7%; margin-left:3%; ">
         

      <div class=" w3-row form-group float-right " style="direction:rtl; margin-right:0.5%; margin-left:3%; width:950px;" >
      <asp:TextBox ID="txtDescriptionReg" runat="server"   CssClass="form-control w3-margin-right col-12  bg-white " Height="100px"   align="right"  style="right: 0px"></asp:TextBox>
      
       
      </div>
    </div>
<div class=" w3-white w3-center navbar navbar-expand-lg   " style=" float: none; direction:rtl; 
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

         <asp:RequiredFieldValidator runat="server" ForeColor="Red" ID="RequiredFieldValidator7" ControlToValidate="fuSignatureReg" ErrorMessage="*"></asp:RequiredFieldValidator>

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
         <asp:RequiredFieldValidator runat="server" ForeColor="Red" ID="RequiredFieldValidator2" ControlToValidate="txtPassSign" ErrorMessage="*"></asp:RequiredFieldValidator>

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
    <script src="js/jquery-2.1.1.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="js/plugins/slimscroll/jquery.slimscroll.min.js"></script>

    <!-- Custom and plugin javascript -->
    <script src="js/inspinia.js"></script>
    <script src="js/plugins/pace/pace.min.js"></script>

    <!-- iCheck -->
    <script src="js/plugins/iCheck/icheck.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.i-checks').iCheck({
                checkboxClass: 'icheckbox_square-green',
                radioClass: 'iradio_square-green',
            });
        });
    </script>




</asp:Content>

