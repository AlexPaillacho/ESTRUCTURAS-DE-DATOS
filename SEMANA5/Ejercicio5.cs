Console.WriteLine("=============================");

Console.WriteLine("UNIVERSIDAD ESTATAL AMAZONICA");

Console.WriteLine("==============================");

List<int> numeros = [1,2,3,4,5,6,7,8,9,10];


// ejercicio 5 invertir la lista de numeros separados por comas.

Console.WriteLine($"Cantidad de números en la lista: {numeros.Count}");


Console.WriteLine("\nNúmeros en orden inverso, separados por comas:");

Console.WriteLine(string.Join(",", numeros.Select(n => n.ToString()).Reverse()));


Console.ReadKey();

