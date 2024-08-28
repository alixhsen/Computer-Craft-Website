using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class DashboardDesktopModel : PageModel
    {
        public List<AdminComputer> AdminDesktopList = new List<AdminComputer>();
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
                AdminDesktopList = new DAL().GetAllDesktopsAdmin();
            }
        }

        public void OnPostDelete(string id)
        {
            new DAL().DeleteComputer(id);
            Response.Redirect("/AdminDashboard/DashboardDesktop");
        }
    }
}
