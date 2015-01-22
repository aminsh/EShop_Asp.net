<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSite.Default" %>
<%@ Register TagPrefix="comX" Namespace="WebSite.Classes.ComponentX" Assembly="WebSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style2
    {
        width: 70%;
    }
</style>
    <script src="Scripts/bootstrap.js"></script>
    <script>
        !function ($) {
            $(function() {

                $('#myCarousel').carousel();
            })
        }(window.jQuery)
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <section>
         <div id="myCarousel" class="carousel slide" >
                  <div class="carousel-inner">
                      <div class="item active">
                          <img src="Images/sliderImage/banner1.jpg" alt="" style="width: 100%; height: 200px"/>
                          <div class="container">
                              <%--<div class="carousel-caption">
              <h1>Example headline.</h1>
              <p class="lead">Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
              <a class="btn btn-large btn-primary" href="#">Sign up today</a>
            </div>--%>
                              <br />
                              
                          </div>
                      </div>
                      <div class="item">
                          <img src="Images/sliderImage/banner2.jpg" alt="" style="width: 100%; height: 200px"/>
                          <div class="container">
                              <%--<div class="carousel-caption">
              <h1>Another example headline.</h1>
              <p class="lead">Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
              <a class="btn btn-large btn-primary" href="#">Learn more</a>
            </div>--%>
                          </div>
                      </div>
                      <div class="item">
                          <img src="Images/sliderImage/banner3.jpg" alt="" style="width: 100%; height: 200px"/>
                          <div class="container">
                              <%--<div class="carousel-caption">
              <h1>One more for good measure.</h1>
              <p class="lead">Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
              <a class="btn btn-large btn-primary" href="#">Browse gallery</a>
            </div>--%>
                          </div>
                      </div>
                      <div class="item">
                          <img src="Images/sliderImage/banner4.jpg" alt="" style="width: 100%; height: 200px"/>
                          <div class="container">
                              <%--<div class="carousel-caption">
              <h1>One more for good measure.</h1>
              <p class="lead">Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
              <a class="btn btn-large btn-primary" href="#">Browse gallery</a>
            </div>--%>
                          </div>
                      </div>
                      <div class="item">
                          <img src="Images/sliderImage/banner5.jpg" alt="" style="width: 100%; height: 200px"/>
                          <div class="container">
                              <%--<div class="carousel-caption">
              <h1>One more for good measure.</h1>
              <p class="lead">Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
              <a class="btn btn-large btn-primary" href="#">Browse gallery</a>
            </div>--%>
                          </div>
                      </div>
                  </div>

                  
                  <a class="right carousel-control" href="#myCarousel" data-slide="prev">&lsaquo;</a>
                  <a class="left carousel-control" href="#myCarousel" data-slide="next">&rsaquo;</a>
              </div>

    </section>
    <asp:MultiView ID="mv" runat="server" ActiveViewIndex="0">
        <asp:View ID="vEntry" runat="server">
            <fieldset>
            <legend>نظر سنجی</legend>
            <asp:Label ID="lblVoteTitle" runat="server"></asp:Label>
   
            <asp:RadioButtonList ID="rbl" runat="server" DataTextField="Title" DataValueField="ID" CellPadding="0" CellSpacing="0" Width="374px"></asp:RadioButtonList>
                <comX:ButtonX ID="btnSave" Text="ثبت" runat="server" OnClick="btnSave_Click" />
                </fieldset>
        </asp:View>
        <asp:View ID="vResult" runat="server">
            <fieldset>
                <legend>نتیجه نظر سنجی</legend>
                <table>
                    <tr>
                        
                 
                <asp:DataList ID="dlResult" runat="server">
                    <ItemTemplate>
                        <td>
                            <asp:Label  runat="server" Text='<%# Eval("VoteItemTitle") %>'></asp:Label>
                        </td>
                        <td style="width: 100px">
                           
                        </td>
                        <td>
                            <asp:Label  runat="server" Text='<%# Eval("Value") %>'></asp:Label>
                            &nbsp; درصد
                        </td>
                        
                    </ItemTemplate>
                    
                </asp:DataList>
                   </tr>
                </table>
         </fieldset>
        </asp:View>
    </asp:MultiView>
    
</asp:Content>
