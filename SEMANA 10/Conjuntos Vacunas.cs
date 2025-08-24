
Console.WriteLine("UNIVERSIDAD ESTATAL AMAZONICA");


// Creamos el numero de personas del 1 al 500.

var total_de_personas = new HashSet<string>();

    for (int i = 1; i <= 500; i++)

{
    total_de_personas.Add($"persona {i}");
}

// Simulamos las personas vacunados esto seria al azar por que utilizamos numeros aleatorios.

var aleatorio = new Random();

var lista_de_todas_las_personas = total_de_personas.ToList();

// Creamos un conjunto de 75 personas vacunadas con Pfizer.

var vacunados_con_Pfizer = new HashSet<string>();

    for (int i = 0; i < 75; i++)
{
    vacunados_con_Pfizer.Add(lista_de_todas_las_personas[aleatorio.Next(lista_de_todas_las_personas.Count)]);
}

// Creamos un conjunto de 75 personas vacunadas con AstraZeneca

var vacunados_con_AstraZeneca = new HashSet<string>();

    for (int i = 0; i < 75; i++)
{
    vacunados_con_AstraZeneca.Add(lista_de_todas_las_personas[aleatorio.Next(lista_de_todas_las_personas.Count)]);
}


// Aplicamos union, interseccion, diferencia para cada grupo de personas.

// Ciudadanos que no se han vacunado.

var total_de_Vacunados = new HashSet<string>(vacunados_con_Pfizer);
total_de_Vacunados.UnionWith(vacunados_con_AstraZeneca);

var No_Vacunados = new HashSet<string>(total_de_personas);
No_Vacunados.ExceptWith(total_de_Vacunados);

// Ciudadanos que han recibido ambas dosis.

var ambas_dosis = new HashSet<string>(vacunados_con_Pfizer);
ambas_dosis.IntersectWith(vacunados_con_AstraZeneca);

// Ciudadanos que solo han recibido la vacuna de Pfizer.

var solo_Pfizer = new HashSet<string>(vacunados_con_Pfizer);
solo_Pfizer.ExceptWith(vacunados_con_AstraZeneca);

// Ciudadanos que solo han recibido la vacuna de AstraZeneca.

var solo_AstraZeneca = new HashSet<string>(vacunados_con_AstraZeneca);
solo_AstraZeneca.ExceptWith(vacunados_con_Pfizer);

// Imprimimos los resultados

Console.WriteLine($"    Informacion sobre la vacunación del COVID-19    ");

Console.WriteLine($"\n Personas que no se han vacunado ({No_Vacunados.Count}):");

    foreach (var nv in No_Vacunados)
{
    Console.WriteLine(nv);
}

Console.WriteLine($"\n Personas que han recibido ambas dosis ({ambas_dosis.Count}):");

    foreach (var ad in ambas_dosis)
{
    Console.WriteLine(ad);
}

Console.WriteLine($"\n Personas que solo han recibido la vacuna de Pfizer ({solo_Pfizer.Count}):");

    foreach (var f in solo_Pfizer)
{
    Console.WriteLine(f);
}

Console.WriteLine($"\n Personas que solo han recibido la vacuna de AstraZeneca ({solo_AstraZeneca.Count}):");
foreach (var A in solo_AstraZeneca)
{
    Console.WriteLine(A);
}