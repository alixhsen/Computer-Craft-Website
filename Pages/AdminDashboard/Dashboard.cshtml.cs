using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class DashoardModel : PageModel
    {
        public string admin;
        public AdminProduct product = new AdminProduct();
        public int orderInYear;
        public int customers;
        public int products;
        public string adminName;

        public int currentYear = DateTime.Now.Year;

        public void OnGet()
        {
            string referer = Request.Headers["referer"].ToString();
            admin = HttpContext.Session.GetString("adminusername");

            if (string.IsNullOrEmpty(referer) || string.IsNullOrEmpty(admin))
            {
                Response.Redirect("/Login");
            }
            else
            {
                product = new DAL().RecentProduct();
                orderInYear = new DAL().NbOfOrderYear();
                customers = new DAL().TotalCustomers();
                products = new DAL().TotalProducts();
                adminName = new DAL().GetAdminName(admin);
            }

        }
    }
}
