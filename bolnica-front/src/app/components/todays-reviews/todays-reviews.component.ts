import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DrugDTO } from 'src/app/Models/drugDTO';
import { RecipeDTO } from 'src/app/Models/recipeDTO';
import { ReviewDTO } from 'src/app/Models/reviewDTO';
import { DrugService } from 'src/app/services/drug.service';
import { RecipeService } from 'src/app/services/recipeService';
import { ReviewService } from 'src/app/services/review.service';

@Component({
  selector: 'app-todays-reviews',
  templateUrl: './todays-reviews.component.html',
  styleUrls: ['./todays-reviews.component.css']
})

export class TodaysReviewsComponent implements OnInit {

  reviews: ReviewDTO[] = new Array<ReviewDTO>();
  mod: string = 'neutral';
  allDrugs: DrugDTO[] = new Array<DrugDTO>();
  recipe: RecipeDTO = new RecipeDTO();

  constructor(private reviewService: ReviewService, private router: Router, 
    public recipeService: RecipeService, private drugService: DrugService) { }

  ngOnInit(): void {
    this.loadReviews();
  }

  loadReviews() {
    this.reviewService.getAllTodaysReviewsOfDoctor().subscribe(
      res => {
        this.reviews = res;
      }
    )
  }

  scheduleForSpecialist(id: number) {
    this.reviewService.selectedReviewId = id;
    this.router.navigateByUrl('/allSpecialists');
  }

  openRecipeForm(review: ReviewDTO){
    this.recipeService.selectedReview = review;
    this.recipe = new RecipeDTO();
    this.recipe.reviewId = review.id;
    this.loadAllDrugs();
    this.mod = 'recipe';
  }

  loadAllDrugs(){
    this.drugService.getAllDrugs().subscribe(
      res => {
        this.allDrugs = res;
      }
    )
  }

  onSubmitRecipe(){
    this.recipeService.saveRecipe(this.recipe).subscribe(
      res => {
        alert('Recipe is created');
        this.mod = 'neutral';
      },
      err => {
        alert('There is some error with server');
      }
    )
  }

  resetForm(){
    this.mod = 'neutral';
  }
}
