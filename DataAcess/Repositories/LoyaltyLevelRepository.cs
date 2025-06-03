using CafeClient.BusinessLogic.Models;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;

namespace CafeClient.DataAccess.Repositories
{
    public class LoyaltyLevelRepository
    {
        private readonly DbConnection _dbConnection;

        public LoyaltyLevelRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<LoyaltyLevel> GetAll()
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM LOYALTY_LEVELS");
            var levels = new List<LoyaltyLevel>();
            foreach (DataRow row in dt.Rows)
            {
                levels.Add(Map(row));
            }
            return levels;
        }

        public LoyaltyLevel GetById(int id)
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM LOYALTY_LEVELS WHERE id = @id", new SqliteParameter("@id", id));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public void Add(LoyaltyLevel level)
        {
            _dbConnection.ExecuteNonQuery(
                "INSERT INTO LOYALTY_LEVELS (name, min_points, discount_percent) VALUES (@name, @minPoints, @discountPercent)",
                new SqliteParameter("@name", level.Name),
                new SqliteParameter("@minPoints", level.MinPoints),
                new SqliteParameter("@discountPercent", level.DiscountPercent)
            );
        }

        public void Update(LoyaltyLevel level)
        {
            _dbConnection.ExecuteNonQuery(
                "UPDATE LOYALTY_LEVELS SET name=@name, min_points=@minPoints, discount_percent=@discountPercent WHERE id=@id",
                new SqliteParameter("@name", level.Name),
                new SqliteParameter("@minPoints", level.MinPoints),
                new SqliteParameter("@discountPercent", level.DiscountPercent),
                new SqliteParameter("@id", level.Id)
            );
        }

        public void Delete(int id)
        {
            _dbConnection.ExecuteNonQuery("DELETE FROM LOYALTY_LEVELS WHERE id = @id", new SqliteParameter("@id", id));
        }

        private LoyaltyLevel Map(DataRow row)
        {
            return new LoyaltyLevel
            {
                Id = (int)(long)row["id"],
                Name = row["name"].ToString(),
                MinPoints = (int)(long)row["min_points"],
                DiscountPercent = (decimal)(double)row["discount_percent"]
            };
        }
    }
}
