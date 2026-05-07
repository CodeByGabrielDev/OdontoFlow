package com.odontoflow.odontoflow.Client;

import org.springframework.stereotype.Service;
import org.springframework.web.reactive.function.client.WebClient;

import com.odontoflow.odontoflow.ResponseDtos.AddressCepResponse;

import lombok.RequiredArgsConstructor;
import reactor.core.publisher.Mono;

@RequiredArgsConstructor
@Service
public class ViaCepClient {

    private final WebClient webClient;

    public Mono<AddressCepResponse> findByCep(String cep) {
        return this.webClient.get().uri("/{cep}/json", cep).retrieve().bodyToMono(AddressCepResponse.class);
    }
}
