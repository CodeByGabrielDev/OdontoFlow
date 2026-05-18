package com.odontoflow.odontoflow.Entities;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import org.hibernate.annotations.UuidGenerator;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Table
@NoArgsConstructor
@Getter
@Setter
public class Patient {
    @Id
    @GeneratedValue
    @UuidGenerator
    private UUID id;
    private String name;
    private String cpf;
    private LocalDate birthDate;
    private String phone;
    private String email;
    private LocalDateTime createdAt;
    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "id_address")
    private AddressPatient address;
    @OneToMany(mappedBy = "patient")
    private List<Appointment> appointment = new ArrayList<>();
    @OneToMany(mappedBy = "patient")
    private List<Anamnesis> anamnesis = new ArrayList<>();
    @OneToMany(mappedBy = "patient")
    private List<Treatment> procedures = new ArrayList<>();
    @OneToMany(mappedBy = "patient")
    private List<Odontogram> odontograms = new ArrayList<>();
    @OneToMany(mappedBy = "patient")
    private List<MedicalRecord> medicalRecords = new ArrayList<>();
    @OneToMany(mappedBy = "patient")
    private List<FinancialEntry> financialEntries = new ArrayList<>();
    @OneToMany(mappedBy = "patient")
    private List<CampaignMessage> patients = new ArrayList<>();

    public Patient(String name, String cpf, LocalDate birthDate, String phone, String email, AddressPatient address,
            LocalDateTime createdAt) {
        this.name = name;
        this.cpf = cpf;
        this.birthDate = birthDate;
        this.phone = phone;
        this.email = email;
        this.address = address;
        this.createdAt = createdAt;
    }

}
