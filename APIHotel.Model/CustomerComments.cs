using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHotel.Model
{
    public class CustomerComments
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int HotelId { get; set; }
        public string Author { get; set; }
    }
}
