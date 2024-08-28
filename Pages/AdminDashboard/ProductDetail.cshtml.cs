using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class ProductDetailModel : PageModel
    {
        public AdminProduct product;
        public string serial;
        public void OnGet()
        {
            serial = Request.Query["id"];
            product = new DAL().GetProductDetail(serial);
        }
    }
}
