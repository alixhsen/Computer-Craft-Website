namespace Computer_Craft.Models
{
    public class Person
    {
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }
        public string Address { get; set; }

        public Person() { }

        public Person(string nationalId, string name,string phone, string email, string username, string address)
        {
            NationalId = nationalId;
            PhoneNumber = phone;
            Name = name;
            Email = email;
            Username = username;
            Address = address;
        }
    }
}
