using System;  // Necesario para usar la consola (Console.WriteLine, Console.ReadLine)
using System.Collections.Generic; // Necesario para manejar listas dinámicas

class Program
{
    static List<string> estudiantes = new List<string>(); // Lista para almacenar nombres de estudiantes
    static List<double> calificaciones = new List<double>(); // Lista para almacenar calificaciones

    static void Main()
    {
        Console.WriteLine("Bienvenido al sistema de gestión de estudiantes.");

        while (true) // Bucle infinito para mostrar el menú hasta que el usuario elija salir
        {
            Console.WriteLine("\n1. Agregar estudiante");
            Console.WriteLine("2. Mostrar lista de estudiantes");
            Console.WriteLine("3. Calcular promedio de calificaciones");
            Console.WriteLine("4. Mostrar estudiante con la calificación más alta");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            // Se usa TryParse para evitar errores si el usuario ingresa texto en lugar de un número
            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.WriteLine("Error: Ingrese un número válido.");
                continue; // Si la entrada no es válida, vuelve a pedir la opción
            }

            switch (opcion) // Se reemplazaron los múltiples if-else por un switch para mayor claridad
            {
                case 1:
                    AgregarEstudiante();
                    break;
                case 2:
                    MostrarEstudiantes();
                    break;
                case 3:
                    CalcularPromedio();
                    break;
                case 4:
                    MostrarEstudianteConMaxCalificacion();
                    break;
                case 5:
                    Console.WriteLine("Saliendo del sistema...");
                    return; // Se usa return en lugar de break para salir del programa
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void AgregarEstudiante()
    {
        Console.Write("Ingrese el nombre del estudiante: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la calificación del estudiante: ");
        // Se usa TryParse para evitar errores si el usuario ingresa un valor no numérico
        if (!double.TryParse(Console.ReadLine(), out double calificacion))
        {
            Console.WriteLine("Error: Ingrese una calificación válida.");
            return;
        }

        estudiantes.Add(nombre);
        calificaciones.Add(calificacion);
        Console.WriteLine("Estudiante agregado correctamente.");
    }

    static void MostrarEstudiantes()
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
        }
        else
        {
            Console.WriteLine("\nLista de estudiantes:");
            for (int i = 0; i < estudiantes.Count; i++)
            {
                Console.WriteLine($"{estudiantes[i]} - Calificación: {calificaciones[i]}");
            }
        }
    }

    static void CalcularPromedio()
    {
        if (calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
        }
        else
        {
            double suma = 0;
            foreach (double calificacion in calificaciones)
            {
                suma += calificacion;
            }

            double promedio = suma / calificaciones.Count;
            Console.WriteLine($"El promedio de calificaciones es: {promedio:F2}"); // Se formatea a 2 decimales
        }
    }

    static void MostrarEstudianteConMaxCalificacion()
    {
        if (calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
            return;
        }

        double maxCalificacion = calificaciones[0]; // Se inicia con el primer estudiante
        string estudianteMax = estudiantes[0];

        for (int i = 1; i < calificaciones.Count; i++)
        {
            if (calificaciones[i] > maxCalificacion) // Se compara cada calificación con la más alta encontrada
            {
                maxCalificacion = calificaciones[i];
                estudianteMax = estudiantes[i];
            }
        }

        Console.WriteLine($"El estudiante con la calificación más alta es: {estudianteMax} con {maxCalificacion}");
    }
}

