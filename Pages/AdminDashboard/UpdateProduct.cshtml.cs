using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class UpdateProductModel : PageModel
    {
        public AdminProduct product;
        public string serial;
        public List<SelectListItem> brands = new List<SelectListItem>();

        public void OnGet()
        {
            string brandname = Request.Query["brand"];

            brands = new DAL().GetBrandsUpdate(brandname);

            serial = Request.Query["id"];
            product = new DAL().GetProductDetail(serial);
        }

        public void OnPost()
        {
            string id = Request.Query["id"];
            product = new DAL().GetProductDetail(id);

            string serial = Request.Form["serialNumber"];
            string name = Request.Form["name"];
            int brandId = Convert.ToInt32(Request.Form["brand"]);
            decimal price = decimal.Parse(Request.Form["price"]);
            int quantity = int.Parse(Request.Form["stockQuantity"]);
            string description = Request.Form["description"];

            // Perform the update operation
            int update = new DAL().UpdateProduct(serial, brandId, name, price, quantity, description);

            if (update == 0)
            {
                TempData["Message"] = "Product details updated successfully!";
                TempData["MessageType"] = "success";

            }
            else
            {
                TempData["Message"] = "Failed to Update!";
                TempData["MessageType"] = "error"; // Changed to "error" to match the failure scenario
            }
        }
    }
}
