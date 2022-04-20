using API_Fase2.Data.DTO.EstabelecimentoDTO;
using API_Fase2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_Fase2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstabelecimentoController : ControllerBase
    {

        private Data.APIContext _context;
        private IMapper _mapper;

        public EstabelecimentoController(Data.APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddEstabelecimento([FromBody] CreateEstabelecimentoDTO estabelecimentoDTO)
        {
            Estabelecimento estabelecimento = _mapper.Map<Estabelecimento>(estabelecimentoDTO);
            _context.Add(estabelecimento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEstabelecimentoById), new { id = estabelecimento.IdEstabelecimento }, estabelecimento);
        }

        [HttpGet]
        public IActionResult GetEstabelecimento()
        {
            List<Estabelecimento> estabelecimentos = _context.Estabelecimentos.ToList();
            if (estabelecimentos != null)
            {
                List<ReadEstabelecimentoDTO> readDTO = _mapper.Map<List<ReadEstabelecimentoDTO>>(estabelecimentos);
                DateTime agora = DateTime.Now;
                foreach (ReadEstabelecimentoDTO dto in readDTO)
                {
                    dto.HoraConsulta = agora;
                }
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetEstabelecimentoById(int id)
        {
            Estabelecimento estabelecimento = _context.Estabelecimentos.FirstOrDefault(estabelecimento => estabelecimento.IdEstabelecimento == id);
            if (estabelecimento != null)
            {
                ReadEstabelecimentoDTO estabelecimentoDTO = _mapper.Map<ReadEstabelecimentoDTO>(estabelecimento);
                estabelecimentoDTO.HoraConsulta = DateTime.Now;
                return Ok(estabelecimentoDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEstabelecimento(int id, [FromBody] UpdateEstabelecimentoDTO estabelecimentoDTO)
        {
            Estabelecimento estabelecimento = _context.Estabelecimentos.FirstOrDefault(estabelecimento => estabelecimento.IdEstabelecimento == id);
            if (estabelecimento != null)
            {
                _mapper.Map(estabelecimentoDTO, estabelecimento);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEstabelecimento(int id)
        {
            Estabelecimento estabelecimento = _context.Estabelecimentos.FirstOrDefault(estabelecimento => estabelecimento.IdEstabelecimento == id);
            if (estabelecimento != null)
            {
                _context.Remove(estabelecimento);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

    }
}
