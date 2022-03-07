using bolnica_back.DTOs;
using bolnica_back.Model;
using bolnica_back.Services;
using Microsoft.AspNetCore.Mvc;

namespace bolnica_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly SurveyService surveyService;

        public SurveyController(SurveyService surveyService)
        {
            this.surveyService = surveyService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(surveyService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            return Ok(surveyService.FindById(id));
        }

        [HttpGet("isTime/{userId}")] 
        public IActionResult IsTimeForSurvey(long userId)
        {
            return Ok();
        }

        [HttpGet("published")]
        public IActionResult GetAllPublishedSurveys()
        {
            return Ok(surveyService.GetAllPublishedSurveys());
        }

        [HttpPost]
        public IActionResult Create(CreateSurveyDTO dto)
        {
            surveyService.Create(new Survey(dto));
            return Ok();
        }

        [HttpPut("publish/{id}")]
        public IActionResult PublishSurvey(long id)
        {
            surveyService.PublishSurvey(id);
            return Ok();
        }

        [HttpPut("unpublish/{id}")]
        public IActionResult UnPublishSurvey(long id)
        {
            surveyService.UnPublishSurvey(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            surveyService.Delete(id);
            return Ok();
        }
    }
}
