using System.Threading.Tasks;

namespace Shoppers_Square.IRepositories
{
   public interface IEmailRepository
    {
        Task SendEmailTest(string Name, string Email,string Body,string Subject);
    }
}
