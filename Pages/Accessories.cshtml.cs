using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages
{
    public class AccessoriesModel : PageModel
    {
        public List<Products> AccessoriesList = new List<Products>();
        
        public void OnGet()
        {
            AccessoriesList = new DAL().GetAllAccessories();
        }
    }
}
