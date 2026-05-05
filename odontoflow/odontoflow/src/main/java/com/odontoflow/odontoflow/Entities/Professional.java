package com.odontoflow.odontoflow.Entities;

import java.util.ArrayList;
import java.util.List;

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
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String name;
    private String cro;
    private String phone;
    private String email;
    @OneToMany(mappedBy = "professional")
    private List<Appointment>appointments = new ArrayList<>();

    @OneToMany(mappedBy = "professional")
    private List<User> user = new ArrayList<>();

    public Professional(String name, String cro, String phone, String email) {
        this.name = name;
        this.cro = cro;
        this.phone = phone;
        this.email = email;
    }
}
