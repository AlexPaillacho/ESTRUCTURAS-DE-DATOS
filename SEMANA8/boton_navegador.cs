
    public class Simulación
    {
        // Pila para el historial de páginas visitadas hacia atrás.
        private Stack<string> historial_retroceder = new Stack<string>();

        // Pila para el historial de páginas que se pueden adelantar.
        private Stack<string> historial_adelantar = new Stack<string>();

        // La URL de la página que el usuario está viendo actualmente.
        private string paginaingresada;

       
        public Simulación(string primerapagina = "http://www.google.com")
        {
            Console.WriteLine($"\nIniciando navegador en: {primerapagina}");
            paginaingresada = primerapagina;
            Console.WriteLine($"Página actual: {paginaingresada}");
        }

        
        public void VisitPage(string url)
        {
            // Se añade al historial_retoceder si ya hay una página actual diferente.
            if (!string.IsNullOrEmpty(paginaingresada) && paginaingresada != url)
            {
                Console.WriteLine($"\nNavegando de '{paginaingresada}' a '{url}'...");
                historial_retroceder.Push(paginaingresada);
            }
            else if (string.IsNullOrEmpty(paginaingresada))
            {
                Console.WriteLine($"\nIniciando navegador en '{url}'...");
            } else {
                Console.WriteLine($"\nYa estás en '{url}'.");
                return; // Si la página es la misma no hay cambios.
            }

            paginaingresada = url;
            historial_adelantar.Clear(); // Borra el historial de avance cuando se visita una nueva página.
            Console.WriteLine($"Página actual: {paginaingresada}");
        }

      
        // Simula el clic en el botón retroceder.

        public void GoBack()
        {
            if (historial_retroceder.Count == 0)
            {
                Console.WriteLine("\nNo hay historial para retroceder.");
                return;
            }

            Console.WriteLine($"\nRetrocediendo de '{paginaingresada}'...");
            historial_adelantar.Push(paginaingresada); // La página actual va al historial de adelante.
            paginaingresada = historial_retroceder.Pop(); // La página anterior se convierte en la actual.
            Console.WriteLine($"Página actual: {paginaingresada}");
        }

        /// <summary>
        /// Simula el clic en el botón "adelantar".
        /// </summary>
        public void GoForward()
        {
            if (historial_adelantar.Count == 0)
            {
                Console.WriteLine("\nNo hay historial para adelantar.");
                return;
            }

            Console.WriteLine($"\nAdelantando de '{paginaingresada}'...");
            historial_retroceder.Push(paginaingresada); // La página actual va al historial de 'atrás'
            paginaingresada = historial_adelantar.Pop(); // La página siguiente se convierte en la actual
            Console.WriteLine($"Página actual: {paginaingresada}");
        }

        /// <summary>
        /// Muestra el estado actual de los historiales del navegador.
        /// </summary>
        public void ShowStatus()
        {
            Console.WriteLine("\n--- Estado del Navegador ---");
            Console.WriteLine($"Página actual: {paginaingresada}");
            // Mostramos el historial de atrás en orden de visita real (Reverse)
            Console.WriteLine($"Historial Atrás: [{string.Join(", ", historial_retroceder.Reverse().ToList())}]");
            // Mostramos el historial de adelante como saldría con Pop (el más reciente primero)
            Console.WriteLine($"Historial Adelante: [{string.Join(", ", historial_adelantar.ToList())}]");
            Console.WriteLine("----------------------------");
        }
    }

    // --- Clase Principal (Program.cs) para la Ejecución ---
    class Program
    {
        static void Main(string[] args)
        {
            Simulación navegador = new Simulación(); // Inicia con google.com

            // Simulación de navegación a diferentes páginas
            navegador.VisitPage("https://www.facebook.com");
            navegador.VisitPage("https://www.youtube.com");
            navegador.VisitPage("https://www.git hub .com");
            navegador.VisitPage("https://www.facebook."); // Volvemos a Facebook

            navegador.ShowStatus();

            // Probando el botón retroceder
            navegador.GoBack(); // De facebook/profile a amazon.com/electronics
            navegador.ShowStatus();

            navegador.GoBack(); // De amazon.com/electronics a youtube.com/trending
            navegador.ShowStatus();

            navegador.GoBack(); // De youtube.com/trending a facebook.com/feed
            navegador.ShowStatus();

            navegador.GoBack(); // De facebook.com/feed a google.com
            navegador.ShowStatus();

            navegador.VisitPage("https://www.UNIVERSIDAD ESTATAL AMAZONICA.com");
            navegador.ShowStatus(); // El historial 'adelante' debería estar vacío ahora

            navegador.GoBack(); // De github.com/explore a youtube.com/trending
            navegador.ShowStatus();

           

            Console.ReadLine(); // Mantiene la consola abierta hasta que presiones una tecla
        }
    }
