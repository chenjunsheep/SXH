using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Api.Response;
using Sxh.Db.Models;

namespace Sxh.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductPayments")]
    public class ProductPaymentsController : Controller
    {
        private readonly SxhContext _context;

        public ProductPaymentsController(SxhContext context)
        {
            _context = context;
        }

        [HttpPost("GetProductPayment/{projectId}")]
        public async Task<IApiActionResult> GetProductPayment([FromRoute] int? projectId, [FromBody] dynamic pagersettings)
        {
            var ret = await _context.ProductPayment.ToListAsync();
            return new ApiActionResultOK(ret);
        }
    }
}