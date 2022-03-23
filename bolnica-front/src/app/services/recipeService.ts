import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { RecipeDTO } from "../Models/recipeDTO";
import { ReviewDTO } from "../Models/reviewDTO";

@Injectable({
  providedIn: 'root'
})

export class RecipeService {
  
  private apiServerUrl = 'http://localhost:31236/api/recipe';

  selectedReview: ReviewDTO = new ReviewDTO();
  
  public constructor (private http: HttpClient) { }

  saveRecipe(recipe: RecipeDTO) {
    return this.http.post(this.apiServerUrl + '/makeRecipe', recipe);
  }

}