namespace Computer_Craft.Models
{
    public class Admin
    {
        public int AdminId { get; set; } 
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public Admin() { }

        public Admin(int id, string fname, string lname, string username, string password)
        {
            AdminId = id;
            Fname = fname;
            Lname = lname;
            Username = username;
            Password = password;
        }
    }
}
