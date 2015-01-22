using System;
using System.Linq;
using System.Web.UI.WebControls;
using DataAccess;
using Model;
using WebSite.Classes.BLogic;
using Tools.Convertors;

namespace WebSite.Security
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            var user = new User
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    RoleID = 1
                };
            UserManagement.Insert(user);
            mvRegister.SetActiveView(vwMessage);
        }

        protected void cvUsername_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = UserManagement.Query().Count(p => p.Username == txtUsername.Text) == 0;
        }
    }
}