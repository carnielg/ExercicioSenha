using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Digite uma senha para verificar a força:");
            Console.WriteLine("(Pressione Enter para sair.)");

            var senha = new StringBuilder();

            // Armazena a posição inicial da linha onde a força da senha será exibida
            int linhaForcaSenha = Console.CursorTop + 1;

            while (true)
            {
                var tecla = Console.ReadKey(intercept: true);

                if (tecla.Key == ConsoleKey.Enter)
                {
                    if (senha.Length > 0)
                    {
                        Console.WriteLine(); // Move para a próxima linha
                        Console.WriteLine("Senha finalizada:");
                        ExibirForcaSenha(senha.ToString(), linhaForcaSenha);
                    }
                    break;
                }
                else if (tecla.Key == ConsoleKey.Backspace && senha.Length > 0)
                {
                    senha.Remove(senha.Length - 1, 1);
                    Console.Write("\b \b"); // Remove o caractere visível no console
                }
                else if (tecla.KeyChar >= 32 && tecla.KeyChar <= 126)
                {
                    senha.Append(tecla.KeyChar);
                    Console.Write("*"); // Exibe um asterisco no console para o caractere digitado
                }

                AtualizarForcaSenha(senha.ToString(), linhaForcaSenha);
            }
            Console.ReadKey();
        }

        static void ExibirForcaSenha(string senha, int linhaForcaSenha)
        {
            int forca = CalcularForcaSenha(senha);

            string indicador = new string('=', forca / 10);
            string forcaDescricao = forca < 30 ? "Fraca" : forca < 70 ? "Média" : "Forte";

            Console.SetCursorPosition(0, linhaForcaSenha);
            Console.Write(new string(' ', Console.WindowWidth)); // Limpa a linha
            Console.SetCursorPosition(0, linhaForcaSenha);
            Console.WriteLine(indicador.PadRight(10, '-')); // Exibe a barra de progresso
            Console.WriteLine($"Força: {forcaDescricao} ({forca}%)"); // Exibe a força da senha
        }

        static void AtualizarForcaSenha(string senha, int linhaForcaSenha)
        {
            //Limpa a linha onde a força da senha será exibida
            Console.SetCursorPosition(0, linhaForcaSenha);
            Console.Write(new string(' ', Console.WindowWidth)); // Limpa a linha
            Console.SetCursorPosition(0, linhaForcaSenha);
            Console.Write("Força da Senha: ");
            ExibirForcaSenha(senha, linhaForcaSenha);
        }

        static int CalcularForcaSenha(string senha)
        {
            int forca = 0;

            if (senha.Length >= 8)
                forca += 20;

            bool temMaiuscula = false;
            bool temMinuscula = false;
            bool temNumero = false;

            foreach (char c in senha)
            {
                if (char.IsUpper(c))
                    temMaiuscula = true;
                else if (char.IsLower(c))
                    temMinuscula = true;
                else if (char.IsDigit(c))
                    temNumero = true;
            }

            if (temMaiuscula)
                forca += 20;
            if (temMinuscula)
                forca += 20;
            if (temNumero)
                forca += 20;

            if (senha.IndexOfAny("!@#$%^&*()_+-=[]{}|;:',.<>?/".ToCharArray()) != -1)
                forca += 20;

            if (forca > 100) forca = 100;

            return forca;
        }
    }
}