public class clasestudy
{
    private string nombre;
    private string[] telefono;

    public clasestudy(string nombre, string[] telefonos)
    {
        this.nombre = nombre;
        this.telefono = telefonos;
    }

    public string getnombre()
    {
        return nombre;
    }

    public void mostrarinformacion() // Este método es clave para mostrar nombre y teléfonos
    {
        Console.WriteLine($"  Nombre: {this.nombre}");
        if (this.telefono != null && this.telefono.Length > 0)
        {
            Console.WriteLine("  Teléfonos:");
            foreach (string tel in this.telefono)
            {
                Console.WriteLine($"  - {tel}");
            }
        }
        else
        {
            Console.WriteLine("  No se han registrado teléfonos.");
        }
    }
}
