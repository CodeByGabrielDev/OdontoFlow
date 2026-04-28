package com.odontoflow.odontoflow.Config;

import org.springframework.http.HttpStatus;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

import com.odontoflow.odontoflow.Entities.Professional;
import com.odontoflow.odontoflow.Repository.ProfessionalRepository;

import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class UsuariosLojaDetailsService implements UserDetailsService {

    private final ProfessionalRepository professionalRepository;

    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        Professional professional = this.professionalRepository.findByLogin(username);
        if (professional == null) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Profissional não encontrado");
        }
        return professional;
    }
}
