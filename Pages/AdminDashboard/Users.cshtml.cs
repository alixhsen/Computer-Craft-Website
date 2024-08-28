using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages.AdminDashboard
{
    public class UsersModel : PageModel
    {
        public string admin;
        public List<Person> persons = new List<Person>();
        public List<DelSup> suppliers = new List<DelSup>();
        public List<DelSup> deliveries = new List<DelSup>();
        public List<Admin> admins = new List<Admin>();
        public void OnGet()
        {
            string referer = Request.Headers["referer"].ToString();
            admin = HttpContext.Session.GetString("adminusername");

            if (string.IsNullOrEmpty(referer) || string.IsNullOrEmpty(admin))
            {
                Response.Redirect("/Login");
            }
            else
            {
                persons = new DAL().Customers();
                suppliers = new DAL().Suppliers();
                deliveries = new DAL().Delivery();
                admins = new DAL().GetAllAdmins();
            }
        }
        
        public void OnPostDeleteAdmin(int id)
        {
            Console.WriteLine("admin delete");
            Console.WriteLine(id);
            new DAL().DeleteAdmin(id);
            TempData["Message"] = "Admin Deleted successfully!";
            TempData["MessageType"] = "success";
        }
        public void OnPostDelete(string id) 
        {
            int res = new DAL().DeleteSupplier(id);

            if(res == 1)
            {
                TempData["Message"] = "Failed to delete supplier! You should remove all products supplied by this supplier before deleting.";
                TempData["MessageType"] = "error";
                persons = new DAL().Customers();
                suppliers = new DAL().Suppliers();
                deliveries = new DAL().Delivery();
                admins = new DAL().GetAllAdmins();

            }
            else
            {
                persons = new DAL().Customers();
                suppliers = new DAL().Suppliers();
                deliveries = new DAL().Delivery();
                admins = new DAL().GetAllAdmins();

                Response.Redirect("/AdminDashboard/Users");
            }
        }

        public void OnPostActivate(string id)
        {
            new DAL().ActivateDelivery(id);

            persons = new DAL().Customers();
            suppliers = new DAL().Suppliers();
            deliveries = new DAL().Delivery();
            admins = new DAL().GetAllAdmins();

            TempData["Message"] = "Activated Successfully";
            TempData["MessageType"] = "success";
        }

        public void OnPostInactivate(string id)
        {
            int res = new DAL().DeActivateDelivery(id);

            if (res == 1)
            {
                TempData["Message"] = "Failed to deactivate delivery! This is the last delivery in the region. You can deactivate it only after adding another delivery to the same region, as no region can be without delivery.";
                TempData["MessageType"] = "error";
                persons = new DAL().Customers();
                suppliers = new DAL().Suppliers();
                deliveries = new DAL().Delivery();
                admins = new DAL().GetAllAdmins();

            }
            else
            {
                TempData["Message"] = "Inactivated Successfully";
                TempData["MessageType"] = "success";
                persons = new DAL().Customers();
                suppliers = new DAL().Suppliers();
                deliveries = new DAL().Delivery();
                admins = new DAL().GetAllAdmins();
            }
        }
    }
}
