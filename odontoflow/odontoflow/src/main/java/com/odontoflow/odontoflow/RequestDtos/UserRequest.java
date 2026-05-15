package com.odontoflow.odontoflow.RequestDtos;

import org.hibernate.validator.constraints.br.CPF;

import com.odontoflow.odontoflow.Entities.Professional;
import com.odontoflow.odontoflow.Enum.Roles;

import jakarta.persistence.Enumerated;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
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
    @NotBlank(message = "o nome username deve ser preenchido")
    @Size(min = 4, max = 30)
    private String username;
    @NotBlank(message = " A senha deve ser preenchida")
    @Size(min = 12)
    private String password;
    @NotBlank
    @NotNull
    private Roles role;
    @CPF
    @NotBlank
    private String cpf;
    @NotBlank(message = "deve ser preenchido o campo nome")
    private String name;
    private String cro;
    @NotBlank(message = "deve ser preenchido o campo telefone")
    private String phone;
    @NotBlank(message = "deve ser preenchido o campo telefone")
    @Email
    private String email;
}
