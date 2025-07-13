
public class HanoiSolver
{
    // Definimos las tres torres como pilas
    private static Stack<int> sourceTower;      
    private static Stack<int> auxiliaryTower;   
    private static Stack<int> destinationTower; 
    private static int numberOfDisks;
    private static long moveCount = 0; 

    public static void Main(string[] args)
    {
        Console.WriteLine("--- Problema de las Torres de Hanói ---");
        Console.Write("Ingrese el número de discos (ej. 3): ");

        while (!int.TryParse(Console.ReadLine(), out numberOfDisks) || numberOfDisks < 1)
        {
            Console.Write("Número de discos inválido. Ingrese un entero positivo: ");
        }

        // Inicializar las torres
        sourceTower = new Stack<int>();
        auxiliaryTower = new Stack<int>();
        destinationTower = new Stack<int>();

        
        // Se carga la torre de origen con los discos en su orden inicial: el más grande en la base y el más pequeño en la cima.
        
        for (int i = numberOfDisks; i >= 1; i--)
        {
            sourceTower.Push(i);
        }

        Console.WriteLine("\nEstado inicial de las torres:");
        PrintTowers();

        Console.WriteLine("\nComenzando la resolución...");
        // Llamar a la función recursiva para resolver el problema
        SolveHanoi(numberOfDisks, sourceTower, destinationTower, auxiliaryTower);

        Console.WriteLine("\n--- Resolución Finalizada ---");
        Console.WriteLine("Estado final de las torres:");
        PrintTowers();
        Console.WriteLine($"\nTotal de movimientos: {moveCount}");

        Console.WriteLine("\nPresione cualquier tecla para salir.");
    }


    public static void SolveHanoi(int n, Stack<int> source, Stack<int> destination, Stack<int> auxiliary)
    {
        if (n == 1)
        {
            
            MoveDisk(source, destination);
        }
        else
        {
            
            SolveHanoi(n - 1, source, auxiliary, destination);

            
            MoveDisk(source, destination);

            
            SolveHanoi(n - 1, auxiliary, destination, source);
        }
    }

    
    private static void MoveDisk(Stack<int> fromTower, Stack<int> toTower)
    {
        // El disco que se mueve es el que está en la cima de la torre de origen
        int disk = fromTower.Pop();
        toTower.Push(disk); 
        moveCount++;

        Console.WriteLine($"\nMovimiento #{moveCount}: Mover disco {disk} de la torre {GetTowerName(fromTower)} a la torre {GetTowerName(toTower)}");
        PrintTowers(); // Mostrar el estado actual de las torres
        
    }

    
    private static string GetTowerName(Stack<int> tower)
    {
        if (tower == sourceTower) return "Origen";
        if (tower == auxiliaryTower) return "Auxiliar";
        if (tower == destinationTower) return "Destino";
        return "Desconocida";
    }

   
    private static void PrintTowers()
    {
        Console.WriteLine("--------------------");
        Console.WriteLine($"Torre Origen   ({sourceTower.Count} discos): {string.Join(", ", sourceTower.Reverse().ToArray())}");
        Console.WriteLine($"Torre Auxiliar ({auxiliaryTower.Count} discos): {string.Join(", ", auxiliaryTower.Reverse().ToArray())}");
        Console.WriteLine($"Torre Destino  ({destinationTower.Count} discos): {string.Join(", ", destinationTower.Reverse().ToArray())}");
        Console.WriteLine("--------------------");
    }
}