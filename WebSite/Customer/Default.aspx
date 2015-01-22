<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/RootWithBasket.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSite.Customer.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/bootstrap.js"></script>
     <script>
         !function ($) {
             $(function () {

                 $('#myCarousel').carousel();
             })
         }(window.jQuery)
     </script>
    
    <section>
         <div id="myCarousel" class="carousel slide">
                  <div class="carousel-inner">
                      <div class="item active">
                          <img src="../Images/sliderImage/banner1.jpg" alt="" style="width: 100%; height: 200px"/>
                          <div class="container">
                          
                          </div>
                      </div>
                      <div class="item">
                          <img src="../Images/sliderImage/banner2.jpg" alt="" style="width: 100%; height: 200px"/>
                          <div class="container">
                             
                          </div>
                      </div>
                      <div class="item">
                          <img src="../Images/sliderImage/banner3.jpg" alt="" style="width: 100%; height: 200px"/>
                          <div class="container">
                             
                          </div>
                      </div>
                      <div class="item">
                          <img src="../Images/sliderImage/banner4.jpg" alt="" style="width: 100%; height: 200px"/>
                          <div class="container">
                              
                          </div>
                      </div>
                      <div class="item">
                          <img src="../Images/sliderImage/banner5.jpg" alt="" style="width: 100%; height: 200px"/>
                          <div class="container">
                             
                          </div>
                      </div>
                  </div>

                  
                  <a class="right carousel-control" href="#myCarousel" data-slide="prev">&lsaquo;</a>
                  <a class="left carousel-control" href="#myCarousel" data-slide="next">&rsaquo;</a>
              </div>

    </section>
</asp:Content>
