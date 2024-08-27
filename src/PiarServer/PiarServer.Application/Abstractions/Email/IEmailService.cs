namespace PiarServer.Application.Abstractions.Email;

public interface IEmailService
{
    void Send(string recipient, string subject, string body);
}