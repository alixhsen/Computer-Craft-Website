using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages
{
    public class LaptopsModel : PageModel
    {
        public List<Computers> LaptopList;

        public void OnGet()
        {
            LaptopList = new DAL().GetAllLaptops();
        }
    }
}
