using Dapper;
using ItemStore.Data.SqlDbAcces;
using ItemStore.Interface;
using ItemStore.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ItemStore.Data
{
    public class UserDAL : IUserDAL
    {
        private string connectionString; 
        public UserDAL(ConnectionString connection)
        {
            connectionString = connection.connectionString; 
        }
        public UserDTO GetUserByEmail(string emailAdress)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var parameters = new { EmailAdress = emailAdress };
                var query = "SELECT * FROM [dbo].[Customer] WHERE Email = @EmailAdress";
                var userDTO = connection.Query<UserDTO>(query, parameters).FirstOrDefault();
                return userDTO;
            }
        }

        public UserDTO GetUserById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var parameters = new { Id = id };
                var query = "SELECT COUNT(1) WHERE ID = @Id";

                return connection.Query<UserDTO>(query, parameters).FirstOrDefault(); 
            }
        }

        public UserDTO GetUserByUserName(string userName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var parameters = new { UserName = userName };
                var query = "SELECT COUNT(1) WHERE UserName = @UserName";

                return connection.Query<UserDTO>(query, parameters).FirstOrDefault(); 
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var query = "SElECT UserName FROM [dbo].[Customer]";

                return connection.Query<UserDTO>(query).ToList();
            }
        }

        public void CreateUser(string email, string userName, string firstName, string lastName, string password, int role)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var parameters = new { UserName = userName, Email = email, Password = password, LastName = lastName, FirstName = firstName, Role = role };
                var query = "INSERT INTO [dbo].[Customer] (UserName, Email, Password, LastName, FirstName, Role) VALUES (@UserName, @Email, @Password, @LastName, @FirstName, @Role)";

                connection.Query(query, parameters);
            }   
        }

        public void UpdateProfile(int id, string email, string userName, string firstName, string lastName, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var parameters = new { UserName = userName, EmailAdress = email, Id = id, LastName = lastName, FirstName = firstName };
                var query = "UPDATE [dbo].[Customer] SET UserEmail = @EmailAdress, UserName = @UserName, LastName = @LastName, FirstName = @FirstName WHERE ID = @Id";

                connection.Query(query, parameters);
            }           
        }
    }
}
