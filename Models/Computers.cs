namespace Computer_Craft.Models
{
    public class Computers
    {
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string RAM { get; set; }
        public string Memory { get; set; }
        public string CPU { get; set; }
        public string Display { get; set; }
        public string Color { get; set; }
        public string OS { get; set; }
        public bool Touchscreen { get; set; }
        public int TotalQuantity { get; set; }
        public Computers() { }

        public Computers(string serialNumber, string name, int price, string description, string image, string rAM, string memory, string cPU, string display, string color, string oS, bool touchscreen, int total)
        {
            SerialNumber = serialNumber;
            Name = name;
            Price = price;
            Description = description;
            Image = image;
            RAM = rAM;
            Memory = memory;
            CPU = cPU;
            Display = display;
            Color = color;
            OS = oS;
            Touchscreen = touchscreen;
            TotalQuantity = total;
        }
    }
}
