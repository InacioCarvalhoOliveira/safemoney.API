namespace safemoney.API.Entities
{
    class Product 
    {
     
        public List<Card> CardId { get; set; } = new List<Card>();
        public List<Tag> TagID { get; set; } = new List<Tag>();

        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public DateTime ProductAcsition { get; set; }
        public decimal ProductValue { get; set; }
        public int PaymentForm { get; set; }


    }
}