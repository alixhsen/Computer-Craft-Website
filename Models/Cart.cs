namespace Computer_Craft.Models
{
    public class Cart
    {
        public string SerialNumber { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int CartQuantity { get; set; }

        public Cart() { }

        public Cart(string serialNumber, string name, string description, string image, int price, int cartQuantity)
        {
            SerialNumber = serialNumber;
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            CartQuantity = cartQuantity;
        }
    }
}
