using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class AddBrandModel : PageModel
    {
        public void OnPost()
        {
            string brand = Request.Form["BrandName"];
            int add = new DAL().AddBrand(brand);

            if (add == 1)
            {
                TempData["Message"] = "Brand added successfully!";
                TempData["MessageType"] = "success";
            }
            else
            {
                TempData["Message"] = "Brand already exists!";
                TempData["MessageType"] = "error";
            }
        }
    }
}
