

// ejercicio 1
public class Nodo
{
    public int Valor { get; set; } 
    public Nodo Siguiente { get; set; } 

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null; 
    }
}


public class ListaEnlazada
{
    public Nodo Cabeza { get; private set; } 

    public ListaEnlazada()
    {
        Cabeza = null; 
    }

    
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

    
    public int ContarElementos()
    {
        int contador = 0; 
        Nodo actual = Cabeza; 

        
        
        while (actual != null)
        {
            contador++; 
            actual = actual.Siguiente; 
        }

        return contador; 
    }

    
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


public class Program
{
    public static void Main(string[] args)
    {
        ListaEnlazada miLista = new ListaEnlazada();

        
        miLista.Agregar(24);
        miLista.Agregar(26);
        miLista.Agregar(28);
        miLista.Agregar(29);
        miLista.Agregar(30);
        miLista.Agregar(32);
        miLista.Agregar(34);

        miLista.ImprimirLista(); 

        int numeroDeElementos = miLista.ContarElementos();
        Console.WriteLine($"\nEl número de elementos en la lista es: {numeroDeElementos}"); 

        
    }
}
