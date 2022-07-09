using APIHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHotel.Data.Respositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllHotels();
        Task<IEnumerable<Hotel>> GetHotelsByCategory(int category);
        Task<IEnumerable<Hotel>> GetHotelsOrderByPriceDesc();
        Task<IEnumerable<Hotel>> GetHotelsOrderByPriceAsc();
        Task<bool> InsertHotel(Hotel hotel);
        Task<bool> UpdateHotel(Hotel hotel);
        Task<bool> DeleteHotel(Hotel hotel);

    }
}
