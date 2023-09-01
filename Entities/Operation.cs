namespace safemoney.API.Entities
{
    class Operation 
    {
        public int OperationId { get; set; }
        public decimal ValueOperation { get; set; }
        public DateTime ActionOperation { get; set; }
        public int TypeOperation { get; set; }
        public int OriginOperation { get; set; }
        public int DestinyOperation { get; set; }
    }
}