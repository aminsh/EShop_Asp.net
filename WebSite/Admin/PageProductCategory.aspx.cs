using System;
using System.Drawing;
using System.IO;
using Helper.MyHelper;
using Model;
using Tools.Convertors;
using WebSite.Classes.BLogic;
using WebSite.Classes.Tools;
using apocryph.BitmapManip;
using System.Linq;

namespace WebSite.Admin
{
    public partial class PageProductCategory : System.Web.UI.Page
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
                var productCategory = ProductCategoryManagement.Query().FirstOrDefault(pc => pc.ID == id);


                if (productCategory != null)
                {
                    txtTitle.Text = productCategory.Title;
                    ViewState["ImageUrl"] = productCategory.ImageUrl;
                }

                mv.SetActiveView(vwEntry);

            }
            else if (e.CommandName == "btnDelete")
            {
                var id = e.CommandArgument.ToInt32();
                var productCategory = ProductCategoryManagement.Query().FirstOrDefault(pc => pc.ID == id);
                if (productCategory != null)
                    if(productCategory.ImageUrl!=string.Empty)
                    FileUploadTools.RemoveFile(Server.MapPath(productCategory.ImageUrl), "ProductCategoryPath");
                
                ProductCategoryManagement.Delete(id);
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
                    var relativeFilename = FileUploadTools.RelariveFileName(fuImageUrl.PostedFile.FileName, "ProductCategoryPath");
                    var physicalFilename = Server.MapPath(relativeFilename);

                    fuImageUrl.PostedFile.SaveAs(physicalFilename);
                    ThumbnailHelper.CreateThumbnail(physicalFilename);

                    ViewState["ImageUrl"] = relativeFilename;
                }

                var productCategory = new ProductCategory()
                                          {
                                              Title = txtTitle.Text,
                                              ImageUrl = ViewState["ImageUrl"].ToString()
                                          };
                ProductCategoryManagement.Insert(productCategory);
                mv.SetActiveView(vwList);
                grd.DataBind();
            }
            else if (ViewState["editmode"].ToString() == "edit")
            {
                if (fuImageUrl.PostedFile.ContentLength != 0)
                {
                    var relativeFilename = FileUploadTools.RelariveFileName(fuImageUrl.PostedFile.FileName, "ProductCategoryPath");
                    
                    string physicalFilename = Server.MapPath(relativeFilename);
                    fuImageUrl.PostedFile.SaveAs(physicalFilename);
                    ThumbnailHelper.CreateThumbnail(physicalFilename);

                    if (ViewState["ImageUrl"].ToString() != string.Empty)
                    {
                        FileUploadTools.RemoveFile(ViewState["ImageUrl"].ToString(), "ProductCategoryPath");
                    }
                    ViewState["ImageUrl"] = relativeFilename;
                }

                int id = Convert.ToInt32(ViewState["id"]);
                var productCategory = ProductCategoryManagement.Query().FirstOrDefault(pc => pc.ID == id);

                productCategory.Title = txtTitle.Text;
                productCategory.ImageUrl = ViewState["ImageUrl"].ToString();

                ProductCategoryManagement.Update(productCategory);

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

        public IQueryable<ProductCategory> GetProductCategories()
        {
            return ProductCategoryManagement.Query().OrderBy(pc=>pc.ID);
        } 
    }


}