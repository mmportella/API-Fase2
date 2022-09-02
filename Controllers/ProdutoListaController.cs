using API_Fase2.Data.DTO.ProdutoListaDTO;
using API_Fase2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_Fase2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoListaController : ControllerBase
    {

        private Data.APIContext _context;
        private IMapper _mapper;

        public ProdutoListaController(Data.APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateProdutoListaDTO produtolistaDTO)
        {
            ProdutoLista produtolista = _mapper.Map<ProdutoLista>(produtolistaDTO);
            _context.ProdutosLista.Add(produtolista);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaProdutoListaPorId), new { id = produtolista.IdProdutoLista }, produtolista);
        }

        [HttpGet]
        public IActionResult GetEstoque()
        {
            List<ProdutoLista> produtoslista = _context.ProdutosLista.ToList();
            if (produtoslista != null)
            {
                List<ReadProdutoListaDTO> readDTO = _mapper.Map<List<ReadProdutoListaDTO>>(produtoslista);
                DateTime agora = DateTime.Now;
                foreach (ReadProdutoListaDTO dto in readDTO)
                {
                    dto.HoraConsulta = agora;
                }
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaProdutoListaPorId(int id)
        {
            ProdutoLista produtolista = _context.ProdutosLista.FirstOrDefault(produtolista => produtolista.IdProdutoLista == id);
            if (produtolista != null)
            {
                ReadProdutoListaDTO produtolistaDTO = _mapper.Map<ReadProdutoListaDTO>(produtolista);
                produtolistaDTO.HoraConsulta = DateTime.Now;
                return Ok(produtolistaDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProdutoLista(int id, [FromBody] UpdateProdutoListaDTO produtolistaDTO)
        {
            ProdutoLista produtolista = _context.ProdutosLista.FirstOrDefault(produtolista => produtolista.IdProdutoLista == id);
            if (produtolista != null)
            {
                _mapper.Map(produtolistaDTO, produtolista);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProdutoLista(int id)
        {
            ProdutoLista produtolista = _context.ProdutosLista.FirstOrDefault(produtolista => produtolista.IdProdutoLista == id);
            if (produtolista != null)
            {
                _context.Remove(produtolista);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

    }
}
