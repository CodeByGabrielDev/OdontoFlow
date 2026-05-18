package com.odontoflow.odontoflow.Repository;

import java.util.UUID;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.odontoflow.odontoflow.Entities.Patient;

@Repository
public interface PatientRepository extends CrudRepository<Patient, UUID> {
    /*
     * private String cpf;
     * private LocalDate birthDate;
     * private String phone;
     * private String email;
     */
    @Query("SELECT E FROM Patient E WHERE E.cpf = :cpf OR E.phone = :phone OR E.email = :email")
    Patient findByCpfOrPhoneOrEmail(@Param("cpf") String cpf, @Param("phone") String phone,
            @Param("email") String email);
}
