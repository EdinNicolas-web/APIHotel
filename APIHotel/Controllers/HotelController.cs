using APIHotel.Data.Respositories;
using APIHotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APIHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            return Ok(await _hotelRepository.GetAllHotels());
        }

        [HttpGet("~/api/Hotel/order-desc")]
        public async Task<IActionResult> GetHotelsOrderByPriceDesc()
        {
            return Ok(await _hotelRepository.GetHotelsOrderByPriceDesc());
        }

        [HttpGet("~/api/Hotel/order-asc")]
        public async Task<IActionResult> GetHotelsOrderByPriceAsc()
        {
            return Ok(await _hotelRepository.GetHotelsOrderByPriceAsc());
        }

        [HttpGet("{category}")]
        public async Task<IActionResult> GetHotelsByCategory(int category)
        {
            return Ok(await _hotelRepository.GetHotelsByCategory(category));
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            if (hotel == null)
                BadRequest();

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            var created = await _hotelRepository.InsertHotel(hotel);
            return Created("created", created);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotel hotel)
        {
            if (hotel == null)
                BadRequest();

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            var created = await _hotelRepository.UpdateHotel(hotel);
            return Created("updated", created); ;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotelRepository.DeleteHotel(new Hotel() { Id = id });
            return Ok();
        }


    }
}
