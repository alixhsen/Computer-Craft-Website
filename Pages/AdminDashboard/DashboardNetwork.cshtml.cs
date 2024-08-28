using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class DashboardNetworkModel : PageModel
    {
        public List<AdminProduct> NetworkAdminList = new List<AdminProduct>();
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
                NetworkAdminList = new DAL().GetAllNetworkAdmin();
            }
        }

        public void OnPostDelete(string id)
        {
            new DAL().DeleteComputer(id);
            Response.Redirect("/AdminDashboard/DashboardNetwork");
        }
    }
}
