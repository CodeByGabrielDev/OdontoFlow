package com.odontoflow.Utils;

public class ValidatorPassword {

    public static boolean validarPwd(String password) {
        boolean temNumero = false;
        boolean temLetra = false;
        boolean temEspecial = false;
        for (char pwd : password.toCharArray()) {
            if (Character.isDigit(pwd)) {
                temNumero = true;
            } else if (Character.isLetter(pwd)) {
                temLetra = true;
            } else {
                temEspecial = true;
            }
        }
        if (temNumero && temLetra && temEspecial) {
            return true;
        }
        return false;

    }
}
