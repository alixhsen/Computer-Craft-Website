using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Computer_Craft.Pages
{
    public class InvoiceModel : PageModel
    {
        public Invoice invoice = new Invoice();
        public int currentYear = DateTime.Now.Year;

        public void OnGet()
        {
            string username = HttpContext.Session.GetString("username");
            invoice = new DAL().Invoice(username);
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("entered on post");
            string username = HttpContext.Session.GetString("username");
            new DAL().DeleteCart(username);
            Console.WriteLine("deleted");
            return RedirectToPage("/Index");
        }
    }
}
