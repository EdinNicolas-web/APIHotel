using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHotel.Model
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public Double Price { get; set; }
    }
}
