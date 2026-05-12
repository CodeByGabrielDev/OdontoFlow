package com.odontoflow.Utils;

public class ValidatorPassword {

    public boolean validarPwd(String password) {
        /*
         * password tem que ter tamanho minimo de carateres(ja implementado no lombok
         * via DTO request)
         * , UpperCase e LowerCase aqui vou tentar usar o contains para conseguir
         * caracteres especiais e numericos
         */
        boolean temNumero = false;
        boolean temLetra = false;
        boolean temEspecial = false;
        for (char pwd : password.toCharArray()) {
            if (Character.isAlphabetic(pwd)) {
                temLetra = true;
            }
            if (Character.isDigit(pwd)) {

            }

        }
    }
}
