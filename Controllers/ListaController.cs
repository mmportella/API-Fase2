using API_Fase2.Data.DTO.ListaDTO;
using API_Fase2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_Fase2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaController : ControllerBase
    {

        private Data.APIContext _context;
        private IMapper _mapper;

        public ListaController(Data.APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddLista([FromBody] CreateListaDTO listaDTO)
        {
            Lista lista = _mapper.Map<Lista>(listaDTO);
            _context.Add(lista);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetListaById), new { id = lista.IdLista }, lista);
        }

        [HttpGet]
        public IActionResult GetLista()
        {
            List<Lista> listas = _context.Listas.ToList();
            if (listas != null)
            {
                List<ReadListaDTO> readDTO = _mapper.Map<List<ReadListaDTO>>(listas);
                DateTime agora = DateTime.Now;
                foreach (ReadListaDTO dto in readDTO)
                {
                    dto.HoraConsulta = agora;
                }
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetListaById(int id)
        {
            Lista lista = _context.Listas.FirstOrDefault(lista => lista.IdLista == id);
            if (lista != null)
            {
                ReadListaDTO listaDTO = _mapper.Map<ReadListaDTO>(lista);
                listaDTO.HoraConsulta = DateTime.Now;
                return Ok(listaDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLista(int id, [FromBody] UpdateListaDTO listaDTO)
        {
            Lista lista = _context.Listas.FirstOrDefault(lista => lista.IdLista == id);
            if (lista != null)
            {
                _mapper.Map(listaDTO, lista);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLista(int id)
        {
            Lista lista = _context.Listas.FirstOrDefault(lista => lista.IdLista == id);
            if (lista != null)
            {
                _context.Remove(lista);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

    }
}
