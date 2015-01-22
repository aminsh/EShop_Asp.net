using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using WebSite.Classes.BLogic;
using Tools.Convertors;

namespace WebSite.Admin
{
    public partial class PageVote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            switch (ViewState["editmode"].ToString())
            {
                case "new":
                    {
                        var vote = new Vote()
                            {
                                Title = txtTitle.Text
                            };
                        VoteManagement.Insert(vote);
                        grd.DataBind();
                        mv.SetActiveView(vList);
                    }
                    break;
                case "edit":
                    {
                        int id = Convert.ToInt32(ViewState["id"]);
                        var vote = VoteManagement.Query().FirstOrDefault(pc => pc.ID == id);

                        vote.Title = txtTitle.Text;
                        VoteManagement.Update(vote);
                        grd.DataBind();
                        mv.SetActiveView(vList);
                    }
                    break;
            }
        }

        protected void grd_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "btnEdit":
                    {
                        var id = e.CommandArgument.ToInt32();

                        ViewState["id"] = id;
                        ViewState["editmode"] = "edit";

                        var vote = VoteManagement.Query().FirstOrDefault(v => v.ID == id);

                        txtTitle.Text = vote.Title;
                        mv.SetActiveView(vEditVote);
                    }
                    break;
                case "btnDelete":
                    {
                        var id = e.CommandArgument.ToInt32();
                        VoteManagement.Delete(id);
                        grd.DataBind();
                    }
                    break;
                case "btnNewItem":
                    {
                        var id = e.CommandArgument.ToInt32();
                        ViewState["voteId"] = id;
                        ViewState["editmode"] = "newItem";

                        txtTitleItem.Text = string.Empty;

                        mv.SetActiveView(vEditItem);
                    }
                    break;
                case "btnEditItem":
                    {
                        var id = e.CommandArgument.ToInt32();
                        ViewState["voteId"] = id;
                        ViewState["editmode"] = "editItem";

                        var voteItem = VoteItemManagement.Query().FirstOrDefault(vi => vi.ID == id);

                        txtTitleItem.Text = voteItem.Title;

                        mv.SetActiveView(vEditItem);
                    }
                    break;
                case "btnDeleteItem":
                    {
                        var id = e.CommandArgument.ToInt32();
                        VoteItemManagement.Delete(id);
                        grd.DataBind();
                    }
                    break;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mv.SetActiveView(vList);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ViewState["editmode"] = "new";
            txtTitle.Text = string.Empty;

            mv.SetActiveView(vEditVote);
        }

        protected void btnSaveItem_Click(object sender, EventArgs e)
        {
            switch (ViewState["editmode"].ToString())
            {
                case "newItem":
                    {
                        var voteId = ViewState["voteId"].ToInt32();
                        var voteItem = new VoteItem()
                        {
                            Title = txtTitleItem.Text,
                            VoteID = voteId
                        };
                        VoteItemManagement.Insert(voteItem);
                        grd.DataBind();
                        mv.SetActiveView(vList);
                    }
                    break;
                case "editItem":
                    {
                        int id = Convert.ToInt32(ViewState["id"]);
                        var voteItem = VoteItemManagement.Query().FirstOrDefault(pc => pc.ID == id);

                        voteItem.Title = txtTitleItem.Text;
                        VoteItemManagement.Update(voteItem);
                        grd.DataBind();
                        mv.SetActiveView(vList);
                    }
                    break;
            }
        }
    }
}