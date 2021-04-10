using BlazorServerAPI.Models;
using System.Threading.Tasks;

namespace BlazorServerAPI.Services
{
    // conflict generator
    public interface IMailService
    {
        // conflict generator
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
