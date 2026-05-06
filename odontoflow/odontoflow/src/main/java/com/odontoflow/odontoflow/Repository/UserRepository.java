package com.odontoflow.odontoflow.Repository;

import java.util.UUID;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import com.odontoflow.odontoflow.Entities.User;

@Repository
public interface UserRepository extends CrudRepository<User, UUID> {
    User findByUsername(String username);
}
