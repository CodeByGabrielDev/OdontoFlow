package com.odontoflow.odontoflow.Config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.reactive.function.client.WebClient;

@Configuration
public class WebClientConfig {
    /*
     * https://viacep.com.br/ws/01001000/json/
     */

    /*
     * JSON da API externa, coletar apenas os atributos relevantes e injetar no
     * objeto pacietne caso seja informado o CEP
     * {
     * "cep": "89041-400",
     * "logradouro": "Rua Benedito Novo",
     * "complemento": "",
     * "unidade": "",
     * "bairro": "Água Verde",
     * "localidade": "Blumenau",
     * "uf": "SC",
     * "estado": "Santa Catarina",
     * "regiao": "Sul",
     * "ibge": "4202404",
     * "gia": "",
     * "ddd": "47",
     * "siafi": "8047"
     * }
     */
    @Bean
    public WebClient webClient(WebClient.Builder builder) {
        return builder.baseUrl("https://viacep.com.br/ws").build();
    }

}
