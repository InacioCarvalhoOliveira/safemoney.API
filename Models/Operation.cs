namespace safemoney.API.Models
{
    class Operation 
    {
        public decimal ValueOperation { get; set; }
        public DateTime ActionOperation { get; set; }
        public int TypeOperation { get; set; }
        public int OriginOperation { get; set; }
        public int DestinyOperation { get; set; }
    }
}