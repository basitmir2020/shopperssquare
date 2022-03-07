using Microsoft.EntityFrameworkCore;
using Shoppers_Square.Db;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.Repositories
{
    public class EnquiryRepository : IEnquiryRepository
    {
        public readonly AppDbContext _context;
        public EnquiryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddEnquiryAsync(OrderStatusModel status)
        {
            await _context.OrderEnquiry.AddAsync(status);
            await _context.SaveChangesAsync();
            var Order = new OrderModel
            {
                Id = status.OrderId,
                OrderStatus = status.OrderStatus
            };
            _context.Entry(Order).Property(x => x.OrderStatus).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public bool ExistEnquiryAsync(int OrderId)
        {
            var enquiry = _context.OrderEnquiry
                .Where(x => x.OrderId == OrderId && x.isDelete == 0)
                .FirstOrDefault();
            if (enquiry == null)
                return true;
            return false;
        }

        public OrderStatusModel SelectByIdAsync(int OrderId)
        {
          return _context
                .OrderEnquiry.
                Include(n=>n.Order)
                .FirstOrDefault(n => n.OrderId == OrderId);
        }
    }
}
