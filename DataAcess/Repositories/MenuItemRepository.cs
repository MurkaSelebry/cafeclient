using CafeClient.BusinessLogic.Models;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;

namespace CafeClient.DataAccess.Repositories
{
    public class MenuItemRepository
    {
        private readonly DbConnection _dbConnection;

        public MenuItemRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<MenuItem> GetAll()
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM MENU_ITEMS");
            var items = new List<MenuItem>();
            foreach (DataRow row in dt.Rows)
            {
                items.Add(Map(row));
            }
            return items;
        }

        public MenuItem GetById(int id)
        {
            var dt = _dbConnection.ExecuteQuery("SELECT * FROM MENU_ITEMS WHERE id = @id", new SqliteParameter("@id", id));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public void Add(MenuItem item)
        {
            _dbConnection.ExecuteNonQuery(
                "INSERT INTO MENU_ITEMS (name, description, price, category, is_active) VALUES (@name, @description, @price, @category, @isActive)",
                new SqliteParameter("@name", item.Name),
                new SqliteParameter("@description", item.Description ?? ""),
                new SqliteParameter("@price", item.Price),
                new SqliteParameter("@category", item.Category ?? ""),
                new SqliteParameter("@isActive", item.IsActive ? 1 : 0)
            );
        }

        public void Update(MenuItem item)
        {
            _dbConnection.ExecuteNonQuery(
                "UPDATE MENU_ITEMS SET name=@name, description=@description, price=@price, category=@category, is_active=@isActive WHERE id=@id",
                new SqliteParameter("@name", item.Name),
                new SqliteParameter("@description", item.Description ?? ""),
                new SqliteParameter("@price", item.Price),
                new SqliteParameter("@category", item.Category ?? ""),
                new SqliteParameter("@isActive", item.IsActive ? 1 : 0),
                new SqliteParameter("@id", item.Id)
            );
        }

        public void Delete(int id)
        {
            _dbConnection.ExecuteNonQuery("DELETE FROM MENU_ITEMS WHERE id = @id", new SqliteParameter("@id", id));
        }

        private MenuItem Map(DataRow row)
        {
            return new MenuItem
            {
                Id = (int)(long)row["id"],
                Name = row["name"].ToString(),
                Description = row["description"].ToString(),
                Price = (decimal)(double)row["price"],
                Category = row["category"].ToString(),
                IsActive = ((long)row["is_active"]) == 1
            };
        }
    }
}
