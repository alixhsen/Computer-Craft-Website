namespace Computer_Craft.Models
{
    public class DelSup
    {
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string IsActive { get; set; }
        public DelSup() { } 
        public DelSup(string nationalId, string name, string phoneNumber, string address, string active)
        {
            NationalId = nationalId;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            IsActive = active;
        }
    }
}
