
using AutoMapper;
using IkJet.BLL.Managers.Concrete;
using IkJet.Common.EmailServices;
using IkJet.Common.Enums;
using IkJet.DTO.Concrete;
using IkJet.Entities.Concrete;
using IkJet.ViewModel.AppUser;
using IkJet.ViewModel.Prepayment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IkJet_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private IMapper _mapper;
        private UserService _userService;

        public AppUserController(UserManager<AppUser> userManager, IMapper mapper, UserService userService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userService = userService;

        }



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = _userManager.Users.ToList();

            var userViewModels = _mapper.Map<List<AppUserViewModel>>(users);

            return Ok(userViewModels);
        }


		//https://localhost:7262/api/AppUser/GetAllHRManager

		[HttpGet("GetAllHRManager")]
		public async Task<IActionResult> GetAllHRManager()
		{
			var users = _userManager.Users.ToList(); 
			var userViewModels = new List<AppUserViewModel>();

			foreach (var user in users)
			{
				var roles = await _userManager.GetRolesAsync(user);
				var userViewModel = _mapper.Map<AppUserViewModel>(user);
				userViewModel.Role = roles.FirstOrDefault(); 
				userViewModels.Add(userViewModel);
			}

			var HRManagers = userViewModels.Where(u => u.Role == "HRManager").ToList();
			return Ok(HRManagers);
		}




		[HttpGet("by-tc/{tCIdentityNumber}")]
        public IActionResult GetByTCIdentityNumber(string tCIdentityNumber)
        {

            var users = _userManager.Users.ToList();

            var user = users.FirstOrDefault(u => u.TCIdentityNumber == tCIdentityNumber);

            if (user == null)
                return NotFound("Kullanıcı bulunamadı.");

            var userViewModel = _mapper.Map<AppUserViewModel>(user);

            return Ok(userViewModel);


        }








        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            AppUser user = await _userManager.FindByIdAsync(id.ToString());

            if (user is null)
                return NotFound("Kullanıcı bulunamadı.");

            var roles = await _userManager.GetRolesAsync(user);

            var userViewModel = _mapper.Map<AppUserViewModel>(user);

            foreach (var item in roles)
            {
                userViewModel.Role = item;
            }

            return Ok(userViewModel);
        }



		[HttpGet("send-email")]
		public async Task<IActionResult> SendEmail(string userId, string password)
		{

			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return BadRequest("Invalid user ID");
			}

			await _userService.SendEmail(user.ConfirmationEmail , password);

	
			return Ok();
		}

        /// <summary>
        /// MVC'deki bize ulaşın form ekranı için oluşturulmuştur
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpGet("contact-email")]
        public async Task<IActionResult> SendEmail(string name, string email, string subject , string message)
        {

            await _userService.SendEmail(name,email,subject,message);

            return Ok();
        }


        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return BadRequest("User ID or token is missing");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest("Invalid user ID");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return Ok("Email confirmed successfully");
            }

            return BadRequest("Email confirmation failed");
        }


        [HttpPost]
        public async Task<IActionResult> Post(AppUserViewModel appUserViewModel)
        {
            var user = _mapper.Map<AppUser>(appUserViewModel);

            user.IsActive = true;
            user.EmailConfirmed = false; // Doğrulama maili göndereceğimiz için başlangıçta false
            user.PhoneNumberConfirmed = true;

            var baseUserName = appUserViewModel.UserName;


            //UserName Uniquelik icin
            var userExists = await _userManager.FindByNameAsync(baseUserName);
            int counter = 1;

            while (userExists is not null)
            {
                appUserViewModel.UserName = $"{baseUserName}{counter}";
                userExists = await _userManager.FindByNameAsync(appUserViewModel.UserName);

                counter++;
            }
            user.UserName = appUserViewModel.UserName; //UserName Uniqulik

            // Email Unique'lik kontrolü
            var emailParts = appUserViewModel.Email.Split('@');
            var emailLocalPart = emailParts[0];  
            var emailDomainPart = emailParts[1];

            var isUser = await _userManager.FindByEmailAsync(appUserViewModel.Email);
            int emailCounter = 1;

            while (isUser is not null)
            {
                appUserViewModel.Email = $"{emailLocalPart}{emailCounter}@{emailDomainPart}";
                isUser = await _userManager.FindByEmailAsync(appUserViewModel.Email);

                emailCounter++;
            }

            user.Email = appUserViewModel.Email; // Email Unique


            var hasher = new PasswordHasher<AppUser>();
            user.PasswordHash = hasher.HashPassword(user, appUserViewModel.Password);

            var result = await _userManager.CreateAsync(user, appUserViewModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, appUserViewModel.Role);

                // E-posta doğrulama işlemi için token oluşturma ve gönderme
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _userService.SendEmailConfirmationAsync(user.Id.ToString(), user.ConfirmationEmail, appUserViewModel.Password, token, user.Email);
                return Ok(user);
            }

            return BadRequest(result.Errors);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AppUserViewModel appUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user is null)
                return NotFound();

            appUserViewModel.Id = id;

            

            appUserViewModel.ImageName = string.IsNullOrWhiteSpace(appUserViewModel.ImageName) ? user.ImageName : appUserViewModel.ImageName;
            appUserViewModel.Email = string.IsNullOrWhiteSpace(appUserViewModel.Email) ? user.Email : appUserViewModel.Email;
            appUserViewModel.FirstName = string.IsNullOrWhiteSpace(appUserViewModel.FirstName) ? user.FirstName : appUserViewModel.FirstName;
            appUserViewModel.LastName = string.IsNullOrWhiteSpace(appUserViewModel.LastName) ? user.LastName : appUserViewModel.LastName;
            appUserViewModel.SecondName = string.IsNullOrWhiteSpace(appUserViewModel.SecondName) ? user.SecondName : appUserViewModel.SecondName;
            appUserViewModel.SecondLastName = string.IsNullOrWhiteSpace(appUserViewModel.SecondLastName) ? user.SecondLastName : appUserViewModel.SecondLastName;

            if (appUserViewModel.BirthDate == default(DateTime))
                appUserViewModel.BirthDate = user.BirthDate;

            appUserViewModel.BirthPlace = string.IsNullOrWhiteSpace(appUserViewModel.BirthPlace) ? user.BirthPlace : appUserViewModel.BirthPlace;
            appUserViewModel.TCIdentityNumber = string.IsNullOrWhiteSpace(appUserViewModel.TCIdentityNumber) ? user.TCIdentityNumber : appUserViewModel.TCIdentityNumber;

            if (appUserViewModel.HireDate == default(DateTime))
                appUserViewModel.HireDate = user.HireDate;

            if (appUserViewModel.TerminationDate == null)
                appUserViewModel.TerminationDate = user.TerminationDate;



            appUserViewModel.IsActive = appUserViewModel.IsActive == default(bool) && !user.IsActive ? user.IsActive : appUserViewModel.IsActive;

            appUserViewModel.JobTitle = string.IsNullOrWhiteSpace(appUserViewModel.JobTitle) ? user.JobTitle : appUserViewModel.JobTitle;
            appUserViewModel.Department = string.IsNullOrWhiteSpace(appUserViewModel.Department) ? user.Department : appUserViewModel.Department;
            appUserViewModel.CompanyName = string.IsNullOrWhiteSpace(appUserViewModel.CompanyName) ? user.CompanyName : appUserViewModel.CompanyName;
            appUserViewModel.Address = string.IsNullOrWhiteSpace(appUserViewModel.Address) ? user.Address : appUserViewModel.Address;

			appUserViewModel.ConfirmationEmail = string.IsNullOrWhiteSpace(appUserViewModel.ConfirmationEmail) ? user.ConfirmationEmail : appUserViewModel.ConfirmationEmail;

			if (appUserViewModel.Salary == default(double))
                appUserViewModel.Salary = user.Salary;


			

			_mapper.Map(appUserViewModel, user);


            if (!string.IsNullOrWhiteSpace(appUserViewModel.Password))
            {
                var hasher = new PasswordHasher<AppUser>();
                user.PasswordHash = hasher.HashPassword(user, appUserViewModel.Password);
            }



            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return Ok(user);

            return BadRequest(result.Errors);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
                return NotFound();

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
                return Ok();

            return BadRequest(result.Errors);

        }


        [HttpGet("UserStatusChange")]
        public async Task<IActionResult> UserStatusChange(int id, bool status)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            user.IsActive = status;
            user.TerminationDate = DateTime.Now;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return Ok();

            return BadRequest(result.Errors);

        }






    }
}
