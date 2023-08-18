namespace safemoney.API.Models
{
    class savings
    {  
        public savings()
        {
            CardId = new List<card>();
        }
        public List<card> CardId { get; set; }
        public Guid SavingId { get; set; }
        public decimal SavingBalance { get; set; }

    }
}