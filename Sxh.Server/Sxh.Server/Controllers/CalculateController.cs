using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Api.Response;
using Sxh.Business.Repository.Interface;

namespace Sxh.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Calculate")]
    public class CalculateController : BaseController
    {
        private readonly ICalculateRepository _repoCalculate;

        public CalculateController(ICalculateRepository repoCalculate) : base()
        {
            _repoCalculate = repoCalculate;
        }

        [HttpGet("GeneratePaymentPlan")]
        public async Task<IApiActionResult> GeneratePaymentPlan()
        {
            try
            {
                await _repoCalculate.GeneratePaymentPlan();
                return new ApiActionResultOK();
            }
            catch (Exception ex)
            {
                return new ApiActionResultException(ex);
            }
        }
    }
}
