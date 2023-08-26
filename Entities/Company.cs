namespace safemoney.API.Entities
{
    public class Company
    {
        public Company(int id, string? cor, string? marca)
        {
            Id = id;
            Cor = cor;
            Marca = marca;
        }

        public int Id { get; set; }
        public string? Cor { get; set; }
        public string? Marca { get; set; }      


    }
}