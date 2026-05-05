package com.odontoflow.odontoflow.Entities;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

import org.springframework.cglib.core.Local;

import com.odontoflow.odontoflow.Enum.StatusAppointment;

import jakarta.persistence.Entity;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
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
public class Appointment {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @ManyToOne
    @JoinColumn(name = "id_patient")
    private Patient patient;
    @ManyToOne
    @JoinColumn(name = "id_professional")
    private Professional professional;
    @OneToMany(mappedBy = "id_appointment_reminder")
    private List<AppointmentReminder> appointmentReminer = new ArrayList<>();
    private LocalDateTime startAt;
    private LocalDateTime endAt;
    @Enumerated(EnumType.STRING)
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
