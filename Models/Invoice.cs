namespace Computer_Craft.Models
{
    public class Invoice
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
     

        public List<Cart> carts;
        public Order orders;


        public Invoice() { }

        public Invoice(string customerName, string address, string email, string phone, List<Cart> carts, Order order)
        {
            CustomerName = customerName;
            Address = address;
            Email = email;
            Phone = phone;
            this.carts = carts;
            this.orders = order;
        }
    }
}
