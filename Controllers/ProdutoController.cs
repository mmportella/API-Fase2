using API_Fase2.Data.DTO.ProdutoDTO;
using API_Fase2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Xml.Linq;

namespace API_Fase2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {

        private Data.APIContext _context;
        private IMapper _mapper;

        public ProdutoController(Data.APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddProduto([FromBody] CreateProdutoDTO produtoDTO)
        {
            Produto produto = _mapper.Map<Produto>(produtoDTO);
            _context.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProdutoById), new { id = produto.IdProduto }, produto);
        }

        [HttpGet]
        public IActionResult GetProduto()
        {
            List<Produto> produtos = _context.Produtos.ToList();
            if (produtos != null)
            {
                List<ReadProdutoDTO> readDTO = _mapper.Map<List<ReadProdutoDTO>>(produtos);
                DateTime agora = DateTime.Now;
                foreach (ReadProdutoDTO dto in readDTO)
                {
                    dto.HoraConsulta = agora;
                }
                return Ok(readDTO);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetProdutoById(int id)
        {
            Produto produto = _context.Produtos.FirstOrDefault(produto => produto.IdProduto == id);
            if (produto != null)
            {
                ReadProdutoDTO produtoDTO = _mapper.Map<ReadProdutoDTO>(produto);
                produtoDTO.HoraConsulta = DateTime.Now;
                return Ok(produtoDTO);
            }
            return NotFound();
        }

        [HttpGet("nome/{nome}")]
        public IActionResult GetProdutoByNome(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                IQueryable<Produto> query = _context.Produtos;
                query = query.Where(e => e.NomeProduto.Contains(nome));
                List<ReadProdutoDTO> readDTO = _mapper.Map<List<ReadProdutoDTO>>(query.ToList());
                return Ok(readDTO);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(int id, [FromBody] UpdateProdutoDTO produtoDTO)
        {
            Produto produto = _context.Produtos.FirstOrDefault(produto => produto.IdProduto == id);
            if (produto != null)
            {
                _mapper.Map(produtoDTO, produto);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            Produto produto = _context.Produtos.FirstOrDefault(produto => produto.IdProduto == id);
            if (produto != null)
            {
                _context.Remove(produto);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

    }
}
