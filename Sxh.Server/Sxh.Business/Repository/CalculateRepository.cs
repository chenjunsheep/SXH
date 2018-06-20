using Sxh.Business.Models;
using Sxh.Business.Repository.Interface;
using Sxh.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Util;
using System.Threading.Tasks;

namespace Sxh.Business.Repository
{
    public class CalculateRepository : BaseRepository, ICalculateRepository
    {
        private SxhContext _context;

        public CalculateRepository(SxhContext context)
        {
            _context = context;
        }

        public async Task<int> GeneratePaymentPlan()
        {
            return await UpdateProductPayment(null);
        }

        #region Private Method

        private async Task<int> UpdateProductPayment(IEnumerable<int> projectIds)
        {
            if (projectIds == null)
            {
                projectIds = (from project in _context.Project
                             where project.StatusId == (int)StatusProject.Active
                             select project.Id).ToList();
            }

            var tmpItems = from product in _context.Product
                           join project in _context.Project on product.ProjectId equals project.Id
                           where projectIds.Contains(product.ProjectId) && project.StatusId == (int)StatusProject.Active
                           select new
                           {
                               product.Id,
                               product.ValueDate,
                               project.PayTypeId,
                               project.Deadline
                           };

            var paymentList = new List<ProductPayment>();
            foreach (var item in tmpItems.ToList())
            {
                var payment = new ProductPayment();
                payment.ProductId = item.Id;
                payment.NextPayment = item.ValueDate;
                payment.LastUpdate = DateTime.Now;

                var dateDue = item.ValueDate.AddMonths(TypeParser.GetInt32Value(item.Deadline * 12));
                switch ((PaymentType)item.PayTypeId)
                {
                    case PaymentType.Annual:
                        payment.FreqTotal = TypeParser.GetInt32Value(item.Deadline);
                        while (payment.NextPayment < DateTime.Now)
                        {
                            payment.NextPayment = payment.NextPayment.AddMonths(12);
                            payment.FreqCurrent++;
                        }
                        break;
                    case PaymentType.AnnualHalf:
                        payment.FreqTotal = TypeParser.GetInt32Value(item.Deadline * 2);
                        while (payment.NextPayment < DateTime.Now)
                        {
                            payment.NextPayment = payment.NextPayment.AddMonths(6);
                            payment.FreqCurrent++;
                        }
                        break;
                    case PaymentType.Quater:
                        payment.FreqTotal = TypeParser.GetInt32Value(item.Deadline * 4);
                        while (payment.NextPayment < DateTime.Now)
                        {
                            payment.NextPayment = payment.NextPayment.AddMonths(3);
                            payment.FreqCurrent++;
                        }
                        break;
                    case PaymentType.Month:
                        payment.FreqTotal = TypeParser.GetInt32Value(item.Deadline * 12);
                        while (payment.NextPayment < DateTime.Now)
                        {
                            payment.NextPayment = payment.NextPayment.AddMonths(1);
                            payment.FreqCurrent++;
                        }
                        break;
                    case PaymentType.Day:
                        payment.FreqTotal = TypeParser.GetInt32Value(item.Deadline * 365);
                        while (payment.NextPayment < DateTime.Now)
                        {
                            payment.NextPayment = payment.NextPayment.AddDays(1);
                            payment.FreqCurrent++;
                        }
                        break;
                    default:
                        break;
                }

                if (payment.NextPayment <= dateDue)
                {
                    paymentList.Add(payment);
                }
            }

            _context.ProductPayment.RemoveRange(from p in _context.ProductPayment select p);
            await _context.SaveChangesAsync();
            await _context.ProductPayment.AddRangeAsync(paymentList);
            return await _context.SaveChangesAsync();
        }

        #endregion
    }
}
