using System.ComponentModel.DataAnnotations.Schema;

namespace safemoney.API.Entities
{
    [Table("[USUARIO]")]
    public class User 
    {
        public string? USERID { get; set; }
        public string? NAMEUSER { get; set; }
        public string? EMAIL { get; set; }
        public string? WEBPASSWORD { get; set; }
    }
}