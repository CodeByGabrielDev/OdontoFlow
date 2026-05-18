package com.odontoflow.odontoflow.Entities;

import java.time.LocalDateTime;
import java.util.UUID;

import org.hibernate.annotations.UuidGenerator;

import jakarta.persistence.Column;
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
@Table(name = "anamnesis")
@Getter
@Setter
@NoArgsConstructor
public class Anamnesis {

    @Id
    @GeneratedValue
    @UuidGenerator
    private UUID id;
    @ManyToOne
    @JoinColumn(name = "id_patient")
    private Patient patient;
    @ManyToOne
    @JoinColumn(name = "id_professional")
    private Professional professional;
    private LocalDateTime createdAt;
    private Boolean diabetes;
    private Boolean hypertension;
    private Boolean heartDisease;
    private Boolean allergies;
    @Column(length = 1000)
    private String allergyDescription;
    private Boolean useMedication;
    @Column(length = 1000)
    private String medicationDescription;
    private Boolean pregnant;
    private Boolean smoker;
    private Boolean anticoagulants;
    private Boolean previousDentalTreatment;
    private Boolean badDentalExperience;
    private Boolean anesthesiaReaction;
    private Boolean gumBleeding;
    private Boolean toothSensitivity;
    private Boolean bruxism;
    private Boolean jawPain;
    private Boolean mouthSores;
    private Boolean dryMouth;
    private Boolean teethClenching;
    private Boolean orthodonticTreatment;
    private Boolean dentalProsthesis;
    private Boolean dentalImplant;
    private Integer brushingFrequencyPerDay;
    private Boolean flossingHabit;
    @Column(length = 1500)
    private String chiefComplaint;
    @Column(length = 3000)
    private String observations;
}