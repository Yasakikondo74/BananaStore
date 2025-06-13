using BananaStore.Models;
using BananaStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BananaStore.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BananaController : ControllerBase
    {
        private readonly IBanana _bananaRepository;
            public BananaController(IBanana bananaRepository)
            {
                _bananaRepository = bananaRepository;
            }
    
            [HttpGet]
            public async Task<IActionResult> GetBananas()
            {
                var bananas = await _bananaRepository.List();
                return Ok(bananas);
            }
    
            [HttpGet("{id}")]
            public async Task<IActionResult> GetBanana(Guid id)
            {
                var banana = await _bananaRepository.Get(id);
                if (banana == null || !banana.Any())
                {
                    return NotFound();
                }
                return Ok(banana);
            }
    
            [HttpPost]
            public async Task<IActionResult> CreateBanana([FromBody] Banana banana)
            {
                if (banana == null)
                {
                    return BadRequest("Invalid banana data.");
                }
                await _bananaRepository.Create(banana);
                return CreatedAtAction(nameof(GetBanana), new { id = banana.Id }, banana);
            }
    
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateBanana(Guid id, [FromBody] Banana banana)
            {
                if (banana == null || id != banana.Id)
                {
                    return BadRequest("Invalid banana data.");
                }
                await _bananaRepository.Update(banana, id);
                return NoContent();
            }
    
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteBanana(Guid id)
            {
                await _bananaRepository.Delete(id);
                return NoContent();
        }
    }
}
