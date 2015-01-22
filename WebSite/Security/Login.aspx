<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebSite.Security.Login" %>
<%@ Register TagPrefix="comX" Namespace="WebSite.Classes.ComponentX" Assembly="WebSite" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" style="width: 70%">
        <tr>
            <td width="100">
                نام کاربری :</td>
            <td align="right">
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" 
                    ControlToValidate="txtUserName" Display="Dynamic" 
                    ErrorMessage="لطفا نام کاربر را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                کلمه عبور :</td>
            <td align="right">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                    ControlToValidate="txtPassword" Display="Dynamic" 
                    ErrorMessage="لطفا کلمه عبور را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvLogin" runat="server" Display="Dynamic" 
                    ErrorMessage="نام کاربر یا کلمه عبور صحیح نیست" ForeColor="Red" 
                    onservervalidate="cvLogin_ServerValidate">→</asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:CheckBox ID="chkRemember" runat="server" Text="مشخصات مرا بخاطر بسپار" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                <comX:ButtonX ID="btnLogin" runat="server" Text="ورود به سیستم" Width="200px" 
                    onclick="btnLogin_Click"
                    />
                <a href="Register.aspx">ثبت نام</a>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:ValidationSummary ID="vsLogin" runat="server" ForeColor="Red" />
            </td>
        </tr>
    </table>
</asp:Content>
