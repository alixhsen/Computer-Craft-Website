namespace Computer_Craft.Models
{
    public class Products
    {
        public string SerialNumber { get; set; }
        public string Name { get; set; } 
        public int Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int TotalQuantity { get; set; }
        public Products() { }
        public Products(string serialNumber, string name, int price, string description, string image, int totalQuantity)
        {
            SerialNumber = serialNumber;
            Name = name;
            Price = price;
            Description = description;
            Image = image;
            TotalQuantity = totalQuantity;
        }
    }
}
