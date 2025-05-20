using System;

class Actividad1S18
{
    public static void Main()
    {
        Estudiante estudiante = new Estudiante();
        estudiante.RegistroDatos();

        int opcion;
        do
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Mostrar nombre y notas aprobadas para cada alumno");
            Console.WriteLine("2. Mostrar nombre y notas no aprobadas para cada alumno");
            Console.WriteLine("3. Mostrar el promedio de notas del grupo");
            Console.WriteLine("4. Salir");
            Console.WriteLine("==============================================");

            opcion = ValidarNumeroUsuario(4);

            switch (opcion)
            {
                case 1:
                    estudiante.NotasAprobadas();
                    break;
                case 2:
                    estudiante.NotasReprobadas();
                    break;
                case 3:
                    estudiante.Promedio();
                    break;
                case 4:
                    Console.WriteLine("Saliendo del programa...");
                    break;
            }

        } while (opcion != 4);
    }

    static int ValidarNumeroUsuario(int numeroLimite)
    {
        bool validezNumero;
        int numeroUsuario;

        do
        {
            Console.Write("Ingrese un número entre 1 y " + numeroLimite + ": ");
            string entradaDeUsuario = Console.ReadLine()!;

            if (int.TryParse(entradaDeUsuario, out numeroUsuario))
            {
                if (numeroUsuario > 0 && numeroUsuario <= numeroLimite)
                {
                    validezNumero = true;
                }
                else
                {
                    Console.WriteLine("Entrada fuera del rango. Intente nuevamente.");
                    validezNumero = false;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Ingrese un número entero válido.");
                validezNumero = false;
            }

        } while (!validezNumero);

        return numeroUsuario;
    }
}

class Estudiante
{
    private string[] estudiantes = new string[10];
    private int[,] notas = new int[10, 10];

    public void RegistroDatos()
    {
        Console.WriteLine("------------ REGISTRO DE ESTUDIANTES Y NOTAS ------------");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"\nIngrese el nombre del estudiante #{i + 1}: ");
            estudiantes[i] = Console.ReadLine()!;

            for (int j = 0; j < 10; j++)
            {
                int nota;
                bool notaValida;
                do
                {
                    Console.Write($"  Nota #{j + 1} (0-100): ");
                    string entrada = Console.ReadLine()!;
                    
                    if (!int.TryParse(entrada, out nota))
                    {
                        Console.WriteLine("Entrada inválida. Debe ser un número entero.");
                        notaValida = false;
                    }
                    else if (nota < 0 || nota > 100)
                    {
                        Console.WriteLine("Nota fuera de rango. Debe estar entre 0 y 100.");
                        notaValida = false;
                    }
                    else
                    {
                        notaValida = true;
                    }
                }
                while (!notaValida);

                notas[i, j] = nota;
            }
        }
    }

    public void NotasAprobadas()
    {
        Console.WriteLine("\n========= NOTAS APROBADAS =========");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"\nEstudiante: {estudiantes[i]}");
            bool tienenAprobadas = false;

            for (int j = 0; j < 10; j++)
            {
                if (notas[i, j] >= 65)
                {
                    Console.Write($"{notas[i, j]} ");
                    tienenAprobadas = true;
                }
            }

            if (!tienenAprobadas)
                Console.Write("Ninguna nota aprobada");

            Console.WriteLine();
        }
    }

    public void NotasReprobadas()
    {
        Console.WriteLine("\n========= NOTAS REPROBADAS =========");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"\nEstudiante: {estudiantes[i]}");
            bool tienenReprobadas = false;

            for (int j = 0; j < 10; j++)
            {
                if (notas[i, j] < 65)
                {
                    Console.Write($"{notas[i, j]} ");
                    tienenReprobadas = true;
                }
            }

            if (!tienenReprobadas)
                Console.Write("Todas las notas son aprobadas");

            Console.WriteLine();
        }
    }

    public void Promedio()
    {
        int suma = 0;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                suma += notas[i, j];
            }
        }

        double promedio = suma / 100.0;
        Console.WriteLine($"\nPromedio general del grupo: {promedio}");
    }
}