using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;
using System;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class AddProductModel : PageModel
    {
        public List<SelectListItem> brands = new List<SelectListItem>();
        public List<SelectListItem> suppliers = new List<SelectListItem>();
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
            string image = Request.Form["image"];
            string type = Request.Form["productType"];

            int add = new DAL().AddProduct(serialNumber, brandId, supplierId, name, price, quantity, description, image, type);


            if (add == 0)
            {
                TempData["Message"] = "Product added successfully!";
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
