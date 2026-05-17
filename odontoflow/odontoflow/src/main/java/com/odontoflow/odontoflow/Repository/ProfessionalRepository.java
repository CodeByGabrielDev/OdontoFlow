package com.odontoflow.odontoflow.Repository;

import java.util.UUID;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import com.odontoflow.odontoflow.Entities.Professional;
import com.odontoflow.odontoflow.Entities.User;

@Repository
public interface ProfessionalRepository extends CrudRepository<Professional, UUID> {
    Professional findByCroUfAndCroNumero(String uf, String numero);

    Professional findByCpf(String cpf);

    
}
