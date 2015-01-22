<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/RootAdmin.Master" AutoEventWireup="true" CodeBehind="PageVote.aspx.cs" Inherits="WebSite.Admin.PageVote" %>
<%@ Register TagPrefix="comX" Namespace="WebSite.Classes.ComponentX" Assembly="WebSite" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="sqlDs" runat="server" ConnectionString="<%$ ConnectionStrings:dbConnectionString %>" 
                    SelectCommand="SELECT * FROM [Votes] "></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDsVoteItem" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:dbConnectionString %>" 
                            SelectCommand="SELECT * FROM [VoteItems] WHERE VoteID = @VoteID">
                            <SelectParameters>
                                <asp:SessionParameter Name="VoteID" SessionField="VoteID" Type="Int32"/>
                            </SelectParameters>
                        </asp:SqlDataSource>
    <asp:MultiView ID="mv" runat="server" ActiveViewIndex="0">
        <asp:View ID="vList" runat="server">
            <br/>
            <comX:ButtonX ID="btnNew" runat="server" onclick="btnNew_Click" Text="جدید" />
            <br/>
            <comX:GridViewX runat="server" ID="grd"
                            AutoGenerateColumns="False"
                            AllowPaging="True"
                            Skin="Outlook" AllowSorting="True" CellSpacing="0" GridLines="None" OnItemCommand="grd_ItemCommand" DataSourceID="sqlDs"
                            >
                            <mastertableview allowfilteringbycolumn="False" datakeynames="ID" datasourceid="sqlDs" hierarchydefaultexpanded="True">
                                <detailtables>
                                    <telerik:GridTableView runat="server" AllowFilteringByColumn="False" DataKeyNames="ID,VoteID" DataSourceID="sqlDsVoteItem">
                                        <parenttablerelation>
                                            <telerik:GridRelationFields DetailKeyField="VoteID" MasterKeyField="ID" />
                                        </parenttablerelation>
                                        <commanditemsettings exporttopdftext="Export to PDF" />
                                        <rowindicatorcolumn filtercontrolalttext="Filter RowIndicator column">
                                        </rowindicatorcolumn>
                                        <expandcollapsecolumn filtercontrolalttext="Filter ExpandColumn column">
                                        </expandcollapsecolumn>

                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Title" FilterControlAltText="Filter Title column" HeaderText="عنوان" SortExpression="Title" UniqueName="Title">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>

                                            <telerik:GridTemplateColumn FilterControlAltText="Filter tmp column" UniqueName="tmp">
                                                        <ItemTemplate>
                                                            <comX:ButtonX ID="btnEditItem" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="btnEditItem" Text="ویرایش" Width="70px" />
                                                            <comX:ButtonX ID="btnDeleteItem" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="btnDeleteItem" 
                                                                onclientclick="return confirm('آیا مایل به حذف اطلاعات جاری هستید ؟');" Text="حذف" Width="70px" />
                                                        </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                        </Columns>
                                        <editformsettings>
                                            <editcolumn filtercontrolalttext="Filter EditCommandColumn column">
                                            </editcolumn>
                                        </editformsettings>
                                    </telerik:GridTableView>
                                </detailtables>
                                <commanditemsettings exporttopdftext="Export to PDF" />
                                <rowindicatorcolumn filtercontrolalttext="Filter RowIndicator column">
                                    <HeaderStyle Width="20px" />
                                </rowindicatorcolumn>
                                <expandcollapsecolumn filtercontrolalttext="Filter ExpandColumn column">
                                    <HeaderStyle Width="20px" />
                                </expandcollapsecolumn>
                                <Columns>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter tmpDate column" UniqueName="tmpGeneral">
                                    <ItemTemplate>
                                        <p>
                                            <b>
                                                موضوع :
                                            </b>
                                            <%# Eval("Title") %>
                                        </p>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>    
                                
                                <telerik:GridTemplateColumn FilterControlAltText="Filter tmp column" UniqueName="tmp">
                                    <ItemTemplate>
                                        <comX:ButtonX ID="btnEdit" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="btnEdit" Text="ویرایش" Width="100px" />
                                        <comX:ButtonX ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="btnDelete" onclientclick="return confirm('آیا مایل به حذف اطلاعات جاری هستید ؟');" Text="حذف" Width="100px" />
                                        <comX:ButtonX ID="btnNewDetail" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="btnNewItem" Text="ردیف جدید" Width="100px" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                                <editformsettings>
                                    <editcolumn filtercontrolalttext="Filter EditCommandColumn column">
                                    </editcolumn>
                                </editformsettings>
                            </mastertableview>
                            <filtermenu enableimagesprites="False">
                            </filtermenu>
                            <headercontextmenu cssclass="GridContextMenu GridContextMenu_WebBlue">
                            </headercontextmenu>
                        </comX:GridViewX>
        </asp:View>
        <asp:View ID="vEditVote" runat="server">
            
            <table class="auto-style1">
                <tr>
                    <td colspan="2">
                        <comX:ButtonX ID="btnSave" runat="server" onclick="btnSave_Click" Text="ذخیره" Width="100px" />
                        <comX:ButtonX ID="btnCancel" runat="server" CausesValidation="False" onclick="btnCancel_Click" Text="انصراف" Width="100px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100px">موضوع :</td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="موضوع الزامی میباشد" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            
        </asp:View>
        <asp:View ID="vEditItem" runat="server">
            <table class="auto-style1">
                <tr>
                    <td colspan="2">
                        <comX:ButtonX ID="btnSaveItem" runat="server" onclick="btnSaveItem_Click" Text="ذخیره" Width="100px" />
                        <comX:ButtonX ID="btnCancelItem" runat="server" CausesValidation="False" onclick="btnCancel_Click" Text="انصراف" Width="100px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100px">عنوان :</td>
                    <td>
                        <asp:TextBox ID="txtTitleItem" runat="server" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitleItem" Display="Dynamic" 
                            ErrorMessage="عنوان الزامی میباشد" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </asp:View>
    </asp:MultiView>
    
</asp:Content>
