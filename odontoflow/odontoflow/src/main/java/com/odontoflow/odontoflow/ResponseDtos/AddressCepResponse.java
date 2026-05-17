package com.odontoflow.odontoflow.ResponseDtos;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@JsonIgnoreProperties(ignoreUnknown = true)
public class AddressCepResponse {

    @JsonProperty("cep")
    private String zipCode;
    @JsonProperty("logradouro")
    private String street;
    @JsonProperty("complemento")
    private String complement;
    @JsonProperty("unidade")
    private String unit;
    @JsonProperty("bairro")
    private String district;
    @JsonProperty("localidade")
    private String city;
    @JsonProperty("uf")
    private String stateCode;
    @JsonProperty("estado")
    private String state;
    @JsonProperty("regiao")
    private String region;

}
