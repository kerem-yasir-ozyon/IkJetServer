using IkJet.BLL.Managers.Concrete;
using IkJet.Common.Enums;
using IkJet.ViewModel.Expense;
using IkJet.ViewModel.WorkOff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IkJet_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseManager _expenseManager;

        public ExpenseController(ExpenseManager expenseManager)
        {
            _expenseManager = expenseManager;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var list = _expenseManager.GetAll();
            var newList = list.Where(e => e.IsDeleted == false).ToList();
            return Ok(newList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var workOff = _expenseManager.Get(id);
            if (workOff == null)
            {
                return NotFound();
            }

            return Ok(workOff);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUserRequestList(int userId)
        {
            var viewModels = _expenseManager.GetByUserRequestList(userId);
            var newList = viewModels.Where(e => e.IsDeleted == false).ToList();
            if (!viewModels.Any())
            {
                return NotFound();
            }




            return Ok(newList);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ExpenseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            viewModel.ApprovalStatus = ApprovalStatus.Pending;


            _expenseManager.Add(viewModel);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ExpenseViewModel viewModel)
        {
            if (id != viewModel.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            viewModel.ApprovalStatus = ApprovalStatus.Pending;

            _expenseManager.Update(viewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _expenseManager.Delete(id);
            return NoContent();
        }
    }
}
