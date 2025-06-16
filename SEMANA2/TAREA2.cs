
 // Clase que representa un Rectángulo
    public class Rectangulo
    {
        // La longitud y el ancho son tipos de datos primitivos (double)
        public double Longitud { get; set; } // Propiedad autoimplementada
        public double Ancho { get; set; }    // Propiedad autoimplementada

        // Constructor para inicializar longitud y ancho
        public Rectangulo(double longitud, double ancho)
        {
            this.Longitud = longitud;
            this.Ancho = ancho;
        }

        // CalcularArea es una función que devuelve un valor double.
        // Se utiliza para calcular el área de un rectángulo.
        public double CalcularArea()
        {
            return Longitud * Ancho;
        }

        // CalcularPerimetro es una función que devuelve un valor double.
        // Se utiliza para calcular el perímetro de un rectángulo.
        public double CalcularPerimetro()
        {
            return 2 * (Longitud + Ancho);
        }
    }
  // Clase principal para probar las clases de figuras geométricas
    class Program
    {
        static void Main(string[] args)
        {Console.WriteLine("\n--- Rectángulo ---");
            // Crear un rectángulo con longitud 10 y ancho 4
            Rectangulo miRectangulo = new Rectangulo(20, 5);
            Console.WriteLine($"Longitud: {miRectangulo.Longitud}");
            Console.WriteLine($"Ancho: {miRectangulo.Ancho}");
            Console.WriteLine($"Área: {miRectangulo.CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {miRectangulo.CalcularPerimetro():F2}");

         }
    }