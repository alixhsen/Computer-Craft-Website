using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class ComputerDetailModel : PageModel
    {
  
        public AdminComputer computer;
        public string serial;
        public void OnGet()
        {
            serial = Request.Query["id"];
            computer = new DAL().GetComputerDetails(serial);
        }
    }
}
