namespace safemoney.API.Models
{
    class Card 
    {
        public int Number { get; set; }
        public DateTime EndValidity { get; set; }
        public string? OwnerCard { get; set; }
        public int FlagType { get; set; }
        public decimal LimitToSpend { get; set; }
        public decimal Saving { get; set; }
        public int PaymentType { get; set; }

    }
}