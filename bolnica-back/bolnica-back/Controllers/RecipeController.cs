using bolnica_back.DTOs;
using bolnica_back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeService recipeService;

        public RecipeController(RecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpPost("makeRecipe")]
        public IActionResult MakeRecipe(MakeRecipeDto dto)
        {
            recipeService.MakeRecipe(dto);
            return Ok();
        }
    }
}
