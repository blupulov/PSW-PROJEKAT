package com.example.apotekabek.service;

import com.example.apotekabek.grpcDto.MakeRecipeDto;
import com.example.apotekabek.model.Recipe;
import com.example.apotekabek.repository.RecipeRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class RecipeService {
    @Autowired
    private final RecipeRepository recipeRepository;

    public RecipeService(RecipeRepository recipeRepository){
        this.recipeRepository = recipeRepository;
    }

    public Recipe SaveRecipe(MakeRecipeDto dto){
        return recipeRepository.save(new Recipe(dto));
    }
}
