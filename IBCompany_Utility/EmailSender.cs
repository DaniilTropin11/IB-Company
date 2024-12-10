using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace IBCompany_Utility // реализация почты для отправки заказов от клиента 
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }

        public async Task Execute(string email, string subject, string body)
        {
           
        }   

    }
}
//IBCompany_Utility