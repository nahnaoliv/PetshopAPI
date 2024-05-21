namespace PetshopAPI.Models.Clientes
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; } //tratar
        public string Telefone { get; set; } // tratar
        public EnumStatusCliente Status { get; set; }
    }
}
