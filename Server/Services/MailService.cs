using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Shared.Models;
using Shared.Services;


namespace Server.Services;

public class MailService : IEmailService
{
    public async Task<ServiceResponse<string>> SendMail()
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<MailRequest>> SendMail(MailRequest request)
    {
        var response = new ServiceResponse<MailRequest>();
        try
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress($"ICTAZ-PROJECT REPOSITORY", "system@ictazcbu.com"));
            email.To.Add((MailboxAddress.Parse("zimbaisaacj2002@gmail.com")));
            email.Subject = $"{request.Subject}";
            email.Body = new TextPart(request.Html) { Text = request.Body };
            
            var smtp = new SmtpClient();
            await smtp.ConnectAsync("host", 465, SecureSocketOptions.SslOnConnect);
            await smtp.AuthenticateAsync("system@wirepickzambia.com", "AdKTu0$axEW=");
            var sendResult = await smtp.SendAsync(email);
            
            //update the result mail to sent email
            return response;
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error sending mail");
            Console.WriteLine(e.Message);
            return new BaseResult() { Success = false, Message =  e.Message };
        }
}

    public class BaseResult : ServiceResponse<MailRequest>
    {
    }
};