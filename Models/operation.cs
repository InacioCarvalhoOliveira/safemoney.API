namespace safemoney.API.Models
{
    class operation 
    {
        public decimal ValueOperation { get; set; }
        public DateTime Operation { get; set; }
        public int TypeOperation { get; set; }
        public int OriginOperation { get; set; }
        public int DestinyOperation { get; set; }
    }
}