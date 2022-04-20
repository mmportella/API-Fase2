using API_Fase2.Data.DTO.EstoqueDTO;
using API_Fase2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_Fase2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController : ControllerBase
    {
        private Data.APIContext _context;
        private IMapper _mapper;

        public EstoqueController(Data.APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateEstoqueDTO estoqueDTO)
        {
            Estoque estoque = _mapper.Map<Estoque>(estoqueDTO);
            _context.Estoques.Add(estoque);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEstoquesPorId), new { id = estoque.IdEstoque }, estoque);
        }

        [HttpGet]
        public IActionResult GetEstoque()
        {
            List<Estoque> estoques = _context.Estoques.ToList();
            if (estoques != null)
            {
                List<ReadEstoqueDTO> readDTO = _mapper.Map<List<ReadEstoqueDTO>>(estoques);
                DateTime agora = DateTime.Now;
                foreach (ReadEstoqueDTO dto in readDTO)
                {
                    dto.HoraConsulta = agora;
                }
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEstoquesPorId(int id)
        {
            Estoque estoque = _context.Estoques.FirstOrDefault(estoque => estoque.IdEstoque == id);
            if (estoque != null)
            {
                ReadEstoqueDTO estoqueDTO = _mapper.Map<ReadEstoqueDTO>(estoque);
                estoqueDTO.HoraConsulta = DateTime.Now;
                return Ok(estoqueDTO);
            }
            return NotFound();
        }

        
        [HttpGet("compara/{id}")]
        public IActionResult RecuperaListaEstoques(int id)
        {
            List<Estoque> estoques = _context.Estoques.ToList();
            List<ComparaEstoqueDTO> dto = _mapper.Map<List<ComparaEstoqueDTO>>(estoques);
            List<ComparaEstoqueDTO> lista = new List<ComparaEstoqueDTO>();
            foreach (ComparaEstoqueDTO estoque in dto)
            {
                if (estoque.ProdutoId == id)
                {
                    lista.Add(estoque);
                }
            }
            Double menorPreco = Double.MaxValue;
            int idEstoque = 0;
            if (lista.Any())
            {
                foreach (ComparaEstoqueDTO e in lista)
                {
                    if (e.Valor <= menorPreco)
                    {
                        menorPreco = e.Valor;
                        idEstoque = e.IdEstoque;
                    }
                }
                return RecuperaEstoquesPorId(idEstoque);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEstoque(int id, [FromBody] UpdateEstoqueDTO estoqueDTO)
        {
            Estoque estoque = _context.Estoques.FirstOrDefault(estoque => estoque.IdEstoque == id);
            if (estoque != null)
            {
                _mapper.Map(estoqueDTO, estoque);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEstoque(int id)
        {
            Estoque estoque = _context.Estoques.FirstOrDefault(estoque => estoque.IdEstoque == id);
            if (estoque != null)
            {
                _context.Remove(estoque);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

    }
}
