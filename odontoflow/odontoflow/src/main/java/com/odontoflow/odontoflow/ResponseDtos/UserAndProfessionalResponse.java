package com.odontoflow.odontoflow.ResponseDtos;

import org.hibernate.validator.constraints.br.CPF;

import com.odontoflow.odontoflow.Enum.Roles;

import jakarta.validation.constraints.Size;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class UserAndProfessionalResponse {
    private String username;
    private String role;
    private String cpf;
    private String name;
    private String cro;
    private String phone;
    private String email;
}
