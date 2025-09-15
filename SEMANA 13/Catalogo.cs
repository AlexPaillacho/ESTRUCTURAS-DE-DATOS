class Catalogo_Revistas
{     // Lista de revistas total (10 )
    private List<string> revistas = new List<string>();

    public Catalogo_Revistas()
    {
        
        revistas.Add("el comercio");
        revistas.Add("extra");
        revistas.Add("yambal");
        revistas.Add("diario");
        revistas.Add("el metro");
        revistas.Add("dominical");
        revistas.Add("ciencia");
        revistas.Add("deporte");
        revistas.Add("Quito");
        revistas.Add("farandula");
    }
      
      // Buscar el nombre de la revista.
    public bool Buscar_Titulo(string titulo_buscado)
    {

        foreach (string titulo in revistas)
        {

            if (string.Equals(titulo, titulo_buscado, StringComparison.OrdinalIgnoreCase))
            {

                return true;
            }
        }

        return false;
    }

    
    // Menú interactivo para gestionar la aplicación.
    
    public void MostrarMenu()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("UNIVERSIDAD ESTATAL AMAZONICA ");
        Console.WriteLine("===============================");
        Console.WriteLine("=== Catálogo de Revistas ===");
        Console.WriteLine("1. Buscar un título de revista");
        Console.WriteLine("2. Salir");
    }

   
    public void Ejecutar()
    {
        bool continuar = true;
        while (continuar)
        {
            MostrarMenu();
            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título de la revista que busca: ");
                    string? titulo_Buscado = Console.ReadLine();
                    bool encontrado = Buscar_Titulo(titulo_Buscado);
                    
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
                    Console.WriteLine("Fializando la busqueda");
                    break;
                
                default:
                    Console.WriteLine("Opción no valida / Intente nuevamente");
                    Console.WriteLine();
                    break;
            }
        }
    }

    // Punto de entrada principal para la aplicación.
    static void Main(string[] args)
    {
        Catalogo_Revistas app = new Catalogo_Revistas();
        app.Ejecutar();
    }
}