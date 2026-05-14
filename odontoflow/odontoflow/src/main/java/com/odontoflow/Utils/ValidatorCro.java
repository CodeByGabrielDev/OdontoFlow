package com.odontoflow.Utils;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class ValidatorCro {

    public boolean validaCroFormatador(String croNaoFormatado) {

        Integer iterador = 0;
        String numeroCro = null;
        String uf = concatenaUf(iterador, croNaoFormatado);

        /*
         * VALIDACAO SE A UF É EXISTENTE
         * partição da String CroNaoFormatado coletando as duas primeiras casas
         * decimais, sendo 0 e 1
         * após isso é o numero do CRO que terá outra validacao
         * AC AL AP AM BA CE DF ES GO
         * MA MT MS MG PA PB PR PE PI
         * RJ RN RS RO RR SC SP SE TO
         */
        String[] UFs = {
                "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO",
                "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI",
                "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"
        };
        if (!apenasLetrasNaUf(uf)) {
            return false;
        }
        if (!existeaUfNoArray(UFs, uf)) {
            return false;
        }

        Integer iterador2 = 0;
        for (char c : croNaoFormatado.toCharArray()) {
            if (iterador2 < 2) {
                iterador2++;
            } else {
                if (Character.isAlphabetic(c)) {
                    return false;
                }
                if (ufCro != null) {
                    numeroCro += Character.toString(c).toUpperCase();
                } else {
                    numeroCro = Character.toString(c).toUpperCase();
                }
            }
        }

    }

    private boolean existeaUfNoArray(String[] ufs, String uf) {
        boolean found = false;

        for (int i = 0; i < ufs.length; i++) {
            if (uf.equalsIgnoreCase(ufs[i].toUpperCase())) {// breve validacao se no array de UFs bate a inforamcao
                                                            // quebrada anteriormente, se bater quer dizer que a UF
                                                            // existe, se nao, não.
                found = true;
                break;
            }
        }

        return found;
    }

    private String concatenaUf(Integer iterador, String croNaoFormatado) {
        String uf = null;
        for (char c : croNaoFormatado.toCharArray()) {
            if (iterador == 2) { // aq eu faço uma validacao se caso o iterador for = 2 quer dzier que ele chegou
                                 // no amxim ode casas no contexto de uma UF, passou disso da pau
                break;
            }
            if (uf != null) {
                uf += Character.toString(c).toUpperCase(); // aqui se a UFCRo for <> de null quer dizer que ja foi
                                                           // salvo a primeira letra da UF, entao eu só vou add a
                                                           // proxima String jogando para upperCase e padronizar
            } else {
                uf = Character.toString(c).toUpperCase(); // aqui encontra partida, senao for a primeira condicao
                                                          // quer dizer que ainda ta null e precisa pegar o primeiro
                                                          // caractere
            }
            iterador++;
        }
        return uf;
    }

    private boolean apenasLetrasNaUf(String uf) {
        for (char c : uf.toCharArray()) {
            if (!Character.isAlphabetic(c)) {
                return false;
            }
        }
        return true;
    }

}
