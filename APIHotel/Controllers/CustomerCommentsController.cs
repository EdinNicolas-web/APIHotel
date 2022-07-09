using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIHotel.Data.Respositories;
using APIHotel.Model;
using System.Threading.Tasks;

namespace APIHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCommentsController : ControllerBase
    {
        private readonly ICustomerCommentsRepository _commentsRepository;
        public CustomerCommentsController(ICustomerCommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        [HttpGet("{hotelId}")]
        public async Task<IActionResult> GetAllCommentsByHotel(int hotelId)
        {
            return Ok(await _commentsRepository.GetCommentsByHotel(hotelId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] CustomerComments comment)
        {
            if (comment == null)
                BadRequest();

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            var created = await _commentsRepository.InsertComment(comment);
            return Created("created", created);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromBody] CustomerComments comment)
        {
            if (comment == null)
                BadRequest();

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            var created = await _commentsRepository.UpdateComment(comment);
            return Created("updated", created);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _commentsRepository.DeleteComment(new CustomerComments() { Id = id });
            return NoContent();
        }
    }
}
