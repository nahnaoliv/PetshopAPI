namespace PetshopAPI.Models.Servico
{
    public class Servico
    {
        public int Id { get; set; }
        public string NameServico { get; set; }
        public string Descrcao { get; set; }
        public double Preco { get; set; }
        public EnumDisponibilidade Disponiblidade { get; set; }
    }
}
