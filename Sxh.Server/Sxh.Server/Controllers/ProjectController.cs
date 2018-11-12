using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sxh.Db.Models;
using Sxh.Shared.Response.Model;

namespace Sxh.Server.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Project")]
    public class ProjectController : BaseController
    {
        private readonly SxhContext _context;

        public ProjectController(SxhContext context) : base()
        {
            _context = context;
        }

        [HttpPost("GetProjects")]
        public async Task<IActionResult> GetProjects([FromBody] dynamic pagersettings)
        {
            try
            {
                var query = from project in _context.Project
                            orderby project.StatusId descending, project.Id
                            select new ProjectOverviewItem()
                            {
                                Id = project.Id,
                                Name = project.Name,
                                StatusId = project.StatusId,
                                StatusName = project.Status.Name,
                                PayTypeId = project.PayTypeId,
                                PayTypeName = project.PayType.Name,
                                Deadline = project.Deadline,
                                TotalFunds = project.TotalFunds,
                                Rate = project.Rate,
                                Note = project.Note,
                                ProjectTypeId = project.ProjectTypeId
                            };

                var ret = await query.ToListAsync();
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return ExceptionDefault(ex);
            }
        }

        [HttpPost("GetProductPayment")]
        public async Task<IActionResult> GetProductPayment([FromBody] dynamic pagersettings)
        {
            try
            {
                var query = from payment in _context.ProductPayment
                            join product in _context.Product on payment.ProductId equals product.Id
                            join project in _context.Project on product.ProjectId equals project.Id
                            join payType in _context.PayType on project.PayTypeId equals payType.Id
                            orderby payment.NextPayment, product.Name
                            select new
                            {
                                product.Id,
                                product.Name,
                                project.ProjectTypeId,
                                NextPayment = payment.NextPayment.ToString("yyyy/MM/dd"),
                                Freq = $"{payment.FreqCurrent}/{payment.FreqTotal}",
                                Fund = product.TotalFunds,
                                FundTotal = project.TotalFunds,
                                project.Rate,
                                PayType = payType.Name,
                                payment.LastUpdate,
                                project.Note,
                            };
                var ret = await query.ToListAsync();
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return ExceptionDefault(ex);
            }
        }
    }
}
