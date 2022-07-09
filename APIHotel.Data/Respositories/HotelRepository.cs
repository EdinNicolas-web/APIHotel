using APIHotel.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHotel.Data.Respositories
{
    public class HotelRepository : IHotelRepository
    {
        private MySQLConfig _connectinString; 
        public HotelRepository(MySQLConfig connectionString)
        {
            _connectinString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectinString.ConnectionString );
        }
        public async Task<bool> DeleteHotel(Hotel hotel)
        {
            var db = dbConnection();
            var sql = @"DELETE 
                        FROM hotel
                      WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new {hotel.Id });
            return result > 0;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            var db = dbConnection();
            var sql = @"SELECT id, name, category, price 
                        FROM hotel";

            return await db.QueryAsync<Hotel>(sql, new {});
        }

        public async Task<bool> InsertHotel(Hotel hotel)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO hotel (name, category, price) 
                        VALUES (@Name, @Category, @Price)";

            var result =  await db.ExecuteAsync(sql, new { hotel.Name, hotel.Category, hotel.Price });

            return result > 0;
        }

        public async Task<bool> UpdateHotel(Hotel hotel)
        {
            var db = dbConnection();
            var sql = @"UPDATE hotel 
                            SET name = @Name, category = @Category, price = @Price
                        WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { hotel.Name, hotel.Category, hotel.Price, hotel.Id });

            return result > 0;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsByCategory(int categoty)
        {
            var db = dbConnection();
            var sql = @"SELECT id, name, category, price 
                        FROM hotel 
                        WHERE category = @Category";

            return await db.QueryAsync<Hotel>(sql, new { Category = categoty });
        }

        public async Task<IEnumerable<Hotel>> GetHotelsOrderByPriceDesc()
        {
            var db = dbConnection();
            var sql = @"SELECT id, name, category, price 
                        FROM hotel 
                        ORDER BY price DESC";

            return await db.QueryAsync<Hotel>(sql, new {  });
        }

        public async Task<IEnumerable<Hotel>> GetHotelsOrderByPriceAsc()
        {
            var db = dbConnection();
            var sql = @"SELECT id, name, category, price 
                        FROM hotel 
                        ORDER BY price ASC";

            return await db.QueryAsync<Hotel>(sql, new { });
        }
    }
}
