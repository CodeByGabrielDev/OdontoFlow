package com.odontoflow.odontoflow.ResponseDtos;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class ProfessionalResponse {
    private String name;
    private String cro;
    private String phone;
    private String email;
}
