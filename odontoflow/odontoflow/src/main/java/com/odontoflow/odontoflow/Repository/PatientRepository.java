package com.odontoflow.odontoflow.Repository;

import java.util.UUID;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import com.odontoflow.odontoflow.Entities.Patient;

@Repository
public interface PatientRepository extends CrudRepository<Patient, UUID> {

}
