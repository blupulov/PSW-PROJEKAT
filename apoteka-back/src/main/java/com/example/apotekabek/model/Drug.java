package com.example.apotekabek.model;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;

@Entity
@Getter
@Setter
@NoArgsConstructor
@Table(name = "Drug")
public class Drug {
    @Id
    @SequenceGenerator(name = "mySeqGenDrug", sequenceName = "mySeq", initialValue = 100, allocationSize = 1)
    @GeneratedValue(generator = "mySeqGenDrug")
    @Column(name = "drug_id", nullable = false)
    private long id;

    @Column(name = "drug_name", nullable = false, unique = true)
    private String name;

    @Column(name="drug_quantity", nullable = false)
    private int quantity;

    public Drug(String name, int quantity){
        this.name = name;
        this.quantity = quantity;
    }
}
