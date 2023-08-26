namespace safemoney.API.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using safemoney.API.Contracts;

    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IcompanyRepository _companyRepo;
        public CompaniesController(IcompanyRepository companyRepo) => _companyRepo = companyRepo;
        
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companyRepo.GetCompanies();
            return Ok(companies);
        }
     
    }
}