package com.example.apotekabek.grpcDto;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
public class MakeRecipeDto {
    private String drugName;
    private String jmbg;
    private int quantity;

    public MakeRecipeDto(String drugName, String jmbg, int quantity){
        this.drugName = drugName;
        this.jmbg = jmbg;
        this.quantity = quantity;
    }
}
