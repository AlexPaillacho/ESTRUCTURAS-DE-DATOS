public class ParenthesisChecker
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Verificación de Paréntesis Balanceados ---");
        Console.WriteLine("Ingrese una expresión matemática:");
        string expression = Console.ReadLine();

        if (IsBalanced(expression))
        {
            Console.WriteLine("Salida: Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Salida: Fórmula NO balanceada.");
        }

        Console.WriteLine("\nPresione cualquier tecla para salir.");
        Console.ReadKey();
    }

    // Método para verificar si la expresión está balanceada
    public static bool IsBalanced(string expression)
    {
        // Usamos un Stack de caracteres para almacenar los caracteres de apertura
        Stack<char> stack = new Stack<char>();

        // Recorremos cada carácter de la expresión
        foreach (char c in expression)
        {
            // Si el carácter es de apertura, lo empujamos a la pila
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            // Si el carácter es de cierre
            else if (c == ')' || c == '}' || c == ']')
            {
                // Si la pila está vacía, significa que encontramos un cierre sin un apertura correspondiente
                if (stack.Count == 0)
                {
                    return false;
                }

                // Obtenemos el carácter de apertura superior de la pila
                char topChar = stack.Pop(); // Sacamos el elemento de la pila

                // Verificamos si el carácter de cierre actual coincide con el de apertura
                switch (c)
                {
                    case ')':
                        if (topChar != '(') return false;
                        break;
                    case '}':
                        if (topChar != '{') return false;
                        break;
                    case ']':
                        if (topChar != '[') return false;
                        break;
                }
            }
            // Si el carácter no es un paréntesis, llave o corchete, lo ignoramos
        }

        // Al final, si la pila está vacía, todos los caracteres de apertura tuvieron su cierre correspondiente
        return stack.Count == 0;
    }
}