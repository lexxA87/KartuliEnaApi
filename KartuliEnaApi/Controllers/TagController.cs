using KartuliEnaApi.Models;
using KartuliEnaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace KartuliEnaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly TagServices _tagServices;

        public TagController(TagServices tagServices)
        {
            _tagServices = tagServices;
        }

        [HttpGet]
        public async Task<List<Tag>> Get() =>
           await _tagServices.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Tag>> Get(string id)
        {
            var tag = await _tagServices.GetAsync(id);

            if (tag is null)
            {
                return NotFound();
            }

            return tag;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Tag newTag)
        {
            await _tagServices.CreateAsync(newTag);

            return CreatedAtAction(nameof(Get), new { id = newTag.Id }, newTag);
            //return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Tag updatedTag)
        {
            var tag = await _tagServices.GetAsync(id);

            if (tag is null)
            {
                return NotFound();
            }

            updatedTag.Id = tag.Id;

            await _tagServices.UpdateAsync(id, updatedTag);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var tag = _tagServices.GetAsync(id);

            if (tag is null)
            {
                return NotFound();
            }

            await _tagServices.RemoveAsync(id);

            return NoContent();
        }
    }
}
