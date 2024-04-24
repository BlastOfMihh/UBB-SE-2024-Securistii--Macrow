﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingPlatform.User
{
    public class UserRepository : IUserRepository
    {
        private string ConnectionString { get; set; }
        private List<IUserTemplate> listOfUsers { get; set; }
        public UserRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.listOfUsers = new List<IUserTemplate>();
            this.LoadUsersFromDataBase();
        }

        public UserRepository(List<IUserTemplate> _listOfUsers, string connectionString)
        {
            this.ConnectionString = connectionString;
            this.listOfUsers = _listOfUsers;
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
                        user = new BasicUser(userId, username, nickname);
                    }
                    else
                    {
                        user = new AdminUser(userId, username);
                    }

                    this.addUserToRepo(user);
                }
            }
        }

        public void addUserToRepo(IUserTemplate User) 
        {
            // it should be safe to delete this line
            // this.ConnectionString = "Data Source=DESKTOP-UELLOC9;Initial Catalog=BidingSystem;Integrated Security=true";
            this.listOfUsers.Add(User);
        }

        public void removeUserFromRepo(IUserTemplate User)
        {
            this.listOfUsers.Remove(User);
        }

        public void updateUserIntoRepo(IUserTemplate olduser, IUserTemplate newuser)
        {
            int olduserIndex = this.listOfUsers.FindIndex(user => user == olduser);
            if (olduserIndex != -1)
            {
                this.listOfUsers[olduserIndex] = newuser;
            }
        }
        public List<IUserTemplate> GetListOfUsers()
        {
            return this.listOfUsers;
        }
    }
}
