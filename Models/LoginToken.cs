using safemoney.API.Contracts;
using safemoney.API.Entities;
using safemoney.API.Context;
using Dapper;
using System.Data;
using Microsoft.Extensions.Logging;
using safemoney.API.Services;

namespace safemoney.API.Models
{
    public class LoginToken : IloginToken
    {
        private readonly DapperContext _context;
        private readonly ILogger<LoginToken> _logger;
       // public LoginToken(ILogger<LoginToken> logger) => _logger = logger;

        public LoginToken(DapperContext context, ILogger<LoginToken> logger)
        {
            _context = context; 
            _logger = logger;
        }
            
        async Task IloginToken.CreateUserToken(User user)
        {
            var query = @"INSERT INTO [USUARIO] (USERID,NAMEUSER,EMAIL,WEBPASSWORD)
            VALUES(@USERID,@NAMEUSER,@EMAIL,@WEBPASSWORD)";
            var query2 = @"SELECT COUNT(*) FROM [USUARIO] WHERE NAMEUSER = @NAMEUSER";                        
            var parm = new DynamicParameters();
            
            parm.Add("USERID", user.USERID, DbType.String);            
            parm.Add("NAMEUSER", user.NAMEUSER, DbType.String);
            parm.Add("EMAIL", user.EMAIL, DbType.String);
            parm.Add("WEBPASSWORD", user.WEBPASSWORD, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                 var userCount = await connection.ExecuteScalarAsync<int>(query2, parm);
                _logger.LogInformation("USERID: {USERID}, NAMEUSER: {NAMEUSER}, EMAIL: {EMAIL}, WEBPASSWORD: {WEBPASSWORD}", user.USERID, user.NAMEUSER, user.EMAIL, user.WEBPASSWORD);

                // Verifica se o usuário já existe
                if (userCount > 0)
                {
                    _logger.LogInformation("Usuário duplicado");

                    return; // Retorna sem fazer o insert
                }

                await connection.ExecuteAsync(query, parm);
                _logger.LogInformation("Usuário criado");

            }
        }
        async Task<IEnumerable<User>> IloginToken.GetUsers()
        {
            var query = "SELECT*FROM [USUARIO]"; // Query SQL para selecionar todos os usuários

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<User>(query);
                return users;
            }
        }
        async Task<User> IloginToken.GetUserById(string userId)
        {

            var query = @"SELECT*FROM [USUARIO] U WHERE U.USERID = @USERID";
            using (var connection = _context.CreateConnection())
            {

                var userByToken = await connection.QuerySingleOrDefaultAsync<User>(query, new { userId });
                return userByToken;

            }
        }
        public async Task UpdateUserById(string userid, User user)
        {
            var query = @"UPDATE [USUARIO] SET NAMEUSER=@NAMEUSER,EMAIL=@EMAIL,WEBPASSWORD=@WEBPASSWORD WHERE USERID=@USERID";
            var parm = new DynamicParameters();
          
            parm.Add("USERID", user.USERID, DbType.String);
            parm.Add("NAMEUSER", user.NAMEUSER, DbType.String);
            parm.Add("EMAIL", user.EMAIL, DbType.String);
            parm.Add("WEBPASSWORD", user.WEBPASSWORD, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parm);
            }
        }


    }
}