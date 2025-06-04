using CafeClient.BusinessLogic.Models;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;

namespace CafeClient.DataAccess.Repositories
{
    public class OrderRepository
    {
        private readonly DbConnection _dbConnection;

        public OrderRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Order> GetAll()
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM ORDERS");
            var orders = new List<Order>();
            foreach (DataRow row in dt.Rows)
            {
                orders.Add(Map(row));
            }
            return orders;
        }

        public Order GetById(int id)
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM ORDERS WHERE id = @id", new SqliteParameter("@id", id));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public void Add(Order order)
        {
            _dbConnection.ExecuteNonQuery(
                "INSERT INTO ORDERS (client_id, user_id, order_date, total_amount, discount_amount, bonus_points_used, bonus_points_earned, status) " +
                "VALUES (@clientId, @userId, @orderDate, @totalAmount, @discountAmount, @bonusPointsUsed, @bonusPointsEarned, @status)",
                new SqliteParameter("@clientId", order.ClientId),
                new SqliteParameter("@userId", order.UserId),
                new SqliteParameter("@orderDate", order.OrderDate),
                new SqliteParameter("@totalAmount", order.TotalAmount),
                new SqliteParameter("@discountAmount", order.DiscountAmount),
                new SqliteParameter("@bonusPointsUsed", order.BonusPointsUsed),
                new SqliteParameter("@bonusPointsEarned", order.BonusPointsEarned),
                new SqliteParameter("@status", order.Status)
            );
        }

        public void Update(Order order)
        {
            _dbConnection.ExecuteNonQuery(
                "UPDATE ORDERS SET client_id=@clientId, user_id=@userId, order_date=@orderDate, total_amount=@totalAmount, discount_amount=@discountAmount, bonus_points_used=@bonusPointsUsed, bonus_points_earned=@bonusPointsEarned, status=@status WHERE id=@id",
                new SqliteParameter("@clientId", order.ClientId),
                new SqliteParameter("@userId", order.UserId),
                new SqliteParameter("@orderDate", order.OrderDate),
                new SqliteParameter("@totalAmount", order.TotalAmount),
                new SqliteParameter("@discountAmount", order.DiscountAmount),
                new SqliteParameter("@bonusPointsUsed", order.BonusPointsUsed),
                new SqliteParameter("@bonusPointsEarned", order.BonusPointsEarned),
                new SqliteParameter("@status", order.Status),
                new SqliteParameter("@id", order.Id)
            );
        }

        public void Delete(int id)
        {
            _dbConnection.ExecuteNonQuery("DELETE FROM ORDERS WHERE id = @id", new SqliteParameter("@id", id));
        }

        public List<Order> GetByClientId(int clientId)
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM ORDERS WHERE client_id = @clientId", new SqliteParameter("@clientId", clientId));
            var orders = new List<Order>();
            foreach (DataRow row in dt.Rows)
            {
                orders.Add(Map(row));
            }
            return orders;
        }

        public List<Order> Search(string criteria)
        {
            var dt = _dbConnection.ExecuteQuery(
                "SELECT * FROM ORDERS WHERE status LIKE @criteria OR CAST(client_id AS TEXT) LIKE @criteria OR CAST(order_date AS TEXT) LIKE @criteria",
                new SqliteParameter("@criteria", $"%{criteria}%"));
            var orders = new List<Order>();
            foreach (DataRow row in dt.Rows)
            {
                orders.Add(Map(row));
            }
            return orders;
        }

        private Order Map(DataRow row)
        {
            return new Order
            {
                Id = (int)(long)row["id"],
                ClientId = (int)(long)row["client_id"],
                UserId = (int)(long)row["user_id"],
                OrderDate = row["order_date"].ToString(),
                TotalAmount = (decimal)(double)row["total_amount"],
                DiscountAmount = (decimal)(double)row["discount_amount"],
                BonusPointsUsed = (int)(long)row["bonus_points_used"],
                BonusPointsEarned = (int)(long)row["bonus_points_earned"],
                Status = row["status"].ToString()
            };
        }
    }
}
