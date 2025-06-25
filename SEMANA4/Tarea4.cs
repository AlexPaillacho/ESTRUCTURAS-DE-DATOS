using System; // Necesario para Console.WriteLine y Console.ReadLine

public class Program
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("Mis contactos");

       
        clasestudy[] contactos = new clasestudy[5];

        
        for (int i = 0; i < contactos.Length; i++) // Iteramos de 0 a 4
        {
            Console.WriteLine($"\n--- Creando contacto para la posición {i} (Contacto {i + 1}) ---");

            // Pedir el nombre al usuario
            Console.Write("Ingrese el nombre del contacto: ");
            string nombreIngresado = Console.ReadLine();

            // Pedir al menos un teléfono (podrías expandir esto para múltiples teléfonos)
            Console.Write("Ingrese un número de teléfono: ");
            string telefonoIngresado = Console.ReadLine();
            string[] telefonos = { telefonoIngresado }; // Crear un array de string con este único teléfono

            // Instanciar (crear) un nuevo objeto clasestudy y asignarlo a la posición actual del array
            contactos[i] = new clasestudy(nombreIngresado, telefonos);

            Console.WriteLine($"Contacto '{nombreIngresado}' creado exitosamente en la posición {i}.");
        }

        // --- PARTE B: MOSTRAR LOS NOMBRES DE LOS CONTACTOS YA CREADOS ---
        // Este es el fragmento de tu código original adaptado para funcionar correctamente.
        Console.WriteLine("\n--- Nombres de mis contactos ---");
        // Asegúrate de que el bucle también sea de 0 a Length-1
        for (int i = 0; i < contactos.Length; i++)
        {
            // Ahora 'contactos[i]' ya NO es null, porque lo inicializamos en el bucle anterior.
            Console.WriteLine($"Contacto {i + 1}: {contactos[i].getnombre()}");
        }

        Console.WriteLine("\nFin de la demostración.");
        // Console.ReadKey(); // Opcional: para que la consola no se cierre inmediatamente
    }
}




 

