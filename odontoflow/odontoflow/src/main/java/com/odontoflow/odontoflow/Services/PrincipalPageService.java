package com.odontoflow.odontoflow.Services;

import org.springframework.http.HttpStatus;
import org.springframework.http.HttpStatusCode;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

import com.odontoflow.Utils.ValidatorPassword;
import com.odontoflow.odontoflow.Config.HashSenha;
import com.odontoflow.odontoflow.Entities.Professional;
import com.odontoflow.odontoflow.Entities.User;
import com.odontoflow.odontoflow.Repository.PatientRepository;
import com.odontoflow.odontoflow.Repository.ProfessionalRepository;
import com.odontoflow.odontoflow.RequestDtos.UserRequest;

import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class PrincipalPageService {

    private final HashSenha hashSenha;
    private final ProfessionalRepository professionalRepository;

    private void registerProfessional(UserRequest userRequest) {
        if (userRequest == null) {
            throw new ResponseStatusException(HttpStatus.NOT_ACCEPTABLE, " usuario deve ser informado.");
        }
        Professional professionalCro = this.professionalRepository.findByCro(userRequest.getCro());
        Professional professionalCpf = this.professionalRepository.findByCpf(userRequest.getCpf());
        if (professionalCpf != null) {
            throw new ResponseStatusException(HttpStatus.CONFLICT,
                    " Ja existe um profissional registrado com esse CPF");
        }
        if (professionalCro != null) {
            throw new ResponseStatusException(HttpStatus.CONFLICT,
                    " ja existe um profissional registrado com esse CRO");
        }
        if (!ValidatorPassword.validarPwd(userRequest.getPassword())) {
            throw new ResponseStatusException(HttpStatus.NOT_ACCEPTABLE, " senha não seguindo o padrao de politica.");
        }

    }

    private void loginProfessional() {

    }
}
