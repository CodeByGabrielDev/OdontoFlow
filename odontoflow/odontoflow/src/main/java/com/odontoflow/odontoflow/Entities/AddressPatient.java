package com.odontoflow.odontoflow.Entities;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import org.hibernate.annotations.UuidGenerator;

import com.fasterxml.jackson.annotation.JsonProperty;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
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
public class AddressPatient {
    @Id
    @GeneratedValue
    @UuidGenerator
    private UUID id;
    private String zipCode;
    private String street;
    private String complement;
    private String unit;
    private String district;
    private String city;
    private String stateCode;
    private String state;
    private String region;
    @OneToMany(mappedBy = "address", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<Patient> patient = new ArrayList<>();

    public AddressPatient(String zipCode, String street, String complement, String unit, String district, String city,
            String stateCode, String state, String region) {
        this.zipCode = zipCode;
        this.street = street;
        this.complement = complement;
        this.unit = unit;
        this.district = district;
        this.city = city;
        this.stateCode = stateCode;
        this.state = state;
        this.region = region;
    }

}
