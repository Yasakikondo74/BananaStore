using BananaStore.Models;
using BananaStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BananaStore.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxController : ControllerBase
    {
        private readonly IBox _boxRepository;
            public BoxController(IBox boxRepository)
            {
                _boxRepository = boxRepository;
            }
    
            [HttpGet]
            public async Task<IActionResult> GetBoxes()
            {
                var boxes = await _boxRepository.List();
                return Ok(boxes);
            }
    
            [HttpGet("{id}")]
            public async Task<IActionResult> GetBox(Guid id)
            {
                var box = await _boxRepository.Get(id);
                if (box == null || !box.Any())
                {
                    return NotFound();
                }
                return Ok(box);
            }
    
            [HttpPost]
            public async Task<IActionResult> CreateBox([FromBody] Box box)
            {
                if (box == null)
                {
                    return BadRequest("Invalid box data.");
                }
                await _boxRepository.Create(box);
                return CreatedAtAction(nameof(GetBox), new { id = box.Id }, box);
            }
    
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateBox(Guid id, [FromBody] Box box)
            {
                if (box == null || id != box.Id)
                {
                    return BadRequest("Invalid box data.");
                }
                await _boxRepository.Update(box, id);
                return NoContent();
            }
    
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteBox(Guid id)
            {
                await _boxRepository.Delete(id);
                return NoContent();
        }
    }
}
