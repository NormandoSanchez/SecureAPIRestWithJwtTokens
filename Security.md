# Seguridad

Para la evaluacion del TFM este archivo se ha subido a GitHub excepcionalmente.

## Claves criptograficas

### INTERNAS

   Para uso exclusivo en la API y entre API y BD

    Key = New Byte() {16, 15, 14, 13, 12, 11, 10, 40, 41, 42, 43, 44, 45, 46, 47, 48}
    IV = New Byte() {1, 2, 3, 4, 5, 6, 7, 8, 23, 23, 25, 26, 27, 28, 29, 30}

    Convertidas a Base64 y almacenadas como variables de entorno 
    INTERNAL_API_KEY= EA8ODQwLCigpKissLS4vMA==
    INTERNAL_API_IV = AQIDBAUGBwgXFxkaGxwdHg==    

### EXTERNAS

    Para uso entre API y sus clientes 

    Key = New Byte() {4, 15, 6, 18, 6, 60, 17, 56, 45, 47, 1, 5, 2, 14, 78, 53}
    IV = New Byte() {1, 2, 3, 4, 5, 6, 7, 8, 23, 23, 25, 26, 27, 28, 29, 30}

    Convertidas a Base64 y almacenadas como variables de entorno
    EXTERNAL_API_KEY = BA8GEgY8ETgtLwEFAg5ONQ==
    EXTERNAL_API_IV = NU4OAgUBLy04ETwGEgYPBA==

## Comunicación con API

    Cuando un cliente se comunica con la api, si tiene que enviar datos como passwords, etc. debe hacerlo encriptando estos datos usando las claves externas.
    Por ejemplo:
        Login -> Login Usuario, sin encriptar.
                 Password, encriptada con las claves externas
    Evidentemente todo cliente debe conocer las claves externas para realizar la encriptacion.
