package com.odontoflow.odontoflow.Entities;

import java.time.LocalDateTime;
import java.util.UUID;

import org.hibernate.annotations.UuidGenerator;

import com.odontoflow.odontoflow.Enum.TypeMovement;

import jakarta.persistence.Entity;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
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
public class StockMovement {
    @Id
    @GeneratedValue
    @UuidGenerator
    private UUID id;
    @ManyToOne
    @JoinColumn(name = "id_product")
    private Product product;
    @Enumerated(EnumType.STRING)
    private TypeMovement typeMovement;
    private Integer quantity;

    private LocalDateTime createdAt;

    public StockMovement(Product product, TypeMovement typeMovement, Integer quantity, LocalDateTime createdAt) {
        this.product = product;
        this.typeMovement = typeMovement;
        this.quantity = quantity;
        this.createdAt = createdAt;
    }

}
