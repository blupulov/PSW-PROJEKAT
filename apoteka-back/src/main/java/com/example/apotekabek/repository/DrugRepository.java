package com.example.apotekabek.repository;

import com.example.apotekabek.model.Drug;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

public interface DrugRepository extends JpaRepository<Drug, Long> {

    @Query("select d from Drug d where d.name = ?1")
    Drug findDrugByName(String name);
}
