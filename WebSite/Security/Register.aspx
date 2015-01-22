<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebSite.Security.Register" %>
<%@ Register TagPrefix="comX" Namespace="WebSite.Classes.ComponentX" Assembly="WebSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 70%" align="center">
<tr>
    <td>
        <asp:MultiView ID="mvRegister" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwRegister" runat="server">
            <table style="width: 70%">
                <tr>
                    <td align="right" width="400px">
                        نام کاربری:</td>
                    <td align="right">
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" 
                            ControlToValidate="txtUsername" Display="Dynamic" 
                            ErrorMessage="لطفا نام کاربر را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvUsername" runat="server" 
                            ErrorMessage="نام کاربری قبلا گرفته شده است" ForeColor="Red" 
                            onservervalidate="cvUsername_ServerValidate">→</asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        کلمه عبور:</td>
                    <td align="right">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                            ControlToValidate="txtPassword" Display="Dynamic" 
                            ErrorMessage="لطفا کلمه عبور را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        کلمه عبور (مجدد):</td>
                    <td align="right">
                        <asp:TextBox ID="txtPasswordAgain" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPasswordAgain" runat="server" 
                            ControlToValidate="txtPasswordAgain" Display="Dynamic" 
                            ErrorMessage="لطفا کلمه عبور را مجددا وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvPasswordCompare" runat="server" 
                            ControlToCompare="txtPassword" ControlToValidate="txtPasswordAgain" 
                            Display="Dynamic" ErrorMessage="دو کلمه عبور وارد شده یکسان نیستند" 
                            ForeColor="Red">→</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        نام و نام خانوادگی:</td>
                    <td align="right">
                        <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFullName" runat="server" 
                            ControlToValidate="txtFullName" Display="Dynamic" 
                            ErrorMessage="لطفا نام و نام خانوادگی را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        شماره تماس:</td>
                    <td align="right">
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" 
                            ControlToValidate="txtPhone" Display="Dynamic" 
                            ErrorMessage="لطفا شماره تماس را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        آدرس ایمیل:</td>
                    <td align="right">
                        <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                            ControlToValidate="txtPhone" Display="Dynamic" 
                            ErrorMessage="لطفا آدرس ایمیل را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                            ControlToValidate="txtEmail" Display="Dynamic" 
                            ErrorMessage="آدرس ایمیل وارد شده صحیح نیست" ForeColor="Red" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">→</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        آدرس پستی:</td>
                    <td align="right">
                        <asp:TextBox ID="txtAddress" runat="server" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                            ControlToValidate="txtAddress" Display="Dynamic" 
                            ErrorMessage="لطفا آدرس پستی را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="right">
                        <comX:ButtonX ID="btnRegister" runat="server" onclick="btnRegister_Click" 
                            Text="تکمیل ثبت نام" Width="200px" />
                    </td>
                </tr>
                <tr>
                <td></td>
                    <td align="right">
                        <asp:ValidationSummary ID="vsRegister" runat="server" ForeColor="Red" 
                            Width="100%" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vwMessage" runat="server">
            ثبت نام شما با موفقیت انجام شد.<br />
            <br />
            جهت بازگشت به صفحه اصلی سایت
            <asp:HyperLink ID="hlDefaultPage" runat="server" NavigateUrl="~/Default.aspx">اینجا</asp:HyperLink>
            &nbsp;را کلیک کنید.<br />
            <br />
            برای ورود به سیستم
            <asp:HyperLink ID="hlLoginPage" runat="server" NavigateUrl="Login.aspx">اینجا</asp:HyperLink>
            &nbsp;را کلیک کنید.
        </asp:View>
    </asp:MultiView>
    </td>
</tr>
</table>
    
</asp:Content>
