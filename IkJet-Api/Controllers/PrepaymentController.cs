using IkJet.BLL.Managers.Concrete;
using IkJet.Common.Enums;
using IkJet.ViewModel.Prepayment;
using IkJet.ViewModel.WorkOff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IkJet_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrepaymentController : ControllerBase
    {
        private readonly PrepaymentManager _prepaymentManager;

        public PrepaymentController(PrepaymentManager prepaymentManager)
        {
            _prepaymentManager = prepaymentManager;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var list = _prepaymentManager.GetAll();
            var newList = list.Where(w => w.IsDeleted == false).ToList();
            return Ok(newList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var workOff = _prepaymentManager.Get(id);
            if (workOff == null)
            {
                return NotFound();
            }

            return Ok(workOff);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUserRequestList(int userId)
        {
            var viewModels = _prepaymentManager.GetByUserRequestList(userId);
            var newList = viewModels.Where(w => w.IsDeleted == false).ToList();

            if (!viewModels.Any())
            {
                return NotFound();
            }




            return Ok(newList);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PrepaymentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            viewModel.ApprovalStatus = ApprovalStatus.Pending;


            _prepaymentManager.Add(viewModel);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PrepaymentViewModel viewModel)
        {
            if (id != viewModel.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            viewModel.ApprovalStatus=ApprovalStatus.Pending;
            _prepaymentManager.Update(viewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _prepaymentManager.Delete(id);
            return NoContent();
        }
    }
}
