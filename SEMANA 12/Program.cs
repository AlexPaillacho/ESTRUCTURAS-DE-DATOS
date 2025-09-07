using System;
using System.Collections.Generic;

public class TorneoFutbol
{
    private Dictionary<string, HashSet<string>> equipos;
    private HashSet<string> jugadoresTotales;

    public TorneoFutbol()
    {
        equipos = new Dictionary<string, HashSet<string>>();
        jugadoresTotales = new HashSet<string>();
    }

    public void RegistrarEquipo(string nombreEquipo)
    {
        if (!equipos.ContainsKey(nombreEquipo))
        {
            equipos[nombreEquipo] = new HashSet<string>();
            Console.WriteLine($"✅ Equipo '{nombreEquipo}' registrado.");
        }
        else
        {
            Console.WriteLine($"❌ El equipo '{nombreEquipo}' ya existe.");
        }
    }

    public void RegistrarJugador(string nombreJugador, string nombreEquipo)
    {
        if (jugadoresTotales.Contains(nombreJugador))
        {
            Console.WriteLine($"❌ El jugador '{nombreJugador}' ya está registrado en el torneo.");
            return;
        }

        if (equipos.ContainsKey(nombreEquipo))
        {
            equipos[nombreEquipo].Add(nombreJugador);
            jugadoresTotales.Add(nombreJugador);
            Console.WriteLine($"✅ Jugador '{nombreJugador}' agregado a '{nombreEquipo}'.");
        }
        else
        {
            Console.WriteLine($"❌ El equipo '{nombreEquipo}' no existe. Registre el equipo primero.");
        }
    }

    // --- Métodos de Reportería ---

    public void MostrarTorneoCompleto()
    {
        Console.WriteLine("\n📋 Reporte del Torneo:");
        if (equipos.Count == 0)
        {
            Console.WriteLine("El torneo no tiene equipos registrados.");
            return;
        }
        
        foreach (var equipo in equipos)
        {
            Console.WriteLine($"\n- Equipo: {equipo.Key}");
            if (equipo.Value.Count > 0)
            {
                foreach (var jugador in equipo.Value)
                {
                    Console.WriteLine($"    • {jugador}");
                }
            }
            else
            {
                Console.WriteLine("    • (Sin jugadores)");
            }
        }
    }

    public void ConsultarJugadoresPorEquipo(string nombreEquipo)
    {
        Console.WriteLine($"\n🔍 Jugadores del equipo '{nombreEquipo}':");
        if (equipos.TryGetValue(nombreEquipo, out var jugadores))
        {
            if (jugadores.Count > 0)
            {
                foreach (var jugador in jugadores)
                {
                    Console.WriteLine($"    • {jugador}");
                }
            }
            else
            {
                Console.WriteLine($"    • El equipo '{nombreEquipo}' no tiene jugadores registrados.");
            }
        }
        else
        {
            Console.WriteLine($"❌ El equipo '{nombreEquipo}' no existe.");
        }
    }
}

public class Registro
{
    public static void Main(string[] args)
    {
        TorneoFutbol miTorneo = new TorneoFutbol();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n--- Menú de Gestión del Torneo de Fútbol ---");
            Console.WriteLine("1. Registrar un nuevo equipo");
            Console.WriteLine("2. Registrar un nuevo jugador");
            Console.WriteLine("3. Mostrar todos los equipos y jugadores");
            Console.WriteLine("4. Consultar jugadores de un equipo");
            Console.WriteLine("5. Salir");
            Console.Write("Por favor, seleccione una opción: ");
            
            string opcion = Console.ReadLine();
            
            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el nombre del equipo: ");
                    string nombreEquipo = Console.ReadLine();
                    miTorneo.RegistrarEquipo(nombreEquipo);
                    break;

                case "2":
                    Console.Write("Ingrese el nombre del jugador: ");
                    string nombreJugador = Console.ReadLine();
                    Console.Write("Ingrese el nombre del equipo al que pertenece: ");
                    string equipoJugador = Console.ReadLine();
                    miTorneo.RegistrarJugador(nombreJugador, equipoJugador);
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
                    Console.WriteLine("Saliendo de la aplicación. ¡Hasta luego!");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
        }
    }
}