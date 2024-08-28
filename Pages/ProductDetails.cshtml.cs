using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages
{
    public class ProductDetailsModel : PageModel
    {
        public Products products = new Products();
        public void OnGet()
        {
            string serial = Request.Query["id"];
            products = new DAL().GetProductDetials(serial);
        }

        public void OnPost()
        {
            string username = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")))
            {
                // Redirect to login page if not authenticated
                Response.Redirect("/Login");
                return;
            }

            string serial = Request.Form["productId"];
            int quantity = Convert.ToInt32(Request.Form["quantity"]);
            new DAL().AddToCart(serial, quantity, username);
            Response.Redirect("/Cart");
        }
    }
}
