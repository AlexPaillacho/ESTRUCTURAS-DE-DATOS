
Console.WriteLine("=============================");

Console.WriteLine("UNIVERSIDAD ESTATAL AMAZONICA");

Console.WriteLine("==============================");

List<string> asignaturas = ["Ingles", "Metodologia", "Sistemas", "Fisica"];

List<int> asignaturas2 = [8, 9, 10, 8 ];


foreach (string materia in asignaturas)
{
    Console.WriteLine(materia);
}

Console.WriteLine("==============================");


foreach (string materia in asignaturas)
{
    Console.WriteLine($"Yo estudio   {materia}");
}

Console.WriteLine("==============================");

foreach (string materia in asignaturas)
{
    Console.WriteLine($"Cuanto sacaste en {materia}");
}

Console.WriteLine("=============================="); 

foreach (string materia in asignaturas)
{
    foreach (int notas in asignaturas2)
    {
      Console.WriteLine($"Yo saque en {materia} {notas}");
    }
}



