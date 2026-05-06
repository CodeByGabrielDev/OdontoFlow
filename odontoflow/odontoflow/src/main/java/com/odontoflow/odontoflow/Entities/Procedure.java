package com.odontoflow.odontoflow.Entities;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import org.hibernate.annotations.UuidGenerator;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Table
@Getter
@Setter
@NoArgsConstructor
public class Procedure {
    @Id
    @GeneratedValue
    @UuidGenerator
    private UUID id;

    private String name;

    private Double priceDefault;
    @OneToMany(mappedBy = "procedure")
    private List<TreatmentItem> treatmentItems = new ArrayList<>();
    @OneToMany(mappedBy = "procedure")
    private List<Commission> commissions = new ArrayList<>();

    public Procedure(String name, Double priceDefault) {
        this.name = name;
        this.priceDefault = priceDefault;
    }

    
}
