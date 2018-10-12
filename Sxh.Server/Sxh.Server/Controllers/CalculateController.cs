using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sxh.Business.Repository.Interface;

namespace Sxh.Server.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Calculate")]
    public class CalculateController : BaseController
    {
        private readonly ICalculateRepository _repoCalculate;

        public CalculateController(ICalculateRepository repoCalculate) : base()
        {
            _repoCalculate = repoCalculate;
        }

        [AllowAnonymous]
        [HttpGet("GeneratePaymentPlan")]
        public async Task<IActionResult> GeneratePaymentPlan()
        {
            try
            {
                await _repoCalculate.GeneratePaymentPlan();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return ExceptionDefault(ex);
            }
        }
    }
}
