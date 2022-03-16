using bolnica_back.DTOs;
using bolnica_back.Services;
using Microsoft.AspNetCore.Mvc;

namespace bolnica_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private readonly DrugService drugService;

        public DrugController(DrugService drugService)
        {
            this.drugService = drugService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(drugService.GetAll());
        }

        [HttpPost]
        public IActionResult Add(MakeDrugDTO dto)
        {
            drugService.Add(dto);
            return Ok();
        }
    }
}
