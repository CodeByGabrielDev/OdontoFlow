package com.odontoflow.odontoflow.RequestDtos;

import java.time.LocalDate;

public class PatientRequest {
    private String name;
    private String cpf;
    private LocalDate birth_Date;
    private String phone;
    private String email;
    private String cep; //da pra fazer uma integração com API de CEP, bem simpkles...
}
