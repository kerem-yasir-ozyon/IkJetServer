using AutoMapper;
using IkJet.BLL.Managers.Concrete;
using IkJet.Common.Enums;
using IkJet.Entities.Concrete;
using IkJet.ViewModel.AppUser;
using IkJet.ViewModel.Expense;
using IkJet.ViewModel.Prepayment;
using IkJet.ViewModel.WorkOff;
using IkJet_Api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IkJet_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRManagerController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly PrepaymentManager _prepaymentManager;
        private readonly WorkOffManager _workOffManager;
        private readonly ExpenseManager _expenseManager;
		private IMapper _mapper;

		public HRManagerController(UserManager<AppUser> userManager, PrepaymentManager prepaymentManager, WorkOffManager workOffManager, ExpenseManager expenseManager, IMapper mapper)
		{
			_userManager = userManager;
			_prepaymentManager = prepaymentManager;
			_workOffManager = workOffManager;
			_expenseManager = expenseManager;
			_mapper = mapper;
		}

		[HttpGet("GetUsersByCompany")]
        public async Task<IActionResult> GetUsersByCompanyName(string companyName)
        {
            if (string.IsNullOrEmpty(companyName))
            {
                return BadRequest("Company name cannot be empty.");
            }

            var users = _userManager.Users.Where(u => u.CompanyName == companyName).ToList();

            if (users == null || !users.Any())
            {
                return NotFound("No users found for the given company name.");
            }
            await Console.Out.WriteLineAsync(users.Count.ToString());

            return Ok(users);
        }

       
        //-------------------------------------------
        [HttpGet("GetExpenseRequestsByCompany")]
        public async Task<IActionResult> GetExpenseRequestsByCompany(string companyName)
        {
            if (string.IsNullOrEmpty(companyName))
            {
                return BadRequest("Company name cannot be empty.");
            }

            var users = _userManager.Users.Where(u => u.CompanyName == companyName).ToList();
            if (users == null || !users.Any())
            {
                return NotFound("No users found for the given company name.");
            }

            var userIds = users.Select(u => u.Id).ToList();
            var expenses = new List<ExpenseRequestsByCompanyViewModel>();

            foreach (var userId in userIds)
            {
                var userExpenses = _expenseManager.GetByUserRequestList(userId)
                                                   .Where(e => !e.IsDeleted)
                                                   .ToList();

                foreach (var expense in userExpenses)
                {
                    var user = users.FirstOrDefault(u => u.Id == expense.AppUserId);
                    if (user != null)
                    {
                        expenses.Add(new ExpenseRequestsByCompanyViewModel
                        {
                            Id = expense.Id,
                            ExpenseType = expense.ExpenseType,
                            Amount = expense.Amount,
                            CurrencyType = expense.CurrencyType,
                            ImageName = expense.ImageName,
                            AppUserId = expense.AppUserId,
                            FirstName = user.FirstName, // Kullanıcı adı
                            LastName = user.LastName, // Kullanıcı soyadı
                            CompanyName = user.CompanyName, // Şirket adı
                            ApprovalStatus = expense.ApprovalStatus,
                            IsDeleted = expense.IsDeleted
                        });
                    }
                }
            }

            var filteredExpenses = expenses.Where(e => e.ApprovalStatus == ApprovalStatus.Pending);
            if (!filteredExpenses.Any())
            {
                return NotFound("No expense requests found for the given company.");
            }

            return Ok(filteredExpenses);
        }

        //-------------------------------------------

        [HttpGet("GetWorkOffRequestsByCompany")]
        public async Task<IActionResult> GetWorkOffRequestsByCompany(string companyName)
        {
            if (string.IsNullOrEmpty(companyName))
            {
                return BadRequest("Company name cannot be empty.");
            }

            var users = _userManager.Users.Where(u => u.CompanyName == companyName).ToList();
            if (users == null || !users.Any())
            {
                return NotFound("No users found for the given company name.");
            }

            var userIds = users.Select(u => u.Id).ToList();
            var workOffs = new List<WorkOffRequestsByCompanyViewModel>();

            foreach (var userId in userIds)
            {
                var userWorkOffs = _workOffManager.GetByUserRequestList(userId)
                                                   .Where(w => !w.IsDeleted)
                                                   .ToList();
                foreach (var workOff in userWorkOffs)
                {
                    var user = users.FirstOrDefault(u => u.Id == workOff.AppUserId);
                    if (user != null)
                    {
                        workOffs.Add(new WorkOffRequestsByCompanyViewModel
                        {
                            Id=workOff.Id,
                            FirstName=user.FirstName,
                            LastName=user.LastName,
                            CompanyName=user.CompanyName,
                            WorkOfType=workOff.WorkOfType,
                            StartDate=workOff.StartDate,
                            EndDate=workOff.EndDate,
                            RequestedLeaveDay=workOff.RequestedLeaveDay,
                            ApprovalStatus=workOff.ApprovalStatus,
                            IsDeleted=workOff.IsDeleted,
                        });
                    }
                }
            }
            var filteredWorkOff = workOffs.Where(e => e.ApprovalStatus == ApprovalStatus.Pending);


            if (!filteredWorkOff.Any())
            {
                return NotFound("No work off requests found for the given company.");
            }


            return Ok(filteredWorkOff);
        }
        //-------------------------------------------

        [HttpGet("GetPrepaymentRequestsByCompany")]
        public async Task<IActionResult> GetPrepaymentRequestsByCompany(string companyName)
        {
            if (string.IsNullOrEmpty(companyName))
            {
                return BadRequest("Company name cannot be empty.");
            }

            var users = _userManager.Users.Where(u => u.CompanyName == companyName).ToList();
            if (users == null || !users.Any())
            {
                return NotFound("No users found for the given company name.");
            }

            var userIds = users.Select(u => u.Id).ToList();
            var prepayments = new List<PrepaymentRequestsByCompanyViewModel>();

            foreach (var userId in userIds)
            {
                var userPrepayments = _prepaymentManager.GetByUserRequestList(userId)
                                                        .Where(p => !p.IsDeleted)
                                                        .ToList();
                foreach (var prepayment in userPrepayments)
                {
                    var user = users.FirstOrDefault(u => u.Id == prepayment.AppUserId);
                    if (user != null)
                    {
                        prepayments.Add(new PrepaymentRequestsByCompanyViewModel
                        {
                            Id = prepayment.Id,
                            FirstName=user.FirstName,
                            LastName=user.LastName,
                            CompanyName= user.CompanyName,
                            Amount=prepayment.Amount,
                            CurrencyType=prepayment.CurrencyType,
                            Description=prepayment.Description,
                            PrepaymentType=prepayment.PrepaymentType,
                            ApprovalStatus=prepayment.ApprovalStatus,
                            IsDeleted=prepayment.IsDeleted,
                        });
                    }
                }
            }
            var filteredPrepayment = prepayments.Where(e => e.ApprovalStatus == ApprovalStatus.Pending);

            if (!filteredPrepayment.Any())
            {
                return NotFound("No prepayment requests found for the given company.");
            }
            await Console.Out.WriteLineAsync(prepayments.Count.ToString());

            return Ok(filteredPrepayment);
        }

        


        [HttpGet("ExpenseStatusChange")]
        public async Task<IActionResult> ExpenseStatusChange(int id, ApprovalStatus newStatus)
        {
            var expense = _expenseManager.Get(id);

            expense.ApprovalStatus = newStatus;

            var model = _mapper.Map<ExpenseViewModel>(expense);

            _expenseManager.Update(model);

            return Ok(model);
        }


        [HttpGet("WorkOffStatusChange")]
        public async Task<IActionResult> WorkOffStatusChange(int id, ApprovalStatus newStatus)
        {
            var workOff = _workOffManager.Get(id);

            workOff.ApprovalStatus = newStatus;

            var model = _mapper.Map<WorkOffViewModel>(workOff);

            _workOffManager.Update(model);

            return Ok(model);
        }



        [HttpGet("PrePaymentStatusChange")]
        public async Task<IActionResult> PrePaymentStatusChange(int id, ApprovalStatus newStatus)
        {
            var prepayment = _prepaymentManager.Get(id);

            prepayment.ApprovalStatus = newStatus;

            var model = _mapper.Map<PrepaymentViewModel>(prepayment);

            _prepaymentManager.Update(model);

            return Ok(model);
        }


    }
}
