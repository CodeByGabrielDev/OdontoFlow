package com.odontoflow.odontoflow.Repository;

import java.util.UUID;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.odontoflow.odontoflow.Entities.User;

@Repository
public interface UserRepository extends CrudRepository<User, UUID> {
    User findByUsername(String username);

    /*
     * SELECT
     * U.USERNAME,
     * P.EMAIL,
     * P.PHONE,
     * P.CPF
     * FROM USERS U
     * INNER JOIN PROFESSIONAL P
     * ON P.ID = U.ID_PROFESSIONAL
     */
    @Query("SELECT E FROM User E INNER JOIN E.professional P WHERE P.cpf = :cpf OR P.email = :email OR P.phone =:phone OR E.username = :username")
    User findByCpfOrEmailOrPhoneOrUsername(@Param("cpf") String cpf, @Param("email") String email,
            @Param("username") String username,
            @Param("phone") String phone);

}
