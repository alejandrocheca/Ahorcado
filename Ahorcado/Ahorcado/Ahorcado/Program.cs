using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static List<string> palabras = new List<string>();

    static Random rand = new Random();

    static void Main()
    {
        CargarPalabras();

        if (palabras.Count == 0)
        {
            Console.WriteLine("No hay palabras disponibles para jugar.");
            return;
        }

        string palabraSecreta = SeleccionarPalabraSecreta();
        char[] palabraAdivinada = new char[palabraSecreta.Length];

        for (int i = 0; i < palabraAdivinada.Length; i++)
        {
            palabraAdivinada[i] = '_';
        }

        int intentosRestantes = 6;

        Console.WriteLine("¡Bienvenido al juego del ahorcado!");
        Console.WriteLine("Tienes 6 intentos para adivinar la palabra secreta.");
        MostrarPalabraAdivinada(palabraAdivinada);

        while (intentosRestantes > 0)
        {
            Console.WriteLine($"Intentos restantes: {intentosRestantes}");
            Console.Write("Ingresa una letra: ");
            char letra = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (palabraSecreta.Contains(letra))
            {
                for (int i = 0; i < palabraSecreta.Length; i++)
                {
                    if (palabraSecreta[i] == letra)
                    {
                        palabraAdivinada[i] = letra;
                    }
                }

                if (new string(palabraAdivinada) == palabraSecreta)
                {
                    Console.WriteLine("¡Felicidades! Has adivinado la palabra secreta: " + palabraSecreta);
                    break;
                }
            }
            else
            {
                intentosRestantes--;
                Console.WriteLine("Letra incorrecta. Intenta de nuevo.");
            }

            MostrarPalabraAdivinada(palabraAdivinada);
        }

        if (intentosRestantes == 0)
        {
            Console.WriteLine("¡Has perdido! La palabra secreta era: " + palabraSecreta);
        }
    }

    static void CargarPalabras()
    {
        try
        {
            palabras = File.ReadAllLines("palabras.txt").ToList();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("El archivo 'palabras.txt' no se encuentra en el directorio.");
        }
    }

    static string SeleccionarPalabraSecreta()
    {
        return palabras[rand.Next(palabras.Count)];
    }

    static void MostrarPalabraAdivinada(char[] palabraAdivinada)
    {
        Console.WriteLine("Palabra: " + new string(palabraAdivinada));
        Console.WriteLine();
    }
}
