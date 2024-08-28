using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class AddDesktopModel : PageModel
    {
        public List<SelectListItem> brands = new List<SelectListItem>();
        public List<SelectListItem> suppliers = new List<SelectListItem>();
        public string ErrorMessage { get; set; }
        public void OnGet()
        {
            brands = new DAL().GetBrands();
            suppliers = new DAL().GetSuppliers();
        }

        public void OnPost()
        {
            string serialNumber = Request.Form["serialNumber"];
            string name = Request.Form["name"];
            int brandId = Convert.ToInt32(Request.Form["brand"]);
            string supplierId = Request.Form["supplier"];
            decimal price = decimal.Parse(Request.Form["price"]);
            int quantity = int.Parse(Request.Form["stockQuantity"]);
            string description = Request.Form["description"];
            string image = Request.Form["image"]; // Handle file upload if needed
            string ram = Request.Form["ram"];
            string memory = Request.Form["memory"];
            string cpu = Request.Form["cpu"];
            string display = Request.Form["display"];
            string color = Request.Form["color"];
            string os = Request.Form["os"];
            bool touchScreen = Request.Form["touchScreen"] == "Yes";

            int add = new DAL().AddNewDesktop(serialNumber, name, brandId, supplierId, price, quantity, description, image, ram, memory, cpu, display, color, os, touchScreen);


            if (add == 0)
            {
                TempData["Message"] = "Desktop added successfully!";
                TempData["MessageType"] = "success";
            }
            else
            {
                TempData["Message"] = "SerialNumber already exists!";
                TempData["MessageType"] = "error";
            }
        }
    }
}
