using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using WebSite.Classes.BLogic;
using Tools.Convertors;

namespace WebSite.Security
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cvLogin_ServerValidate(object source, ServerValidateEventArgs args)
        {          
            args.IsValid = UserManagement.Query().Count(p => p.Username == txtUserName.Text && p.Password == txtPassword.Text) != 0;

            if (args.IsValid)
            {
                var user = UserManagement.Query().FirstOrDefault(p => p.Username == txtUserName.Text);
                if (user != null)
                    ViewState["UserID"] = user.ID;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                FormsAuthentication.RedirectFromLoginPage(ViewState["UserID"].ToString(),chkRemember.Checked);
                int userId = ViewState["UserID"].ToInt32();


                var user = UserManagement.Query().FirstOrDefault(p => p.ID == userId);
                if (user != null)
                    Session["UserFullName"] = user.FullName;
            }
        }

    }
}