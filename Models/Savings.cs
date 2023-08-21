namespace safemoney.API.Models
{
    class Savings
    {  
        // public savings()
        // {
        //     CardId = new List<card>();
        // }
        public List<Card> CardId { get; set; } = new List<Card>();
        public Guid SavingId { get; set; }
        public decimal SavingBalance { get; set; }

    }
}