using Dapper;
using ItemStore.Data.SqlDbAcces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using ItemStore.Interface.DTO;
using ItemStore.Interface.Interfaces;

namespace ItemStore.Data.DAL
{
    public class ItemDAL : IItemDAL
    {
        public List<ItemDTO> GetAllItems()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var query = "SElECT * FROM [dbo].[Item]";

                return connection.Query<ItemDTO>(query).ToList();
            }
        }

        public void CreateItem(string name, string brand, double price, string image, string description)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { Name = name, Brand = brand, Price = price, Image = image, Description = description };
                var query = "INSERT INTO [dbo].[Item] (Name, Brand, Price, Image, Description) VALUES (@Name, @Brand, @Price, @Image, @Description)";

                connection.Query(query, parameters);
            }
        }

        public void DeleteItem(int ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameter = new { Id = ID };
                var query = "DELETE FROM [dbo].[Item] WHERE ID = @Id";

                connection.Query(query, parameter);
            }
        }

        public void UpdateItem(int ID, string name, string brand, double price, string image, string description)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new {ID = ID,  Name = name, Brand = brand, Price = price, Image = image, Description = description };
                var query = "UPDATE [dbo].[Item] SET Name = @Name, Brand = @Brand, Price = @Price, Image = @Image, Description = @Description WHERE ID = @Id";

                connection.Query(query, parameters);
            }
        }
    }
}


