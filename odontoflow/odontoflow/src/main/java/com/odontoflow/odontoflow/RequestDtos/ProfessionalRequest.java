package com.odontoflow.odontoflow.RequestDtos;

import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.NonNull;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class ProfessionalRequest {
    @NotBlank(message = "deve ser preenchido o campo nome")
    private String name;
    private String cro;
    @NotBlank(message = "deve ser preenchido o campo telefone")
    private String phone;
    @NotBlank(message = "deve ser preenchido o campo telefone")
    @Email
    private String email;
}
