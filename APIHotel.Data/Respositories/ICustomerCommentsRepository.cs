using APIHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHotel.Data.Respositories
{
    public  interface ICustomerCommentsRepository
    {
        Task<IEnumerable<CustomerComments>> GetCommentsByHotel(int hotelId);
        Task<bool> InsertComment( CustomerComments comment );
        Task<bool> UpdateComment( CustomerComments comment);
        Task<bool> DeleteComment( CustomerComments comment);
    }
}
