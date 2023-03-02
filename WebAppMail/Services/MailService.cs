using System;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using WebAppMail.Models;

namespace WebAppMail.Services
{
    public class MailService : IMailService
    {
        public async Task<Mail> SendEmailAsync(Letter letter)
        {
            Mail mail = new Mail()
            {
                Subject = letter.Subject,
                Body = letter.Body,
                Result = "OK",
                FailedMessage = "",
                Date = DateTime.Now,
                Recipients = letter.Recipients.Select(recipient => new Recipient()
                {
                    RecipientEmail = recipient
                }).ToList()
                //RecipientId = 3
            };

            List<MimeMessage> messages = new List<MimeMessage>();

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "login@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", "dmitry.mazinn@gmail.com"));
            emailMessage.Subject = letter.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = letter.Body
            };
            messages.Add(emailMessage);
            foreach (var message in messages)
            {
                try
                {
                    using (var client = new SmtpClient())
                    {
                        await client.ConnectAsync("smtp.gmail.com", 465, true);
                        await client.AuthenticateAsync("dmitry.mazinn@gmail.com", "wveofmxlqztcfpnu");
                        await client.SendAsync(message);
                        await client.DisconnectAsync(true);
                    }
                }
                catch (Exception ex)
                {
                    mail.FailedMessage += $"Failed: {message.To}:{ex}\n";
                    mail.Result = "Failed";
                }
            }
            return mail;
        }
    }
}
