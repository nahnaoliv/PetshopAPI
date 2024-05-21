using Microsoft.EntityFrameworkCore;
using PetshopAPI.Models.ClientePet;
using PetshopAPI.Models.Clientes;
using PetshopAPI.Models.Servico;

namespace PetshopAPI.Context
{
    public class PetshopContext : DbContext
    {
        public PetshopContext(DbContextOptions<PetshopContext> options) : base(options)
        { 
        
        }
                    //Class     Banco
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<ClientePet> ClientePets { get; set; }
        public DbSet<Servico> Servicos { get; set; }
    }
}
