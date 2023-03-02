using System.Threading.Tasks;
using WebAppMail.Models;
namespace WebAppMail.Services
{
    public interface IMailService
    {
        public Task<Mail> SendEmailAsync(Letter letter);
    }
}
