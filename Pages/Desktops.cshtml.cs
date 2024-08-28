using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages
{
    public class DesktopsModel : PageModel
    {
        public List<Computers> list = new List<Computers>();
        public void OnGet()
        {
            list = new DAL().GetAllDesktop();
        }
    }
}
