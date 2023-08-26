using safemoney.API.Entities;
namespace safemoney.API.Contracts
{
    public interface IcompanyRepository 
    {
        public Task<IEnumerable<Company>> GetCompanies();
    }
}