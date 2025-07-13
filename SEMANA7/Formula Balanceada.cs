
// clase revisar expresiones
public class REVISAREXPRESIONES
{
    public static void Main(string[] args)
    {
        Console.WriteLine("   Verificación de Paréntesis Balanceados  ");
        Console.WriteLine("Ingrese una expresión matemática:");
        string expression = Console.ReadLine();

        if (IsBalanced (expression))
        {
            Console.WriteLine("Salida: Fórmula balanceada");
        }
        else
        {
            Console.WriteLine("Salida: Fórmula No balanceada");
        }

        Console.WriteLine("\nPresione cualquier tecla para salir  ");
    }

    // Verificamos si la funcion esta correcta o balanceada
    public static bool IsBalanced(string expression)
    {

        Stack<char> stack = new Stack<char>();


        foreach (char c in expression)
        {

            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }

            else if (c == ')' || c == '}' || c == ']')
            {

                if (stack.Count == 0)
                {
                    return false;
                }


                char topChar = stack.Pop();


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

        }


        return stack.Count == 0;
    }
}