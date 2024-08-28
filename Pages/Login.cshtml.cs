using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages
{
    public class LoginModel : PageModel
    {
        public string MessageText { get; set; }
        public string MessageType { get; set; }
        public bool LoggedIn { get; set; } = false;
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            string username = Request.Form["username"];
            string pass = Request.Form["password"];
            int res = new DAL().AuthenticateUser(username, pass);
            if (res == 3)
            {
                MessageType = "error";
                MessageText = "Invalid Username or Password";
            }
            else if(res == 1)
            {
                LoggedIn = true;
                Response.Redirect("/Index");
                HttpContext.Session.SetString("username", username);
                Response.Redirect("/Index");
            }
            else
            {
                HttpContext.Session.SetString("adminusername", username);
                Response.Redirect("/AdminDashboard/Dashboard");
            }

        }

    }
}
