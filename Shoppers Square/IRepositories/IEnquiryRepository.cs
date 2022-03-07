using Shoppers_Square.Models;
using System.Threading.Tasks;

namespace Shoppers_Square.IRepositories
{
    public interface IEnquiryRepository
    {
        bool ExistEnquiryAsync(int OrderId);

        Task AddEnquiryAsync(OrderStatusModel status);

        OrderStatusModel SelectByIdAsync(int OrderId);
    }
}
