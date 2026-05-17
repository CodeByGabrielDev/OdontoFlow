package com.odontoflow.odontoflow.ResponseDtos;

import java.time.LocalDate;

import org.hibernate.validator.constraints.br.CPF;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class PatientResponse {
    private String name;
    private String cpf;
    private LocalDate birth_Date;
    private String phone;
    private String email;
    private AddressCepResponse addressCepResponse;
}
