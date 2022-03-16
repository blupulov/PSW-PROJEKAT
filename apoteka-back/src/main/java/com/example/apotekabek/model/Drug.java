package com.example.apotekabek.model;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;

@Entity
@Getter
@Setter
@NoArgsConstructor
public class Drug {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "drug_id", nullable = false)
    private long id;

    @Column(name = "drug_name", nullable = false, unique = true)
    private String name;

    @Column(name="drug_quantity", nullable = false)
    private int quantity;
}
