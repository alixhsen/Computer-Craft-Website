namespace Computer_Craft.Models
{
    public class Brands
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public Brands() { }

        public Brands(int id, string name) 
        {
            BrandId = id;
            BrandName = name;
        }
    }
}
