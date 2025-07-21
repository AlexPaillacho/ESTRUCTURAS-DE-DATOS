
    public class Simulación
    {
        // Pila para el historial de páginas visitadas hacia atrás.
        private Stack<string> historial_retroceder = new Stack<string>();

        // Pila para el historial de páginas que se pueden adelantar.
        private Stack<string> historial_adelantar = new Stack<string>();

        // La URL de la página que el usuario está viendo actualmente.
        private string pagina_ingresada;

       
        public Simulación(string primerapagina = "http://www.google.com")
        {
            Console.WriteLine($"\nIniciando navegador en: {primerapagina}");
            pagina_ingresada = primerapagina;
            Console.WriteLine($"Página actual: {pagina_ingresada}");
        }

        
        public void VisitPage(string url)
        {
            // Se añade al historial_retoceder si ya hay una página actual diferente.
            if (!string.IsNullOrEmpty(pagina_ingresada) && pagina_ingresada != url)
            {
                Console.WriteLine($"\nNavegando de '{pagina_ingresada}' a '{url}'");
                historial_retroceder.Push(pagina_ingresada);
            }
            else if (string.IsNullOrEmpty(pagina_ingresada))
            {
                Console.WriteLine($"\nIniciando navegador en '{url}'");
            } else {
                Console.WriteLine($"\nYa estás en '{url}'.");
                return; // Si la página es la misma no hay cambios.
            }

            pagina_ingresada = url;
            historial_adelantar.Clear(); // Borra el historial de avance cuando se visita una nueva página.
            Console.WriteLine($"Página actual: {pagina_ingresada}");
        }

      
        // Simula el clic del botón retroceder.

        public void GoBack()
        {
            if (historial_retroceder.Count == 0)
            {
                Console.WriteLine("\nNo hay historial para retroceder.");
                return;
            }

            Console.WriteLine($"\nRetrocediendo de '{pagina_ingresada}'...");
            historial_adelantar.Push(pagina_ingresada); // La página actual va al historial de adelante.
            pagina_ingresada = historial_retroceder.Pop(); // La página anterior se convierte en la actual.
            Console.WriteLine($"Página actual: {pagina_ingresada}");
        }

   
        // Simula el clic del botón adelantar.
               public void GoForward()
        {
            if (historial_adelantar.Count == 0)
            {
                Console.WriteLine("\nNo hay historial para adelantar.");
                return;
            }

            Console.WriteLine($"\nAdelantando de '{pagina_ingresada}'...");
            historial_retroceder.Push(pagina_ingresada); // La página actual va al historial de atrás.
            pagina_ingresada = historial_adelantar.Pop(); // La página siguiente se convierte en la actual
            Console.WriteLine($"Página actual: {pagina_ingresada}");
        }

        
        /// Muestra el estado actual de los historiales del navegador.
        
        public void ShowStatus()
        {
            Console.WriteLine("\n--- Estado del Navegador ---");
            Console.WriteLine($"Página actual: {pagina_ingresada}");
            // Mostramos el historial de atrás en orden de visita.
            Console.WriteLine($"Historial Atrás: [{string.Join(", ", historial_retroceder.Reverse().ToList())}]");
            // Mostramos el historial de adelante.
            Console.WriteLine($"Historial Adelante: [{string.Join(", ", historial_adelantar.ToList())}]");
            Console.WriteLine("----------------------------");
        }
    }

    
    class navegación
    {
        static void Main(string[] args)
        {
            Simulación navegador = new Simulación(); 

            // Simulación de navegación a diferentes páginas
            navegador.VisitPage("https://www.facebook.com");
            navegador.VisitPage("https://www.youtube.com");
            navegador.VisitPage("https://www.git hub .com");
            navegador.VisitPage("https://www.facebook."); // Volvemos a Facebook

            navegador.ShowStatus();

            // Probando el botón retroceder
            navegador.GoBack(); 
            navegador.ShowStatus();

            navegador.GoBack(); 
            navegador.ShowStatus();

            navegador.GoBack();
            navegador.ShowStatus();

            navegador.GoBack(); 
            navegador.ShowStatus();

            navegador.VisitPage("https://www.UNIVERSIDAD ESTATAL AMAZONICA.com");
            navegador.ShowStatus(); 

            navegador.GoBack(); 
            navegador.ShowStatus();

           

            Console.ReadLine(); // Mantiene la consola abierta hasta que presione una tecla.
        }
    }
