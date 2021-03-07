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
        public UserDTO GetUserByEmail(string emailAdress)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { EmailAdress = emailAdress };
                var query = "SELECT * FROM [dbo].[Customer] WHERE Email = @EmailAdress";
                var userDTO = connection.Query<UserDTO>(query, parameters).FirstOrDefault();
                return userDTO;
            }
        }

        public bool ComparePasswords(string emailAdress, string password)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { EmailAdress = emailAdress, Password = password };
                var query = "SELECT COUNT(1) FROM [dbo].[Customer] WHERE Email = @EmailAdress AND Password = @Password";

                bool isTheSame = connection.ExecuteScalar<bool>(query, parameters);

                return isTheSame; 
            }
        }

        public UserDTO GetUserById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { Id = id };
                var query = "SELECT COUNT(1) WHERE ID = @Id";

                return connection.Query<UserDTO>(query, parameters).FirstOrDefault(); 
            }
        }

        public UserDTO GetUserByUserName(string userName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { UserName = userName };
                var query = "SELECT COUNT(1) WHERE UserName = @UserName";

                return connection.Query<UserDTO>(query, parameters).FirstOrDefault(); 
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var query = "SElECT UserName FROM [dbo].[Customer]";

                return connection.Query<UserDTO>(query).ToList();
            }
        }

        void CreateUser(string email, string userName, string firstName, string lastName, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                var parameters = new { UserName = userName, Email = email, Password = password, LastName = lastName, FirstName = firstName };
                var query = "INSERT INTO [dbo].[Customer] (UserName, Email, Password, LastName, FirstName) VALUES (@UserName, @Email, @Password, @LastName, @FirstName)";

                connection.Query(query, parameters);
            }
        }
    }
}
