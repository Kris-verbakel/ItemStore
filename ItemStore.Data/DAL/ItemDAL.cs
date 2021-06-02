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
    public class ItemDAL : IItemContainerDAL, IItemModelDAL
    {
        private string connectionString; 

        public ItemDAL(ConnectionString connection)
        {
            connectionString = connection.connectionString; 
        }

        public List<ItemDTO> GetAllItems()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var query = "SElECT * FROM [dbo].[Item]";

                return connection.Query<ItemDTO>(query).ToList();
            }
        }

        public void CreateItem(ItemDTO itemDTO, int userID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var parameters = new { Name = itemDTO.Name, Brand = itemDTO.Brand, Price = itemDTO.Price, Image = itemDTO.Image, Description = itemDTO. Description, UserID = userID  };
                var query = "INSERT INTO [dbo].[Item] (Name, Brand, Price, Image, Description, UserID) VALUES (@Name, @Brand, @Price, @Image, @Description, @UserID)";

                connection.Query(query, parameters);
            }
        }

        public void DeleteItem(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var parameter = new { Id = ID };
                var query = "DELETE FROM [dbo].[Item] WHERE ID = @Id";

                connection.Query(query, parameter);
            }
        }

        public void UpdateItem(int ID, ItemDTO itemDTO)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var parameters = new {ID = ID, Name = itemDTO.Name, Brand = itemDTO.Brand, Price = itemDTO.Price, Image = itemDTO.Image, Description = itemDTO.Description };
                var query = "UPDATE [dbo].[Item] SET Name = @Name, Brand = @Brand, Price = @Price, Image = @Image, Description = @Description WHERE ID = @Id";

                connection.Query(query, parameters);
            }
        }

        public ItemDTO GetItemById(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var parameters = new { ID = ID };
                var query = "SELECT * FROM [dbo].[Item] WHERE ID = @ID";

                var itemDTO = connection.Query<ItemDTO>(query, parameters).FirstOrDefault();

                return itemDTO; 
            }
        }
    }
}


