package com.example.apotekabek.service;

import com.example.apotekabek.grpcDto.RequestForDrugPurchaseDto;
import com.example.apotekabek.model.Drug;
import com.example.apotekabek.repository.DrugRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class DrugService {
    @Autowired
    private final DrugRepository drugRepository;

    public DrugService(DrugRepository drugRepository){
        this.drugRepository = drugRepository;
    }

    public List<Drug> FindAll(){
        return drugRepository.findAll();
    }

    public Drug FindByName(String name){
        return drugRepository.findDrugByName(name);
    }

    public boolean processRequestForDrugPurchase(RequestForDrugPurchaseDto dto) {
        Drug drug = drugRepository.findDrugByName(dto.getDrugName());

        if(drug == null)
            return false;

        if(drug.getQuantity() >= dto.getDrugQuantity()){
            drug.setQuantity(drug.getQuantity() - dto.getDrugQuantity());
            drugRepository.save(drug);
            return true;
        }

        return false;
    }
}
