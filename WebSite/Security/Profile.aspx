<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebSite.Security.Profile" %>
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
                    <td align="right">
                        نام :</td>
                    <td align="right">
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                            ControlToValidate="txtFirstName" Display="Dynamic" 
                            ErrorMessage="لطفا نام را وارد کنید" 
                            ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                         نام خانوادگی:</td>
                    <td align="right">
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" 
                            ControlToValidate="txtLastName" Display="Dynamic" 
                            ErrorMessage="لطفا نام و نام خانوادگی را وارد کنید" 
                            ForeColor="Red">→</asp:RequiredFieldValidator>
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
                        <asp:TextBox ID="txtAddress" runat="server" Width="300px" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                            ControlToValidate="txtAddress" Display="Dynamic" 
                            ErrorMessage="لطفا آدرس پستی را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="right">
                        <comX:ButtonX ID="btnSave" runat="server" 
                            Text="ذخیره" Width="200px" CssClass="btn btn-success" OnClick="btnSave_Click"/>
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
            بروزرسانی پروفایل شما با موفقیت انجام شد.<br />
            <br />
            جهت بازگشت به صفحه اصلی سایت
            <asp:HyperLink ID="hlDefaultPage" runat="server" NavigateUrl="~/Default.aspx">اینجا</asp:HyperLink>
            &nbsp;را کلیک کنید.<br />
        </asp:View>
    </asp:MultiView>
    </td>
</tr>
</table>
</asp:Content>
