using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class UpdatePersonModel : PageModel
    {
        public SupplierDelivery person = new SupplierDelivery();    
        public void OnGet()
        {
            string national = Request.Query["id"];
            person = new DAL().GetPersonDetail(national);
        }


        public void OnPost()
        {
            string national = Request.Query["id"];
            person = new DAL().GetPersonDetail(national);

            string fname = Request.Form["fname"];
            string lname = Request.Form["lname"];
            string phone = Request.Form["phone"];

            string country = Request.Form["country"];
            string region = Request.Form["region"];
            string town = Request.Form["town"];
            string street = Request.Form["street"];
            string building = Request.Form["building"];
            int floor = Convert.ToInt32(Request.Form["floor"]);

            int update = new DAL().UpdatePerson(national, fname, lname, phone, country, region, town, street, building, floor);
            if (update != 0)
            {
                TempData["Message"] = "Failed to Update!";
                TempData["MessageType"] = "error";
            }
            else
            {
                TempData["Message"] = "Updated successfully!";
                TempData["MessageType"] = "success";
            }
        }
    }
}
