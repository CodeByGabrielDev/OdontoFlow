package com.odontoflow.odontoflow.Entities;

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

@Table
@Getter
@Entity
@Setter
@NoArgsConstructor
public class OdontogramTooth {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @ManyToOne
    @JoinColumn(name = "id_odontogram")
    private Odontogram odontogram;

    private Integer toothNumber;

    public OdontogramTooth(Odontogram odontogram, Integer toothNumber) {
        this.odontogram = odontogram;
        this.toothNumber = toothNumber;
    }



    
    

}
