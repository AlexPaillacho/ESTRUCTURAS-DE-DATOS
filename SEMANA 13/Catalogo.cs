
Console.WriteLine("UNIVERSIDAD ESTATAL AMAZONICA");

class CatalogoRevistas
{
    // Catálogo de revistas (lista de cadenas de texto).
    private List<string> revistas = new List<string>();

    public CatalogoRevistas()
    {
        // Se inicializa el catálogo con 10 títulos de revistas.
        revistas.Add("National Geographic");
        revistas.Add("Time");
        revistas.Add("The Economist");
        revistas.Add("Vogue");
        revistas.Add("Science");
        revistas.Add("Wired");
        revistas.Add("Forbes");
        revistas.Add("Playboy");
        revistas.Add("New Yorker");
        revistas.Add("People");
    }

    /// <summary>
    /// Método de búsqueda iterativa para encontrar un título en el catálogo.
    /// </summary>
    /// <param name="tituloBuscado">El título de la revista a buscar.</param>
    /// <returns>Verdadero si el título se encuentra, falso en caso contrario.</returns>
    public bool BuscarTitulo(string tituloBuscado)
    {
        // Se itera sobre cada título en la lista 'revistas'.
        foreach (string titulo in revistas)
        {
            // Se compara el título actual con el título buscado.
            // La comparación ignora mayúsculas y minúsculas para una búsqueda más flexible.
            if (string.Equals(titulo, tituloBuscado, StringComparison.OrdinalIgnoreCase))
            {
                // Si se encuentra una coincidencia, se retorna 'true'.
                return true;
            }
        }
        // Si el bucle termina sin encontrar el título, se retorna 'false'.
        return false;
    }

    /// <summary>
    /// Menú interactivo para gestionar la aplicación.
    /// </summary>
    public void MostrarMenu()
    {
        Console.WriteLine("--- Catálogo de Revistas ---");
        Console.WriteLine("1. Buscar un título de revista");
        Console.WriteLine("2. Salir");
    }

    /// <summary>
    /// Método principal que contiene la lógica de la aplicación.
    /// </summary>
    public void Ejecutar()
    {
        bool continuar = true;
        while (continuar)
        {
            MostrarMenu();
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título de la revista a buscar: ");
                    string tituloBuscado = Console.ReadLine();
                    bool encontrado = BuscarTitulo(tituloBuscado);
                    
                    if (encontrado)
                    {
                        Console.WriteLine("Resultado: Encontrado");
                    }
                    else
                    {
                        Console.WriteLine("Resultado: No encontrado");
                    }
                    Console.WriteLine();
                    break;
                
                case "2":
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    Console.WriteLine();
                    break;
            }
        }
    }

    // Punto de entrada principal para la aplicación.
    static void Main(string[] args)
    {
        CatalogoRevistas app = new CatalogoRevistas();
        app.Ejecutar();
    }
}