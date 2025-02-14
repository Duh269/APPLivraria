using Application.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APPLivraria.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<IEnumerable<Livro>> Get() => await _livroService.GetAllLivrosAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> Get(int id)
        {
            var livro = await _livroService.GetLivroByIdAsync(id);
            return livro != null ? Ok(livro) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Livro livro)
        {
            await _livroService.AddLivroAsync(livro);
            return CreatedAtAction(nameof(Get), new { id = livro.Id }, livro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Livro livro)
        {
            if (id != livro.Id) return BadRequest();
            await _livroService.UpdateLivroAsync(livro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _livroService.DeleteLivroAsync(id);
            return NoContent();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
