
public class Campeonato_de_futbol
{
    private Dictionary<string, HashSet<string>> equipos;
    private HashSet<string> jugadores_totales;

    public Campeonato_de_futbol()
    {
        equipos = new Dictionary<string, HashSet<string>>();
        jugadores_totales = new HashSet<string>();
        
        
        Inscritos();
    }


    private void Inscritos()
    {
        Console.WriteLine("\n==================================");
        Console.WriteLine("\n  2 equipos ya inscritos con 2 jugadores cada uno...");
        Console.WriteLine("\n==================================");

        // Equipo 1: La Victoria
        Console.WriteLine("\n==================================");
        Registrar_Equipo(" La Victoria ");
        Console.WriteLine("\n==================================");
        Registrar_Jugador(" Alex ", " La Victoria ");
        Registrar_Jugador(" Gari ", " La Victoria ");

        // Equipo 2: Guamani
        Console.WriteLine("\n==================================");
        Registrar_Equipo(" Guamani ");
        Registrar_Jugador(" Miguel ", " Guamani ");
        Registrar_Jugador(" Luis ", " Guamani ");



        Console.WriteLine("\n==================================");
        Console.WriteLine(" Registrados correctamente.\n");
        
    }

    public void Registrar_Equipo(string nombre_del_Equipo)
    {
        if (!equipos.ContainsKey(nombre_del_Equipo))
        {
            equipos[nombre_del_Equipo] = new HashSet<string>();
            Console.WriteLine($" Equipo '{nombre_del_Equipo}' registrado.");
        }
        else
        {
            Console.WriteLine($" El equipo '{nombre_del_Equipo}' ya existe.");
        }
    }

    public void Registrar_Jugador(string nombre_Jugador, string nombreEquipo)
    {
        if (jugadores_totales.Contains(nombre_Jugador))
        {
            Console.WriteLine($" El jugador '{nombre_Jugador}' ya está registrado en el torneo.");
            return;
        }

        if (equipos.ContainsKey(nombreEquipo))
        {
            equipos[nombreEquipo].Add(nombre_Jugador);
            jugadores_totales.Add(nombre_Jugador);
            Console.WriteLine($" Jugador '{nombre_Jugador}' agregado a '{nombreEquipo}'.");
        }
        else
        {
            Console.WriteLine($" El equipo '{nombreEquipo}' no existe. Registre el equipo primero.");
        }
    }

  

    public void MostrarTorneoCompleto()
    {
        Console.WriteLine("\n Reporte del Torneo:");
        if (equipos.Count == 0)
        {
            Console.WriteLine("El campeonato no tiene equipos registrados.");
            return;
        }

        foreach (var equipo in equipos)
        {
            Console.WriteLine($"\n- Equipo: {equipo.Key}");
            if (equipo.Value.Count > 0)
            {
                foreach (var jugador in equipo.Value)
                {
                    Console.WriteLine($"   {jugador}");
                }
            }
            else
            {
                Console.WriteLine(" (Sin jugadores)");
            }
        }
    }

    public void ConsultarJugadoresPorEquipo(string nombreEquipo)
    {
        Console.WriteLine($"\n Jugadores del equipo '{nombreEquipo}':");
        if (equipos.TryGetValue(nombreEquipo, out var jugadores))
        {
            if (jugadores.Count > 0)
            {
                foreach (var jugador in jugadores)
                {
                    Console.WriteLine($" {jugador}");
                }
            }
            else
            {
                Console.WriteLine($"  El equipo '{nombreEquipo}' no tiene jugadores registrados.");
            }
        }
        else
        {
            Console.WriteLine($" El equipo '{nombreEquipo}' no existe.");
        }
    }
}

public class Registro
{
    public static void Main(string[] args)
    {
        Campeonato_de_futbol miTorneo = new Campeonato_de_futbol();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("\n UNIVERSIDAD ESTATAL AMAZONICA");
            Console.WriteLine("\n==================================");
            Console.WriteLine("\n--- Menú del campeonato de Fútbol ---");
            Console.WriteLine("\n==================================");

            Console.WriteLine("1. Registrar un nuevo equipo");
            Console.WriteLine("2. Registrar un nuevo jugador");
            Console.WriteLine("3. Mostrar todos los equipos y jugadores");
            Console.WriteLine("5. Salir");
            Console.Write("Por favor, seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el nombre del equipo: ");
                    string nombreEquipo = Console.ReadLine();
                    miTorneo.Registrar_Equipo(nombreEquipo);
                    break;

                case "2":
                    Console.Write("Ingrese el nombre del jugador: ");
                    string nombreJugador = Console.ReadLine();
                    Console.Write("Ingrese el nombre del equipo al que pertenece: ");
                    string equipoJugador = Console.ReadLine();
                    miTorneo.Registrar_Jugador(nombreJugador, equipoJugador);
                    break;

                case "3":
                    miTorneo.MostrarTorneoCompleto();
                    break;

                case "4":
                    Console.Write("Ingrese el nombre del equipo a consultar: ");
                    string equipoConsulta = Console.ReadLine();
                    miTorneo.ConsultarJugadoresPorEquipo(equipoConsulta);
                    break;

                case "5":
                    salir = true;
                    Console.WriteLine("Cerrando la aplicacion. ¡Hasta pronto!");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor intente de nuevo.");
                    break;
            }
        }
    }
}