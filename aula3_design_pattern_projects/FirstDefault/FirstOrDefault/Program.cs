List<int> numeros = new List<int>{1,2,3,4,5};

int primeiroNumero = numeros.FirstOrDefault();
Console.WriteLine(primeiroNumero);

int primeiroNumeroMaiorTres = numeros.FirstOrDefault(n => n > 3);
Console.WriteLine(primeiroNumeroMaiorTres);

int primeiroNumeroMaiorCinco = numeros.FirstOrDefault(n => n > 5);
Console.WriteLine(primeiroNumeroMaiorCinco);