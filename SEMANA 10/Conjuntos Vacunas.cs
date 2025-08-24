
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

var vacunadosPfizer = new HashSet<string>();

    for (int i = 0; i < 75; i++)
{
    vacunadosPfizer.Add(lista_de_todas_las_personas[aleatorio.Next(lista_de_todas_las_personas.Count)]);
}

// Creamos un conjunto de 75 personas vacunadas con AstraZeneca

var vacunadosAstraZeneca = new HashSet<string>();

    for (int i = 0; i < 75; i++)
{
    vacunadosAstraZeneca.Add(lista_de_todas_las_personas[aleatorio.Next(lista_de_todas_las_personas.Count)]);
}


// 2. Aplicar operaciones de teoría de conjuntos

// Ciudadanos que no se han vacunado
var todosVacunados = new HashSet<string>(vacunadosPfizer);
todosVacunados.UnionWith(vacunadosAstraZeneca);
var noVacunados = new HashSet<string>(total_de_personas);
noVacunados.ExceptWith(todosVacunados);

// Ciudadanos que han recibido ambas dosis (intersección)
var ambasDosis = new HashSet<string>(vacunadosPfizer);
ambasDosis.IntersectWith(vacunadosAstraZeneca);

// Ciudadanos que solo han recibido la vacuna de Pfizer (diferencia)
var soloPfizer = new HashSet<string>(vacunadosPfizer);
soloPfizer.ExceptWith(vacunadosAstraZeneca);

// Ciudadanos que solo han recibido la vacuna de AstraZeneca (diferencia)
var soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca);
soloAstraZeneca.ExceptWith(vacunadosPfizer);

// 3. Imprimir los resultados
Console.WriteLine($"--- Reporte de Vacunación COVID-19 ---");

Console.WriteLine($"\n Ciudadanos que no se han vacunado ({noVacunados.Count}):");
foreach (var c in noVacunados)
{
    Console.WriteLine(c);
}

Console.WriteLine($"\n Ciudadanos que han recibido ambas dosis ({ambasDosis.Count}):");
foreach (var c in ambasDosis)
{
    Console.WriteLine(c);
}

Console.WriteLine($"\n Ciudadanos que solo han recibido la vacuna de Pfizer ({soloPfizer.Count}):");
foreach (var c in soloPfizer)
{
    Console.WriteLine(c);
}

Console.WriteLine($"\n Ciudadanos que solo han recibido la vacuna de AstraZeneca ({soloAstraZeneca.Count}):");
foreach (var c in soloAstraZeneca)
{
    Console.WriteLine(c);
}