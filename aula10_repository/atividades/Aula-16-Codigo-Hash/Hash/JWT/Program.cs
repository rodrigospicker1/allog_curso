// dotnet add package Microsoft.IdentityModel.Tokens --version 6.30.0
// dotnet add package Microsoft.IdentityModel.JsonWebTokens --version 6.30.0
// dotnet add package System.Text.Json --version 7.0.2
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using jwt;
using Microsoft.IdentityModel.Tokens;

// Cria o header
// Verbatim text 
// Indica que uma string literal deve ser interpretada textualmente.
// Duas aspas dupla reproduz uma aspas dupla
// var headerSegment = @"{""typ"":""JWT"",""alg"":""HS256""}";

//#######################      PASSO 1: Cria o Header e o Payload     #######################
// Cria o header que é um conjunto de chave-valor
var headerRepresentation = new Dictionary<string, object>
{
    { "alg", "HS256" },
    { "typ", "JWT" },
};

/*  
    Converte o dictionary de claims em JSON que é uma string. É necessário
    ser uma string para transformar o payload em um array de bytes de um 
    determinado formato.

    "JsonSerializer" Fornece funcionalidade para serializar objetos ou tipos
    de valor para JSON e para desserializar JSON em objetos ou tipos de valor.

    "Serialize" Converte o valor de um tipo especificado por um parâmetro de 
    tipo genérico em uma string JSON.

    "WriteIndented" Obtém ou define um valor que indica se o JSON deve usar 
    impressão bonita. Por padrão, o JSON é serializado sem nenhum espaço em 
    branco extra.
*/
var headerSegment = JsonSerializer.Serialize(headerRepresentation,
    new JsonSerializerOptions() { WriteIndented = false });


// Cria o payload que é um conjunto de chave-valor
var payloadRepresentation = new Dictionary<string, object>
            {
                { "claim1", 10 },
                { "claim2", "claim2-value" },
                { "name", "Jackson Camara" },
                { "given_name", "Jackson" },
                { "social", new Dictionary<string, string>()
                    {
                        { "facebook", "jacksoncamara" },
                        { "google", "jacksoncamara" }
                    }
                },
                { "logins", new[] {"jacksoncamara", "jackson_camara"} },
            };


var payloadSegment = JsonSerializer.Serialize(payloadRepresentation,
     new JsonSerializerOptions() { WriteIndented = false });

// Mostra o header e o payload formatado em JSON no console
JwsExample.ShowHeaderPayload(headerSegment, payloadSegment);


// #######################      PASSO 2: Transforma Head e Payload em Base64Url      #######################
/* 
Base64url é um formato de codificação de dados binários em ASCII que permite a 
representação segura de dados binários em uma string de caracteres sem ter 
quebras ou caracteres que podem prejudicar a tecnologia que estamos utilizando
*/
var header = Base64UrlEncoder.Encode(headerSegment);
var payload = Base64UrlEncoder.Encode(payloadSegment);

// Mostra o header e o payload em Base64Url
JwsExample.ShowBase64Parts(header, payload);



//######################      PASSO 3: Gera o que será assinado      #######################
// Concatena o header e o payload para assinatura
var signatureSegment = $"{header}.{payload}";

// Mostra o header e o payload concatenado
JwsExample.ShowSignatureParts(signatureSegment);


//######################      PASSO 4: Cria a chave de assinatura      #######################
/*
    Cria  a chave
    "RandomNumberGenerator" fornece funcionalidades para gerar valores aleatórios.
    "GetBytes" cria uma matriz de bytes com uma sequência aleatória
    criptograficamente forte de valores.
*/ 
// byte[] key = new byte[16];
// RandomNumberGenerator.Fill(key);

// // Mostra chave gerada no console.
// JwsExample.ShowKeyInfo(key);

// Para testar com uma chave fixa
byte[] key = Encoding.UTF8.
    GetBytes("thisisthesecretforgeneratingakey(mustbeatleast32bitlong)");

//#######################      PASSO 5: Assina com HMACSHA256      #######################

//Cria uma instância de HMACSHA256
// Recebe no construtor a chave que será usada na assinatura
var hmac = new HMACSHA256(key);

/*
    Converte signatureSegment para um array de bytes usando a codificação UTF-8
    UTF-8 é um padrão de codificação de caractere.

    "GetBytes()" é usado para codificar uma string em um formato específico de
    bytes para que possa ser transmitida ou armazenada em um arquivo ou banco de dados

    "ComputeHash()" Recebe um array de bytes que representa o que será assinado que é 
    o payload mais o header concatenado. Retorna um novo array de bytes que contém o 
    valor hash calculado.
*/
var signatureBytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(signatureSegment));
JwsExample.ShowSignatureBytes(signatureBytes);

//#######################      PASSO 6: Transforma assinatura em Base64Url    #######################
// Transforma assinatura em Base64Url
var signature = Base64UrlEncoder.Encode(signatureBytes);

// Mostra a assinatura em Base64URL
JwsExample.ShowSignatureBase64Url(signature);


// #######################      PASSO 7: Monta a estrutura JWS/JWT   #######################
// Concatena header, payload e signature
var jws = $"{header}.{payload}.{signature}";

// Mostra o JWT
JwsExample.ShowJws(jws);

