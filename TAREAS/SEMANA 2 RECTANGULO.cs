using System; // Necesario para usar Console.WriteLine y Console.ReadLine

public class CalcularAreaRectangulo
{
    public static void Main(string[] args)
    {
        // 1. Declarar variables para almacenar el ancho y la altura.
        // Usamos 'double' para permitir números con decimales.
        double ancho;
        double altura;
        double area;

        // 2. Pedir al usuario que ingrese el ancho.
        Console.WriteLine("Por favor, ingresa el ancho del rectángulo:");
        // Console.ReadLine() lee lo que el usuario escribe como texto (string).
        // Convert.ToDouble() convierte ese texto a un número decimal (double).
        ancho = Convert.ToDouble(Console.ReadLine());

        // 3. Pedir al usuario que ingrese la altura.
        Console.WriteLine("Ahora, ingresa la altura del rectángulo:");
        altura = Convert.ToDouble(Console.ReadLine());

        // 4. Calcular el área.
        // El área de un rectángulo es simplemente ancho por altura.
        area = ancho * altura;

        // 5. Mostrar el resultado al usuario.
        // Usamos una cadena interpolada ($"...") para mostrar el resultado de forma clara.
        // ":F2" formatea el número a dos decimales para una mejor presentación.
        Console.WriteLine($"\nEl área del rectángulo es: {area:F2}");

        // Opcional: Pausar la consola para que el usuario pueda ver el resultado.
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadLine(); // Espera a que el usuario presione una tecla antes de cerrar.
    }
}
