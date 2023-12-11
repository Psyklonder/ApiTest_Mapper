using ApiTest.Context;
using ApiTest.DTO;
using ApiTest.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly TestContext _db;
        private readonly IMapper _mapper;
        public PersonaController(TestContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // GET: api/<TipoIdentificacionController>
        [HttpGet]
        public async Task<IActionResult> Consultar()
        {
            var response = _mapper.Map<List<PersonaDTO>>(await _db.Persona.Include(x => x.TipoIdentificacion).ToListAsync());
            if (response == null)
            {
                return NotFound("No se encontraron resultados");
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Consultar(long id)
        {
            var response = _mapper.Map<PersonaDTO>(await _db.Persona.Include(x => x.TipoIdentificacion).Where(x => x.Id == id).FirstOrDefaultAsync());
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
