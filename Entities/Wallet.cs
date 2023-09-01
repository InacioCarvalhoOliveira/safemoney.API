namespace safemoney.API.Entities
{
    class Wallet 
    {
        public Guid WalletId { get; set; }
        public decimal BalanceWallet { get; set; }
        public decimal BalanceWalletLimit { get; set; }
    }
}