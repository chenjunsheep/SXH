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

        [HttpPost("GetProductPayment")]
        public async Task<IApiActionResult> GetProductPayment([FromBody] dynamic pagersettings)
        {
            var query = from payment in _context.ProductPayment
                        join product in _context.Product on payment.ProductId equals product.Id
                        join project in _context.Project on product.ProjectId equals project.Id
                        orderby payment.NextPayment, product.Name
                        select new
                        {
                            product.Name,
                            NextPayment = payment.NextPayment.ToString("yyyy/MM/dd"),
                            Freq = $"{payment.FreqCurrent}/{payment.FreqTotal}",
                            Funds = $"{product.TotalFunds}/{project.TotalFunds}",
                            project.Rate,
                            payment.LastUpdate,
                        };
            var ret = await query.ToListAsync();
            return new ApiActionResultOK(ret);
        }
    }
}