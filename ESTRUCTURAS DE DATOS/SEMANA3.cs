// MATRIZ DE REGISTRO
 class Estudiante
{
    // Propiedades de la clase Estudiante
     int Id { get; set; }
     string Nombres { get; set; }
     string Apellidos { get; set; }
     string Direccion { get; set; }

    // Array para almacenar los tres números de teléfono
    public string[] Telefonos { get; set; }

    // Constructor que inicializa todas las propiedades
    public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
    {
        Id = id;
        Nombres = nombres;
        Apellidos = apellidos;
        Direccion = direccion;

        // Aseguramos que el array de teléfonos tenga espacio para 3 elementos
        Telefonos = new string[3];

        if (telefonos != null)
        {
            // Copiamos los elementos del array de entrada hasta un máximo de 3
            int elementosACopiar = Math.Min(telefonos.Length, 3);
            Array.Copy(telefonos, Telefonos, elementosACopiar);
        }
        // Si se proporcionaron menos de 3, los elementos restantes de Telefonos
        // se quedarán con su valor predeterminado (null para string),
        // o "" si los inicializamos explícitamente en el constructor por defecto.
        // Aquí los dejaremos como null si no se copian.
    }

    // Constructor sin parámetros (opcional, pero útil)
      Estudiante()
    {
        Telefonos = new string[3]; // Inicializa el array con 3 elementos vacíos ("") o null
    }

    // Método para mostrar la información del estudiante
    public void MostrarInformacion()
    {
        Console.WriteLine($"--- Información del Estudiante ID: {Id} ---");
        Console.WriteLine($"Nombres: {Nombres}");
        Console.WriteLine($"Apellidos: {Apellidos}");
        Console.WriteLine($"Dirección: {Direccion}");
        Console.WriteLine("Teléfonos:");
        for (int i = 0; i < Telefonos.Length; i++)
        {
            // Mostramos el teléfono o un mensaje si está vacío/nulo
            Console.WriteLine($"  - Teléfono {i + 1}: {(string.IsNullOrEmpty(Telefonos[i]) ? "No especificado" : Telefonos[i])}");
        }
        Console.WriteLine("--------------------------------------\n");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Demostración de Registro de Estudiantes \n");

        // Ejemplo 1 Estudiante sin teléfonos iniciales
        string[] telAlex = { "", "","" };
        Estudiante estudiante1 = new Estudiante(1, "Alex", "Rey", "Calle e2e", telAlex);
        estudiante1.MostrarInformacion();

        // Ejemplo 2 Estudiante con 3 teléfonos  
        string[] telLore = { "0989652331", "0989563214","0986532145" }; // Solo 3 teléfonos
        Estudiante estudiante2 = new Estudiante(2, "Lore", "Castillo", "maldonado 45", telLore);
        estudiante2.MostrarInformacion();

        // Ejemplo 3 Estudiante con 3 teléfonos 
        Estudiante estudiante3 = new Estudiante(3, "Bryan", "Ramirez", "guamani", new string[] { }); // Array vacío
        estudiante3.Telefonos[0] = "0956324552";
        estudiante3.Telefonos[1] = "0956874552";
        estudiante3.Telefonos[2] = "0989542362";

        // El Telefonos[2] se quedará como null si no se asigna.
        estudiante3.MostrarInformacion();

       
       
        // Ejemplo 4: Array (matriz) de objetos Estudiante 
        Console.WriteLine("--- Demostración de un Array de Estudiantes ---");
        Estudiante[] listaEstudiantes = new Estudiante[2]; // Array para 2 estudiantes

        string[] telSofia = { "0965321478", "0965321478", "0963254879" };
        listaEstudiantes[0] = new Estudiante(4, "Sofia", "Pico", "lagarto", telSofia);

        string[] telLuis = { "0956321452", "0956321451","09865231452" }; // 3 numeros de telefono
        listaEstudiantes[1] = new Estudiante(5, "Luis", "Guaman", "panecillo", telLuis);

        foreach (Estudiante est in listaEstudiantes)
        {
            est.MostrarInformacion();
        }


        Console.WriteLine("Presiona cualquier tecla para salir.");
        Console.ReadLine(); 
    }
}