package com.odontoflow.odontoflow.Entities;

import java.util.UUID;

import org.hibernate.annotations.UuidGenerator;

import com.odontoflow.odontoflow.Enum.SourceLead;
import com.odontoflow.odontoflow.Enum.StatusLead;

import jakarta.persistence.Entity;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Table
@Getter
@NoArgsConstructor
@Setter
public class Lead {

    @Id
    @GeneratedValue
    @UuidGenerator
    private UUID id;
    private String name;
    private String phone;
    @Enumerated(EnumType.STRING)
    private SourceLead sourceLead;
    @Enumerated(EnumType.STRING)
    private StatusLead statusLead;
    public Lead(String name, String phone, SourceLead sourceLead, StatusLead statusLead) {
        this.name = name;
        this.phone = phone;
        this.sourceLead = sourceLead;
        this.statusLead = statusLead;
    }

    
}
