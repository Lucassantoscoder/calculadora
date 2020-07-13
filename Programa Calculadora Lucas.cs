using System;

namespace Calculadora
{
    class Calculadora   
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // O valor padrão é "não é um número" que usamos se uma operação, como divisão, puder resultar em um erro.

            // Use uma instrução switch para fazer as contas ok.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Peça ao usuário para inserir um divisor diferente de zero.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Retornar texto para uma entrada de opção incorreta.
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Aplicativo de calculadora simples do C#.
            Console.WriteLine("Calculadora Simples Lucas C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declarar variávei ​​e definido como vazio.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Peça ao usuário para digitar o primeiro número.
                Console.Write("Adicione um numero que deseja calcular: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Esta entrada não é válida.Por favor insira um valor numérico: ");
                    numInput1 = Console.ReadLine();
                }

                // Peça ao usuário para digitar o segundo número.
                Console.Write("Digite outro número e pressione Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Esta entrada não é válida.Por favor insira um valor numérico: ");
                    numInput2 = Console.ReadLine();
                }

                // Peça ao usuário para escolher um operador.
                Console.WriteLine("Escolha um operador da lista a seguir:");
                Console.WriteLine("\ta - Adicao");
                Console.WriteLine("\ts - Subtracao");
                Console.WriteLine("\tm - Multiplicacao");
                Console.WriteLine("\td - Divisao");
                Console.Write("Sua Escolha foi----> ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculadora.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Esta operação resultará em um erro de matematica.\n");
                    }
                    else Console.WriteLine("Seu Resultado: {0:0.##}\n", result);

                    Console.WriteLine("Obrigado por usar a calculadora simples lucas");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ah nãoooo! Ocorreu uma exceção ao tentar fazer as contas.\n - Details: " + e.Message);
                }

                Console.WriteLine("*********************************************\n");

                // Aguarde a resposta do usuário antes de fechar.
                Console.Write("Pressione 'n' e Enter para fechar o aplicativo ou pressione qualquer outra tecla e Enter para continuar: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Espaçamento amigável entre linhas.
            }
            return;
        }
    }
}