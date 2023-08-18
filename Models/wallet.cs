namespace safemoney.API.Models
{
    class wallet 
    {
        public Guid WalletId { get; set; }
        public decimal BalanceWallet { get; set; }
        public decimal BalanceWalletLimit { get; set; }
    }
}