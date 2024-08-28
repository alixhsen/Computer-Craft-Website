using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages
{
    public class IndexModel : PageModel
    {
        public List<Computers> LaptopList;
        public List<Computers> DesktopList;
        public List<Products> NetworkList;
        public List<Products> SecurityList;
        public List<Products> ComponentList;
        public List<Products> AccessoriesList;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            LaptopList = new DAL().GetRandomLaptops();
            DesktopList = new DAL().GetRandomDesktop();
            NetworkList = new DAL().GetRandomNetwork();
            SecurityList = new DAL().GetRandomSecurity();
            ComponentList = new DAL().GetRandomComponent();
            AccessoriesList = new DAL().GetRandomAccessories();
        }
    }
}
