namespace Computer_Craft.Models
{
    public class AdminOrder
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public int OrderAmount { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string DeliveryID { get; set; }
        public string OrderStatus { get; set; }

        public AdminOrder() { }

        public AdminOrder(int orderId, DateTime orderDate, string customerName, int orderAmount, string customerAddress, string customerPhoneNumber, string deliveryID, string orderStatus)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            CustomerName = customerName;
            OrderAmount = orderAmount;
            CustomerAddress = customerAddress;
            CustomerPhoneNumber = customerPhoneNumber;
            DeliveryID = deliveryID;
            OrderStatus = orderStatus;
        }
    }
}
