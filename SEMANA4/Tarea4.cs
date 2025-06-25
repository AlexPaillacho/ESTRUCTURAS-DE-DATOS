using System; // Necesario para Console.WriteLine y Console.ReadLine

public class CONTACTOS
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("Mis contactos");

       
        clasestudy[] contactos = new clasestudy[5];

        
        for (int i = 0; i < contactos.Length-1; i++) // Iteramos de 0 a 4
        {



            Console.WriteLine($"\n--- Creando contacto para la posición {i} (Contacto {i + 1}) ---");

            // Pedir el nombre del contacto
            Console.Write("Ingrese el nombre del contacto: ");
            string nombreIngresado = Console.ReadLine();

            // Pedir elnumero de teléfono 
            Console.Write("Ingrese un número de teléfono: ");
            string telefonoIngresado = Console.ReadLine();
            string[] telefonos = { telefonoIngresado }; 

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
            if (contactos[i] != null)
           
            // Ahora 'contactos[i]' ya NO es null, porque lo inicializamos en el bucle anterior.
            Console.WriteLine($"Contacto {i + 1}: {contactos[i].getnombre()}");
        }

        Console.WriteLine("\nFin de la demostración.");
        // Console.ReadKey(); // Opcional: para que la consola no se cierre inmediatamente
    }
}