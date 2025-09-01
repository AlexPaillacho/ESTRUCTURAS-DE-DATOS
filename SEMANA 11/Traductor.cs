public class APP
{
    public static void Main(string[] args)
    {
        Traductor traductorApp = new Traductor();
        bool salir = false;

        while (!salir)
        {
            traductorApp.MostrarMenu();
            string? opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    traductorApp.TraducirFrase();
                    break;
                case "2":
                    traductorApp.AgregarPalabras();
                    break;
                case "0":
                    salir = true;
                    Console.WriteLine("Finalizando el programa ¡ Se finalizo correctamente! ");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor seleccione una opción del menú.");
                    break;
            }
            Console.WriteLine();
        }
    }
}

public class Traductor
{
   
    private Dictionary<string, string> diccionarioInglesEspanol;
    private Dictionary<string, string> diccionarioEspanolIngles;

    public Traductor()
    {
        
        diccionarioEspanolIngles = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"tiempo", "time"},
            {"persona", "person"},
            {"año", "year"},
            {"camino", "way"},
            {"día", "day"},
            {"cosa", "thing"},
            {"hombre", "man"},
            {"mundo", "world"},
            {"vida", "life"},
            {"mano", "hand"},
            {"ojo", "eye"},
            {"este", "this"},
            {"es", "is"},
            {"depende", "depends"},
            {"mucho", "much"},
            {"del", "on the"},
            {"que", "that"},
            {"lo", "it"},
            {"ve", "sees"},
            {"hermoso", "beautiful"},
            {"este dia es hermoso depende mucho del ojo que lo ve", "this day is beautiful it depends a lot on the eye that sees it"},
        
             
        };

        
        diccionarioInglesEspanol = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"time", "tiempo"},
            {"person", "persona"},
            {"year", "año"},
            {"way", "camino"},
            {"day", "día"},
            {"thing", "cosa"},
            {"man", "hombre"},
            {"world", "mundo"},
            {"life", "vida"},
            {"hand", "mano"},
            {"eye", "ojo"},
            {"this", "este"},
            {"is", "es"},
            {"depends", "depende"},
            {"much", "mucho"},
            {"on the", "del"},
            {"that", "que"},
            {"it", "lo"},
            {"sees", "ve"},
            {"beautiful", "hermoso"},
            {"this day is beautiful it depends a lot on the eye that sees it", "este dia es hermoso depende mucho del ojo que lo ve"}
        };
    }

    public void MostrarMenu()
    {
        Console.WriteLine("=================== ====================");
        Console.WriteLine("UNIVERSIDAD ESTATAL AMAZONICA");
        Console.WriteLine("=================== ====================");
        Console.WriteLine("==================== MENÚ====================");
        Console.WriteLine();
        Console.WriteLine("1. Traducir una frase");
        Console.WriteLine("2. Agregar palabras al diccionario");
        Console.WriteLine("0. Salir");
        Console.WriteLine();
        Console.Write("Seleccione una opción: ");
    }

    public void TraducirFrase()
    {
        Console.WriteLine("===============================");
        Console.Write("Ingrese la frase que quiere traducir: ");
        string? frase = Console.ReadLine();

        // El operador ?? crea un arreglo vacío si la frase es nula
        string[] palabras = frase?.Split(' ') ?? new string[0];
        string[] traduccion = new string[palabras.Length];

        for (int i = 0; i < palabras.Length; i++)
        {
            string palabra = palabras[i];
            
            // Intenta traducir de español a inglés
            if (diccionarioEspanolIngles.ContainsKey(palabra))
            {
                traduccion[i] = diccionarioEspanolIngles[palabra];
            }
            // Intenta traducir de inglés a español
            else if (diccionarioInglesEspanol.ContainsKey(palabra))
            {
                traduccion[i] = diccionarioInglesEspanol[palabra];
            }
            // Si no se encuentra, mantiene la palabra original
            else
            {
                traduccion[i] = palabra;
            }
        }
        Console.WriteLine("Traducción: " + string.Join(" ", traduccion));
    }

    public void AgregarPalabras()
    {
        Console.WriteLine("=== Agregar Nuevas Palabras ===");
        Console.Write("Ingrese la palabra en español: ");
        string? palabraEspanol = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Ingrese la traducción en inglés: ");
        string? palabraIngles = Console.ReadLine()?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(palabraEspanol) || string.IsNullOrWhiteSpace(palabraIngles))
        {
            Console.WriteLine("Las palabras no pueden estar vacías. Por favor intente de nuevo.");
            return;
        }

        // Evita agregar palabras que ya existen en ambos diccionarios

        if (diccionarioEspanolIngles.ContainsKey(palabraEspanol) || diccionarioInglesEspanol.ContainsKey(palabraIngles))
        {
            Console.WriteLine($"La palabra '{palabraEspanol}' o '{palabraIngles}' ya existe en el diccionario.");
            return;
        }

        // Agrega la palabra en ambos diccionarios para la traducción bidireccional

        diccionarioEspanolIngles.Add(palabraEspanol, palabraIngles);

        diccionarioInglesEspanol.Add(palabraIngles, palabraEspanol);
        
        Console.WriteLine($"Palabra '{palabraEspanol}' y su traducción '{palabraIngles}' agregadas correctamente");


        
    }
}