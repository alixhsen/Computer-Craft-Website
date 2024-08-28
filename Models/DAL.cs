using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Computer_Craft.Models
{
    public class DAL
    {
        public string connection = "Data Source=.\\sqlexpress;Initial Catalog=ComputerCraftDB;Integrated Security=True";
        SqlConnection conn;
        SqlCommand cmd;
        public Computers laptop;
        public Computers desktop;

        public Computers computerDetail = new Computers();
        public Products productDetail = new Products();

        AdminComputer adminLaptop;
        AdminComputer adminDesktop;

        AdminComputer computer;
        AdminProduct product;

        AdminProduct network;
        AdminProduct security;
        AdminProduct components;
        AdminProduct accessories;

        //LAPTOP PART 


        public List<Computers> GetAllLaptops()
        {
            List<Computers> Laptoplist = new List<Computers>();
            laptop = null;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select  Products.SerialNumber ,ProductName, Description, Price, Image, RAM, CPU, Memory, Display, Color, OS, TouchScreen, Quantity\r\nfrom Products inner join Computer\r\non Products.SerialNumber = Computer.SerialNumber\r\nwhere Computer.ComputerType = 'LAPTOP'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string serialnb = reader.GetString(0);
                string name = reader.GetString(1);
                string description = reader.GetString(2);
                int price = reader.GetInt32(3);
                string image = reader.GetString(4);
                string ram = reader.GetString(5);
                string cpu = reader.GetString(6);
                string memory = reader.GetString(7);
                string display = reader.GetString(8);
                string color = reader.GetString(9);
                string os = reader.GetString(10);
                bool touch = reader.GetBoolean(11);
                int quantity = reader.GetInt32(12);

                laptop = new Computers(serialnb, name, price, description, image, ram, memory, cpu, display, color, os, touch, quantity);
                Laptoplist.Add(laptop);
            }
            return Laptoplist;
        }

        public Computers GetDetials(string id)
        {
            conn = new SqlConnection(connection);

            conn.Open();
            cmd = new SqlCommand(@"
    SELECT 
        p.SerialNumber,
        p.ProductName,
        p.Price,
        p.Description,
        p.Image,
        c.RAM,
        c.Memory,
        c.CPU,
        c.Display,
        c.Color,
        c.OS,
        c.Touchscreen,
        p.Quantity
    FROM 
        Products p
    LEFT JOIN 
        Computer c ON p.SerialNumber = c.SerialNumber
    WHERE 
        p.SerialNumber = @id
        AND (p.ProductType = 'LAPTOP' OR p.ProductType = 'DESKTOP');", conn);


            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                computerDetail.SerialNumber = reader.GetString(0);
                computerDetail.Name = reader.GetString(1);
                computerDetail.Price = reader.GetInt32(2);
                computerDetail.Description = reader.GetString(3);
                computerDetail.Image = reader.GetString(4);
                computerDetail.RAM = reader.GetString(5);
                computerDetail.Memory = reader.GetString(6);
                computerDetail.CPU = reader.GetString(7);
                computerDetail.Display = reader.GetString(8);
                computerDetail.Color = reader.GetString(9);
                computerDetail.OS = reader.GetString(10);
                computerDetail.Touchscreen = reader.GetBoolean(11);
                computerDetail.TotalQuantity = reader.GetInt32(12);
            }
            return computerDetail;
            conn.Close();
        }

        public List<Computers> GetRandomLaptops()
        {
            List<Computers> Laptoplist = new List<Computers>();
            laptop = null;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand(@"
        SELECT TOP 3
            Products.SerialNumber,
            ProductName,
            Description,
            Price,
            Image,
            RAM,
            CPU,
            Memory,
            Display,
            Color,
            OS,
            TouchScreen,
            Quantity
        FROM 
            Products 
        INNER JOIN 
            Computer ON Products.SerialNumber = Computer.SerialNumber
        WHERE 
            Computer.ComputerType = 'LAPTOP'
        ORDER BY 
            NEWID();", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string serialnb = reader.GetString(0);
                string name = reader.GetString(1);
                string description = reader.GetString(2);
                int price = reader.GetInt32(3);
                string image = reader.GetString(4);
                string ram = reader.GetString(5);
                string cpu = reader.GetString(6);
                string memory = reader.GetString(7);
                string display = reader.GetString(8);
                string color = reader.GetString(9);
                string os = reader.GetString(10);
                bool touch = reader.GetBoolean(11);
                int quantity = reader.GetInt32(12);

                laptop = new Computers(serialnb, name, price, description, image, ram, memory, cpu, display, color, os, touch, quantity);
                Laptoplist.Add(laptop);
            }

            conn.Close();
            return Laptoplist;
        }




        //DESKTOP PART

        public List<Computers> GetAllDesktop()
        {
            List<Computers> DesktopList = new List<Computers>();
            desktop = null;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select  Products.SerialNumber ,ProductName, Description, Price, Image, RAM, CPU, Memory, Display, Color, OS, TouchScreen, Quantity\r\nfrom Products inner join Computer\r\non Products.SerialNumber = Computer.SerialNumber\r\nwhere Computer.ComputerType = 'DESKTOP'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string serialnb = reader.GetString(0);
                string name = reader.GetString(1);
                string description = reader.GetString(2);
                int price = reader.GetInt32(3);
                string image = reader.GetString(4);
                string ram = reader.GetString(5);
                string cpu = reader.GetString(6);
                string memory = reader.GetString(7);
                string display = reader.GetString(8);
                string color = reader.GetString(9);
                string os = reader.GetString(10);
                bool touch = reader.GetBoolean(11);
                int quantity = reader.GetInt32(12);

                desktop = new Computers(serialnb, name, price, description, image, ram, memory, cpu, display, color, os, touch, quantity);
                DesktopList.Add(desktop);
            }
            return DesktopList;
        }

        public List<Computers> GetRandomDesktop()
        {
            List<Computers> DesktopList = new List<Computers>();
            desktop = null;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand(@"
        SELECT TOP 3
            Products.SerialNumber,
            ProductName,
            Description,
            Price,
            Image,
            RAM,
            CPU,
            Memory,
            Display,
            Color,
            OS,
            TouchScreen,
            Quantity
        FROM 
            Products 
        INNER JOIN 
            Computer ON Products.SerialNumber = Computer.SerialNumber
        WHERE 
            Computer.ComputerType = 'DESKTOP'
        ORDER BY 
            NEWID();", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string serialnb = reader.GetString(0);
                string name = reader.GetString(1);
                string description = reader.GetString(2);
                int price = reader.GetInt32(3);
                string image = reader.GetString(4);
                string ram = reader.GetString(5);
                string cpu = reader.GetString(6);
                string memory = reader.GetString(7);
                string display = reader.GetString(8);
                string color = reader.GetString(9);
                string os = reader.GetString(10);
                bool touch = reader.GetBoolean(11);
                int quantity = reader.GetInt32(12);

                desktop = new Computers(serialnb, name, price, description, image, ram, memory, cpu, display, color, os, touch, quantity);
                DesktopList.Add(desktop);
            }
            conn.Close();
            return DesktopList;
        }


        //NETWORK PART

        public List<Products> GetAllNetwork()
        {
            List<Products> NewtorkList = new List<Products>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select Products.SerialNumber, ProductName, Price, Description, Image from Products where Products.ProductType = 'NETWORK'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Products network = new Products();
                network.SerialNumber = reader.GetString(0);
                network.Name = reader.GetString(1);
                network.Price = reader.GetInt32(2);
                network.Description = reader.GetString(3);
                network.Image = reader.GetString(4);

                NewtorkList.Add(network);
            }
            return NewtorkList;
        }

        public List<Products> GetRandomNetwork()
        {
            List<Products> RandomNetwork = new List<Products>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select TOP 3 Products.SerialNumber, ProductName, Price, Description, Image from Products where Products.ProductType = 'NETWORK' ORDER BY NEWID()", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Products network = new Products();
                network.SerialNumber = reader.GetString(0);
                network.Name = reader.GetString(1);
                network.Price = reader.GetInt32(2);
                network.Description = reader.GetString(3);
                network.Image = reader.GetString(4);

                RandomNetwork.Add(network);
            }
            return RandomNetwork;
        }

        //SECURITY PART

        public List<Products> GetAllSecurity()
        {
            List<Products> SecurityList = new List<Products>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select Products.SerialNumber, ProductName, Price, Description, Image from Products where Products.ProductType = 'SECURITY'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Products security = new Products();
                security.SerialNumber = reader.GetString(0);
                security.Name = reader.GetString(1);
                security.Price = reader.GetInt32(2);
                security.Description = reader.GetString(3);
                security.Image = reader.GetString(4);

                SecurityList.Add(security);
            }
            return SecurityList;
        }

        public List<Products> GetRandomSecurity()
        {
            List<Products> RandomSecurity = new List<Products>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select TOP 3 Products.SerialNumber, ProductName, Price, Description, Image from Products where Products.ProductType = 'SECURITY' ORDER BY NEWID()", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Products security = new Products();
                security.SerialNumber = reader.GetString(0);
                security.Name = reader.GetString(1);
                security.Price = reader.GetInt32(2);
                security.Description = reader.GetString(3);
                security.Image = reader.GetString(4);

                RandomSecurity.Add(security);
            }
            return RandomSecurity;
        }

        //COMPONENT PART

        public List<Products> GetAllComponents()
        {
            List<Products> ComponentList = new List<Products>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select Products.SerialNumber, ProductName, Price, Description, Image from Products where Products.ProductType = 'COMPONENT'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Products component = new Products();
                component.SerialNumber = reader.GetString(0);
                component.Name = reader.GetString(1);
                component.Price = reader.GetInt32(2);
                component.Description = reader.GetString(3);
                component.Image = reader.GetString(4);

                ComponentList.Add(component);
            }
            return ComponentList;
        }

        public List<Products> GetRandomComponent()
        {
            List<Products> RandomComponent = new List<Products>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select TOP 3 Products.SerialNumber, ProductName, Price, Description, Image from Products where Products.ProductType = 'COMPONENT' ORDER BY NEWID()", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Products component = new Products();
                component.SerialNumber = reader.GetString(0);
                component.Name = reader.GetString(1);
                component.Price = reader.GetInt32(2);
                component.Description = reader.GetString(3);
                component.Image = reader.GetString(4);

                RandomComponent.Add(component);
            }
            return RandomComponent;
        }


        //ACCESSORIES PART

        public List<Products> GetAllAccessories()
        {
            List<Products> AccessoriesList = new List<Products>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select Products.SerialNumber, ProductName, Price, Description, Image from Products where Products.ProductType = 'ACCESSORIES'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Products accessories = new Products();
                accessories.SerialNumber = reader.GetString(0);
                accessories.Name = reader.GetString(1);
                accessories.Price = reader.GetInt32(2);
                accessories.Description = reader.GetString(3);
                accessories.Image = reader.GetString(4);

                AccessoriesList.Add(accessories);
            }
            return AccessoriesList;
        }

        public List<Products> GetRandomAccessories()
        {
            List<Products> RandomAccessories = new List<Products>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select TOP 3 Products.SerialNumber, ProductName, Price, Description, Image from Products where Products.ProductType = 'ACCESSORIES' ORDER BY NEWID()", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Products accessories = new Products();
                accessories.SerialNumber = reader.GetString(0);
                accessories.Name = reader.GetString(1);
                accessories.Price = reader.GetInt32(2);
                accessories.Description = reader.GetString(3);
                accessories.Image = reader.GetString(4);

                RandomAccessories.Add(accessories);
            }
            return RandomAccessories;
        }


        //Function to Add User + Check if NationalID and Password are already exists
        public int AddNewUser(string firstName, string lastName, string email, string password, string phoneNumber, string country, string region, string town, string street, string building, int floorNb, string NationalID, string username)
        {
            using (conn = new SqlConnection(connection))
            {
                conn.Open();

                // Check if NationalID already exists
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Person WHERE NationalID = @NationalID", conn);
                cmd.Parameters.AddWithValue("@NationalID", NationalID);
                int nationalIDCount = (int)cmd.ExecuteScalar();
                if (nationalIDCount > 0)
                {
                    return 1; // NationalID already exists
                }

                // Check if Email already exists
                cmd = new SqlCommand("SELECT COUNT(*) FROM Account WHERE Email = @Email", conn);
                cmd.Parameters.AddWithValue("@Email", email);
                int emailCount = (int)cmd.ExecuteScalar();
                if (emailCount > 0)
                {
                    return 2; // Email already exists
                }

                // Check if Username already exists in Account table
                cmd = new SqlCommand("SELECT COUNT(*) FROM Account WHERE Username = @Username", conn);
                cmd.Parameters.AddWithValue("@Username", username);
                int usernameCount = (int)cmd.ExecuteScalar();
                if (usernameCount > 0)
                {
                    return 3; // Username already exists in Account table
                }

                // Check if Username already exists in Admin table
                cmd = new SqlCommand("SELECT COUNT(*) FROM Admin WHERE Username = @Username", conn);
                cmd.Parameters.AddWithValue("@Username", username);
                int adminUsernameCount = (int)cmd.ExecuteScalar();
                if (adminUsernameCount > 0)
                {
                    return 4; // Username already exists in Admin table
                }

                // Insert Address
                cmd = new SqlCommand("INSERT INTO Address (Country, Region, Town, Street, Building, FloorNb) OUTPUT INSERTED.AdressId VALUES (@Country, @Region, @Town, @Street, @Building, @FloorNb)", conn);
                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Parameters.AddWithValue("@Region", region);
                cmd.Parameters.AddWithValue("@Town", town);
                cmd.Parameters.AddWithValue("@Street", street);
                cmd.Parameters.AddWithValue("@Building", building);
                cmd.Parameters.AddWithValue("@FloorNb", floorNb);

                int addressId = (int)cmd.ExecuteScalar();

                // Insert Person
                cmd = new SqlCommand("INSERT INTO Person (NationalID, AdressId, FirstName, LastName, PersonType, PhoneNumber) VALUES (@NationalID, @AdressId, @FirstName, @LastName, @PersonType, @PhoneNumber)", conn);
                cmd.Parameters.AddWithValue("@NationalID", NationalID);
                cmd.Parameters.AddWithValue("@AdressId", addressId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@PersonType", "Customer");
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                cmd.ExecuteNonQuery();

                // Insert Account
                cmd = new SqlCommand("INSERT INTO Account (Email, Password, NationalID, Username) VALUES (@Email, @Password, @NationalID, @Username)", conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@NationalID", NationalID);
                cmd.Parameters.AddWithValue("@Username", username);

                cmd.ExecuteNonQuery();

                return 5; // Indicate success
            }
        }


        public int AuthenticateUser(string username, string password)
        {
            using (conn = new SqlConnection(connection))
            {
                conn.Open();

                // Check in Account table
                cmd = new SqlCommand("SELECT COUNT(*) FROM Account WHERE Username = @Username AND Password = @Password", conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                int accountCount = (int)cmd.ExecuteScalar();
                if (accountCount > 0)
                {
                    return 1; // Redirect to Index page
                }

                // Check in Admin table
                cmd = new SqlCommand("SELECT COUNT(*) FROM Admin WHERE Username = @Username AND Password = @Password", conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                int adminCount = (int)cmd.ExecuteScalar();

                if (adminCount > 0)
                {
                    return 2; // Redirect to Dashboard page
                }

                return 3; // If no match found, stay on the login page
            }
        }

        public void AddToCart(string serial, int quantity, string username)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("INSERT INTO Cart (SerialNumber, Quantity, CustomerUsername) VALUES (@Serial, @Quantity, @Username)", conn);
            cmd.Parameters.AddWithValue("@Serial", serial);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@Username", username);

            cmd.ExecuteNonQuery();
        }

        public List<Cart> GetAllCart(string username)
        {
            List<Cart> CartList = new List<Cart>();

            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select Products.SerialNumber, ProductName , Products.Description, Products.Image, Price, Cart.Quantity\r\nfrom Products\r\ninner join Cart\r\non Products.SerialNumber = Cart.SerialNumber\r\nwhere Cart.CustomerUsername = @username", conn);
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Cart cart = new Cart();
                cart.SerialNumber = reader.GetString(0);
                cart.Name = reader.GetString(1);
                cart.Description = reader.GetString(2);
                cart.Image = reader.GetString(3);
                cart.Price = reader.GetInt32(4);
                cart.CartQuantity = reader.GetInt32(5);

                CartList.Add(cart);
            }
            return CartList;
        }

        public void DeleteCartItem(string serial, string username)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("delete from Cart where SerialNumber = @serial and CustomerUsername = @username", conn);
            cmd.Parameters.AddWithValue("@serial", serial);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void AddOrder(string username, decimal totalPrice, DateTime date)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                // Get the region of the customer from the Person table
                string getCustomerRegionQuery = @"
       select Address.Region 
from Address inner join Person on Person.AdressId = Address.AdressId
inner join Account on Account.NationalID = Person.NationalID
where Account.Username = @username";

                SqlCommand getCustomerRegionCommand = new SqlCommand(getCustomerRegionQuery, conn);
                getCustomerRegionCommand.Parameters.AddWithValue("@username", username);

                string customerRegion = getCustomerRegionCommand.ExecuteScalar()?.ToString();


                // Get a random Delivery ID with the same region as the customer
                string getRandomDeliveryQuery = @"
        SELECT TOP 1 p.NationalID
        FROM Person p
        INNER JOIN Address a ON p.AdressId = a.AdressId
        WHERE p.PersonType = 'Delivery' AND a.Region = @Region AND p.DeliveryStatus = 'ACTIVE'
        ORDER BY NEWID()";

                SqlCommand getDeliveryCommand = new SqlCommand(getRandomDeliveryQuery, conn);
                getDeliveryCommand.Parameters.AddWithValue("@Region", customerRegion);
                string deliveryId = getDeliveryCommand.ExecuteScalar()?.ToString();

                // Insert the order into the Orders table
                string insertOrderQuery = @"
        INSERT INTO Orders (CustomerUsername, TotalPrice, OrderDate, DeliveryID, OrderStatus)
        VALUES (@Username, @TotalPrice, @Date, @DeliveryID, @status)";

                SqlCommand insertOrderCommand = new SqlCommand(insertOrderQuery, conn);
                insertOrderCommand.Parameters.AddWithValue("@Username", username);
                insertOrderCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);
                insertOrderCommand.Parameters.AddWithValue("@Date", date);
                insertOrderCommand.Parameters.AddWithValue("@DeliveryID", deliveryId);
                insertOrderCommand.Parameters.AddWithValue("@status", "UNPAID");

                insertOrderCommand.ExecuteNonQuery();
            }
        }


        public Invoice Invoice(string username)
        {
            List<Cart> CartList = new List<Cart>();
            Order order = new Order();

            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select Products.SerialNumber, ProductName , Products.Description, Products.Image, Price, Cart.Quantity\r\nfrom Products\r\ninner join Cart\r\non Products.SerialNumber = Cart.SerialNumber\r\nwhere Cart.CustomerUsername = @username", conn);
            cmd.Parameters.AddWithValue("@username", username);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Cart cart = new Cart();
                    cart.SerialNumber = reader.GetString(0);
                    cart.Name = reader.GetString(1);
                    cart.Description = reader.GetString(2);
                    cart.Image = reader.GetString(3);
                    cart.Price = reader.GetInt32(4);
                    cart.CartQuantity = reader.GetInt32(5);

                    CartList.Add(cart);
                }
            }


            cmd = new SqlCommand("select CONCAT (Person.FirstName, ' ', Person.LastName) \r\nfrom Person inner join Account on Person.NationalID = Account.NationalID\r\nwhere Account.Username = @username", conn);
            cmd.Parameters.AddWithValue("@username", username);
            string CustomerName = cmd.ExecuteScalar().ToString();

            cmd = new SqlCommand("SELECT CONCAT (Country, ', ', Region, ', ', Town, ', ', Street, ', ', Building, ', ', FloorNb) \r\nFROM Address \r\nINNER JOIN Person ON Person.AdressId = Address.AdressId\r\nINNER JOIN Account ON Account.NationalID = Person.NationalID\r\nWHERE Account.Username = @username;\r\n", conn);
            cmd.Parameters.AddWithValue("@username", username);
            string address = cmd.ExecuteScalar().ToString();

            cmd = new SqlCommand("Select Email\r\nfrom Account where Username = @username", conn);
            cmd.Parameters.AddWithValue("@username", username);
            string email = cmd.ExecuteScalar().ToString();

            cmd = new SqlCommand("select PhoneNumber from Person\r\ninner join Account\r\non Account.NationalID = Person.NationalID\r\nwhere Account.Username = @username", conn);
            cmd.Parameters.AddWithValue("@username", username);
            string phone = cmd.ExecuteScalar().ToString();

            cmd = new SqlCommand("SELECT TOP 1 OrderId, TotalPrice, OrderDate, CustomerUsername \r\nFROM Orders \r\nWHERE CustomerUsername = @username \r\nORDER BY OrderId DESC;\r\n", conn);
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataReader reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {
                order.OrderId = reader1.GetInt32(0);
                order.TotalPrice = Convert.ToDecimal(reader1.GetInt32(1));
                order.OrderDate = reader1.GetDateTime(2);
            }

            Order ordertemp = order;

            Invoice invoice = new Invoice(CustomerName, address, email, phone, CartList, ordertemp);

            return invoice;
        }


        public void DeleteCart(string username)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Cart WHERE CustomerUsername = @username", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Products GetProductDetials(string id)
        {
            conn = new SqlConnection(connection);

            conn.Open();
            cmd = new SqlCommand(@"
    SELECT 
        p.SerialNumber,
        p.ProductName,
        p.Price,
        p.Description,
        p.Image,
        p.Quantity
    FROM 
        Products p
    WHERE 
        p.SerialNumber = @id", conn);


            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productDetail.SerialNumber = reader.GetString(0);
                productDetail.Name = reader.GetString(1);
                productDetail.Price = reader.GetInt32(2);
                productDetail.Description = reader.GetString(3);
                productDetail.Image = reader.GetString(4);
                productDetail.TotalQuantity = reader.GetInt32(5);
            }
            return productDetail;
            conn.Close();
        }

        public void UpdateCartQuantity(string username, string serial, int quantity)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("UPDATE Cart SET Quantity = @quantity WHERE CustomerUsername = @username AND SerialNumber = @serial", conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@serial", serial);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateCartTotalPrice(string username, decimal tprice)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("UPDATE Orders SET TotalPrice = @tprice where CustomerUsername = @username", conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@tprice", tprice);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public decimal CalculateTotalPrice(string username)
        {
            decimal totalPrice = 0;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("SELECT SUM(Cart.Quantity * Products.Price) AS TotalPrice FROM Cart JOIN Products ON Cart.SerialNumber = Products.SerialNumber WHERE Cart.CustomerUsername = @username", conn);
            cmd.Parameters.AddWithValue("@username", username);

            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                totalPrice = Convert.ToDecimal(result);
            }

            conn.Close();
            return totalPrice;
        }

        public void UpdateProductQuantity(string serial, int quantity)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();

                // Decrease the quantity of the product in the Products table
                string updateQuantityQuery = @"
        UPDATE Products
        SET Quantity = Quantity - @Quantity
        WHERE SerialNumber = @SerialNumber";

                SqlCommand updateQuantityCommand = new SqlCommand(updateQuantityQuery, conn);
                updateQuantityCommand.Parameters.AddWithValue("@SerialNumber", serial);
                updateQuantityCommand.Parameters.AddWithValue("@Quantity", quantity);

                updateQuantityCommand.ExecuteNonQuery();
            }
        }

        public List<AdminComputer> GetAllLaptopsAdmin()
        {
            List<AdminComputer> AdminComputerList = new List<AdminComputer>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select Products.SerialNumber, Brands.BrandName, CONCAT(Person.FirstName, ' ', Person.LastName) AS SupplierName, Products.ProductName, Products.Price, Products.Description, Products.Image, Products.Quantity ,Computer.RAM, Computer.OS, Computer.Memory, Computer.CPU, Computer.Display, Computer.Color, Computer.Touchscreen\r\nfrom Products inner join Brands on Products.BrandId = Brands.BrandId\r\ninner join Computer on Computer.SerialNumber = Products.SerialNumber\r\ninner join Person on Products.SupplierID = Person.NationalID\r\nwhere Computer.ComputerType = 'LAPTOP'\r\norder by Products.SerialNumber", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string serialnb = reader.GetString(0);
                string brand = reader.GetString(1);
                string supplier = reader.GetString(2);
                string name = reader.GetString(3);
                int price = reader.GetInt32(4);
                string description = reader.GetString(5);
                string image = reader.GetString(6);
                int quantity = reader.GetInt32(7);
                string ram = reader.GetString(8);
                string os = reader.GetString(9);
                string memory = reader.GetString(10);
                string cpu = reader.GetString(11);
                string display = reader.GetString(12);
                string color = reader.GetString(13);
                bool touch = reader.GetBoolean(14);

                adminLaptop = new AdminComputer(serialnb, brand, supplier, name, price, description, image, ram, memory, cpu, display, color, os, touch, quantity);
                AdminComputerList.Add(adminLaptop);
            }
            return AdminComputerList;
        }

        public List<AdminComputer> GetAllDesktopsAdmin()
        {
            List<AdminComputer> AdminComputerList = new List<AdminComputer>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select Products.SerialNumber, Brands.BrandName, CONCAT(Person.FirstName, ' ', Person.LastName) AS SupplierName, Products.ProductName, Products.Price, Products.Description, Products.Image, Products.Quantity ,Computer.RAM, Computer.OS, Computer.Memory, Computer.CPU, Computer.Display, Computer.Color, Computer.Touchscreen\r\nfrom Products inner join Brands on Products.BrandId = Brands.BrandId\r\ninner join Computer on Computer.SerialNumber = Products.SerialNumber\r\ninner join Person on Products.SupplierID = Person.NationalID\r\nwhere Computer.ComputerType = 'DESKTOP'\r\norder by Products.SerialNumber", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string serialnb = reader.GetString(0);
                string brand = reader.GetString(1);
                string supplier = reader.GetString(2);
                string name = reader.GetString(3);
                int price = reader.GetInt32(4);
                string description = reader.GetString(5);
                string image = reader.GetString(6);
                int quantity = reader.GetInt32(7);
                string ram = reader.GetString(8);
                string os = reader.GetString(9);
                string memory = reader.GetString(10);
                string cpu = reader.GetString(11);
                string display = reader.GetString(12);
                string color = reader.GetString(13);
                bool touch = reader.GetBoolean(14);

                adminDesktop = new AdminComputer(serialnb, brand, supplier, name, price, description, image, ram, memory, cpu, display, color, os, touch, quantity);
                AdminComputerList.Add(adminDesktop);
            }
            return AdminComputerList;
        }

        public List<AdminProduct> GetAllNetworkAdmin()
        {
            List<AdminProduct> NetworkList = new List<AdminProduct>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select SerialNumber, Brands.BrandName, CONCAT(Person.FirstName, ' ' , Person.LastName) AS SupplierName, Products.ProductName, Products.Price, Products.Quantity, Products.Description, Products.Image \r\nfrom Products inner join Brands on Brands.BrandId =Products.BrandId\r\ninner join Person on Person.NationalID = Products.SupplierID\r\nwhere Products.ProductType = 'Network'\r\norder by Products.SerialNumber", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string serialnb = reader.GetString(0);
                string brand = reader.GetString(1);
                string supplier = reader.GetString(2);
                string name = reader.GetString(3);
                int price = reader.GetInt32(4);
                int quantity = reader.GetInt32(5);
                string description = reader.GetString(6);
                string image = reader.GetString(7);

                network = new AdminProduct(serialnb, brand, supplier, name, price, description, image, quantity);
                NetworkList.Add(network);
            }
            return NetworkList;
        }

        public List<AdminProduct> GetAllSecurityAdmin()
        {
            List<AdminProduct> SecurityList = new List<AdminProduct>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select SerialNumber, Brands.BrandName, CONCAT(Person.FirstName, ' ' , Person.LastName) AS SupplierName, Products.ProductName, Products.Price, Products.Quantity, Products.Description, Products.Image \r\nfrom Products inner join Brands on Brands.BrandId =Products.BrandId\r\ninner join Person on Person.NationalID = Products.SupplierID\r\nwhere Products.ProductType = 'Security'\r\norder by Products.SerialNumber", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string serialnb = reader.GetString(0);
                string brand = reader.GetString(1);
                string supplier = reader.GetString(2);
                string name = reader.GetString(3);
                int price = reader.GetInt32(4);
                int quantity = reader.GetInt32(5);
                string description = reader.GetString(6);
                string image = reader.GetString(7);

                security = new AdminProduct(serialnb, brand, supplier, name, price, description, image, quantity);
                SecurityList.Add(security);
            }
            return SecurityList;
        }

        public List<AdminProduct> GetAllComponentsAdmin()
        {
            List<AdminProduct> ComponentsList = new List<AdminProduct>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select SerialNumber, Brands.BrandName, CONCAT(Person.FirstName, ' ' , Person.LastName) AS SupplierName, Products.ProductName, Products.Price, Products.Quantity, Products.Description, Products.Image \r\nfrom Products inner join Brands on Brands.BrandId =Products.BrandId\r\ninner join Person on Person.NationalID = Products.SupplierID\r\nwhere Products.ProductType = 'component'\r\norder by Products.SerialNumber", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string serialnb = reader.GetString(0);
                string brand = reader.GetString(1);
                string supplier = reader.GetString(2);
                string name = reader.GetString(3);
                int price = reader.GetInt32(4);
                int quantity = reader.GetInt32(5);
                string description = reader.GetString(6);
                string image = reader.GetString(7);

                components = new AdminProduct(serialnb, brand, supplier, name, price, description, image, quantity);
                ComponentsList.Add(components);
            }
            return ComponentsList;
        }

        public List<AdminProduct> GetAllAccessoriesAdmin()
        {
            List<AdminProduct> AccessoriesList = new List<AdminProduct>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select SerialNumber, Brands.BrandName, CONCAT(Person.FirstName, ' ' , Person.LastName) AS SupplierName, Products.ProductName, Products.Price, Products.Quantity, Products.Description, Products.Image \r\nfrom Products inner join Brands on Brands.BrandId =Products.BrandId\r\ninner join Person on Person.NationalID = Products.SupplierID\r\nwhere Products.ProductType = 'accessories'\r\norder by Products.SerialNumber", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string serialnb = reader.GetString(0);
                string brand = reader.GetString(1);
                string supplier = reader.GetString(2);
                string name = reader.GetString(3);
                int price = reader.GetInt32(4);
                int quantity = reader.GetInt32(5);
                string description = reader.GetString(6);
                string image = reader.GetString(7);

                accessories = new AdminProduct(serialnb, brand, supplier, name, price, description, image, quantity);
                AccessoriesList.Add(accessories);
            }
            return AccessoriesList;
        }

        public AdminProduct RecentProduct()
        {
            AdminProduct Product = null;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("SELECT TOP 1 SerialNumber, Brands.BrandName, CONCAT(Person.FirstName, ' ' , Person.LastName) AS SupplierName, Products.ProductName, Products.Price, Products.Quantity, Products.Description, Products.Image\r\nfrom Products inner join Brands on Brands.BrandId =Products.BrandId\r\ninner join Person on Person.NationalID = Products.SupplierID\r\nORDER BY NEWID();\r\n", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string serialnb = reader.GetString(0);
                string brand = reader.GetString(1);
                string supplier = reader.GetString(2);
                string name = reader.GetString(3);
                int price = reader.GetInt32(4);
                int quantity = reader.GetInt32(5);
                string description = reader.GetString(6);
                string image = reader.GetString(7);

                Product = new AdminProduct(serialnb, brand, supplier, name, price, description, image, quantity);
            }
            return Product;
        }

        public int TotalProducts()
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select count(*) from Products", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
            conn.Close();
        }

        public int TotalCustomers()
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select count(*) from Account\r\ninner join Person on Account.NationalID = Person.NationalID\r\nwhere Person.PersonType = 'customer'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
            conn.Close();
        }

        public int TotalPersons()
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select count(*) from Person", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
            conn.Close();
        }

        public List<Person> Customers()
        {
            List<Person> UserList = new List<Person>();
            Person p = null;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select Person.NationalID, CONCAT(Person.FirstName, ' ', Person.LastName) AS PersonName, Account.Email, Account.Username, CONCAT(Address.Country,', ',Address.Region,', ', Address.Town) AS PAddress, Person.PhoneNumber\r\nfrom Person inner join Address on Person.AdressId = Address.AdressId\r\ninner join Account on Account.NationalID = Person.NationalID\r\nwhere Person.PersonType = 'customer'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                p = new Person();
                p.NationalId = reader.GetString(0);
                p.Name = reader.GetString(1);
                p.Email = reader.GetString(2);
                p.Username = reader.GetString(3);
                p.Address = reader.GetString(4);
                p.PhoneNumber = reader.GetString(5);

                UserList.Add(p);
            }
            return UserList;
        }

        public List<DelSup> Suppliers()
        {
            List<DelSup> delsup = new List<DelSup>();
            DelSup supplier = null;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select Person.NationalID ,CONCAT(Person.FirstName, ' ', Person.LastName) AS PersonName, Person.PhoneNumber, CONCAT(Address.Country,', ',Address.Region,', ', Address.Town) AS PAddress\r\nfrom Person inner join Address on Person.AdressId = Address.AdressId\r\nwhere Person.PersonType = 'Supplier'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                supplier = new DelSup();
                supplier.NationalId = reader.GetString(0);
                supplier.Name = reader.GetString(1);
                supplier.PhoneNumber = reader.GetString(2);
                supplier.Address = reader.GetString(3);

                delsup.Add(supplier);
            }
            return delsup;
        }

        public List<DelSup> Delivery()
        {
            List<DelSup> delsup = new List<DelSup>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select Person.NationalID ,CONCAT(Person.FirstName, ' ', Person.LastName) AS PersonName, Person.PhoneNumber, CONCAT(Address.Country,', ',Address.Region,', ', Address.Town) AS PAddress, Person.DeliveryStatus\r\nfrom Person inner join Address on Person.AdressId = Address.AdressId\r\nwhere Person.PersonType = 'Delivery' ORDER BY Person.AdressId DESC", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string NationalId = reader.GetString(0);
                string Name = reader.GetString(1);
                string PhoneNumber = reader.GetString(2);
                string Address = reader.GetString(3);
                string status = reader.GetString(4);
                DelSup p = new DelSup(NationalId, Name, PhoneNumber, Address, status);
                delsup.Add(p);
            }
            return delsup;
        }

        public List<SelectListItem> GetBrands()
        {
            List<SelectListItem> brands = new List<SelectListItem>();
            conn = new SqlConnection(connection);
            cmd = new SqlCommand("select * from Brands", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = reader.GetString(1);
                sli.Value = Convert.ToString(reader.GetInt32(0));
                brands.Add(sli);
            }
            return brands;
        }
        public List<SelectListItem> GetBrandsUpdate(string select = "")
        {
            List<SelectListItem> brands = new List<SelectListItem>();
            conn = new SqlConnection(connection);
            cmd = new SqlCommand("select * from Brands", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = reader.GetString(1);
                sli.Value = Convert.ToString(reader.GetInt32(0));
                if (sli.Text == select)
                {
                    sli.Selected = true;
                }
                brands.Add(sli);
            }
            return brands;
        }
        public List<SelectListItem> GetSuppliers()
        {
            List<SelectListItem> suppliers = new List<SelectListItem>();
            conn = new SqlConnection(connection);
            cmd = new SqlCommand("select Person.NationalID, CONCAT(Person.FirstName,' ', Person.LastName)\r\nfrom Person\r\nwhere Person.PersonType = 'supplier'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = reader.GetString(1) + " / NationalId: " + reader.GetString(0);
                sli.Value = reader.GetString(0);
                suppliers.Add(sli);
            }
            return suppliers;
        }

        public List<SelectListItem> GetSuppliersUpdate(string select = "")
        {
            List<SelectListItem> suppliers = new List<SelectListItem>();
            conn = new SqlConnection(connection);
            cmd = new SqlCommand("select Person.NationalID, CONCAT(Person.FirstName,' ', Person.LastName)\r\nfrom Person\r\nwhere Person.PersonType = 'supplier'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = reader.GetString(1) + " / NationalId: " + reader.GetString(0);
                sli.Value = reader.GetString(0);
                if (sli.Value == select)
                {
                    sli.Selected = true;
                }
                suppliers.Add(sli);
            }
            return suppliers;
        }
        public int AddNewLaptop(string SerialNumber, string name, int brandId, string supplierId, decimal price, int quantity, string description, string image, string ram, string memory, string cpu, string display, string color, string os, bool touchScreen)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                // Check if Serial Number already exists in the Products table
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Products WHERE SerialNumber = @SerialNumber", conn);
                cmd.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                int serialNumberCount = (int)cmd.ExecuteScalar();
                if (serialNumberCount > 0)
                {
                    return 1; // Serial Number already exists
                }

                // Insert Laptop into Products table
                cmd = new SqlCommand("INSERT INTO Products (SerialNumber, ProductName, BrandId, SupplierId, Price, Quantity, Description, Image, ProductType) OUTPUT INSERTED.SerialNumber VALUES (@SerialNumber, @Name, @BrandId, @SupplierId, @Price, @Quantity, @Description, @Image, 'LAPTOP')", conn);
                cmd.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@BrandId", brandId);
                cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Image", image);

                string productId = (string)cmd.ExecuteScalar();

                // Insert Laptop specifications into Computer table
                cmd = new SqlCommand("INSERT INTO Computer (SerialNumber, RAM, Memory, CPU, Display, Color, OS, TouchScreen, ComputerType) VALUES (@ProductId, @RAM, @Memory, @CPU, @Display, @Color, @OS, @TouchScreen, @type)", conn);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.Parameters.AddWithValue("@RAM", ram);
                cmd.Parameters.AddWithValue("@Memory", memory);
                cmd.Parameters.AddWithValue("@CPU", cpu);
                cmd.Parameters.AddWithValue("@Display", display);
                cmd.Parameters.AddWithValue("@Color", color);
                cmd.Parameters.AddWithValue("@OS", os);
                cmd.Parameters.AddWithValue("@TouchScreen", touchScreen ? 1 : 0);
                cmd.Parameters.AddWithValue("@type", "LAPTOP");

                cmd.ExecuteNonQuery();

                return 0; // Indicate success
            }
        }

        public int AddBrand(string brandname)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                // Check if the brand already exists
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Brands WHERE BrandName = @brand", conn);
                checkCmd.Parameters.AddWithValue("@brand", brandname);
                int brandExists = (int)checkCmd.ExecuteScalar();

                if (brandExists > 0)
                {
                    // Brand already exists
                    conn.Close();
                    return 0; // Indicate that the brand already exists
                }

                // Insert the new brand
                SqlCommand cmd = new SqlCommand("INSERT INTO Brands (BrandName) VALUES (@brand)", conn);
                cmd.Parameters.AddWithValue("@brand", brandname);
                cmd.ExecuteNonQuery();
                conn.Close();

                return 1; // Indicate that the brand was successfully added
            }
        }

        public void DeleteComputer(string serialNb)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("DELETE FROM Computer where Computer.SerialNumber = @serial", conn);
            cmd.Parameters.AddWithValue("@serial", serialNb);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("delete from Products where Products.SerialNumber = @serial", conn);
            cmd.Parameters.AddWithValue("@serial", serialNb);
            cmd.ExecuteNonQuery();
        }

        public AdminComputer GetComputerDetails(string Id)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select Products.SerialNumber, Brands.BrandName, Products.SupplierID, Products.ProductName, Products.Price, Products.Description, Products.Quantity, Products.Image,\r\ncomputer.RAM, Computer.Memory, Computer.CPU, Computer.Display, Computer.Color, Computer.OS, Computer.Touchscreen\r\nfrom Products inner join Brands on Products.BrandId = Brands.BrandId\r\ninner join Computer on Products.SerialNumber = Computer.SerialNumber where Products.SerialNumber = @serial", conn);
            cmd.Parameters.AddWithValue("@serial", Id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                computer = new AdminComputer();
                computer.SerialNumber = reader.GetString(0);
                computer.BrandName = reader.GetString(1);
                computer.Supplier = reader.GetString(2);
                computer.Name = reader.GetString(3);
                computer.Price = reader.GetInt32(4);
                computer.Description = reader.GetString(5);
                computer.TotalQuantity = reader.GetInt32(6);
                computer.Image = reader.GetString(7);
                computer.RAM = reader.GetString(8);
                computer.Memory = reader.GetString(9);
                computer.CPU = reader.GetString(10);
                computer.Display = reader.GetString(11);
                computer.Color = reader.GetString(12);
                computer.OS = reader.GetString(13);
                computer.Touchscreen = reader.GetBoolean(14);
            }
            return computer;
        }

        public int AddProduct(string serial, int brand, string supplier, string name, decimal price, int quantity, string description, string image, string type)
        {
            conn = new SqlConnection(connection);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Products WHERE SerialNumber = @SerialNumber", conn);
            cmd.Parameters.AddWithValue("@SerialNumber", serial);
            int serialNumberCount = (int)cmd.ExecuteScalar();
            if (serialNumberCount > 0)
            {
                return 1; // Serial Number already exists
            }

            cmd = new SqlCommand("INSERT INTO Products VALUES(@serial, @brand, @supplier, @name, @price, @quantity, @description, @image, @type)", conn);
            cmd.Parameters.AddWithValue("@serial", serial);
            cmd.Parameters.AddWithValue("@brand", brand);
            cmd.Parameters.AddWithValue("@supplier", supplier);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@image", image);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.ExecuteNonQuery();
            return 0;
        }

        public AdminProduct GetProductDetail(string serial)
        {
            AdminProduct product = null;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select SerialNumber, Brands.BrandName, SupplierID, Products.ProductName, Products.Price, Products.Quantity, Products.Description, Products.Image \r\nfrom Products inner join Brands on Brands.BrandId =Products.BrandId\r\ninner join Person on Person.NationalID = Products.SupplierID\r\nwhere Products.SerialNumber = @serial\r\norder by Products.SerialNumber", conn);
            cmd.Parameters.AddWithValue("@serial", serial);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string serialnb = reader.GetString(0);
                string brand = reader.GetString(1);
                string supplier = reader.GetString(2);
                string name = reader.GetString(3);
                int price = reader.GetInt32(4);
                int quantity = reader.GetInt32(5);
                string description = reader.GetString(6);
                string image = reader.GetString(7);

                product = new AdminProduct(serialnb, brand, supplier, name, price, description, image, quantity);
            }
            return product;
        }

        public int AddAdmin(string username, string fname, string lname, string pass)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                // Check if the brand already exists
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Admin WHERE Username = @user", conn);
                checkCmd.Parameters.AddWithValue("@user", username);
                int brandExists = (int)checkCmd.ExecuteScalar();

                if (brandExists > 0)
                {
                    // Brand already exists
                    conn.Close();
                    return 0; // Indicate that the brand already exists
                }

                // Insert the new brand
                SqlCommand cmd = new SqlCommand("INSERT INTO Admin (AdminFName, AdminLName, Username, Password) VALUES (@fname, @lname, @username, @pass)", conn);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@pass", pass);

                cmd.ExecuteNonQuery();
                conn.Close();

                return 1; // Indicate that the brand was successfully added
            }
        }

        public int AddNewDesktop(string SerialNumber, string name, int brandId, string supplierId, decimal price, int quantity, string description, string image, string ram, string memory, string cpu, string display, string color, string os, bool touchScreen)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                // Check if Serial Number already exists in the Products table
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Products WHERE SerialNumber = @SerialNumber", conn);
                cmd.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                int serialNumberCount = (int)cmd.ExecuteScalar();
                if (serialNumberCount > 0)
                {
                    return 1; // Serial Number already exists
                }

                // Insert Laptop into Products table
                cmd = new SqlCommand("INSERT INTO Products (SerialNumber, ProductName, BrandId, SupplierId, Price, Quantity, Description, Image, ProductType) OUTPUT INSERTED.SerialNumber VALUES (@SerialNumber, @Name, @BrandId, @SupplierId, @Price, @Quantity, @Description, @Image, 'LAPTOP')", conn);
                cmd.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@BrandId", brandId);
                cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Image", image);

                string productId = (string)cmd.ExecuteScalar();

                // Insert Laptop specifications into Computer table
                cmd = new SqlCommand("INSERT INTO Computer (SerialNumber, RAM, Memory, CPU, Display, Color, OS, TouchScreen, ComputerType) VALUES (@ProductId, @RAM, @Memory, @CPU, @Display, @Color, @OS, @TouchScreen, @type)", conn);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.Parameters.AddWithValue("@RAM", ram);
                cmd.Parameters.AddWithValue("@Memory", memory);
                cmd.Parameters.AddWithValue("@CPU", cpu);
                cmd.Parameters.AddWithValue("@Display", display);
                cmd.Parameters.AddWithValue("@Color", color);
                cmd.Parameters.AddWithValue("@OS", os);
                cmd.Parameters.AddWithValue("@TouchScreen", touchScreen ? 1 : 0);
                cmd.Parameters.AddWithValue("@type", "DESKTOP");

                cmd.ExecuteNonQuery();

                return 0; // Indicate success
            }
        }

        public string GetAdminName(string username)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select CONCAT(Admin.AdminFName, ' ', Admin.AdminLName) AS AdminName from Admin \r\nwhere Admin.Username = @admin", conn);
            cmd.Parameters.AddWithValue("@admin", username);
            string name = cmd.ExecuteScalar().ToString();
            return name;
        }

        public int AddSupplier(string firstName, string lastName, string email, string phoneNumber, string country, string region, string town, string street, string building, int floorNb, string NationalID)
        {
            using (conn = new SqlConnection(connection))
            {
                conn.Open();

                // Check if NationalID already exists
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Person WHERE NationalID = @NationalID", conn);
                cmd.Parameters.AddWithValue("@NationalID", NationalID);
                int nationalIDCount = (int)cmd.ExecuteScalar();
                if (nationalIDCount > 0)
                {
                    return 1; // NationalID already exists
                }

                // Insert Address
                cmd = new SqlCommand("INSERT INTO Address (Country, Region, Town, Street, Building, FloorNb) OUTPUT INSERTED.AdressId VALUES (@Country, @Region, @Town, @Street, @Building, @FloorNb)", conn);
                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Parameters.AddWithValue("@Region", region);
                cmd.Parameters.AddWithValue("@Town", town);
                cmd.Parameters.AddWithValue("@Street", street);
                cmd.Parameters.AddWithValue("@Building", building);
                cmd.Parameters.AddWithValue("@FloorNb", floorNb);

                int addressId = (int)cmd.ExecuteScalar();

                // Insert Person
                cmd = new SqlCommand("INSERT INTO Person (NationalID, AdressId, FirstName, LastName, PersonType, PhoneNumber) VALUES (@NationalID, @AdressId, @FirstName, @LastName, @PersonType, @PhoneNumber)", conn);
                cmd.Parameters.AddWithValue("@NationalID", NationalID);
                cmd.Parameters.AddWithValue("@AdressId", addressId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@PersonType", "Supplier");
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                cmd.ExecuteNonQuery();

                return 0;
            }
        }

        public int AddDelivery(string firstName, string lastName, string email, string phoneNumber, string country, string region, string town, string street, string building, int floorNb, string NationalID)
        {
            using (conn = new SqlConnection(connection))
            {
                conn.Open();

                // Check if NationalID already exists
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Person WHERE NationalID = @NationalID", conn);
                cmd.Parameters.AddWithValue("@NationalID", NationalID);
                int nationalIDCount = (int)cmd.ExecuteScalar();
                if (nationalIDCount > 0)
                {
                    return 1; // NationalID already exists
                }

                // Insert Address
                cmd = new SqlCommand("INSERT INTO Address (Country, Region, Town, Street, Building, FloorNb) OUTPUT INSERTED.AdressId VALUES (@Country, @Region, @Town, @Street, @Building, @FloorNb)", conn);
                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Parameters.AddWithValue("@Region", region);
                cmd.Parameters.AddWithValue("@Town", town);
                cmd.Parameters.AddWithValue("@Street", street);
                cmd.Parameters.AddWithValue("@Building", building);
                cmd.Parameters.AddWithValue("@FloorNb", floorNb);

                int addressId = (int)cmd.ExecuteScalar();

                // Insert Person
                cmd = new SqlCommand("INSERT INTO Person (NationalID, AdressId, FirstName, LastName, PersonType, PhoneNumber, DeliveryStatus) VALUES (@NationalID, @AdressId, @FirstName, @LastName, @PersonType, @PhoneNumber, @status)", conn);
                cmd.Parameters.AddWithValue("@NationalID", NationalID);
                cmd.Parameters.AddWithValue("@AdressId", addressId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@PersonType", "Delivery");
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@status", "ACTIVE");
                cmd.ExecuteNonQuery();

                return 0;
            }
        }

        public int DeleteSupplier(string NationalId)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();

                // Get the address ID associated with the person
                using (var cmd = new SqlCommand("select Person.AdressId from Person where Person.NationalID = @national", conn))
                {
                    cmd.Parameters.AddWithValue("@national", NationalId);
                    int address = Convert.ToInt32(cmd.ExecuteScalar());

                    // Check if there are any products associated with the person
                    using (var cmdProduct = new SqlCommand("select count(*) from Products where Products.SupplierID = @national", conn))
                    {
                        cmdProduct.Parameters.AddWithValue("@national", NationalId);
                        int countProduct = Convert.ToInt32(cmdProduct.ExecuteScalar());
                        if (countProduct != 0)
                        {
                            return 1; // if there are any products supplied by this supplier
                        }
                    }
                    // If there are no products or orders, delete the person and address
                    using (var cmdDeletePerson = new SqlCommand("delete from Person where Person.NationalID = @national", conn))
                    {
                        cmdDeletePerson.Parameters.AddWithValue("@national", NationalId);
                        cmdDeletePerson.ExecuteNonQuery();
                    }

                    using (var cmdDeleteAddress = new SqlCommand("delete from Address where Address.AdressId = @address", conn))
                    {
                        cmdDeleteAddress.Parameters.AddWithValue("@address", address);
                        cmdDeleteAddress.ExecuteNonQuery();
                    }

                    return 0;
                }
            }
        }

        public List<Admin> GetAllAdmins()
        {
            List<Admin> AdminList = new List<Admin>();
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select * from Admin", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string fname = reader.GetString(1);
                string lname = reader.GetString(2);
                string username = reader.GetString(3);
                string password = reader.GetString(4);

                Admin admin = new Admin(id, fname, lname, username, password);
                AdminList.Add(admin);
            }
            return AdminList;
        }

        public void DeleteAdmin(int id)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("delete from Admin where AdminID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public int DeActivateDelivery(string national)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();

                // Get the region of the delivery person
                using (var cmd = new SqlCommand("select Address.Region from Address " +
                                                 "inner join Person on Person.AdressId = Address.AdressId " +
                                                 "where Person.NationalID = @national", conn))
                {
                    cmd.Parameters.AddWithValue("@national", national);
                    string region = cmd.ExecuteScalar()?.ToString();

                    if (string.IsNullOrEmpty(region))
                    {
                        // Return -1 if the delivery person is not found
                        return -1;
                    }

                    // Count the number of delivery persons in that region
                    cmd.CommandText = "select count(*) from Person " +
                                      "inner join Address on Person.AdressId = Address.AdressId " +
                                      "where Address.Region = @region and PersonType = 'Delivery'";
                    cmd.Parameters.AddWithValue("@region", region);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count <= 1)
                    {
                        // Do not deactivate if this is the last delivery person in the region
                        return 1;
                    }

                    // Deactivate the delivery person
                    cmd.CommandText = "update Person set DeliveryStatus = 'INACTIVE' WHERE NationalID = @national";
                    cmd.ExecuteNonQuery();

                }
            }
            return 0;
        }

        public void ActivateDelivery(string national)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();

                using (var cmd = new SqlCommand("update Person set DeliveryStatus = 'ACTIVE' WHERE NationalID = @national", conn))
                {
                    cmd.Parameters.AddWithValue("@national", national);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public List<AdminOrder> GetDeliveryPaidOrders(string delivery)
        {
            List<AdminOrder> ordersList = new List<AdminOrder>();
            AdminOrder order = null;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("SELECT \r\n    CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,\r\n    o.TotalPrice AS TotalOrderAmount,\r\n    CONCAT(\r\n        a.Country, ', ', \r\n        a.Region, ', ', \r\n        a.Town, ', ', \r\n        a.Street, ', ', \r\n        'Building ', a.Building, ', ', \r\n        'Floor ', a.FloorNb\r\n    ) AS FullAddress,\r\n    c.PhoneNumber,\r\n\to.OrderId, \r\n\to.OrderDate,\r\n\to.OrderStatus,\r\n\to.DeliveryID\r\nFROM \r\n    Orders o\r\nINNER JOIN \r\n    Account acc ON acc.Username = o.CustomerUsername\r\nINNER JOIN \r\n    Person c ON c.NationalID = acc.NationalID\r\nINNER JOIN \r\n    Address a ON c.AdressId = a.AdressId\r\nwhere o.DeliveryID = @delivery and o.OrderStatus = 'PAID' ORDER BY o.OrderId DESC", conn);
            cmd.Parameters.AddWithValue("@delivery", delivery);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                order = new AdminOrder();
                order.CustomerName = reader.GetString(0);
                order.OrderAmount = reader.GetInt32(1);
                order.CustomerAddress = reader.GetString(2);
                order.CustomerPhoneNumber = reader.GetString(3);
                order.OrderId = reader.GetInt32(4);
                order.OrderDate = reader.GetDateTime(5);
                order.OrderStatus = reader.GetString(6);
                order.DeliveryID = reader.GetString(7);

                ordersList.Add(order);
            }
            return ordersList;
        }

        public List<AdminOrder> GetDeliveryUnPaidOrders(string delivery)
        {
            List<AdminOrder> ordersList = new List<AdminOrder>();
            AdminOrder order = null;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("SELECT \r\n    CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,\r\n    o.TotalPrice AS TotalOrderAmount,\r\n    CONCAT(\r\n        a.Country, ', ', \r\n        a.Region, ', ', \r\n        a.Town, ', ', \r\n        a.Street, ', ', \r\n        'Building ', a.Building, ', ', \r\n        'Floor ', a.FloorNb\r\n    ) AS FullAddress,\r\n    c.PhoneNumber,\r\n\to.OrderId, \r\n\to.OrderDate,\r\n\to.OrderStatus,\r\n\to.DeliveryID\r\nFROM \r\n    Orders o\r\nINNER JOIN \r\n    Account acc ON acc.Username = o.CustomerUsername\r\nINNER JOIN \r\n    Person c ON c.NationalID = acc.NationalID\r\nINNER JOIN \r\n    Address a ON c.AdressId = a.AdressId\r\nwhere o.DeliveryID = @delivery and o.OrderStatus = 'UNPAID' ORDER BY o.OrderId DESC", conn);
            cmd.Parameters.AddWithValue("@delivery", delivery);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                order = new AdminOrder();
                order.CustomerName = reader.GetString(0);
                order.OrderAmount = reader.GetInt32(1);
                order.CustomerAddress = reader.GetString(2);
                order.CustomerPhoneNumber = reader.GetString(3);
                order.OrderId = reader.GetInt32(4);
                order.OrderDate = reader.GetDateTime(5);
                order.OrderStatus = reader.GetString(6);
                order.DeliveryID = reader.GetString(7);

                ordersList.Add(order);
            }
            return ordersList;
        }

        public string GetDeliveryName(string delivery)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select CONCAT(Person.FirstName, ' ', Person.LastName) from Person\r\nwhere Person.NationalID = @delivery", conn);
            cmd.Parameters.AddWithValue("@delivery", delivery);
            string name = cmd.ExecuteScalar().ToString();
            return name;
        }

        public int NbOfOrderYear()
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("SELECT \r\n    count(*) AS NbOfOrders\r\nFROM \r\n    Orders\r\nWHERE \r\n    YEAR(OrderDate) = YEAR(GETDATE())\r\n", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }


        public List<AdminOrder> GetPaidOrders()
        {
            List<AdminOrder> ordersList = new List<AdminOrder>();
            AdminOrder order = null;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand(@"SELECT 
    CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
    o.TotalPrice AS TotalOrderAmount,
    CONCAT(
        a.Country, ', ', 
        a.Region, ', ', 
        a.Town, ', ', 
        a.Street, ', ', 
        'Building ', a.Building, ', ', 
        'Floor ', a.FloorNb
    ) AS FullAddress,
    c.PhoneNumber,
    o.OrderId, 
    o.OrderDate,
    o.OrderStatus,
    o.DeliveryID
FROM 
    Orders o
INNER JOIN 
    Account acc ON acc.Username = o.CustomerUsername
INNER JOIN 
    Person c ON c.NationalID = acc.NationalID
INNER JOIN 
    Address a ON c.AdressId = a.AdressId
WHERE 
    o.OrderStatus = 'PAID'
ORDER BY 
    o.OrderId DESC", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                order = new AdminOrder();
                order.CustomerName = reader.GetString(0);
                order.OrderAmount = reader.GetInt32(1);
                order.CustomerAddress = reader.GetString(2);
                order.CustomerPhoneNumber = reader.GetString(3);
                order.OrderId = reader.GetInt32(4);
                order.OrderDate = reader.GetDateTime(5);
                order.OrderStatus = reader.GetString(6);
                order.DeliveryID = reader.GetString(7);

                ordersList.Add(order);
            }
            return ordersList;
        }

        public List<AdminOrder> GetUnPaidOrders()
        {
            List<AdminOrder> ordersList = new List<AdminOrder>();
            AdminOrder order = null;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand(@"SELECT 
    CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
    o.TotalPrice AS TotalOrderAmount,
    CONCAT(
        a.Country, ', ', 
        a.Region, ', ', 
        a.Town, ', ', 
        a.Street, ', ', 
        'Building ', a.Building, ', ', 
        'Floor ', a.FloorNb
    ) AS FullAddress,
    c.PhoneNumber,
    o.OrderId, 
    o.OrderDate,
    o.OrderStatus,
    o.DeliveryID
FROM 
    Orders o
INNER JOIN 
    Account acc ON acc.Username = o.CustomerUsername
INNER JOIN 
    Person c ON c.NationalID = acc.NationalID
INNER JOIN 
    Address a ON c.AdressId = a.AdressId
WHERE 
    o.OrderStatus = 'UNPAID'
ORDER BY 
    o.OrderId DESC", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                order = new AdminOrder();
                order.CustomerName = reader.GetString(0);
                order.OrderAmount = reader.GetInt32(1);
                order.CustomerAddress = reader.GetString(2);
                order.CustomerPhoneNumber = reader.GetString(3);
                order.OrderId = reader.GetInt32(4);
                order.OrderDate = reader.GetDateTime(5);
                order.OrderStatus = reader.GetString(6);
                order.DeliveryID = reader.GetString(7);

                ordersList.Add(order);
            }
            return ordersList;
        }


        public void PaidOrder(int id)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();

                using (var cmd = new SqlCommand("update Orders set OrderStatus = 'PAID' WHERE OrderId = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void UnPaidOrder(int id)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();

                using (var cmd = new SqlCommand("update Orders set OrderStatus = 'UNPAID' WHERE OrderId = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public int UpdateComputer(string serial, string ram, string memory, string cpu, string display, string color, string os, int brandId, string name, decimal price, int quantity, string description)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();

                // Update the Computer table
                using (var cmd = new SqlCommand(@"UPDATE Computer
                                         SET RAM = @ram, 
                                             Memory = @memory, 
                                             CPU = @cpu, 
                                             Display = @display, 
                                             Color = @color, 
                                             OS = @os
                                         WHERE SerialNumber = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", serial);
                    cmd.Parameters.AddWithValue("@ram", ram);
                    cmd.Parameters.AddWithValue("@memory", memory);
                    cmd.Parameters.AddWithValue("@cpu", cpu);
                    cmd.Parameters.AddWithValue("@display", display);
                    cmd.Parameters.AddWithValue("@color", color);
                    cmd.Parameters.AddWithValue("@os", os);

                    cmd.ExecuteNonQuery();
                }

                // Update the Products table
                using (var cmd = new SqlCommand(@"UPDATE Products
                                         SET BrandId = @brand, 
                                             ProductName = @name, 
                                             Price = @price, 
                                             Quantity = @quantity, 
                                             Description = @description
                                         WHERE SerialNumber = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", serial);
                    cmd.Parameters.AddWithValue("@brand", brandId);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@description", description);

                    cmd.ExecuteNonQuery();
                }
                return 0;
            }
        }
        public int UpdateProduct(string serial, int brandId, string name, decimal price, int quantity, string description)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();
                // Update the Products table
                using (var cmd = new SqlCommand(@"UPDATE Products
                                         SET BrandId = @brand, 
                                             ProductName = @name, 
                                             Price = @price, 
                                             Quantity = @quantity, 
                                             Description = @description
                                         WHERE SerialNumber = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", serial);
                    cmd.Parameters.AddWithValue("@brand", brandId);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@description", description);

                    cmd.ExecuteNonQuery();
                }
                return 0;
            }
        }


        public Admin GetAdminDetail(string username)
        {
            Admin admin = null;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select * from Admin where Username = @user", conn);
            cmd.Parameters.AddWithValue("@user", username);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                admin = new Admin();
                admin.AdminId = reader.GetInt32(0);
                admin.Fname = reader.GetString(1);
                admin.Lname = reader.GetString(2);
                admin.Username = reader.GetString(3);
                admin.Password = reader.GetString(4);
            }
            return admin;
        }

        public int ResetAdminPassword(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                // Check if the user exists and get the current password
                using (SqlCommand cmd = new SqlCommand("select Password from Admin where Username = @user", conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);

                    object result = cmd.ExecuteScalar();

                    string currentPassword = result.ToString();

                    // Check if the new password is the same as the current password
                    if (currentPassword == password)
                    {
                        // No need to reset the password, they are the same
                        return 1;
                    }
                }

                // Update the password
                using (SqlCommand cmd = new SqlCommand("update Admin set Password = @pass where Username = @user", conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password); // Ideally, hash the password before storing it

                    cmd.ExecuteNonQuery();
                }
            }

            return 0;
        }

        public SupplierDelivery GetPersonDetail(string national)
        {
            SupplierDelivery person = null;
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("select Person.NationalID,  Person.FirstName, Person.LastName, Person.PhoneNumber,\tAddress.Country, Address.Region,\r\nAddress.Town, Address.Street, Address.Building, Address.FloorNb\r\n\r\nfrom Person inner join Address on Address.AdressId = Person.AdressId\r\n\r\nwhere Person.NationalID = @id", conn);
            cmd.Parameters.AddWithValue("@id", national);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                person = new SupplierDelivery();
                person.national = reader.GetString(0);
                person.Fname = reader.GetString(1);
                person.Lname = reader.GetString(2);
                person.PhoneNumber = reader.GetString(3);
                person.Country = reader.GetString(4);
                person.Region = reader.GetString(5);
                person.Town = reader.GetString(6);
                person.Street = reader.GetString(7);
                person.Building = reader.GetString(8);
                person.FloorNb = reader.GetInt32(9);

            }
            return person;
        }

        public int UpdatePerson(
            string national,
            string newFirstName,
            string newLastName,
            string newPhoneNumber,
            string newCountry,
            string newRegion,
            string newTown,
            string newStreet,
            string newBuilding,
            int newFloorNb)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                // Update Address
                string addressQuery = "UPDATE Address " +
                                      "SET Country = @Country, " +
                                      "    Region = @Region, " +
                                      "    Town = @Town, " +
                                      "    Street = @Street, " +
                                      "    Building = @Building, " +
                                      "    FloorNb = @FloorNb " +
                                      "WHERE AdressId = (SELECT AdressId FROM Person WHERE NationalID = @NationalID)";

                using (SqlCommand addressCmd = new SqlCommand(addressQuery, conn))
                {
                    // Set parameters for Address
                    addressCmd.Parameters.AddWithValue("@Country", newCountry);
                    addressCmd.Parameters.AddWithValue("@Region", newRegion);
                    addressCmd.Parameters.AddWithValue("@Town", newTown);
                    addressCmd.Parameters.AddWithValue("@Street", newStreet);
                    addressCmd.Parameters.AddWithValue("@Building", newBuilding);
                    addressCmd.Parameters.AddWithValue("@FloorNb", newFloorNb);
                    addressCmd.Parameters.AddWithValue("@NationalID", national);

                    // Execute the command
                    int addressRowsAffected = addressCmd.ExecuteNonQuery();
                }

                // Update Person
                string personQuery = "UPDATE Person " +
                                     "SET FirstName = @FirstName, " +
                                     "    LastName = @LastName, " +
                                     "    PhoneNumber = @phone " +
                                     "WHERE NationalID = @NationalID";

                using (SqlCommand personCmd = new SqlCommand(personQuery, conn))
                {
                    // Set parameters for Person
                    personCmd.Parameters.AddWithValue("@FirstName", newFirstName);
                    personCmd.Parameters.AddWithValue("@LastName", newLastName);
                    personCmd.Parameters.AddWithValue("@phone", newPhoneNumber);
                    personCmd.Parameters.AddWithValue("@NationalID", national);

                    // Execute the command
                    int personRowsAffected = personCmd.ExecuteNonQuery();

                    // Optional: Check if the update was successful
                    if (personRowsAffected > 0)
                    {
                        return 0; // person updated successfully
                    }
                    else
                    {
                        return 1; //failed to update person
                    }
                }
            }
        }

    }
}

