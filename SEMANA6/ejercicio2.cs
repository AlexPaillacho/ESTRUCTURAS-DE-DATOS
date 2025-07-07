// Ejercicio 2
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


    public int BuscarYContarElementos(int valorBuscado)
    {
        int ocurrencias = 0;
        Nodo actual = Cabeza;


        while (actual != null)
        {

            if (actual.Valor == valorBuscado)
            {
                ocurrencias++;
            }
            actual = actual.Siguiente;

        }
        
        if (ocurrencias == 0)
        {
            Console.WriteLine($"El dato {valorBuscado} no fue encontrado en la lista.");
        }
        else
        {
            Console.WriteLine($"El dato {valorBuscado} fue encontrado {ocurrencias} vez(es) en la lista.");
        }

        return ocurrencias;


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
        Console.WriteLine("--- Prueba de Lista Enlazada y Búsqueda ---");
        ListaEnlazada miLista = new ListaEnlazada();


        miLista.Agregar(10);
        miLista.Agregar(8);
        miLista.Agregar(22);
        miLista.Agregar(8);
        miLista.Agregar(40);
        miLista.Agregar(10);

        miLista.ImprimirLista();


        Console.WriteLine("\n--- Buscando elementos ---");


        int valorBuscar1 = 8;
        int vecesEncontrado1 = miLista.BuscarYContarElementos(valorBuscar1);
        Console.WriteLine($"El método retornó: {vecesEncontrado1}");

        Console.WriteLine("--------------------");


        int valorBuscar2 = 22;
        int vecesEncontrado2 = miLista.BuscarYContarElementos(valorBuscar2);
        Console.WriteLine($"El método retornó: {vecesEncontrado2}");

        Console.WriteLine("--------------------");


        int valorBuscar3 = 50;
        int vecesEncontrado3 = miLista.BuscarYContarElementos(valorBuscar3);
        Console.WriteLine($"El método retornó: {vecesEncontrado3}");

        Console.WriteLine("--------------------");


        Console.WriteLine("\n--- Probando búsqueda en lista vacía ---");
        ListaEnlazada listaVacia = new ListaEnlazada();
        listaVacia.ImprimirLista();
        int valorBuscarEnVacia = 99;
        int vecesEncontradoVacia = listaVacia.BuscarYContarElementos(valorBuscarEnVacia);
        Console.WriteLine($"El método retornó: {vecesEncontradoVacia}");

        Console.WriteLine("\n--- Fin de las pruebas ---");
    }
}