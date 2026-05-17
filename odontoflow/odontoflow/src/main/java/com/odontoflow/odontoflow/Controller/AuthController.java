package com.odontoflow.odontoflow.Controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
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

    @PostMapping("/register")
    public UserAndProfessionalResponse registerProfessional(@RequestBody UserRequest userRequest) {
        return this.authService.registerProfessional(userRequest);
    }

    @GetMapping("/login")
    public String loginAuth(@RequestParam String username, @RequestParam String pwd) {
        return this.authService.loginAuth(username, pwd);
        /*
         * eyJhbGciOiJIUzI1NiJ9.
         * eyJzdWIiOiJnYWJyaWVsLm9saXZlaXJhMSIsInJvbGUiOiJERU5USVNUIiwicHJvZmVzc2lvbmFsSWQiOiJlMDRhMjY1NC00YWMzLTRjZGItYjUxMy1hM2RjYWVlZDJlOWMiLCJpYXQiOjE3NzkwMjk2MTksImV4cCI6MTc3OTAzMzIxOX0
         * .tg1OY04H3LZ9d1kp3IyoOgBK3VvWA9T8qcOVC4MHjlU -- TOKEN GERADO
         */
    }
}
