using CafeClient.BusinessLogic.Models;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;

namespace CafeClient.DataAccess.Repositories
{
    public class OrderItemRepository
    {
        private readonly DbConnection _dbConnection;

        public OrderItemRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<OrderItem> GetAll()
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM ORDER_ITEMS");
            var items = new List<OrderItem>();
            foreach (DataRow row in dt.Rows)
            {
                items.Add(Map(row));
            }
            return items;
        }

        public OrderItem GetById(int id)
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM ORDER_ITEMS WHERE id = @id", new SqliteParameter("@id", id));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public void Add(OrderItem item)
        {
            _dbConnection.ExecuteNonQuery(
                "INSERT INTO ORDER_ITEMS (order_id, menu_item_id, quantity, price, notes) VALUES (@orderId, @menuItemId, @quantity, @price, @notes)",
                new SqliteParameter("@orderId", item.OrderId),
                new SqliteParameter("@menuItemId", item.MenuItemId),
                new SqliteParameter("@quantity", item.Quantity),
                new SqliteParameter("@price", item.Price),
                new SqliteParameter("@notes", item.Notes ?? "")
            );
        }

        public void Update(OrderItem item)
        {
            _dbConnection.ExecuteNonQuery(
                "UPDATE ORDER_ITEMS SET order_id=@orderId, menu_item_id=@menuItemId, quantity=@quantity, price=@price, notes=@notes WHERE id=@id",
                new SqliteParameter("@orderId", item.OrderId),
                new SqliteParameter("@menuItemId", item.MenuItemId),
                new SqliteParameter("@quantity", item.Quantity),
                new SqliteParameter("@price", item.Price),
                new SqliteParameter("@notes", item.Notes ?? ""),
                new SqliteParameter("@id", item.Id)
            );
        }

        public void Delete(int id)
        {
            _dbConnection.ExecuteNonQuery("DELETE FROM ORDER_ITEMS WHERE id = @id", new SqliteParameter("@id", id));
        }

        public List<OrderItem> GetByOrderId(int orderId)
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM ORDER_ITEMS WHERE order_id = @orderId", new SqliteParameter("@orderId", orderId));
            var items = new List<OrderItem>();
            foreach (DataRow row in dt.Rows)
            {
                items.Add(Map(row));
            }
            return items;
        }

        private OrderItem Map(DataRow row)
        {
            return new OrderItem
            {
                Id = (int)(long)row["id"],
                OrderId = (int)(long)row["order_id"],
                MenuItemId = (int)(long)row["menu_item_id"],
                Quantity = (int)(long)row["quantity"],
                Price = (decimal)(double)row["price"],
                Notes = row["notes"].ToString()
            };
        }
    }
}
