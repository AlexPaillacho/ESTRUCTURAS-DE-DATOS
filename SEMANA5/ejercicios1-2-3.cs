
 Console.WriteLine("=============================");

 Console.WriteLine("UNIVERSIDAD ESTATAL AMAZONICA");

 Console.WriteLine("==============================");

 List<string> asignaturas = ["Ingles", "Metodologia", "Sistemas", "Fisica"];

 List<int> asignaturas2 = [10];
 

// ejercicio 1  mostrar cada una de las asignaturas en pantalla
foreach (string materia in asignaturas)
{
    Console.WriteLine(materia);
}

 Console.WriteLine("==============================");



// ejercicio 2 mostrar en pantalla "yo estudio" con todas las asignaturas
foreach (string materia in asignaturas)
{
    Console.WriteLine($"Yo estudio   {materia}");
}

 Console.WriteLine("==============================");
 

 // ejercicio 3 preguntar y mostrar las notas de cada materia

 foreach (string materia in asignaturas)
{
    Console.WriteLine($"Cuanto sacaste en {materia}");
}

 Console.WriteLine("=============================="); 

 foreach (string materia in asignaturas)
 {
     Console.WriteLine($"Yo saque en {materia}");

     foreach (int notas in asignaturas2)
     {
         Console.WriteLine(notas);
     }
 }


