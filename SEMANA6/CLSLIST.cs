

// 1. Clase para representar un Nodo de la lista enlazada
public class Nodo
{
    public int Valor { get; set; } // El dato que guarda el nodo
    public Nodo Siguiente { get; set; } // Referencia al siguiente nodo

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null; // Inicialmente, no apunta a ningún otro nodo
    }
}

// 2. Clase para representar la Lista Enlazada
public class ListaEnlazada
{
    public Nodo Cabeza { get; private set; } // El primer nodo de la lista

    public ListaEnlazada()
    {
        Cabeza = null; // La lista está vacía al inicio
    }

    // Método para añadir un nuevo nodo al final de la lista (útil para pruebas)
    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        if (Cabeza == null)
        {
            Cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }

    // 3. Función para calcular el número de elementos (la longitud) de la lista
    public int ContarElementos()
    {
        int contador = 0; // Inicializamos el contador en cero
        Nodo actual = Cabeza; // Empezamos desde el primer nodo

        // Recorremos la lista mientras el nodo actual no sea nulo
        // (es decir, hasta que lleguemos al final de la lista)
        while (actual != null)
        {
            contador++; // Incrementamos el contador por cada nodo que encontramos
            actual = actual.Siguiente; // Nos movemos al siguiente nodo
        }

        return contador; // Devolvemos el total de nodos contados
    }

    // Método para imprimir la lista (útil para verificar)
    public void ImprimirLista()
    {
        if (Cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = Cabeza;
        Console.Write("Lista: ");
        while (actual != null)
        {
            Console.Write($"{actual.Valor} -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }
}

// Clase principal para probar la funcionalidad
public class Program
{
    public static void Main(string[] args)
    {
        ListaEnlazada miLista = new ListaEnlazada();

        // Agregamos algunos elementos a la lista para probar
        miLista.Agregar(10);
        miLista.Agregar(20);
        miLista.Agregar(30);
        miLista.Agregar(40);

        miLista.ImprimirLista(); // Imprime: Lista: 10 -> 20 -> 30 -> 40 -> null

        // Calculamos y mostramos el número de elementos
        int numeroDeElementos = miLista.ContarElementos();
        Console.WriteLine($"\nEl número de elementos en la lista es: {numeroDeElementos}"); // Debería ser 4

        Console.WriteLine("\n--- Probando con una lista vacía ---");
        ListaEnlazada listaVacia = new ListaEnlazada();
        listaVacia.ImprimirLista(); // Imprime: La lista está vacía.
        int elementosListaVacia = listaVacia.ContarElementos();
        Console.WriteLine($"El número de elementos en la lista vacía es: {elementosListaVacia}"); // Debería ser 0

        Console.WriteLine("\n--- Probando con un solo elemento ---");
        ListaEnlazada listaUnElemento = new ListaEnlazada();
        listaUnElemento.Agregar(100);
        listaUnElemento.ImprimirLista(); // Imprime: Lista: 100 -> null
        int elementosUnElemento = listaUnElemento.ContarElementos();
        Console.WriteLine($"El número de elementos en la lista de un solo elemento es: {elementosUnElemento}"); // Debería ser 1
    }
}
