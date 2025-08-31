public class Traducción
{
  
    // Diccionario para la traducción de español a inglés
    private static Dictionary<string, string> diccionarioEspanolIngles = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        {"tiempo", "Time"},
        {"persona", "Person"},
        {"año", "Year"},
        {"camino", "Way"},
        {"día", "Day"},
        {"cosa", "Thing"},
        {"hombre", "Man"},
        {"mundo", "World"},
        {"Este", "This"},
        {"es", "is"},
        {"depende", "depends"},
        {"mucho", "much"},
        {"del", "on the"},
        {"ojo", "eye"},
        {"que", "that"},
        {"lo", "sees"},
        {"ve", "it"},
        {"hermoso", "beautiful"},
       { "Este día es hermoso depende mucho del ojo que lo ve","This day is beautiful, it depends a lot on the eye that sees it" }
    };

    public static void Main(string[] args)
    {
       

        bool salir = false;
        while (!salir)
        {
            MostrarMenu();
            string? opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    TraducirFrase();
                    break;
                case "2":
                    AgregarPalabras();
                    break;
                case "0":
                    salir = true;
                    Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción del menú.");
                    break;
            }
            Console.WriteLine();
        }
    }

    private static void MostrarMenu()
    {
        Console.WriteLine("=================== ====================");
        Console.WriteLine("UNIVERSIDAD ESTATAL AMAZONICA");
        Console.WriteLine("=================== ====================");
        Console.WriteLine("==================== MENÚ ====================");
        Console.WriteLine();
        Console.WriteLine("1. Traducir una frase");
        Console.WriteLine("2. Agregar palabras al diccionario");
        Console.WriteLine("0. Salir");
        Console.WriteLine();
        Console.Write("Seleccione una opción: ");
    }

    private static void TraducirFrase()
    {
        Console.WriteLine("===============================");

        Console.Write("Ingrese la frase a traducir que quiere traducir a ingles: ");
     
        string? frase = Console.ReadLine();

        string[] palabras = frase.Split(' ');
        string[] traduccion = new string[palabras.Length];

        for (int i = 0; i < palabras.Length; i++)
        {
            string? palabra = palabras[i];
            
           if (diccionarioEspanolIngles.ContainsKey(palabra))
            {
                traduccion[i] = diccionarioEspanolIngles[palabra];
            }
            // Si no se encuentra en ningún diccionario, mantiene la palabra original
            else
            {
                traduccion[i] = palabra;
            }
        }
        Console.WriteLine("Traducción: " + string.Join(" ", traduccion));
    }

    private static void AgregarPalabras()
    {
        Console.WriteLine("=== Agregar Nuevas Palabras ===");
        Console.Write("Ingrese la palabra en inglés: ");
        string? palabraIngles = Console.ReadLine();
        Console.Write("Ingrese la traducción en español: ");
        string? palabraEspanol = Console.ReadLine();

        // Evita agregar palabras que ya existen
        if (diccionarioEspanolIngles.ContainsKey  (palabraIngles))
        {
            Console.WriteLine($"La palabra '{palabraIngles}' ya existe en el diccionario.");
            return;
        }

        // Agrega la palabra en ambos diccionarios para la traducción bidireccional
        
        diccionarioEspanolIngles.Add(palabraEspanol, palabraIngles);
        
        Console.WriteLine($"Palabra '{palabraIngles}' y su traducción '{palabraEspanol}' agregadas correctamente.");
    }
}
