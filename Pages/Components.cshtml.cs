using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages
{
    public class ComponentsModel : PageModel
    {
        public List<Products> ComponentList = new List<Products>();
        public void OnGet()
        {
            ComponentList = new DAL().GetAllComponents();
        }
    }
}
