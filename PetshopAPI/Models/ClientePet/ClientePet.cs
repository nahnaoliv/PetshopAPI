namespace PetshopAPI.Models.ClientePet
{
    public class ClientePet
    {
        public int Id { get; set; }
        public string NamePet { get; set; }
        public EnumRaca Tipo { get; set; }
        public int Idade { get; set; }
        public string NomeTutor { get; set; }
    }
}
