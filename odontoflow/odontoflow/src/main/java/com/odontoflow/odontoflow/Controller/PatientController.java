package com.odontoflow.odontoflow.Controller;

import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.odontoflow.odontoflow.RequestDtos.PatientRequest;
import com.odontoflow.odontoflow.ResponseDtos.PatientResponse;
import com.odontoflow.odontoflow.Services.PatientService;

import lombok.RequiredArgsConstructor;

@RequiredArgsConstructor
@RestController
@RequestMapping("/api-odontoflow/patient")
public class PatientController {

    private final PatientService patientService;

    @PostMapping
    public PatientResponse registerPatient(@RequestBody PatientRequest patientRequest) {
        return this.patientService.registerPatient(patientRequest);
    }
}
