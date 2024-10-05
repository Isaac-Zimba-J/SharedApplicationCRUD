using Shared.Models;

namespace Shared.Services;

public interface IEmailService
{
    Task<ServiceResponse<string>> SendMail();
    Task<ServiceResponse<MailRequest>> SendMail(MailRequest request);
}