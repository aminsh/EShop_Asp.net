using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper.MyHelper;
using Model;
using Tools.Convertors;
using WebSite.Classes.BLogic;
using WebSite.Classes.Tools;

namespace WebSite.Admin
{
    public partial class PageProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grd_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

            if (e.CommandName == "btnEdit")
            {
                ViewState["editmode"] = "edit";
                ViewState["id"] = e.CommandArgument.ToString();

                int id = Convert.ToInt32(e.CommandArgument);
                var product = ProductManagement.Query().FirstOrDefault(p => p.ID == id);


                if (product != null)
                {
                    txtTitle.Text = product.Title;
                    ViewState["ImageUrl"] = product.ImageUrl;
                    txtPrice.Text = product.Price.ToString();
                    ddlProductCategory.SelectedValue = product.ProductCategoryID.ToString();
                    txtDescription.Text = product.Description;
                }

                mv.SetActiveView(vwEntry);

            }
            else if (e.CommandName == "btnDelete")
            {
                var id = e.CommandArgument.ToInt32();
                var product = ProductManagement.Query().FirstOrDefault(pc => pc.ID == id);
                if (product != null)
                    if (product.ImageUrl != string.Empty)
                        FileUploadTools.RemoveFile(Server.MapPath(product.ImageUrl), "productPath");

                ProductManagement.Delete(id);
                grd.DataBind();
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ViewState["editmode"] = "new";

            txtTitle.Text = string.Empty;
            ViewState["ImageUrl"] = string.Empty;

            mv.SetActiveView(vwEntry);

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ViewState["editmode"].ToString() == "new")
            {
                if (fuImageUrl.HasFile)
                {
                    var relativeFilename = FileUploadTools.RelariveFileName(fuImageUrl.PostedFile.FileName, "productPath");
                    var physicalFilename = Server.MapPath(relativeFilename);

                    fuImageUrl.PostedFile.SaveAs(physicalFilename);
                    ThumbnailHelper.CreateThumbnail(physicalFilename);

                    ViewState["ImageUrl"] = relativeFilename;
                    //txtTitle.Text = string.Empty;
                    //txtDescription.Text = string.Empty;
                    //txtPrice.Text = "0";


                }

                var product = new Product()
                {
                    Title = txtTitle.Text,
                    ImageUrl = ViewState["ImageUrl"].ToString(),
                    ProductCategoryID = ddlProductCategory.SelectedValue.ToInt32(),
                    Price = txtPrice.Text.ToInt32(),
                    Description = txtDescription.Text
                };
                ProductManagement.Insert(product);
                mv.SetActiveView(vwList);
                grd.DataBind();
            }
            else if (ViewState["editmode"].ToString() == "edit")
            {
                if (fuImageUrl.PostedFile.ContentLength != 0)
                {
                    var relativeFilename = FileUploadTools.RelariveFileName(fuImageUrl.PostedFile.FileName, "productPath");

                    string physicalFilename = Server.MapPath(relativeFilename);
                    fuImageUrl.PostedFile.SaveAs(physicalFilename);
                    ThumbnailHelper.CreateThumbnail(physicalFilename);

                    if (ViewState["ImageUrl"].ToString() != string.Empty)
                    {
                        FileUploadTools.RemoveFile(ViewState["ImageUrl"].ToString(), "productPath");
                    }
                    ViewState["ImageUrl"] = relativeFilename;
                }

                int id = Convert.ToInt32(ViewState["id"]);
                var product = ProductManagement.Query().FirstOrDefault(pc => pc.ID == id);

                product.Title = txtTitle.Text;
                product.ImageUrl = ViewState["ImageUrl"].ToString();
                product.ProductCategoryID = ddlProductCategory.SelectedValue.ToInt32();
                product.Price = txtPrice.Text.ToInt32();
                product.Description = txtDescription.Text;

                ProductManagement.Update(product);

                mv.SetActiveView(vwList);
                grd.DataBind();
            }
        }


        protected string GetThumbFilename(string filename)
        {
            return filename == string.Empty
                ? string.Empty
                : FileUploadTools.GetThumbFilename(filename);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mv.SetActiveView(vwList);
        }

       
    }
}