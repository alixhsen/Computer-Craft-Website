using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class UpdateAdminModel : PageModel
    {
        public Admin admin;
        public void OnGet()
        {
            string username = Request.Query["id"];
            admin = new DAL().GetAdminDetail(username);
        }

        public void OnPost()
        {
            string username = Request.Query["id"];
            admin = new DAL().GetAdminDetail(username);

            string password = Request.Form["pass"];
            int update = new DAL().ResetAdminPassword(username, password);

            if (update == 0)
            {
                TempData["Message"] = "Password Reseted successfully!";
                TempData["MessageType"] = "success";

            }
            else if(update == 1)
            {
                TempData["Message"] = "New and Current Passwords Are The Same!";
                TempData["MessageType"] = "error";
            }
            else
            {
                TempData["Message"] = "Failed to Reset Password!";
                TempData["MessageType"] = "error";
            }
        }
    }
}
