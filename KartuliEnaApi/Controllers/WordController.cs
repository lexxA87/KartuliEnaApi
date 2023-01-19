using KartuliEnaApi.Models;
using KartuliEnaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace KartuliEnaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordController : ControllerBase
    {
        private readonly WordServices _wordServices;

        public WordController(WordServices wordServices)
        {
            _wordServices = wordServices;
        }

        [HttpGet]
        public async Task<List<Word>> Get() =>
            await _wordServices.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Word>> Get(string id)
        {
            var word = await _wordServices.GetAsync(id);

            if (word is null)
            {
                return NotFound();
            }

            return word;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Word newWord)
        {
            await _wordServices.CreateAsync(newWord);

            return CreatedAtAction(nameof(Get), new { id = newWord.Id }, newWord);
            //return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Word updatedWord)
        {
            var word = await _wordServices.GetAsync(id);

            if (word is null)
            {
                return NotFound();
            }

            updatedWord.Id = word.Id;

            await _wordServices.UpdateAsync(id, updatedWord);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var word = _wordServices.GetAsync(id);

            if (word is null)
            {
                return NotFound();
            }

            await _wordServices.RemoveAsync(id);

            return NoContent();
        }
    }
}
