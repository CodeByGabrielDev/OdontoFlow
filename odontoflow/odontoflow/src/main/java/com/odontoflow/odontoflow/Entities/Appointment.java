package com.odontoflow.odontoflow.Entities;

import java.time.LocalDate;
import java.time.LocalDateTime;

import org.springframework.cglib.core.Local;

import com.odontoflow.odontoflow.Enum.StatusAppointment;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Table
@NoArgsConstructor
@Getter
@Setter
public class Appointment {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private LocalDateTime startAt;
    private LocalDateTime endAt;
    private StatusAppointment status;
    private String notes;
    private LocalDate createdAt;

    public Appointment(LocalDateTime startAt, LocalDateTime endAt, StatusAppointment status, String notes,
            LocalDate createdAt) {
        this.startAt = startAt;
        this.endAt = endAt;
        this.status = status;
        this.notes = notes;
        this.createdAt = createdAt;
    }

}
