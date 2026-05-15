package com.odontoflow.odontoflow.Services;

import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

import com.odontoflow.Utils.ValidatorCro;
import com.odontoflow.Utils.ValidatorPassword;
import com.odontoflow.odontoflow.Config.HashSenha;
import com.odontoflow.odontoflow.Entities.CroData;
import com.odontoflow.odontoflow.Entities.Professional;
import com.odontoflow.odontoflow.Entities.User;
import com.odontoflow.odontoflow.Enum.Roles;
import com.odontoflow.odontoflow.Repository.ProfessionalRepository;
import com.odontoflow.odontoflow.RequestDtos.UserRequest;
import com.odontoflow.odontoflow.ResponseDtos.UserAndProfessionalResponse;

import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class AuthService {

    private final HashSenha hashSenha;
    private final ProfessionalRepository professionalRepository;

    public UserAndProfessionalResponse registerProfessional(UserRequest userRequest) {

        validatorBasicAttributes(userRequest);

        if (userRequest.getRole().equals(Roles.DENTIST)) {
            return instanceObjectDentist(userRequest);
        }

        Professional professional = new Professional(
                userRequest.getName(),
                null,
                userRequest.getCpf(),
                userRequest.getPhone(),
                userRequest.getEmail());

        User user = new User(
                userRequest.getUsername(),
                this.hashSenha.passwordEncoder().encode(userRequest.getPassword()),
                userRequest.getRole(),
                professional);

        professional.getUser().add(user);
        this.professionalRepository.save(professional);

        return new UserAndProfessionalResponse(
                user.getUsername(),
                user.getRole().toString(),
                professional.getCpf(),
                professional.getName(),
                null,
                professional.getPhone(),
                professional.getEmail());
    }

    private UserAndProfessionalResponse instanceObjectDentist(UserRequest userRequest) {

        validatorDentist(userRequest);

        CroData croData = ValidatorCro.formatarCro(userRequest.getCro());

        if (croData == null) {
            throw new ResponseStatusException(
                    HttpStatus.NOT_ACCEPTABLE,
                    "CRO inválido");
        }

        Professional professionalCro = professionalRepository
                .findByCroUfAndCroNumero(
                        croData.getUf(),
                        croData.getNumero());

        if (professionalCro != null) {
            throw new ResponseStatusException(
                    HttpStatus.CONFLICT,
                    "Já existe um profissional registrado com esse CRO");
        }

        Professional professional = new Professional(
                userRequest.getName(),
                croData,
                userRequest.getCpf(),
                userRequest.getPhone(),
                userRequest.getEmail());

        User user = new User(
                userRequest.getUsername(),
                this.hashSenha.passwordEncoder().encode(userRequest.getPassword()),
                userRequest.getRole(),
                professional);

        professional.getUser().add(user);
        this.professionalRepository.save(professional);

        return new UserAndProfessionalResponse(
                user.getUsername(),
                user.getRole().toString(),
                professional.getCpf(),
                professional.getName(),
                professional.getCro().getUf() + professional.getCro().getNumero(),
                professional.getPhone(),
                professional.getEmail());
    }

    private void validatorDentist(UserRequest userRequest) {

        if (userRequest.getCro() == null) {
            throw new ResponseStatusException(
                    HttpStatus.NOT_ACCEPTABLE,
                    "Caso seja dentista, deve informar o CRO");
        }
    }

    private void validatorBasicAttributes(UserRequest userRequest) {

        if (userRequest == null) {
            throw new ResponseStatusException(
                    HttpStatus.NOT_ACCEPTABLE,
                    "Usuário deve ser informado");
        }

        if (!ValidatorPassword.validarPwd(userRequest.getPassword())) {
            throw new ResponseStatusException(
                    HttpStatus.NOT_ACCEPTABLE,
                    "Senha não segue o padrão de política");
        }

        Professional professionalCpf = this.professionalRepository.findByCpf(userRequest.getCpf());

        if (professionalCpf != null) {
            throw new ResponseStatusException(
                    HttpStatus.CONFLICT,
                    "Já existe um profissional com esse CPF");
        }
    }
}