package com.example.apotekabek.grpcDto;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
public class RequestForDrugPurchaseDto {
    String drugName;
    int drugQuantity;

    public RequestForDrugPurchaseDto(String drugName, int drugQuantity){
        this.drugName = drugName;
        this.drugQuantity = drugQuantity;
    }

}
