using safemoney.API.Entities;
namespace safemoney.API.Contracts
{
    public interface IloginToken
    {
        public Task CreateUserToken(User user);
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUserById(string userId);
        public Task UpdateUserById(string userid, User user);
        
    }
}