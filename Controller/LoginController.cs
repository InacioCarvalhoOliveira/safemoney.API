namespace Name.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using safemoney.API.Entities;

    [Route("api/[LoginController]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateCompany(User user)
        {
            try
            {
                var createdCompany = await CreateCompany(user);
                return CreatedAtRoute("UserTokenId", new { UserId = createdCompany}, createdCompany);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
}
    }
}