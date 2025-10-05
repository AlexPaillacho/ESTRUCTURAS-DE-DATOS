

// Definición de la Clase Vuelo 
public class Vuelo
{
    
    public string Destino { get; set; }
    public decimal Precio { get; set; }  
    public string Numero_Vuelo { get; set; }

    public override string ToString()
    {
        return $" -> {Destino} ({Numero_Vuelo}) - ${Precio}";
    }
}

//  Definición de la Clase Vuelos 
public class GrafoVuelos
{
    
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

    // Base de Datos 
    public void CargarRutasFicticias()
    {
        // Origen:  ECUADOR
        AgregarVuelo("ECUADOR", new Vuelo { Destino = "MADRID", Precio = 1200, Numero_Vuelo = "AV108" });
        AgregarVuelo("ECUADOR", new Vuelo { Destino = "JAPON", Precio = 2000, Numero_Vuelo = "AV102" });
        AgregarVuelo("ECUADOR", new Vuelo { Destino = "MADRID", Precio = 2500, Numero_Vuelo = "IB202" });

        // Origen: MADRID 
        AgregarVuelo("MADRID", new Vuelo { Destino = "EEUU", Precio = 1000, Numero_Vuelo = "AV404" });
        AgregarVuelo("MADRID", new Vuelo { Destino = "EEUU", Precio = 400, Numero_Vuelo = "IB505" });

        // Origen: MEXICO
        AgregarVuelo("ECUADOR", new Vuelo { Destino = "JAPON", Precio = 600, Numero_Vuelo = "IB238" });

        // Origen: MEXICO
        AgregarVuelo("EEUU", new Vuelo { Destino = "MADRID", Precio = 900, Numero_Vuelo = "IB905" });
        
       
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

    // Método de Consulta
    public (decimal, List<string>) EncontrarRutaMasBarata(string origen, string destino)
    {
     
        var distancias = new Dictionary<string, decimal>();
        var predecesores = new Dictionary<string, string>();
        
        var noVisitados = new SortedSet<(decimal Costo, string Aeropuerto)>();

        
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

        
        while (noVisitados.Any())
        {
            
            var (costoActual, actual) = noVisitados.First();
            noVisitados.Remove(noVisitados.First());

           
            if (actual == destino) break;
            
           
            if (costoActual > distancias[actual]) continue;
            
            
            if (!Rutas.ContainsKey(actual)) continue; 

           
            foreach (var vuelo in Rutas[actual])
            {
                string vecino = vuelo.Destino;
                decimal nuevoCosto = costoActual + vuelo.Precio;

                if (nuevoCosto < distancias[vecino])
                {
                    
                    if (distancias[vecino] != decimal.MaxValue)
                    {
                        
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
        
        if (paso != origen)
        {
             return (decimal.MaxValue, new List<string>()); 
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

// Programa Principal y Análisis 

public class Programa
{
    public static async Task Main(string[] args)
    {
        var grafo = new GrafoVuelos();
        grafo.CargarRutasFicticias();
        
        
        grafo.MostrarGrafo();

        string origenBusqueda = "ECUADOR";
        string destinoBusqueda = "MADRID";

       
        var (costo, ruta) = grafo.EncontrarRutaMasBarata(origenBusqueda, destinoBusqueda);

      
        Console.WriteLine($"\n--- Resultado de la Consulta de Vuelos Baratos ---");
        if (costo != decimal.MaxValue)
        {
            Console.WriteLine($"Origen: {origenBusqueda}, Destino: {destinoBusqueda}");
            Console.WriteLine($"Costo Total Mínimo: ${costo}");
            Console.WriteLine($"Ruta: {string.Join(" -> ", ruta)}");
        }
        else
        {
            Console.WriteLine($"No hay ruta disponible de {origenBusqueda} a {destinoBusqueda}.");
        }

        
    }

    
}