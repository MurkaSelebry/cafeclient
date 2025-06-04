using CafeClient.BusinessLogic.Models;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;

namespace CafeClient.DataAccess.Repositories
{
    public class ClientRepository
    {
        private readonly DbConnection _dbConnection;

        public ClientRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Client> GetAll()
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM CLIENTS");
            var clients = new List<Client>();
            foreach (DataRow row in dt.Rows)
            {
                clients.Add(new Client
                {
                    Id = (int)(long)row["id"],
                    FirstName = row["first_name"].ToString(),
                    LastName = row["last_name"].ToString(),
                    Phone = row["phone"]?.ToString(),
                    Email = row["email"]?.ToString(),
                    BirthDate = row["birth_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["birth_date"]),
                    LoyaltyLevelId = row["loyalty_level_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["loyalty_level_id"]),
                    BonusPoints = row["bonus_points"] == DBNull.Value ? 0 : Convert.ToInt32(row["bonus_points"]),
                    RegistrationDate = row["registration_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["registration_date"])
                });
            }
            return clients;
        }

        public Client GetById(int id)
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM CLIENTS WHERE id = @id",
                new SqliteParameter("@id", id));
            if (dt.Rows.Count == 0) return null;
            var row = dt.Rows[0];
            return new Client
            {
                Id = (int)(long)row["id"],
                FirstName = row["first_name"].ToString(),
                LastName = row["last_name"].ToString(),
                Phone = row["phone"]?.ToString(),
                Email = row["email"]?.ToString(),
                BirthDate = row["birth_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["birth_date"]),
                LoyaltyLevelId = row["loyalty_level_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["loyalty_level_id"]),
                BonusPoints = row["bonus_points"] == DBNull.Value ? 0 : Convert.ToInt32(row["bonus_points"]),
                RegistrationDate = row["registration_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["registration_date"])
            };
        }

        public void Add(Client client)
        {
            _dbConnection.ExecuteNonQuery(
                "INSERT INTO CLIENTS (first_name, last_name) VALUES (@firstName, @lastName)",
                new SqliteParameter("@firstName", client.FirstName),
                new SqliteParameter("@lastName", client.LastName)
            );
        }

        public void Update(Client client)
        {
            _dbConnection.ExecuteNonQuery(
                "UPDATE CLIENTS SET first_name = @firstName, last_name = @lastName WHERE id = @id",
                new SqliteParameter("@firstName", client.FirstName),
                new SqliteParameter("@lastName", client.LastName),
                new SqliteParameter("@id", client.Id)
            );
        }

        public void Delete(int id)
        {
            _dbConnection.ExecuteNonQuery(
                "DELETE FROM CLIENTS WHERE id = @id",
                new SqliteParameter("@id", id)
            );
        }

        // Additional methods
        public Client GetByPhone(string phone)
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM CLIENTS WHERE phone = @phone",
                new SqliteParameter("@phone", phone));
            if (dt.Rows.Count == 0) return null;
            var row = dt.Rows[0];
            return new Client
            {
                Id = (int)(long)row["id"],
                FirstName = row["first_name"].ToString(),
                LastName = row["last_name"].ToString(),
                Phone = row["phone"]?.ToString(),
                Email = row["email"]?.ToString(),
                BirthDate = row["birth_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["birth_date"]),
                LoyaltyLevelId = row["loyalty_level_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["loyalty_level_id"]),
                BonusPoints = row["bonus_points"] == DBNull.Value ? 0 : Convert.ToInt32(row["bonus_points"]),
                RegistrationDate = row["registration_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["registration_date"])
            };
        }

        public List<Client> Search(string criteria)
        {
            var dt = _dbConnection.ExecuteQuery(
                "SELECT * FROM CLIENTS WHERE first_name LIKE @criteria OR last_name LIKE @criteria",
                new SqliteParameter("@criteria", $"%{criteria}%"));
            var clients = new List<Client>();
            foreach (DataRow row in dt.Rows)
            {
                clients.Add(new Client
                {
                    Id = (int)(long)row["id"],
                    FirstName = row["first_name"].ToString(),
                    LastName = row["last_name"].ToString(),
                    Phone = row["phone"]?.ToString(),
                    Email = row["email"]?.ToString(),
                    BirthDate = row["birth_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["birth_date"]),
                    LoyaltyLevelId = row["loyalty_level_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["loyalty_level_id"]),
                    BonusPoints = row["bonus_points"] == DBNull.Value ? 0 : Convert.ToInt32(row["bonus_points"]),
                    RegistrationDate = row["registration_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["registration_date"])
                });
            }
            return clients;
        }

        // Example: GetStatistics() can return a custom DTO or dictionary
    }
}
