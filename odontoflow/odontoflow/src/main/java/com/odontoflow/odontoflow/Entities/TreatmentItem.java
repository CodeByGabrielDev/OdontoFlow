package com.odontoflow.odontoflow.Entities;

import java.util.UUID;

import org.hibernate.annotations.UuidGenerator;

import com.odontoflow.odontoflow.Enum.StatusTreatment;

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
public class TreatmentItem {
    @Id
    @GeneratedValue
    @UuidGenerator
    private UUID id;
    @ManyToOne
    @JoinColumn(name = "id_treatment")
    private Treatment treatment;
    @ManyToOne
    @JoinColumn(name = "id_procedure")
    private Procedure procedure;
    private Integer tooth;
    @Enumerated(EnumType.STRING)
    private StatusTreatment statusTreatment;
    
    private Double price;
    
}
