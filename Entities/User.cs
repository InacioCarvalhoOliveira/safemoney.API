namespace safemoney.API.Entities
{
    public class User 
    {
        public Guid UserId { get; set; }
        public string? NameUser { get; set; }
        public string? Email { get; set; }
        public string? WebPassword { get; set; }
    }
}