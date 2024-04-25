﻿using System.Data.SqlClient;

namespace BiddingPlatform.User
{
    public class UserRepository : IUserRepository
    {
        private string ConnectionString { get; set; }
        public List<IUserTemplate> ListOfUsers { get; set; }
        public UserRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.ListOfUsers = new List<IUserTemplate>();
            this.LoadUsersFromDataBase();
        }

        public UserRepository(List<IUserTemplate> listOfUsers, string connectionString)
        {
            this.ConnectionString = connectionString;
            this.ListOfUsers = listOfUsers;
        }
        private void LoadUsersFromDataBase()
        {
            string query = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["UserID"]);
                    string username = reader["Username"].ToString();
                    string nickname = reader["Nickname"].ToString();
                    string userType = reader["UserType"].ToString();

                    IUserTemplate user;
                    if (userType == "Basic")
                    {
                        user = new BasicUser(userId, username, nickname) as IUserTemplate;
                    }
                    else
                    {
                        user = new AdminUser(userId, username) as IUserTemplate;
                    }

                    this.AddUserToRepo(user);
                }
            }
        }

        public void AddUserToRepo(IUserTemplate user)
        {
            this.ListOfUsers.Add(user);
        }

        public void RemoveUserFromRepo(IUserTemplate user)
        {
            this.ListOfUsers.Remove(user);
        }

        public void UpdateUserIntoRepo(IUserTemplate olduser, IUserTemplate newuser)
        {
            int olduserIndex = this.ListOfUsers.FindIndex(user => user == olduser);
            if (olduserIndex != -1)
            {
                this.ListOfUsers[olduserIndex] = newuser;
            }
        }
        public List<IUserTemplate> GetListOfUsers()
        {
            return this.ListOfUsers;
        }
    }
}
