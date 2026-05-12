package com.odontoflow.odontoflow.RequestDtos;

import com.odontoflow.odontoflow.Entities.Professional;
import com.odontoflow.odontoflow.Enum.Roles;

import jakarta.persistence.Enumerated;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.validation.constraints.Size;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class UserRequest {
    private String username;
    @Size(min = 12)
    private String password;
    private Integer role;
}
