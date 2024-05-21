using Microsoft.AspNetCore.Mvc;
using PetshopAPI.Context;
using PetshopAPI.Models.ClientePet;
using PetshopAPI.Models.Clientes;
using PetshopAPI.Validacoes;
using System.Linq;
using Validacoes;

namespace PetshopAPI.Controllers
{
    [ApiController]
    [Route("PetShopAPI/[Controller]")]
    public class ClientePetController : ControllerBase
    {
        private readonly PetshopContext _context;

        public ClientePetController(PetshopContext context) 
        {
            _context = context;
        }

        [HttpPost()]
        public IActionResult CriarClientePet(ClientePet clientePet)
        {
            if (clientePet == null)
                return BadRequest(new { Erro = "Dados nao pode ser vazios ou invalidos" });


            _context.Add(clientePet);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterPorId), new { id = clientePet.Id }, clientePet);
            //return Ok(clientePet);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var ObterId = _context.ClientePets.Find(id);
            if (ObterId == null)
                return NotFound("Id Invalido");

            return Ok(ObterId);
        }

        [HttpGet("Todos")]
        public IActionResult ObterTodos()
        {
            var ObterTodos = _context.ClientePets;

            if (ObterTodos == null)
                return NotFound("Nao encontrado");

            return Ok(ObterTodos);
        }

        //[HttpGet("PorTipo")]
        //public IActionResult ObterPorTipo(EnumRaca tipo)
        //{
        //    var ObterTipo = _context.ClientePets.Where(x => x.Tipo == tipo);

        //    if (ObterTipo == null)
        //        return NotFound();

        //    return Ok(ObterTipo);
        //}

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, ClientePet clientePet)
        {
            var clientePetBanco = _context.ClientePets.Find(id);

            if (clientePetBanco == null)
                return BadRequest(new { Error = "Id nao encontrado" });

            clientePetBanco.NamePet = clientePet.NamePet;
            clientePetBanco.Idade = clientePet.Idade;
            clientePetBanco.Tipo = clientePet.Tipo;
            clientePetBanco.NomeTutor = clientePet.NomeTutor;

            _context.ClientePets.Update(clientePetBanco);
            _context.SaveChanges();

            return Ok(clientePetBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var DeleteCliente = _context.ClientePets.Find(id);

            if (DeleteCliente == null)
                return NotFound();

            _context.ClientePets.Remove(DeleteCliente);
            _context.SaveChanges();

            return Ok(DeleteCliente);
        }
    }
}
