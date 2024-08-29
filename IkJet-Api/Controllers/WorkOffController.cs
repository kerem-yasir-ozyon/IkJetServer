using IkJet.BLL.Managers.Concrete;
using IkJet.Common.Enums;
using IkJet.DAL.Services.Concrete;
using IkJet.Entities.Concrete;
using IkJet.ViewModel.AppUser;
using IkJet.ViewModel.WorkOff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IkJet_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOffController : ControllerBase
    {
        private readonly WorkOffManager _workOffManager;


        public WorkOffController(WorkOffManager workOffManager, UserManager<AppUser> userManager)
        {
            _workOffManager = workOffManager;
            
        }

        [HttpGet]
        public IActionResult Get()
        {
           var list = _workOffManager.GetAll();
            var newList = list.Where(w=>w.IsDeleted==false).ToList();
            return Ok(newList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var workOff = _workOffManager.Get(id);
            if (workOff == null)
            {
                return NotFound();
            }

            return Ok(workOff);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUserRequestList(int userId)
        {
            var viewModels = _workOffManager.GetByUserRequestList(userId);
            var newList = viewModels.Where(w => w.IsDeleted == false).ToList();
            if (!viewModels.Any())
            {
                return NotFound();
            }

           


            return Ok(newList);
        }

        [HttpPost]
        public IActionResult Post([FromBody] WorkOffViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            viewModel.ApprovalStatus = ApprovalStatus.Pending;

            
            _workOffManager.Add(viewModel); 

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WorkOffViewModel viewModel)
        {
            if (id != viewModel.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            viewModel.ApprovalStatus = ApprovalStatus.Pending;

            _workOffManager.Update(viewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _workOffManager.Delete(id);
            return NoContent();
        }
    }
}
