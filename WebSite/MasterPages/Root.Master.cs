using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.Classes.BLogic;

namespace MyPortal
{
    public partial class Root : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                int userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                if (Session["UserFullName"] == null)
                {                    
                    Session["UserFullName"] = UserManagement.Query().FirstOrDefault(p => p.ID ==userId ).FullName;                      
                }
               
                lblUser.Text = "کاربر جاری : " + Session["UserFullName"].ToString();

                int roleId = UserManagement.Query().FirstOrDefault(p => p.ID == userId).RoleID;
                
            }
            
        }

        protected string GetUserFullName()
        {
            
            if (Session["UserFullName"] == null)
            {
                int userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                Session["UserFullName"] = UserManagement.Query().FirstOrDefault(p => p.ID == userId).FullName;
            }

            return Session["UserFullName"].ToString();
        }

        protected void lbSignOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect(FormsAuthentication.DefaultUrl);
        }
    }
}