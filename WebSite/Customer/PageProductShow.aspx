<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/RootWithBasket.Master" AutoEventWireup="true" CodeBehind="PageProductShow.aspx.cs" Inherits="WebSite.Customer.PageProductShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.7.2.min.js"></script>
    <script src="../Scripts/lightbox.js"></script>
    <link href="../Content/lightbox.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="demo-section">
        <h2>گروه محصولات</h2>
        <input data-bind="kendoDropDownList: {
    data: productCategories, value: selectedProductCategoryId,
    template: tmp,
    useKOTemplates: true, dataTextField: 'Title', dataValueField: 'ID'
}" style="width: 400px;" id="ddlproductCategory" />   
    </div>
  
   <div data-bind="kendoListView: { data: products, template: 'listTmpl', useKOTemplates: true }" id="listView"> </div>
    
    <script id="listTmpl" type="text/html">
        <div class="product">
            <a data-bind="attr: { href: ImageUrl }" rel="lightbox">
                <img data-bind="attr: { src: ImageUrlThumb }" />
            </a>
            
             <h3 data-bind="text: Title"></h3>
            <a class="btn btn-success" href="#" data-bind="click: $parent.addToBasket"><i class="icon-shopping-cart icon-white"></i> اضافه به سبد خرید </a>            
        </div>
</script>
</asp:Content>
