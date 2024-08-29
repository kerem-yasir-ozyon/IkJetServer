using IkJet.BLL.Managers.Concrete;
using IkJet.Common.Enums;
using IkJet.Entities.Concrete;
using IkJet.ViewModel.Company;
using IkJet.ViewModel.Expense;
using Microsoft.AspNetCore.Mvc;

namespace IkJet_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyManager _companyManager;

        public CompanyController(CompanyManager companyManager)
        {
            _companyManager = companyManager;
        }

        

        [HttpPost]
        public IActionResult Post([FromBody] CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _companyManager.Add(companyViewModel);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CompanyViewModel companyViewModel)
        {
            if (id != companyViewModel.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _companyManager.Update(companyViewModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _companyManager.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = _companyManager.GetAll();
            var newList = list.Where(e => e.IsDeleted == false).ToList();
            return Ok(newList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var company = _companyManager.Get(id);
            return Ok(company);
        }

        [HttpGet("by-taxnumber/{taxNumber}")]
        public IActionResult GetByTaxNumber(string taxNumber)
        {
            var list = _companyManager.GetAll();
            var company = list.FirstOrDefault(c => c.TaxNumber == taxNumber);
            return Ok(company);
        }


        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            var list = await _companyManager.GetAllAsync();
            var newList = list.Where(e => e.IsDeleted == false).ToList();
            return Ok(newList);
        }




    }
}
