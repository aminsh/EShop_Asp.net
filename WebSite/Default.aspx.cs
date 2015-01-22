using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Security;
using DataAccess;
using Model;
using WebSite.Classes.BLogic;
using Tools.Convertors;

namespace WebSite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserManagement.Query().ToList();

            if (!Page.IsPostBack)
            {
                var db = new DbObject();
                var query = "select * from votes where id=@id";

                SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@id", 1),
                    };

                var ds = db.RunQuery(query, "votes",parameters);

                if (ds.Tables[0].Rows.Count!=0)
                {
                    lblVoteTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                }

                query = "select * from VoteItems where voteid=@voteid";

                parameters = new SqlParameter[]
                    {
                        new SqlParameter("@voteid", 1),
                    };
                ds = db.RunQuery(query, "voteitems",parameters);
                rbl.DataSource = ds.Tables[0];
                rbl.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var voteItemId = rbl.SelectedValue.ToInt32();
            var userId = User.Identity.Name.ToInt32();

            VoteUserManagement.Insert(new VoteUser()
                {
                    UserID = userId,
                    VoteItemID = voteItemId
                });

            var db = new DbObject();
            var query = string.Empty;
                                                                                
                                                                                
            query+="             SELECT    * ,                                                     ";
            query+="           ( SELECT    Title                                                   ";
            query+="             FROM      dbo.VoteItems                                           ";
            query+="             WHERE     ID = vuGroup.VoteItemID                                 ";
            query+="           ) AS VoteItemTitle                                                  ";
            query+=" FROM      ( SELECT    VoteItemID ,                                            ";
            query+="                       ( COUNT(*) * 100 )                                      ";
            query+="                       / ( SELECT  COUNT(*)                                    ";
            query+="                           FROM    dbo.VoteUsers                               ";
            query+="                           WHERE   ( SELECT    VoteID                          ";
            query+="                                     FROM      dbo.VoteItems                   ";
            query+="                                     WHERE     ID = vu.VoteItemID              ";
            query+="                                   ) = 1                                       ";
            query+="                         ) AS Value                                            ";
            query+="             FROM      ( SELECT    ID ,                                        ";
            query+="                                   VoteItemID ,                                ";
            query+="                                   UserID ,                                    ";
            query+="                                   ( SELECT    VoteID                          ";
            query+="                                     FROM      dbo.VoteItems                   ";
            query+="                                     WHERE     ID = vu.VoteItemID              ";
            query+="                                   ) AS voteID                                 ";
            query+="                         FROM      dbo.VoteUsers AS vu                         ";
            query+="                         WHERE     ( SELECT    VoteID                          ";
            query+="                                     FROM      dbo.VoteItems                   ";
            query+="                                     WHERE     ID = vu.VoteItemID              ";
            query+="                                   ) = 1                                       ";
            query+="                       ) vu                                                    ";
            query+="             GROUP BY  vu.VoteItemID                                           ";
            query += "           ) vuGroup ";

            var ds = db.RunQuery(query, "voteResult");
            dlResult.DataSource = ds.Tables[0];
            dlResult.DataBind();
            mv.SetActiveView(vResult);
        }
    }
}