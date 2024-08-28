namespace Computer_Craft.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public Order()
        {

        }

        public Order(int orderId, decimal totalPrice, DateTime orderDate)
        {
            OrderId = orderId;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
        }
    }
}
