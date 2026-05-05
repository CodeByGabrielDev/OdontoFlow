package com.odontoflow.odontoflow.Entities;

import java.time.LocalDateTime;

import jakarta.persistence.Entity;
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
public class Anamnesis {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @ManyToOne
    @JoinColumn(name = "id_patient")
    private Patient patient;

    private String answers; //JSON AQUI EM 

    private LocalDateTime createdAt;

    public Anamnesis(Patient patient, String answers, LocalDateTime createdAt) {
        this.patient = patient;
        this.answers = answers;
        this.createdAt = createdAt;
    }


    
}
