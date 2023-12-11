using ApiTest.Context;
using ApiTest.DTO;
using ApiTest.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TipoIdentificacionController : ControllerBase
    {
        private readonly TestContext _db;
        private readonly IMapper _mapper;
        public TipoIdentificacionController(TestContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        // GET: api/<TipoIdentificacionController>
        [HttpGet]
        public async Task<IActionResult> ObtenerTipos()
        {
            var response = _mapper.Map<List<TipoIdentificacionDTO>>(await _db.TipoIdentificacion.ToListAsync());
            if (response == null)
            {
                return NotFound("No se encontraron resultados");
            }
            else
            {
                return Ok(response);
            }
        }


        // GET api/<TipoIdentificacionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _mapper.Map<TipoIdentificacionDTO>(await _db.TipoIdentificacion.FindAsync(id));
            if (response == null)
            {
                return NotFound("No se encontraron resultados");
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
