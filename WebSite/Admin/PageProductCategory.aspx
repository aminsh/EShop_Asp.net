<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/RootAdmin.Master" AutoEventWireup="true" CodeBehind="PageProductCategory.aspx.cs" Inherits="WebSite.Admin.PageProductCategory" %>

<%@ Register TagPrefix="comX" Namespace="WebSite.Classes.ComponentX" Assembly="WebSite" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:SqlDataSource ID="sqlDs" runat="server" ConnectionString="<%$ ConnectionStrings:dbConnectionString %>" 
                    SelectCommand="SELECT * FROM [ProductCategories] ORDER BY [ID]"></asp:SqlDataSource>
                <asp:MultiView ID="mv" runat="server" ActiveViewIndex="0">
                    <asp:View ID="vwList" runat="server">
                        <table class="style2" >
                            <tr>
                                <td align="right">
                                    <comX:ButtonX ID="btnNew" runat="server" onclick="btnNew_Click" Text="جدید" 
                                        Width="100px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <comX:GridViewX ID="grd" runat="server" CellSpacing="0" 
                                        GridLines="None" onitemcommand="grd_ItemCommand" Skin="Outlook" 
                                        AllowSorting="True" DataSourceID="sqlDs" AllowFilteringByColumn="True" AllowPaging="True" Culture="fa-IR">
                                        <MasterTableView autogeneratecolumns="False" datakeynames="ID" DataSourceID="sqlDs" 
                                            >
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                 <telerik:GridTemplateColumn DataField="ImageUrl" 
                                                    FilterControlAltText="Filter ImageUrl column" HeaderText="تصویر" 
                                                    UniqueName="ImageUrl" AllowFiltering="False">
                                                    <ItemTemplate>     
                                                        <asp:Image ID="Image1" runat="server" 
                                                            ImageUrl='<%# GetThumbFilename(Eval("ImageUrl").ToString()) %>' Visible='<%# Eval("ImageUrl")!=null %>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="Title" 
                                                    FilterControlAltText="Filter Title column" HeaderText="عنوان" 
                                                    SortExpression="Title" UniqueName="Title">
                                                   
                                                </telerik:GridBoundColumn>
                                               
                                                <telerik:GridTemplateColumn FilterControlAltText="Filter tmp column" 
                                                    UniqueName="tmp" AllowFiltering="False">
                                                    

                                                    <ItemTemplate>
                                                        

                                                        <comX:ButtonX ID="btnEdit" runat="server" CommandArgument='<%# Eval("ID") %>' 
                                                            CommandName="btnEdit" Text="ویرایش" Width="70px" />
                                                        

                                                        <comX:ButtonX ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' 
                                                            CommandName="btnDelete" Text="حذف" Width="70px" 
                                                            OnClientClick="return confirm('آیا مایل به حذف ردیف جاری هستید ؟')"/>
                                                        

                                                    </ItemTemplate>
                                                    

                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView>
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_WebBlue">
                                        </HeaderContextMenu>
                                    </comX:GridViewX>
                                    <br/>
                                    
                                  
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="vwEntry" runat="server">
                        <div id="entry">
                            
                            <table class="style2">
                                <tr>
                                    <td colspan="2" align="right">
                                        <comX:ButtonX ID="btnSave" runat="server" Text="ذخیره" Width="100px" 
                                            onclick="btnSave_Click" />
                                        <comX:ButtonX ID="btnCancel" runat="server" Text="انصراف" Width="100px" 
                                            onclick="btnCancel_Click" CausesValidation="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        عنوان :
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" 
                                            ErrorMessage="عنوان الزامی میباشد" Display="Dynamic" ControlToValidate="txtTitle" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        آیکون :</td>
                                    <td align="right">
                                        <asp:FileUpload ID="fuImageUrl" runat="server" />
                                    </td>
                                </tr>
                            </table>
                            
                        </div>
                    </asp:View>
                </asp:MultiView>
    
</asp:Content>
