using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IkJet.Common.EmailServices
{
    public class UserService
    {
        private readonly EmailService _emailService;

        public UserService(EmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task SendEmailConfirmationAsync(string userId, string confirmationEmail, string password, string token, string email)
        {
            var encodedToken = HttpUtility.UrlEncode(token);
            var confirmationLink = $"https://ikjet-api20240824103050.azurewebsites.net/api/AppUser/confirm-email?userId={userId}&token={encodedToken}";



            var message = $"Lütfen e-posta adresinizi onaylamak için <a href=\"{confirmationLink}\">buraya tıklayın</a><br/>.E-posta adresiniz: {email}<br/>Şifreniz: {password}";

            await _emailService.SendConfirmationEmailAsync(confirmationEmail, "Confirm your email", message);
        }



		public async Task SendEmail(string email, string password)
		{

			var message = $"Yeni şifreniz: {password}  'tür. Şifrenizle giriş yaptıktan sonra profil bölümünden şifrenizi değiştirebilirsiniz";

			await _emailService.SendConfirmationEmailAsync(email, "Şifre Sıfırlama İşlemi Başarılı!", message);
		}

		public async Task SendEmail(string email, string password, string userCompanyEmail)
        {

            var message = $"Yeni şifreniz: {password}  'tür. Giriş yapabileceğiniz şirket mail adresiniz: {userCompanyEmail}  'dir.Mail ve şifrenizle giriş yaptıktan sonra profil bölümünden şifrenizi değiştirebilirsiniz";


            await _emailService.SendConfirmationEmailAsync(email, "Şifre Sıfırlama İşlemi Başarılı!", message);
		}


        /// <summary>
        /// Ön yüzdeki Contact formu için oluşturulmuş method, bize ulaşın kısmı için yapılmıştır.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="userCompanyEmail"></param>
        /// <returns></returns>
        public async Task SendEmail(string name, string email, string subject, string incomingMessage  )
        {

            var message = $"Sayın yönetici  ;" +
                $" {name}  adlı kişiden, " +
                $" {subject}  açıklamasıyla " +
                $" {incomingMessage} mesajı tarafınıza iletilmiştir ." +
                $" " +
                $" Geri dönüşlerinizi {email} mail adresine iletebilirsiniz. " +
                $" İyi günler. ";


            await _emailService.ContactUsAsync("Bir yeni iletiniz var!", message);
        }


    }
}
