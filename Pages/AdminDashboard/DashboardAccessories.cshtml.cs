using Computer_Craft.Models;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class DashboardAccessoriesModel : PageModel
    {
        public List<AdminProduct> AccessoriesAdminList = new List<AdminProduct>();
        public string admin;
        public void OnGet()
        {
            admin = HttpContext.Session.GetString("adminusername");
            string referer = Request.Headers["referer"].ToString();
            if (string.IsNullOrEmpty(referer) || string.IsNullOrEmpty(admin))
            {
                Response.Redirect("/Login");
            }
            else
            {
                AccessoriesAdminList = new DAL().GetAllAccessoriesAdmin();
            }
        }
        public void OnPostDelete(string id)
        {
            new DAL().DeleteComputer(id);
            AccessoriesAdminList = new DAL().GetAllAccessoriesAdmin();
            Response.Redirect("/AdminDashboard/DashboardAccessories");
        }
    }
}
