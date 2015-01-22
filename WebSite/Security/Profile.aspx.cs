using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools.Convertors;
using WebSite.Classes.BLogic;

namespace WebSite.Security
{
    public partial class Profile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            var userId = User.Identity.Name.ToInt32();
            var user = UserManagement.Query().FirstOrDefault(u => u.ID == userId);
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtAddress.Text = user.Address;
            txtEmail.Text = user.Email;
            txtPhone.Text = user.Phone;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var userId = User.Identity.Name.ToInt32();
            var user = UserManagement.Query().FirstOrDefault(u => u.ID == userId);

            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.Address = txtAddress.Text;
            user.Email = txtEmail.Text;
            user.Phone = txtPhone.Text;

            UserManagement.Update(user);
            mvRegister.SetActiveView(vwMessage);
        }
    }
}