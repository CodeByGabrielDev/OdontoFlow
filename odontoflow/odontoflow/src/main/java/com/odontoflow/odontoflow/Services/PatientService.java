package com.odontoflow.odontoflow.Services;

import com.odontoflow.odontoflow.Controller.PatientController;
import java.net.http.HttpClient;
import java.time.LocalDateTime;

import org.springframework.http.HttpStatus;
import org.springframework.http.HttpStatusCode;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

import com.odontoflow.odontoflow.Entities.AddressPatient;
import com.odontoflow.odontoflow.Entities.Patient;
import com.odontoflow.odontoflow.Repository.PatientRepository;
import com.odontoflow.odontoflow.RequestDtos.PatientRequest;
import com.odontoflow.odontoflow.ResponseDtos.AddressCepResponse;
import com.odontoflow.odontoflow.ResponseDtos.PatientResponse;

import lombok.RequiredArgsConstructor;

@RequiredArgsConstructor
@Service
public class PatientService {

    private final ViaCepService viaCepService;

    private final PatientRepository patientRepository;

    public PatientResponse registerPatient(PatientRequest patientRequest) {
        if (patientRequest == null) {
            throw new ResponseStatusException(HttpStatus.CONFLICT, " o cadastro do cliente esta vazio");
        }

        Patient patientValidator = this.patientRepository.findByCpfOrPhoneOrEmail(patientRequest.getCpf(),
                patientRequest.getPhone(), patientRequest.getEmail());
        if (patientValidator != null) {
            throw new ResponseStatusException(HttpStatus.CONFLICT,
                    "informacoes ja informadas em outro paciente. CPF do paciente: " + patientValidator.getCpf());
        }
        /*
         * Construir uma validação para os atributos vindo do request, cliente pode
         * informar atributos NULL ocasionando em NPE abaixo na criação do objeto
         */
        Patient patient = new Patient(patientRequest.getName(), patientRequest.getCpf(), patientRequest.getBirth_Date(),
                patientRequest.getPhone(), patientRequest.getEmail(), null, LocalDateTime.now());

        if (patientRequest.getCep() != null) {
            AddressCepResponse addressCepResponse = this.viaCepService.findZipCode(patientRequest.getCep());
            System.out.println("CEP: " + patientRequest.getCep());

            System.out.println("CEP entitdade: " + addressCepResponse.toString());
            AddressPatient addressPatient = new AddressPatient();
            if (addressCepResponse != null) {
                helperInjectionCep(addressCepResponse, addressPatient);
            }
            addressPatient.getPatient().add(patient);
            patient.setAddress(addressPatient);
        }

        patientRepository.save(patient);
        return mountDto(patient);

    }

    private void validateAttributesInDtoRequest(PatientRequest patientRequest) {
        if (patientRequest.getBirth_Date() == null) {
            throw new ResponseStatusException(HttpStatus.NOT_ACCEPTABLE, " A data de nascimento não pode ser null");
        }
        if (patientRequest.getCep() == null) {
            throw new ResponseStatusException(HttpStatus.NOT_ACCEPTABLE, " O CEP deve ser preenchido");
        }
        if (patientRequest.getCpf() == null) {
            throw new ResponseStatusException(HttpStatus.NOT_ACCEPTABLE, " O Cpf nao pode ser null");
        }
        if (patientRequest.getEmail() == null) {
            throw new ResponseStatusException(HttpStatus.NOT_ACCEPTABLE, " O email nao pode ser null");
        }
        if (patientRequest.getName() == null) {
            throw new ResponseStatusException(HttpStatus.NOT_ACCEPTABLE, " O nome nao pode ser null");
        }
        if (patientRequest.getPhone() == null) {
            throw new ResponseStatusException(HttpStatus.NOT_ACCEPTABLE, " o telefone nao pode ser null");
        }
    }

    public PatientResponse mountDto(Patient patient) {
        PatientResponse patientResponse = new PatientResponse();
        if (patient.getAddress() != null) {
            helperAdressMountDto(patient, patientResponse);
        }
        if (patient.getPhone() != null) {
            patientResponse.setPhone(patient.getPhone());
        }
        if (patient.getBirthDate() != null) {
            patientResponse.setBirth_Date(patient.getBirthDate());
        }
        if (patient.getCpf() != null) {
            patientResponse.setCpf(patient.getCpf());
        }
        if (patient.getEmail() != null) {
            patientResponse.setEmail(patient.getEmail());
        }
        if (patient.getName() != null) {
            patientResponse.setName(patient.getName());
        }
        return patientResponse;
    }

    private void helperInjectionCep(AddressCepResponse addressCepResponse, AddressPatient addressPatient) {
        if (addressCepResponse.getCity() != null) {
            addressPatient.setCity(addressCepResponse.getCity());
        }
        if (addressCepResponse.getComplement() != null) {
            addressPatient.setComplement(addressCepResponse.getComplement());
        }
        if (addressCepResponse.getDistrict() != null) {
            addressPatient.setDistrict(addressCepResponse.getDistrict());
        }
        if (addressCepResponse.getRegion() != null) {
            addressPatient.setRegion(addressCepResponse.getRegion());
        }
        if (addressCepResponse.getState() != null) {
            addressPatient.setState(addressCepResponse.getState());
        }
        if (addressCepResponse.getStateCode() != null) {
            addressPatient.setStateCode(addressCepResponse.getStateCode());
        }
        if (addressCepResponse.getStreet() != null) {
            addressPatient.setStreet(addressCepResponse.getStreet());
        }
        if (addressCepResponse.getUnit() != null) {
            addressPatient.setUnit(addressCepResponse.getUnit());
        }
        if (addressCepResponse.getZipCode() != null) {
            addressPatient.setZipCode(addressCepResponse.getZipCode());
        }
    }

    private void helperAdressMountDto(Patient patient, PatientResponse patientResponse) {
        patientResponse.setAddressCepResponse(new AddressCepResponse());
        if (patient.getAddress() != null) {
            if (patient.getAddress().getCity() != null) {
                patientResponse.getAddressCepResponse().setCity(patient.getAddress().getCity());
            }
            if (patient.getAddress().getComplement() != null) {
                patientResponse.getAddressCepResponse().setComplement(patient.getAddress().getComplement());
            }
            if (patient.getAddress().getDistrict() != null) {
                patientResponse.getAddressCepResponse().setDistrict(patient.getAddress().getDistrict());
            }
            if (patient.getAddress().getRegion() != null) {
                patientResponse.getAddressCepResponse().setRegion(patient.getAddress().getRegion());
            }
            if (patient.getAddress().getState() != null) {
                patientResponse.getAddressCepResponse().setState(patient.getAddress().getState());
            }
            if (patient.getAddress().getStateCode() != null) {
                patientResponse.getAddressCepResponse().setStateCode(patient.getAddress().getStateCode());
            }
            if (patient.getAddress().getStreet() != null) {
                patientResponse.getAddressCepResponse().setStreet(patient.getAddress().getStreet());
            }
            if (patient.getAddress().getUnit() != null) {
                patientResponse.getAddressCepResponse().setUnit(patient.getAddress().getUnit());
            }
            if (patient.getAddress().getZipCode() != null) {
                patientResponse.getAddressCepResponse().setZipCode(patient.getAddress().getZipCode());
            }
        }

    }
}
