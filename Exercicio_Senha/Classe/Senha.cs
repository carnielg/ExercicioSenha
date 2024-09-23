using System;

public class Senha
{
    public string Valor { get; private set; }

    public Senha(string valor)
    {
        Valor = valor;
    }

    public string VerificarSeguranca()
    {
        // Verifica se a senha tem pelo menos 8 caracteres
        if (Valor.Length < 8)
        {
            return "Senha fraca: A senha deve ter pelo menos 8 caracteres.";
        }

        bool temMaiuscula = false;
        bool temMinuscula = false;
        bool temNumero = false;

        // Verifica cada caractere da senha
        foreach (char c in Valor)
        {
            if (char.IsUpper(c))
            {
                temMaiuscula = true;
            }
            else if (char.IsLower(c))
            {
                temMinuscula = true;
            }
            else if (char.IsDigit(c))
            {
                temNumero = true;
            }
        }

        // Verifica se todos os critérios foram atendidos
        if (!temMaiuscula)
        {
            return "Senha fraca: A senha deve conter pelo menos uma letra maiúscula.";
        }
        if (!temMinuscula)
        {
            return "Senha fraca: A senha deve conter pelo menos uma letra minúscula.";
        }
        if (!temNumero)
        {
            return "Senha fraca: A senha deve conter pelo menos um número.";
        }

        return "Senha forte.";
    }
}