namespace safemoney.API.Models
{
    class Product 
    {
        // public product()
        // {
        //     CardId = new List<card>();
        //     TagID = new List<tag>();
        // }
        public List<Card> CardId { get; set; } = new List<Card>();
        public List<Tag> TagID { get; set; } = new List<Tag>();

        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public DateTime ProductAcsition { get; set; }
        public decimal ProductValue { get; set; }
        public int PaymentForm { get; set; }


    }
}