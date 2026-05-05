package com.odontoflow.odontoflow.Entities;

import com.odontoflow.odontoflow.Enum.StatusTreatment;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
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
public class Treatment {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @ManyToOne
    @JoinColumn(name = "id_patient")
    private Patient patient;
    @Enumerated(EnumType.STRING)
    private StatusTreatment statusTreatment;
    @Column(name = "total_value")
    private Double totalValue;
    public Treatment(Patient patient, StatusTreatment statusTreatment, Double totalValue) {
        this.patient = patient;
        this.statusTreatment = statusTreatment;
        this.totalValue = totalValue;
    }

    

}
