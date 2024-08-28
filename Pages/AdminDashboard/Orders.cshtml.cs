using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class OrdersModel : PageModel
    {
        public List<AdminOrder> OrderListPaid = new List<AdminOrder>();
        public List<AdminOrder> OrderListUnPaid = new List<AdminOrder>();
        public void OnGet()
        {
            OrderListPaid = new DAL().GetPaidOrders();
            OrderListUnPaid = new DAL().GetUnPaidOrders();
        }

        public void OnPostPaid()
        {
            int id = Convert.ToInt32(Request.Query["id"]);
            new DAL().PaidOrder(id);
            TempData["Message"] = "Piad";
            TempData["MessageType"] = "success";

            OrderListPaid = new DAL().GetPaidOrders();
            OrderListUnPaid = new DAL().GetUnPaidOrders();
        }

        public void OnPostUnpaid()
        {
            int id = Convert.ToInt32(Request.Query["id"]);
            new DAL().UnPaidOrder(id);
            TempData["Message"] = "Order Unpaid";
            TempData["MessageType"] = "success";

            OrderListPaid = new DAL().GetPaidOrders();
            OrderListUnPaid = new DAL().GetUnPaidOrders();
        }
    }
}
