package com.odontoflow.odontoflow.RequestDtos;

import java.time.LocalDate;

import org.hibernate.validator.constraints.br.CPF;

import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class PatientRequest {
    @NotNull
    @NotBlank
    private String name;
    @NotNull
    @NotBlank
    @CPF
    private String cpf;
    @NotBlank
    @NotNull
    private LocalDate birth_Date;
    private String phone;
    @Email
    private String email;
    private String cep; // da pra fazer uma integração com API de CEP, bem simpkles...
}
