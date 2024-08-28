using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class DeliveryOrdersModel : PageModel
    {
        public List<AdminOrder> OrderListPaid = new List<AdminOrder>();
        public List<AdminOrder> OrderListUnPaid = new List<AdminOrder>();
        public string deliveryname;
        public void OnGet()
        {
            string id = Request.Query["id"];

            OrderListPaid = new DAL().GetDeliveryPaidOrders(id);
            OrderListUnPaid = new DAL().GetDeliveryUnPaidOrders(id);
            deliveryname = new DAL().GetDeliveryName(id);
        }
    }
}
