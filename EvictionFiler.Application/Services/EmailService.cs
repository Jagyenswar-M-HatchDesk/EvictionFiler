using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.Interfaces.IServices;

namespace EvictionFiler.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendFirmEnrollEmailAsync(string toEmail, string userName, string firmName, string password)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Housing Court Filer", _config["Email:From"]));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = $"Welcome to {firmName}!";

            var builder = new BodyBuilder
            {
                HtmlBody = GetFirmEnrollTemplate(userName, firmName, toEmail, password)
            };

            message.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(
                _config["Email:SmtpHost"],
                int.Parse(_config["Email:SmtpPort"]),
                MailKit.Security.SecureSocketOptions.StartTls
            );

            await client.AuthenticateAsync(
                _config["Email:Username"],
                _config["Email:Password"]
            );

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        public async Task SendOtpAsync(string toEmail, string otp)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Housing Court Filer", _config["Email:From"]));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = "Your OTP Code";

            var builder = new BodyBuilder
            {
                HtmlBody = $@"
        <h2>Your OTP Code</h2>
        <h1>{otp}</h1>
        <p>This OTP is valid for a short time.</p>"
            };

            message.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(
                _config["Email:SmtpHost"],
                int.Parse(_config["Email:SmtpPort"]),
                MailKit.Security.SecureSocketOptions.StartTls);

            await client.AuthenticateAsync(
                _config["Email:Username"],
                _config["Email:Password"]);

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }

        private string GetFirmEnrollTemplate(string userName, string firmName, string email, string password)
        {
            return $@"
        <div style='font-family:Poppins,Arial,sans-serif; padding:20px; color:#1F365D'>
            <h2>Welcome, {userName}!</h2>
            <p>Your firm <strong>{firmName}</strong> has been successfully enrolled in the Housing Court Filer system.</p>
            <p>You can now log in and start managing your filings.</p>
            <p> UserId: {email}</p>
            <p> Password: {password}</p>
            <br/>
            <a href='https://housingcourtfiler-dev.azurewebsites.net/' 
               style='background:#1F365D; color:white; padding:10px 15px; 
                      text-decoration:none; border-radius:6px;'>Login</a>

            <br/><br/>

            <p style='font-size:12px; color:#6c757d'>If you did not request this, please contact support.</p>
        </div>";
        }
    }
}
