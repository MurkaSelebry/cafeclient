using CafeClient.BusinessLogic.Models;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;

namespace CafeClient.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly DbConnection _dbConnection;

        public UserRepository()
        {
            _dbConnection = new DbConnection();
        }

        public List<User> GetAll()
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM USERS");
            var users = new List<User>();
            foreach (DataRow row in dt.Rows)
            {
                users.Add(Map(row));
            }
            return users;
        }

        public User GetById(int id)
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM USERS WHERE id = @id", new SqliteParameter("@id", id));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public User GetByUsername(string username)
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM USERS WHERE username = @username", new SqliteParameter("@username", username));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public void Add(User user)
        {
            _dbConnection.ExecuteNonQuery(
                "INSERT INTO USERS (username, password_hash, full_name, role, date_created) VALUES (@username, @passwordHash, @fullName, @role, @dateCreated)",
                new SqliteParameter("@username", user.Username),
                new SqliteParameter("@passwordHash", user.PasswordHash),
                new SqliteParameter("@fullName", user.FullName),
                new SqliteParameter("@role", user.Role),
                new SqliteParameter("@dateCreated", user.DateCreated)
            );
        }

        public void Update(User user)
        {
            _dbConnection.ExecuteNonQuery(
                "UPDATE USERS SET username=@username, password_hash=@passwordHash, full_name=@fullName, role=@role, date_created=@dateCreated WHERE id=@id",
                new SqliteParameter("@username", user.Username),
                new SqliteParameter("@passwordHash", user.PasswordHash),
                new SqliteParameter("@fullName", user.FullName),
                new SqliteParameter("@role", user.Role),
                new SqliteParameter("@dateCreated", user.DateCreated),
                new SqliteParameter("@id", user.Id)
            );
        }

        public void Delete(int id)
        {
            _dbConnection.ExecuteNonQuery("DELETE FROM USERS WHERE id = @id", new SqliteParameter("@id", id));
        }

        private User Map(DataRow row)
        {
            return new User
            {
                Id = (int)(long)row["id"],
                Username = row["username"].ToString(),
                PasswordHash = row["password_hash"].ToString(),
                FullName = row["full_name"].ToString(),
                Role = row["role"].ToString(),
                DateCreated = row["date_created"].ToString()
            };
        }
    }
}
