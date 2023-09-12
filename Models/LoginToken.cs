using safemoney.API.Contracts;
using safemoney.API.Entities;
using safemoney.API.Context;
using Dapper;
using System.Data;
using safemoney.API.Services;

namespace safemoney.API.Models
{
    public class LoginToken : IloginToken
    {
        private readonly DapperContext _context;

        public LoginToken(DapperContext context) => _context = context;
        public async Task CreateUserToken(User user)
        {
            var query = @"INSERT INTO [USUARIO] (USERID,NAMEUSER,EMAIL,WEBPASSWORD)
            VALUES(@USERID,@NAMEUSER,@EMAIL,@WEBPASSWORD)";
            var parm = new DynamicParameters();
            parm.Add("USERID",user.USERID,DbType.String);
            parm.Add("NAMEUSER",user.NAMEUSER,DbType.String);
            parm.Add("EMAIL",user.EMAIL,DbType.String);
            parm.Add("WEBPASSWORD",user.WEBPASSWORD,DbType.String);
            
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parm);                
            }
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var query = "SELECT * FROM [USUARIO]"; // Query SQL para selecionar todos os usuários

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<User>(query);
                return users;
            }
        }
        // public async Task<IEnumerable<User>> GetUerByToken()
        // {
        //     string token = TokenService.GenerateToken();

        // }

    }
}