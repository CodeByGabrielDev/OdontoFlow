package com.odontoflow.odontoflow.Services;

import org.springframework.stereotype.Service;

import com.odontoflow.odontoflow.Client.ViaCepClient;
import com.odontoflow.odontoflow.ResponseDtos.AddressCepResponse;

import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class ViaCepService {

    private final ViaCepClient viaCepClient;

    public AddressCepResponse findZipCode(String zipCode) {
        return this.viaCepClient.findByCep(zipCode).block();
    }
}
