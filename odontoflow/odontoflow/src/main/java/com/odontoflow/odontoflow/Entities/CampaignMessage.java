package com.odontoflow.odontoflow.Entities;

import java.time.LocalDateTime;
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
public class CampaignMessage {
    @Id
    @GeneratedValue
    @UuidGenerator
    private UUID id;
    @ManyToOne
    @JoinColumn(name = "id_campaign")
    private Campaign campaign;
    @ManyToOne
    @JoinColumn(name = "id_patient")
    private Patient patient;
    private LocalDateTime sentAt;

    public CampaignMessage(Campaign campaign, Patient patient, LocalDateTime sentAt) {
        this.campaign = campaign;
        this.patient = patient;
        this.sentAt = sentAt;
    }

}
