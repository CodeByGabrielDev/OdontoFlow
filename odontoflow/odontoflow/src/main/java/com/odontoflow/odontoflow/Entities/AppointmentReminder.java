package com.odontoflow.odontoflow.Entities;

import java.time.LocalDateTime;
import java.util.UUID;

import org.hibernate.annotations.UuidGenerator;

import com.odontoflow.odontoflow.Enum.TypeReminder;

import jakarta.persistence.Entity;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Table(name = "appointment_reminder")
@Getter
@Setter
@NoArgsConstructor
public class AppointmentReminder {
    @Id
    @GeneratedValue
    @UuidGenerator
    private UUID id;
    @ManyToOne
    @JoinColumn(name = "id_appointment")
    private Appointment appointment;
    @Enumerated(EnumType.STRING)
    private TypeReminder typeReminder;

    private LocalDateTime sendAt;

    public AppointmentReminder(Appointment appointment, TypeReminder typeReminder, LocalDateTime sendAt) {
        this.appointment = appointment;
        this.typeReminder = typeReminder;
        this.sendAt = sendAt;
    }


    
}
