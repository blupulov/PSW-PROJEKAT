package com.example.apotekabek.grpcService;

import com.example.apotekabek.grpcDto.MakeRecipeDto;
import com.example.apotekabek.model.Recipe;
import com.example.apotekabek.service.RecipeService;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import org.springframework.beans.factory.annotation.Autowired;
import rs.ac.uns.ftn.grpc.RequestForRecipeMaking;
import rs.ac.uns.ftn.grpc.ResponseForRecipeMaking;
import rs.ac.uns.ftn.grpc.SpringRecipeMakingServiceGrpc;

@GrpcService
public class RecipeMakingService extends SpringRecipeMakingServiceGrpc.SpringRecipeMakingServiceImplBase {
    @Autowired
    private RecipeService recipeService;

    @Override
    public void makeRecipe(RequestForRecipeMaking req, StreamObserver<ResponseForRecipeMaking> res){
        System.out.println("Drug name: " + req.getDrugName() + ", JMBG: " + req.getJmbg()
                + ", quantity: " + req.getQuantity());

        Recipe recipe = recipeService.SaveRecipe(
                new MakeRecipeDto(req.getDrugName(), req.getJmbg(), req.getQuantity()));

        ResponseForRecipeMaking response;

        if(recipe == null)
            response = ResponseForRecipeMaking.newBuilder()
                    .setStatus("404")
                    .setMessage("Recipe is not created")
                    .build();
        else
            response = ResponseForRecipeMaking.newBuilder()
                    .setStatus("200")
                    .setMessage("Recipe is created")
                    .build();

        res.onNext(response);
        res.onCompleted();
    }
}
