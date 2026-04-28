package com.odontoflow.odontoflow.Repository;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import com.odontoflow.odontoflow.Entities.Professional;

@Repository
public interface ProfessionalRepository extends CrudRepository<Professional, Long> {
    Professional findByCro(String cro);
}
