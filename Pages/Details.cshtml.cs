using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages
{
    public class DetailsModel : PageModel
    {
        public Computers computers = new Computers();
        public string ErrorMessage { get; set; } = "";
        public void OnGet()
        {
            string serial = Request.Query["id"];
            computers = new DAL().GetDetials(serial);
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

            string serialq = Request.Query["id"];
            computers = new DAL().GetDetials(serialq);
            int qquantity = Convert.ToInt32(Request.Form["quantity"]);

            if (qquantity > computers.TotalQuantity)
            {
                Console.WriteLine("error quantity");
                // Set an error message if the requested quantity exceeds stock
                ErrorMessage = "The requested quantity exceeds the available stock.";
            }

            string serial = Request.Form["productId"];
            int quantity = Convert.ToInt32(Request.Form["quantity"]);
            new DAL().AddToCart(serial, quantity, username);
            Response.Redirect("/Cart");
        }
    }
}
