package com.odontoflow.odontoflow.Entities;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import org.hibernate.annotations.Collate;
import org.hibernate.annotations.UuidGenerator;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.Embedded;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Table(name = "professional")
@Getter
@Setter
@NoArgsConstructor
public class Professional {

    @Id
    @GeneratedValue
    @UuidGenerator
    private UUID id;
    private String name;
    @Column(unique = true)
    private String cpf;
    @Column(unique = true)
    private String phone;
    @Column(unique = true)
    private String email;
    @OneToMany(mappedBy = "professional")
    private List<Appointment> appointments = new ArrayList<>();
    @OneToMany(mappedBy = "professional")
    private List<Commission> commissions = new ArrayList<>();
    @OneToMany(mappedBy = "professional", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<User> user = new ArrayList<>();
    @Embedded
    private CroData cro;

    public Professional(String name, CroData croData, String cpf, String phone,
            String email) {
        this.name = name;
        this.cro = croData;
        this.cpf = cpf;
        this.phone = phone;
        this.email = email;
    }
}
