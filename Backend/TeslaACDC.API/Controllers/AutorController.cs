using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data;

namespace TeslaACDC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AutorController : ControllerBase
    {

        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }


        [HttpGet]
        [Route("GetAllAutores")]
        public async Task<IActionResult> GetAllAutores()
        {
            var autores = await _autorService.GetAllAutores();
            return Ok(autores);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> FindAutorById(int id)
        {
            var autor = await _autorService.FindAutorById(id);
            return Ok(autor);
        }

        [HttpGet]
        [Route("GetByName")]
        public async Task<IActionResult> FindAutorByName(string nombre)
        {
            var autor = await _autorService.FindAutorByName(nombre);
            return Ok(autor);
        }

        // [HttpGet]
        // [Route("GetByRange")]
        // public async Task<IActionResult> FindAlbumByRange(int year1, int year2)
        // {
        //     var album = await _autorService.FindAutorByRange(year1, year2);
        //     return Ok(album);
        // }


        [HttpPost]
        [Route("CreateAutor")]
        public async Task<IActionResult> AddAutor(Autor autor)
        {
            var newAutor = await _autorService.AddAutor(autor);
            return Ok(newAutor);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateAutor(int id, Autor autor)
        {
            var updatedAutor = await _autorService.UpdateAutor(id, autor);
            return Ok(updatedAutor);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var deleteAutor = await _autorService.DeleteAutor(id);
            return Ok(deleteAutor);
        }
    }
}
