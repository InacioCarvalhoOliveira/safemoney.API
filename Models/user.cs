namespace safemoney.API.Models
{
    class user 
    {
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? WebPassword { get; set; }
    }
}