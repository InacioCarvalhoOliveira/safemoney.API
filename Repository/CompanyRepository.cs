using safemoney.API.Contracts;
using safemoney.API.Context;
using safemoney.API.Entities;

using Dapper;

namespace safemoney.API.Repository
{
    class CompanyRepository : IcompanyRepository
    {   
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context) => _context = context;

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = @"SELECT * FROM companies;";

            using(var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }
       
    }
}