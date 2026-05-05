package com.odontoflow.odontoflow.Entities;

import java.util.UUID;

import org.hibernate.annotations.UuidGenerator;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Table
@Getter
@Setter
@NoArgsConstructor
public class Commission {
    @Id
    @GeneratedValue
    @UuidGenerator
    private UUID id;
    @ManyToOne
    @JoinColumn(name = "id_professional")
    private Professional professional;
    @ManyToOne
    @JoinColumn(name = "id_procedure")
    private Procedure procedure;
    private  Double percent;
    private Double amount;

    public Commission(Professional professional, Procedure procedure, Double percent, Double amount) {
        this.professional = professional;
        this.procedure = procedure;
        this.percent = percent;
        this.amount = amount;
    }

    
}
