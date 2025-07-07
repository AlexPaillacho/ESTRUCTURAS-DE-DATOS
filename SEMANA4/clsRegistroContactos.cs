// public class RegistroContactos
// {
//     public Contacto[] _nombres { get; set; }

   
//        public RegistroContactos(int Maximonombres)
//     {
//         _nombres = new Contacto[Maximonombres];
//     }

//     public void IngresoNuevocontacto(Contacto _numero, int posicion)
//     {
//         _nombres[posicion] = _numero;
//     }

//     public void imprimirnombres()
//     {
//         Console.WriteLine("Listado de contactos registradas");
//         System.Console.WriteLine("===========================");

//         for (int i = 0; i < _nombres.Length; i++)
//         {
//             //while (continuar == true)
//             //{
//             if (_nombres[i] != null)
//             {
//                 Console.WriteLine("nombre " + _nombres[i].Nombre);
//             }
//             //     else
//             //     {
//             //         continuar = false;
//             //     }
//             // }
//         }
//     }


//     public void buscar(string nombrecontacto)
//     {
//         Console.WriteLine();
//         Console.WriteLine("Búsqueda de contacto");
//         System.Console.WriteLine("===========================");
//         if (encontrar(nombrecontacto))
//         {
//             Console.WriteLine("El registro fue encontrado");
//         }
//         else
//         {
//             Console.WriteLine("No se encuentro el registro");
//         }
//     }


   


//     private bool encontrar(string nombre)
//     {
//         bool encontrado = false;

//         for (int i = 0; i < _nombres.Length; i++)
//         {
//             if (_nombres[i] != null)
//             {
//                 if (nombre == _nombres[i].Nombre)
//                 {
//                     encontrado = true;
//                 }
//             }
//         }

//         return encontrado;
//     }
// }

// public class Contacto
// {
//     public string Nombre { get; set; }
//     public double Telefono { get; set; }

//     // Constructor
//     public Contacto(string nombre, int _numero)
//     {
//         Nombre = nombre;
//         Telefono = _numero;

//     }
// }


