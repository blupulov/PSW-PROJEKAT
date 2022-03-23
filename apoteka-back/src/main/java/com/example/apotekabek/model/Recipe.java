package com.example.apotekabek.model;

import com.example.apotekabek.grpcDto.MakeRecipeDto;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;

@Entity
@Getter
@Setter
@NoArgsConstructor
public class Recipe {
    @Id
    @SequenceGenerator(name = "mySeqGenRecipe", sequenceName = "mySeqRecipe", initialValue = 100, allocationSize = 1)
    @GeneratedValue(generator = "mySeqGenRecipe")
    @Column(name = "recipe_id", nullable = false)
    private long id;

    @Column(nullable = false)
    private String jmbg;

    @Column(nullable = false)
    private int quantity;

    @Column(nullable = false)
    private String drugName;

    @Column(nullable = false)
    private boolean issued = false;

    public Recipe(MakeRecipeDto dto){
        this.jmbg = dto.getJmbg();
        this.quantity = dto.getQuantity();
        this.drugName = dto.getDrugName();
        this.issued = false;
    }
}
