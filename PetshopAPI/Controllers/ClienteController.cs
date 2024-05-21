using Microsoft.AspNetCore.Mvc;
using PetshopAPI.Context;
using PetshopAPI.Models.Clientes;
using PetshopAPI.Validacoes;
using System;
using System.Linq;
using Validacoes;

namespace PetshopAPI.Controllers
{
    [ApiController]
    [Route("PetShopAPI/[Controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly PetshopContext _context; // banco de dados

        public ClienteController(PetshopContext context)
        {
            _context = context;
        }

        [HttpPost()]
        public IActionResult CriarCliente(Clientes clientes) // Criando cliente
        {
            if (clientes == null)
                return BadRequest(new { Erro = "Dados nao pode ser vazios ou invalidos" }); 

            if (!ValidaCPF.IsCpf(clientes.Cpf))
                return BadRequest(new { Erro = "CPF inválido" }); // validarCPF

            if (!ValidarTelCelSimples.Validar(clientes.Telefone))
                return BadRequest (new { Error = "Número de telefone inválido" }); // validar DDD telefone e celular


            _context.Add(clientes);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterPorId), new { id = clientes.Id }, clientes);
            //return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id) // Buscar por ID
        {
            var ObterId = _context.Clientes.Find(id);
            if (ObterId == null)
                return NotFound("Id Invalido");

            return Ok(ObterId);
        }

        [HttpGet("Todos")] // Trazer todas as informaçoes do banco
        public IActionResult ObterTodos() 
        {
            var ObterTodos = _context.Clientes;

            if(ObterTodos == null)
                return NotFound("Nao encontrado");

            return Ok(ObterTodos);
        }

        //[HttpGet("PorStatus")] // Buscar por Status
        //public IActionResult ObterPorStatus(EnumStatusCliente status)
        //{
        //    var ObterStatus = _context.Clientes.Where(x => x.Status == status);

        //    if (ObterStatus == null)
        //        return NotFound();

        //    return Ok(ObterStatus);
        //}

        [HttpPut("{id}")] // Atualizar informações
        public IActionResult Atualizar(int id, Clientes clientes)
        {
            var clienteBanco = _context.Clientes.Find(id);

            if (clienteBanco == null)
                return BadRequest(new { Error = "Id nao encontrado" });

            if (!ValidaCPF.IsCpf(clientes.Cpf))
                return BadRequest(new { Erro = "CPF inválido" });

            if (!ValidarTelCelSimples.Validar(clientes.Telefone))
                return BadRequest(new { Error = "Número de telefone válido" });

            clienteBanco.Nome = clientes.Nome;
            clienteBanco.Cpf = clientes.Cpf;
            clienteBanco.Telefone = clientes.Telefone;
            clienteBanco.Status = clientes.Status;

            _context.Clientes.Update(clienteBanco);
            _context.SaveChanges();

            return Ok(clienteBanco);
        }

        [HttpDelete("{id}")] // Deletar
        public IActionResult DeleteCliente(int id)
        {
            var DeleteCliente = _context.Clientes.Find(id);

            if (DeleteCliente == null)
                return NotFound();

            _context.Clientes.Remove(DeleteCliente);
            _context.SaveChanges();

                return Ok(DeleteCliente);
        }
    }
}
