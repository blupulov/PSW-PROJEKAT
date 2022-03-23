using bolnica_back.DTOs;
using bolnica_back.GrpcServices;
using bolnica_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Services
{
    public class RecipeService
    {
        private readonly UserService userService;
        private readonly ReviewService reviewService;
        private readonly MakingRecipeService makeRecipeService;

        public RecipeService(UserService userService, ReviewService reviewService, MakingRecipeService makingRecipeService)
        {
            this.reviewService = reviewService;
            this.userService = userService;
            this.makeRecipeService = makingRecipeService;
        }

        public void MakeRecipe(MakeRecipeDto dto)
        {
            Review review = reviewService.FindReviewById(dto.ReviewId);
            User user = userService.FindUserById((long)review.UserId);

            MakeRecipeGrpcDto grpcDto = new MakeRecipeGrpcDto() { DrugName = dto.DrugName, Jmbg = user.Jmbg, Quantity = dto.DrugQuantity };
            makeRecipeService.SendMessageForRecipe(grpcDto);
        }
    }
}
