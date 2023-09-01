using safemoney.API.Entities;
namespace safemoney.API.Contracts
{
    public interface IloginToken
    {
        public Task CreateUserToken(User user);
    }
}