package com.odontoflow.odontoflow.Entities;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import org.hibernate.annotations.UuidGenerator;

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
@Table
@Getter
@Setter
@NoArgsConstructor
public class Product {

    @Id
    @GeneratedValue
    @UuidGenerator
    private UUID id;
    private String name;

    private Integer quantity;

    private Integer minStock;

    private Double cost;
    @OneToMany(mappedBy = "product")
    private List<StockMovement> stockMovements = new ArrayList<>();

    public Product(String name, Integer quantity, Integer minStock, Double cost) {
        this.name = name;
        this.quantity = quantity;
        this.minStock = minStock;
        this.cost = cost;
    }

}
