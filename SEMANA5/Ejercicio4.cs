 Console.WriteLine("=============================");

 Console.WriteLine("UNIVERSIDAD ESTATAL AMAZONICA");

 Console.WriteLine("==============================");

List<int> precios = [50, 75, 46, 22, 80, 65, 8];


// ejercicio 4 ordenar de menor a mayor los numeros.

precios.Sort();

         Console.WriteLine(precios.Count);
        foreach (int valor in precios)
         {
            
             Console.WriteLine($"Precio: {valor}");
        }


