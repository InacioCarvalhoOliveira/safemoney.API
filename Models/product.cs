namespace safemoney.API.Models
{
    class product 
    {
        public product()
        {
            CardId = new List<card>();
            TagID = new List<tag>();
        }
        public List<card> CardId { get; set; }
        public List<tag> TagID { get; set; }

        
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public DateTime ProductAcsition { get; set; }
        public decimal ProductValue { get; set; }
        public int PaymentForm { get; set; }


    }
}