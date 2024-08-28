using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages
{
    public class ResgisterModel : PageModel
    {
        public string MessageType { get; set; }
        public string MessageText { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            string firstName = Request.Form["fname"];
            string lastName = Request.Form["lname"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            string phoneNumber = Request.Form["phone"];
            string country = Request.Form["country"];
            string region = Request.Form["region"];
            string town = Request.Form["town"];
            string street = Request.Form["street"];
            string building = Request.Form["building"];
            int floorNb = int.Parse(Request.Form["floor"]);
            string nationalID = Request.Form["national"];
            string username = Request.Form["username"]; 

            int add = new DAL().AddNewUser(firstName, lastName, email, password, phoneNumber, country, region, town, street, building, floorNb, nationalID, username);
            if (add == 1)
            {
                MessageType = "error";
                MessageText = "National ID Already Exists";
            }
            else if (add == 2)
            {
                MessageType = "error";
                MessageText = "Email Already Exists";
            }
            else if(add == 3 || add == 4)
            {
                MessageType= "error";
                MessageText = "Username Already Taken";
            }
            else
            {
                MessageType = "success";
                MessageText = "Registration Successful";
                Response.Redirect("/Index");
            }
        }
    }
}
