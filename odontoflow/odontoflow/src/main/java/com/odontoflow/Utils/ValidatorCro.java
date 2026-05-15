package com.odontoflow.Utils;

import org.springframework.stereotype.Component;

import com.odontoflow.odontoflow.Entities.CroData;

public class ValidatorCro {

    public static CroData formatarCro(String croNaoFormatado) {

        if (croNaoFormatado == null) {
            return null;
        }

        croNaoFormatado = croNaoFormatado.trim().toUpperCase();

        if (croNaoFormatado.length() < 3) {
            return null;
        }

        String uf = croNaoFormatado.substring(0, 2);
        String numero = croNaoFormatado.substring(2);

        if (!ufValida(uf)) {
            return null;
        }

        if (!numeroValido(numero)) {
            return null;
        }
        System.out.println(new CroData(uf, numero).toString());
        return new CroData(uf, numero);
    }

    private static boolean ufValida(String uf) {

        String[] ufs = {
                "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO",
                "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI",
                "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"
        };

        for (String item : ufs) {
            if (item.equalsIgnoreCase(uf)) {
                return true;
            }
        }

        return false;
    }

    private static boolean numeroValido(String numero) {

        if (numero.isBlank()) {
            return false;
        }

        for (char c : numero.toCharArray()) {

            if (!Character.isDigit(c)) {
                return false;
            }
        }

        return true;
    }
}