package com.odontoflow.odontoflow.Entities;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import org.hibernate.annotations.UuidGenerator;

import com.odontoflow.odontoflow.Enum.CampaignType;

import jakarta.persistence.Entity;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import jakarta.persistence.GeneratedValue;
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
public class Campaign {

    @Id
    @GeneratedValue
    @UuidGenerator
    private UUID id;
    private String name;
    @Enumerated(EnumType.STRING)
    private CampaignType campaignType;
    private LocalDateTime createdAt;
    @OneToMany(mappedBy = "campaign")
    private List<CampaignMessage>campaignMessages = new ArrayList<>();

    public Campaign(String name, CampaignType campaignType, LocalDateTime createdAt) {
        this.name = name;
        this.campaignType = campaignType;
        this.createdAt = createdAt;
    }

}
