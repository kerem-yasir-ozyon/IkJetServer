using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.Common.EmailServices
{
    public class EmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService()
        {
            _smtpClient = new SmtpClient("smtp.gmail.com") // SMTP sunucusu adresi
            {
                Port = 587, // veya 465 (sunucunuzun desteklediği port)
                Credentials = new NetworkCredential("ikjet06@gmail.com", "plmdkjeupyfxkioh"), // SMTP kimlik bilgileri
                EnableSsl = true, // Güvenli bağlantı
            };
        }

        public async Task SendConfirmationEmailAsync(string email, string subject, string message)
        {

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("ikjet06@gmail.com"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true // HTML formatında e-posta gönderimi
            };

            mailMessage.To.Add(email);

            await _smtpClient.SendMailAsync(mailMessage);
        }



        /// <summary>
        /// Ön yüzdeki Contact formu için oluşturulmuş method, bize ulaşın kısmı için yapılmıştır.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task ContactUsAsync(string subject, string message)
        {
            var mailTo = new MailAddress("ikjet06@gmail.com");

            MailMessage mailMessage = new MailMessage
            {
                From = mailTo,
                Subject = subject,
                Body = message,
                IsBodyHtml = true 
            };

            

            mailMessage.To.Add(mailTo);

            await _smtpClient.SendMailAsync(mailMessage);
        }



    }
}
