using Dapper;
using ItemStore.Data.SqlDbAcces;
using ItemStore.Interface;
using ItemStore.Interface.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ItemStore.Data
{
    public class UserDAL : IUserContainerDAL, IUserModelDAL
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
                var query = "SELECT * FROM [dbo].[Customer] WHERE UserName = @UserName";
                var userDTO = connection.Query<UserDTO>(query, parameters).FirstOrDefault();
                return userDTO;
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

        public void CreateUser(UserDTO newAcc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var parameters = new { UserName = newAcc.UserName, Email = newAcc.Email, Password = newAcc.Password, LastName = newAcc.LastName, FirstName = newAcc.FirstName, Adress = newAcc.Adress, City = newAcc.City, Country = newAcc.Country, PostalCode = newAcc.PostalCode };
                var query = "INSERT INTO [dbo].[Customer] (UserName, Email, Password, LastName, FirstName, Adress, City, Country, PostalCode) VALUES (@UserName, @Email, @Password, @LastName, @FirstName, @Adress, @City, @Country, @PostalCode)";

                connection.Query(query, parameters);
            }   
        }

        public void UpdateProfile(int id, UserDTO userAcc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var parameters = new { UserName = userAcc.UserName, EmailAdress = userAcc.Email, Id = id, LastName = userAcc.LastName, FirstName = userAcc.FirstName, Adress = userAcc.Adress, City = userAcc.City, Country = userAcc.Country, PostalCode = userAcc.PostalCode };
                var query = "UPDATE [dbo].[Customer] SET Email = @EmailAdress, UserName = @UserName, LastName = @LastName, FirstName = @FirstName, Adress = @Adress, City = @City, Country = @Country, PostalCode = @PostalCode WHERE ID = @Id";

                connection.Query(query, parameters);
            }           
        }
    }
}
