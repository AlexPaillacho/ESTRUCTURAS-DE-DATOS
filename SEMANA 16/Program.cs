

// --- 1. Definición de la Clase Vuelo (Arista) ---
public class Vuelo
{
    // Una Arista del grafo
    public string Destino { get; set; } // Vértice al que apunta
    public decimal Precio { get; set; }  // Peso de la arista
    public string NumeroVuelo { get; set; }

    public override string ToString()
    {
        return $" -> {Destino} ({NumeroVuelo}) - ${Precio:F2}";
    }
}

// --- 2. Definición de la Clase GrafoVuelos (Lista de Adyacencia) ---
public class GrafoVuelos
{
    // Lista de Adyacencia: Aeropuerto (Vértice) -> Lista de Vuelos directos (Aristas)
    private Dictionary<string, List<Vuelo>> Rutas;

    public GrafoVuelos()
    {
        Rutas = new Dictionary<string, List<Vuelo>>();
    }

    public void AgregarVuelo(string origen, Vuelo vuelo)
    {
        if (!Rutas.ContainsKey(origen))
        {
            Rutas[origen] = new List<Vuelo>();
        }
        Rutas[origen].Add(vuelo);
    }

    // Base de Datos Ficticia
    public void CargarRutasFicticias()
    {
        // Origen: BOG (Bogotá)
        AgregarVuelo("BOG", new Vuelo { Destino = "MIA", Precio = 250.00m, NumeroVuelo = "AV101" });
        AgregarVuelo("BOG", new Vuelo { Destino = "MEX", Precio = 180.00m, NumeroVuelo = "LA606" });
        AgregarVuelo("BOG", new Vuelo { Destino = "MAD", Precio = 550.00m, NumeroVuelo = "IB707" });

        // Origen: MIA (Miami)
        AgregarVuelo("MIA", new Vuelo { Destino = "MEX", Precio = 150.00m, NumeroVuelo = "DL404" });
        AgregarVuelo("MIA", new Vuelo { Destino = "LAX", Precio = 300.75m, NumeroVuelo = "AA505" });

        // Origen: MEX (Ciudad de México)
        AgregarVuelo("MEX", new Vuelo { Destino = "BOG", Precio = 200.00m, NumeroVuelo = "AM808" });

        // Origen: MAD (Madrid)
        AgregarVuelo("MAD", new Vuelo { Destino = "BCN", Precio = 45.99m, NumeroVuelo = "VY909" });
        
        // Agregar algunos aeropuertos sin salidas para que sean considerados como destinos posibles
        if (!Rutas.ContainsKey("LAX")) Rutas.Add("LAX", new List<Vuelo>());
        if (!Rutas.ContainsKey("BCN")) Rutas.Add("BCN", new List<Vuelo>());
    }

    // Método de Reportería: Visualizar Grafo
    public void MostrarGrafo()
    {
        Console.WriteLine("\n--- Reportería: Estructura del Grafo de Vuelos ---");
        foreach (var origen in Rutas.Keys.OrderBy(k => k))
        {
            if (Rutas[origen].Count > 0)
            {
                 Console.WriteLine($"\nAeropuerto Origen: {origen} ({Rutas[origen].Count} rutas)");
                 foreach (var vuelo in Rutas[origen])
                 {
                     Console.WriteLine($"\t{vuelo}");
                 }
            }
        }
    }

    // Método de Consulta: Algoritmo de Dijkstra para la Ruta Más Barata
    public (decimal, List<string>) EncontrarRutaMasBarata(string origen, string destino)
    {
        // 1. Inicialización
        var distancias = new Dictionary<string, decimal>();
        var predecesores = new Dictionary<string, string>();
        
        // Se simplifica el SortedSet para usar el Comparer predeterminado de Tuple.
        // Esto asume que el costo (Item1) es suficiente para el ordenamiento,
        // eliminando la comparación secundaria por nombre de aeropuerto.
        var noVisitados = new SortedSet<(decimal Costo, string Aeropuerto)>();

        // Determinar todos los aeropuertos (vértices)
        var todosLosAeropuertos = Rutas.Keys
            .Concat(Rutas.Values.SelectMany(v => v).Select(v => v.Destino)).Distinct();

        foreach (var aeropuerto in todosLosAeropuertos)
        {
            distancias[aeropuerto] = decimal.MaxValue;
        }

        if (!distancias.ContainsKey(origen)) return (decimal.MaxValue, new List<string> { $"Origen '{origen}' no existe." });
        if (!distancias.ContainsKey(destino)) return (decimal.MaxValue, new List<string> { $"Destino '{destino}' no existe." });

        distancias[origen] = 0;
        noVisitados.Add((0, origen));

        // 2. Ejecución del Algoritmo de Dijkstra
        while (noVisitados.Any())
        {
            // Extraer el nodo con la distancia más corta (greedy)
            var (costoActual, actual) = noVisitados.First();
            noVisitados.Remove(noVisitados.First());

            // Si llegamos al destino, detenemos la búsqueda
            if (actual == destino) break;
            
            // Si el costo actual es mayor que el registrado, descartamos
            if (costoActual > distancias[actual]) continue;
            
            // Si el nodo no tiene salidas, continuamos
            if (!Rutas.ContainsKey(actual)) continue; 

            // Relajación de aristas
            foreach (var vuelo in Rutas[actual])
            {
                string vecino = vuelo.Destino;
                decimal nuevoCosto = costoActual + vuelo.Precio;

                if (nuevoCosto < distancias[vecino])
                {
                    // La remoción previa requiere buscar por el viejo costo, que es complicado sin el comparador de desempate.
                    // Para evitar el error en el comparador, ajustamos la remoción a esta forma.
                    // Nota: Si el aeropuerto existe con su costo anterior, es mejor removerlo antes de insertar.
                    if (distancias[vecino] != decimal.MaxValue)
                    {
                        // Buscamos la entrada anterior para eliminarla. Esto puede ser ineficiente si el set es grande.
                        var oldEntry = noVisitados.FirstOrDefault(x => x.Aeropuerto == vecino);
                        if (oldEntry != default)
                        {
                             noVisitados.Remove(oldEntry); 
                        }
                    }
                    
                    distancias[vecino] = nuevoCosto;
                    predecesores[vecino] = actual;
                    noVisitados.Add((nuevoCosto, vecino));
                }
            }
        }
        
        // 3. Reconstruir el camino
        if (distancias.GetValueOrDefault(destino, decimal.MaxValue) == decimal.MaxValue)
        {
            return (decimal.MaxValue, new List<string>());
        }

        List<string> ruta = new List<string>();
        string paso = destino;
        while (paso != origen && predecesores.ContainsKey(paso))
        {
            ruta.Add(paso);
            paso = predecesores[paso];
        }
        // Verificar que se encontró el camino de vuelta al origen
        if (paso != origen)
        {
             return (decimal.MaxValue, new List<string>()); // No se encontró camino
        }
        ruta.Add(origen);
        ruta.Reverse();

        return (distancias[destino], ruta);
    }
    
    public int ContarVertices()
    {
        return Rutas.Keys.Concat(Rutas.Values.SelectMany(v => v).Select(v => v.Destino)).Distinct().Count();
    }

    public int ContarAristas()
    {
        return Rutas.Values.Sum(v => v.Count);
    }
}

// --- 3. Programa Principal y Análisis ---

public class Programa
{
    public static void Main(string[] args)
    {
        var grafo = new GrafoVuelos();
        grafo.CargarRutasFicticias();
        
        // --- Reportería (Visualización y Consulta) ---
        grafo.MostrarGrafo();

        string origenBusqueda = "BOG";
        string destinoBusqueda = "LAX";

        // Se elimina la línea Stopwatch stopwatch = new Stopwatch();

        // Se elimina stopwatch.Start();

        // Ejecutar la consulta (Algoritmo de Dijkstra)
        var (costo, ruta) = grafo.EncontrarRutaMasBarata(origenBusqueda, destinoBusqueda);

        // Se elimina stopwatch.Stop();
        
        Console.WriteLine($"\n--- Resultado de la Consulta de Vuelos Baratos ---");
        if (costo != decimal.MaxValue)
        {
            Console.WriteLine($"Origen: {origenBusqueda}, Destino: {destinoBusqueda}");
            Console.WriteLine($"Costo Total Mínimo: ${costo:F2}");
            Console.WriteLine($"Ruta: {string.Join(" -> ", ruta)}");
        }
        else
        {
            Console.WriteLine($"No hay ruta disponible de {origenBusqueda} a {destinoBusqueda}.");
        }

        
    }

    
}