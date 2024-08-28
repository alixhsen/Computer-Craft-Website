namespace Computer_Craft.Models
{
    public class SupplierDelivery
    {
        public string national { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string  PhoneNumber { get; set; }

        public string Country { get; set; }
        public string Region { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public int  FloorNb { get; set; }

        public SupplierDelivery() { }

        public SupplierDelivery(string national, string fname, string lname, string phoneNumber, string country, string region, string town, string street, string building, int floorNb)
        {
            this.national = national;
            Fname = fname;
            Lname = lname;
            PhoneNumber = phoneNumber;
            Country = country;
            Region = region;
            Town = town;
            Street = street;
            Building = building;
            FloorNb = floorNb;
        }

    }
}
