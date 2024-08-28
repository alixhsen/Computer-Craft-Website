using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages
{
    public class NetworksModel : PageModel
    {
        public List<Products> NetworkList = new List<Products>();  
        public void OnGet()
        {
            NetworkList = new DAL().GetAllNetwork();
        }
    }
}
