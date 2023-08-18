namespace safemoney.API.Models
{
    class product 
    {
        
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public DateTime ProductAcsition { get; set; }
        public decimal ProductValue { get; set; }
        public int PaymentForm { get; set; }


    }
}