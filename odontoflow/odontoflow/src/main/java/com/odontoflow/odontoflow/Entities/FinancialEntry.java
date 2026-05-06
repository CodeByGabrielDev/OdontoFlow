package com.odontoflow.odontoflow.Entities;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import org.hibernate.annotations.UuidGenerator;

import com.odontoflow.odontoflow.Enum.StatusFinancialEntry;
import com.odontoflow.odontoflow.Enum.TypeFinancialEntry;

import jakarta.persistence.Entity;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Table(name = "financial_entry")
@Entity
@Getter
@Setter
@NoArgsConstructor
public class FinancialEntry {

    @Id
    @GeneratedValue
    @UuidGenerator
    private UUID id;
    /*
     * - id
     * - type (RECEIVABLE, PAYABLE)
     * - patientId (nullable)
     * - description
     * - amount
     * - dueDate
     * - status (PENDING, PAID, OVERDUE)
     * - createdAt
     */
    @Enumerated(EnumType.STRING)
    private TypeFinancialEntry typeFinancialEntry;
    @ManyToOne
    @JoinColumn(name = "id_patient")
    private Patient patient;

    private String description;

    private Double amount;

    private LocalDate dueDate;
    @Enumerated(EnumType.STRING)
    private StatusFinancialEntry financialEntry;

    private LocalDateTime createdAt;
    @OneToMany(mappedBy = "financialEntry")
    private List<Payment>payments = new ArrayList<>();

    public FinancialEntry(TypeFinancialEntry typeFinancialEntry, Patient patient, String description, Double amount,
            LocalDate dueDate, StatusFinancialEntry financialEntry, LocalDateTime createdAt) {
        this.typeFinancialEntry = typeFinancialEntry;
        this.patient = patient;
        this.description = description;
        this.amount = amount;
        this.dueDate = dueDate;
        this.financialEntry = financialEntry;
        this.createdAt = createdAt;
    }

}
