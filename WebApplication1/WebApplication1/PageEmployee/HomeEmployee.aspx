<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/PageEmployee/employee.Master" CodeBehind="HomeEmployee.aspx.cs" Inherits="WebApplication1.PageEmployee.HomeEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                      <img src="img/logo2.png" Class=" img-circle rounded  w3-padding-64 w3-opacity-max" style="margin-right:30%"width=500 >
    <asp:Literal ID="PopupBox" runat="server" Visible="false"></asp:Literal>
    <div id="simplemodal-container" class="simplemodal-container" style=" display:none;position: fixed; z-index: 1002; height: 320px; width: 590px; left: 365.5px; top: -31.5px;"><a class="modalCloseImg simplemodal-close" title="Close"></a><div tabindex="-1" class="simplemodal-wrap" style="height: 100%; outline: 0px; width: 100%; overflow: auto;"><div id="messageDialog" lang="ar" dir="rtl" style="" class="simplemodal-data">

                    <h3 style="text-align: right">
                        <span id="msgTitle">رسالة تنبيه.... الرجاء الإنتباه</span>
                    </h3>
                    <p></p>
                    <h2 style="text-align: center"><span id="msgBody">الملبغ المدفوع غير كافي لعملية التسجيل بالحد الإدنى او المبلغ المدفوع من البنك غير مرحل الى الان</span></h2>
                </div></div></div>
</asp:Content>