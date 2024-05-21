using Microsoft.AspNetCore.Mvc;
using PetshopAPI.Context;
using PetshopAPI.Models.ClientePet;
using PetshopAPI.Models.Servico;
using System.Linq;

namespace PetshopAPI.Controllers
{
    [ApiController]
    [Route("PetShopAPI/Controller")]
    public class ServicosController : ControllerBase
    {
        private readonly PetshopContext _context;

        public ServicosController(PetshopContext context)
        {
            _context = context;
        }

        [HttpPost()]
        public IActionResult CriarServico(Servico servicos)
        {
            if (servicos == null)
                return BadRequest(new { Erro = "Dados nao pode ser vazios ou invalidos" });


            _context.Add(servicos);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterPorId), new { id = servicos.Id }, servicos);
            //return Ok(clientePet);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var ObterId = _context.Servicos.Find(id);
            if (ObterId == null)
                return NotFound("Id Invalido");

            return Ok(ObterId);
        }

        [HttpGet("Todos")]
        public IActionResult ObterTodos()
        {
            var ObterTodos = _context.Servicos;

            if (ObterTodos == null)
                return NotFound("Nao encontrado");

            return Ok(ObterTodos);
        }

        //[HttpGet("PorTipo")]
        //public IActionResult ObterPorTipo(EnumDisponibilidade disponiblidade)
        //{
        //    var ObterTipo = _context.Servicos.Where(x => x.Disponiblidade == disponiblidade);

        //    if (ObterTipo == null)
        //        return NotFound();

        //    return Ok(ObterTipo);
        //}

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Servico servico)
        {
            var servicoBanco = _context.Servicos.Find(id);

            if (servicoBanco == null)
                return BadRequest(new { Error = "Id nao encontrado" });

            servicoBanco.NameServico = servico.NameServico;
            servicoBanco.Descrcao = servico.Descrcao;
            servicoBanco.Preco = servico.Preco;
            servicoBanco.Disponiblidade = servico.Disponiblidade;

            _context.Servicos.Update(servicoBanco);
            _context.SaveChanges();

            return Ok(servicoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var DeleteServico = _context.Servicos.Find(id);

            if (DeleteServico == null)
                return NotFound();

            _context.Servicos.Remove(DeleteServico);
            _context.SaveChanges();

            return Ok(DeleteServico);
        }
    }
}
