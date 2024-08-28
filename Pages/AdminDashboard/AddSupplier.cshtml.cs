using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class AddSupplierModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            string firstName = Request.Form["fname"];
            string lastName = Request.Form["lname"];
            string email = Request.Form["email"];
            string phoneNumber = Request.Form["phone"];
            string country = Request.Form["country"];
            string region = Request.Form["region"];
            string town = Request.Form["town"];
            string street = Request.Form["street"];
            string building = Request.Form["building"];
            int floorNb = int.Parse(Request.Form["floor"]);
            string nationalID = Request.Form["national"];

            int add = new DAL().AddSupplier(firstName, lastName, email, phoneNumber, country, region, town, street, building, floorNb, nationalID);

            if (add == 0)
            {
                TempData["Message"] = "Supplier added successfully!";
                TempData["MessageType"] = "success";
            }
            else
            {
                TempData["Message"] = "National ID already exists!";
                TempData["MessageType"] = "error";
            }
        }    

    }
}
