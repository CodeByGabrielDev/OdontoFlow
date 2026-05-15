package com.odontoflow.odontoflow.Controller;

import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.odontoflow.odontoflow.RequestDtos.UserRequest;
import com.odontoflow.odontoflow.ResponseDtos.UserAndProfessionalResponse;
import com.odontoflow.odontoflow.Services.AuthService;

import lombok.RequiredArgsConstructor;

@RequiredArgsConstructor
@RequestMapping("/api-odontoflow/auth")
@RestController
public class AuthController {

    private final AuthService authService;

    @PostMapping("/register/")
    public UserAndProfessionalResponse registerProfessional(@RequestBody UserRequest userRequest) {
        return this.authService.registerProfessional(userRequest);
    }

}
