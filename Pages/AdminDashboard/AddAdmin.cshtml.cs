using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class AddAdminModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            string fname = Request.Form["fname"];
            string lname = Request.Form["lname"];
            string username = Request.Form["username"];
            string password = Request.Form["pass"];
            int add = new DAL().AddAdmin(username, fname, lname, password);

            if (add == 1)
            {
                TempData["Message"] = "Admin added successfully!";
                TempData["MessageType"] = "success";
            }
            else
            {
                TempData["Message"] = "Admin Username already exists!";
                TempData["MessageType"] = "error";
            }
        }
    }
}
