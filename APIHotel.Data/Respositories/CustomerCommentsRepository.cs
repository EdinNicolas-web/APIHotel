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
    public class CustomerCommentsRepository : ICustomerCommentsRepository
    {
        private MySQLConfig _connectinString;
        public CustomerCommentsRepository(MySQLConfig connectionString)
        {
            _connectinString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectinString.ConnectionString);
        }

        public async Task<bool> DeleteComment(CustomerComments comment)
        {
            var db = dbConnection();
            var sql = @"DELETE 
                        FROM customer_comments
                      WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { comment.Id });
            return result > 0;
        }

        public async Task<IEnumerable<CustomerComments>> GetCommentsByHotel(int hotelId)
        {

            var db = dbConnection();
            var sql = @"SELECT *
                        FROM customer_comments 
                        WHERE hotel_id = @HotelId";

            return await db.QueryAsync<CustomerComments>(sql, new { HotelId = hotelId });
        }

        public async Task<bool> InsertComment(CustomerComments comment)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO customer_comments (rating, comment, hotel_id, author) 
                        VALUES (@Rating, @Comment, @HotelId, @Author)";
            var result = await db.ExecuteAsync(sql, new { comment.Rating, comment.Comment, comment.HotelId, comment.Author });

            return result > 0;
        }

        public async Task<bool> UpdateComment(CustomerComments comment)
        {
            var db = dbConnection();
            var sql = @"UPDATE customer_comments 
                            SET rating = @Rating, comment = @Comment, author = @Author
                        WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { comment.Rating, comment.Comment,  comment.Author, comment.Id });

            return result > 0;
        }
    }
}
