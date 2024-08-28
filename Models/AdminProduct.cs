namespace Computer_Craft.Models
{
    public class AdminProduct
    {
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public string Supplier { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int TotalQuantity { get; set; }


        public AdminProduct(string serialNumber, string brand, string supplier, string name, int price, string description, string image, int totalQuantity)
        {
            SerialNumber = serialNumber;
            Brand = brand;
            Supplier = supplier;
            Name = name;
            Price = price;
            Description = description;
            Image = image;
            TotalQuantity = totalQuantity;
        }

        public AdminProduct() { }   
    }
}
