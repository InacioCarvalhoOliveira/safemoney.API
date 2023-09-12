using safemoney.API.Entities;
namespace safemoney.API.Contracts
{
    public interface IloginToken
    {
        public Task CreateUserToken(User user);
        //public Task GetUsers();
        public Task<IEnumerable<User>> GetUsers();
        //public Task<IEnumerable<User>> GetUserByToken();

    }
}