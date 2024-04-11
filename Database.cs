using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using pr10.models;
using Tmds.DBus.Protocol;

namespace pr10.Database;

public class Database
{
    public MySqlConnectionStringBuilder _connectionString { get; }

    public Database()
    {
        _connectionString = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Database = "pr10",
            UserID = "root",
            Password = "123456"
        };
    }

    public MySqlConnectionStringBuilder  getConnectionString()
    {
        return _connectionString;
    }

    public Category GetCategoryById(int id)
    {
        Category category = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM categories WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    category = new Category(reader.GetInt32("id"), reader.GetString("Name"));
                }
            }

            conn.Close();
        }

        return category;
    }

    public Product GetProductById(int id)
    {
        Product product = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM products where id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category currentCategory = GetCategoryById(reader.GetInt32("Category"));
                    Manufacture currentManufacture = GetManufactureById(reader.GetInt32("Manufacturer"));
                    Provider currentProvider = GetProviderById(reader.GetInt32("Provider"));
                    UnitMeasurement currentUnit = GetUnitMeasurementById(reader.GetInt32("Unit"));

                    product = new Product(reader.GetInt32("id"),
                        reader.GetString("Article"),
                        reader.GetString("Name"),
                        currentUnit,
                        reader.GetInt32("Price"),
                        reader.GetInt32("MaxSale"),
                        currentManufacture,
                        currentProvider,
                        currentCategory,
                        reader.GetInt32("CurrentSale"),
                        reader.GetInt32("Count"),
                        reader.GetString("Description"),
                        reader.IsDBNull(reader.GetOrdinal("Image")) ? null : reader.GetString("Image"));
                }
            }

            conn.Close();
        }

        return product;
    }

    public Manufacture GetManufactureById(int id)
    {
        Manufacture manufacture = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM manufactures WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    manufacture = new Manufacture(reader.GetInt32("id"), reader.GetString("Name"));
                }
            }

            conn.Close();
        }

        return manufacture;
    }

    public Point GetPointById(int id)
    {
        Point points = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM points WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    points = new Point(reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3));
                }
            }

            conn.Close();
        }

        return points;
    }



    public Role GetRoleById(int id)
    {
        Role role = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM role WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    role = new Role(reader.GetInt32("id"),
                        reader.GetString("Name"));
                }
            }

            conn.Close();
        }

        return role;
    }

    public UnitMeasurement GetUnitMeasurementById(int id)
    {
        UnitMeasurement unitMeasurement = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM unitmeasurements WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    unitMeasurement = new UnitMeasurement(
                        reader.GetInt32("id"),
                        reader.GetString("Name"));
                }
            }

            conn.Close();
        }

        return unitMeasurement;
    }

    public User GetUserById(int id)
    {
        User user = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM users WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Role currentRole = GetRoleById(reader.GetInt32("Role"));
                    user = new User(reader.GetInt32("id"),
                        reader.GetString("Name"),
                        reader.GetString("Login"),
                        reader.GetString("Password"),
                        currentRole);
                }
            }

            conn.Close();
        }

        return user;
    }

    public Provider GetProviderById(int id)
    {
        Provider provider = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM providers WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    provider = new Provider(reader.GetInt32("id"),
                        reader.GetString("Name"));
                }
            }

            conn.Close();
        }

        return provider;
    }

    public OrderStatus GetOrderStatusById(int id)
    {
        OrderStatus orderStatus = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM orderstatuses WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    orderStatus = new OrderStatus(reader.GetInt32("id"),
                        reader.GetString("Name"));
                }
            }

            conn.Close();
        }

        return orderStatus;
    }

    public Order GetOrderById(int id)
    {
        Order order = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM orders WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idUser = reader.IsDBNull(reader.GetOrdinal("Client")) ? 99999999 : reader.GetInt32("Client");
                    User currentUser = GetUserById(idUser);
                    ;
                    Point currentPoint = GetPointById(reader.GetInt32("Point"));
                    OrderStatus orderStatus = GetOrderStatusById(reader.GetInt32("StatusOrder"));
                    order = new Order(reader.GetInt32("id"),
                        reader.GetDateTime("Date"),
                        reader.GetDateTime("DeliveryDate"),
                        currentPoint,
                        currentUser,
                        reader.GetInt32("CodeReceive"),
                        orderStatus);
                }
            }

            conn.Close();
        }

        return order;
    }

    public FullOrder GetFullOrderById(int id)
    {
        FullOrder fullOrder = null;
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM fullorders WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Order currentOrder = GetOrderById(reader.GetInt32("Order"));
                    Product currentProduct = GetProductById(reader.GetInt32("Product"));
                    fullOrder = new FullOrder(reader.GetInt32("id"),
                        currentOrder,
                        currentProduct,
                        reader.GetInt32("CountProduct"));
                }
            }

            conn.Close();
        }

        return fullOrder;
    }

    public List<Category> GetAllCategories()
    {
        List<Category> categories = new List<Category>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM categories";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categories.Add(new Category(
                        reader.GetInt32("Id"),
                        reader.GetString("Name")));
                }
            }

            conn.Close();
        }

        return categories;
    }

    public List<Manufacture> GetAllManufactures()
    {
        List<Manufacture> manufactures = new List<Manufacture>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM manufactures";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    manufactures.Add(new Manufacture(
                        reader.GetInt32("Id"),
                        reader.GetString("Name")));
                }
            }

            conn.Close();
        }

        return manufactures;
    }

    public List<OrderStatus> GetAllOrderStatuses()
    {
        List<OrderStatus> orderStatuses = new List<OrderStatus>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM orderstatuses";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    orderStatuses.Add(new OrderStatus(
                        reader.GetInt32("Id"),
                        reader.GetString("Name")));
                }
            }

            conn.Close();
        }

        return orderStatuses;
    }

    public List<Point> GetAllPoints()
    {
        List<Point> points = new List<Point>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM points";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    points.Add(new Point(
                        reader.GetInt32("Id"),
                        reader.GetString("City"),
                        reader.GetString("Street"),
                        reader.GetInt32("Home")));
                }
            }

            conn.Close();
        }

        return points;
    }

    public List<Provider> GetAllProviders()
    {
        List<Provider> providers = new List<Provider>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM providers";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    providers.Add(new Provider(
                        reader.GetInt32("Id"),
                        reader.GetString("Name")));
                }
            }

            conn.Close();
        }

        return providers;
    }

    public List<Role> GetAllRoles()
    {
        List<Role> roles = new List<Role>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM roles";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(new Role(
                        reader.GetInt32("Id"),
                        reader.GetString("Name")));
                }
            }

            conn.Close();
        }

        return roles;
    }

    public List<UnitMeasurement> GetAllUnitMeasurements()
    {
        List<UnitMeasurement> unitMeasurements = new List<UnitMeasurement>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM unitmeasurements";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    unitMeasurements.Add(new UnitMeasurement(
                        reader.GetInt32("Id"),
                        reader.GetString("Name")));
                }
            }

            conn.Close();
        }

        return unitMeasurements;
    }

    public List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM products";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category currentCategory = GetCategoryById(reader.GetInt32("Category"));
                    Manufacture currentManufacture = GetManufactureById(reader.GetInt32("Manufacturer"));
                    Provider currentProvider = GetProviderById(reader.GetInt32("Provider"));
                    UnitMeasurement currentUnit = GetUnitMeasurementById(reader.GetInt32("Unit"));

                    products.Add(new Product(reader.GetInt32("id"),
                        reader.GetString("Article"),
                        reader.GetString("Name"),
                        currentUnit,
                        reader.GetInt32("Price"),
                        reader.GetInt32("MaxSale"),
                        currentManufacture,
                        currentProvider,
                        currentCategory,
                        reader.GetInt32("CurrentSale"),
                        reader.GetInt32("Count"),
                        reader.GetString("Description"),
                        reader.IsDBNull(reader.GetOrdinal("Image")) ? null : reader.GetString("Image")));
                }
            }

            conn.Close();
        }
        return products;
    }

    public List<User> GetAllUsers()
    {
        List<User> users = new List<User>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
              conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM user";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Role currentRole = GetRoleById(reader.GetInt32("Role"));
                    users.Add(new User(
                        reader.GetInt32("Id"),
                        reader.GetString("Name"),
                        reader.GetString("Login"),
                        reader.GetString("Password"),
                        currentRole));
                }
            }

            conn.Close();
        }

        return users;
    }

    public List<Order> GetAllOrders()
    {
        List<Order> orders = new List<Order>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM orders";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idUser = reader.IsDBNull(reader.GetOrdinal("Client")) ? 99999999 : reader.GetInt32("Client");
                    User currentUser = GetUserById(idUser);
                    ;
                    Point currentPoint = GetPointById(reader.GetInt32("Point"));
                    OrderStatus orderStatus = GetOrderStatusById(reader.GetInt32("StatusOrder"));
                    orders.Add(new Order(reader.GetInt32("id"),
                        reader.GetDateTime("Date"),
                        reader.GetDateTime("DeliveryDate"),
                        currentPoint,
                        currentUser,
                        reader.GetInt32("CodeReceive"),
                        orderStatus));
                }
            }

            conn.Close();
        }

        return orders;
    }

    public void DeleteProductById(int id)
    {
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "Delete FROM fullorders where Product = @id; " +
                                  "Delete FROM products where id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
    public void InsertProduct(Product product)
    {
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "insert into products (Article,Name,Unit,Price,MaxSale,Manufacturer," +
                                  "Provider,Category,CurrentSale,Count,Description,Image) " +
                                  "values (@Article,@Name,@Unit,@Price,@MaxSale,@Manufacturer," +
                                  "@Provider,@Category,@CurrentSale,@Count,@Description,@Image) ";
                cmd.Parameters.AddWithValue("@Article",product.Article);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Unit", product.Unit.Id);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@MaxSale", product.MaxSale);
                cmd.Parameters.AddWithValue("@Manufacturer", product.Manufacturer.Id);
                cmd.Parameters.AddWithValue("@Provider", product.Provider.Id);
                cmd.Parameters.AddWithValue("@Category", product.Category.Id);
                cmd.Parameters.AddWithValue("@CurrentSale",product.CurrentSale );
                cmd.Parameters.AddWithValue("@Count", product.Count);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Image", product.Image);
                var reader = cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }

    public void UpdateProduct(Product product)
    {
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "Update products " +
                                  "SET Article =@Article, " +
                                  "Name = @Name, " +
                                  "Unit = @Unit, " +
                                  "Price = @Price, " +
                                  "MaxSale = @MaxSale, " +
                                  "Manufacturer = @Manufacturer, " +
                                  "Provider =@Provider, " +
                                  "Category =@Category, " +
                                  "CurrentSale = @CurrentSale, " +
                                  "Count = @Count, " +
                                  "Description = @Description, " +
                                  "Image = @Image " +
                                  "WHERE id = @id";
                cmd.Parameters.AddWithValue("@id",product.Id);
                cmd.Parameters.AddWithValue("@Article",product.Article);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Unit", product.Unit.Id);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@MaxSale", product.MaxSale);
                cmd.Parameters.AddWithValue("@Manufacturer", product.Manufacturer.Id);
                cmd.Parameters.AddWithValue("@Provider", product.Provider.Id);
                cmd.Parameters.AddWithValue("@Category", product.Category.Id);
                cmd.Parameters.AddWithValue("@CurrentSale",product.CurrentSale );
                cmd.Parameters.AddWithValue("@Count", product.Count);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Image", product.Image);
                var reader = cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }

    public List<FullOrder> GetAllFullOrders()
    {
        List<FullOrder> fullOrders = new List<FullOrder>();
        using (var conn = new MySqlConnection(_connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM fullorders";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Order currentOrder = GetOrderById(reader.GetInt32("Order"));
                    Product currentProduct = GetProductById(reader.GetInt32("Product"));

                    fullOrders.Add(new FullOrder(
                        reader.GetInt32("Id"),
                        currentOrder,
                        currentProduct,
                        reader.GetInt32("CountProduct")));
                }
            }

            conn.Close();
        }

        return fullOrders;
    }
}