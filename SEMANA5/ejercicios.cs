
Console.WriteLine("=============================");

Console.WriteLine("UNIVERSIDAD ESTATAL AMAZONICA");

Console.WriteLine("==============================");

List<string> asignaturas = ["Ingles", "Metodologia", "Sistemas", "Fisica"];

List<int> notas = [8, 9, 10, 8 ];


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
    Console.WriteLine($"Cuanto sacaste en   {materia}");


    foreach (int nota in notas)
    {
    Console.WriteLine($"Yo saque en  {materia} + {notas}");

    }
}