using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages
{
    public class SecurityModel : PageModel
    {
        public List<Products> SecurityList = new List<Products>();
        public void OnGet()
        {
            SecurityList = new DAL().GetAllSecurity();
        }
    }
}
