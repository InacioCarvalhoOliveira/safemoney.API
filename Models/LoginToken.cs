using safemoney.API.Contracts;
using safemoney.API.Entities;
using safemoney.API.Context;
using Dapper;
using System.Data;

namespace safemoney.API.Models
{
    public class LoginToken : IloginToken
    {
        private readonly DapperContext _context;
        public LoginToken(DapperContext context) => _context = context;
        public async Task CreateUserToken(User user)
        {
            var query = @"INSERT INTO [USER] VALUES(@USERID,@NAMEUSER,@EMAIL,@WEBPASSWORD)";
            
            var parm = new DynamicParameters();
            parm.Add("USERID",user.UserId);
            parm.Add("NAMEUSER",user.NameUser,DbType.String);
            parm.Add("EMAIL",user.Email,DbType.String);
            parm.Add("WEBPASSWORD",user.WebPassword,DbType.String);
            
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parm);                
            }


        }
    }
}