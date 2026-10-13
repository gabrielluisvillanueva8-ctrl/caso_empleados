using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace caso_empleados
{
    internal class Program
    {
        static int max_emp = 50;
        static string[] nombres_empl = new string[max_emp];
        static string[] correo_emp = new string[max_emp];
        static int cont_empl = 0;
        static string rutaArchivo = "empleados_datos.txt";
        static public void Titulo()
        {
            Console.WriteLine("*************************************************");
            Console.WriteLine("**SISTEMA DE EMPLEADOS ARREGLOS Y CADENAS**");
            Console.WriteLine("*************************************************");
        }
        static public void Registrar_empleado()
        {
            Console.Clear();
            Console.WriteLine("******REGISTRO DE EMPLEADO*******");
            if (cont_empl >= max_emp)
            {
                Console.WriteLine("Capacidad maxima alcanzada");
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Ingresar nombres y apellidos:");
            string nombres = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(nombres))
            {
                Console.WriteLine("Error: el nombre no puede estar vacio...!");
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
                return;
            }
            string nombres_MAyus = nombres.ToUpper();
            string[] partes = nombres_MAyus.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string primer_nombre = partes.Length > 0 ? partes[0] : "Usuario";
            string correo = $"{primer_nombre.ToLower()}@upn.edu.pe";
            nombres_empl[cont_empl] = nombres_MAyus;
            correo_emp[cont_empl] = correo;
            cont_empl++;
            Console.WriteLine("\n¡Empleado registrado exitosamente!");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
        static public void buscar_emp()
        {
            Console.Clear();
            Console.WriteLine("******BUSCAR EMPLEADO*******");
            Console.WriteLine("***************************");
            if (cont_empl == 0)
            {
                Console.WriteLine("No hay empleados registrados");
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Ingrese el nombre del empleado a buscar: ");
            string buscar_nombre = Console.ReadLine()?.Trim().ToUpper();
            if (string.IsNullOrEmpty(buscar_nombre))
            {
                Console.WriteLine("Error: el campo de búsqueda no puede estar vacío.");
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
                return;
            }
            bool encontrado = false;
            for (int i = 0; i < cont_empl; i++)
            {
                if (nombres_empl[i].Contains(buscar_nombre))
                {
                    Console.WriteLine($"Nombre: {nombres_empl[i]} | Correo: {correo_emp[i]}");
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Empleado no encontrado");
            }
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
        static public void ordenar_alfabeticamente()
        {
            Console.Clear();
            Console.WriteLine("******ORDENAR EMPLEADOS*******");
            Console.WriteLine("******************************");
            if (cont_empl <= 1)
            {
                Console.WriteLine("No hay suficientes empleados para ordenar");
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
                return;
            }
            for (int i = 0; i < cont_empl - 1; i++)
            {
                for (int j = 0; j < cont_empl - 1 - i; j++)
                {
                    if (string.Compare(nombres_empl[j], nombres_empl[j + 1]) > 0)
                    {
                        string temp_nombre = nombres_empl[j];
                        nombres_empl[j] = nombres_empl[j + 1];
                        nombres_empl[j + 1] = temp_nombre;
                        string temp_correo = correo_emp[j];
                        correo_emp[j] = correo_emp[j + 1];
                        correo_emp[j + 1] = temp_correo;
                    }
                }
            }
            Console.WriteLine("¡Empleados ordenados alfabéticamente con éxito!\n");
            Console.WriteLine($"{"Nombres y Apellidos",-35} | {"Correo corporativo"}");
            Console.WriteLine(new string('-', 65));
            for (int i = 0; i < cont_empl; i++)
            {
                if (nombres_empl[i] != null)
                {
                    Console.WriteLine($"{nombres_empl[i],-35} | {correo_emp[i]}");
                }
            }
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
        static public void mostrar()
        {
            Console.Clear();
            Console.WriteLine("******LISTADO DE EMPLEADOS******");
            Console.WriteLine("*********************************");
            if (cont_empl == 0)
            {
                Console.WriteLine("No hay empleados registrados");
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"{"Nombres y Apellidos",-35} | {"Correo corporativo"}");
            Console.WriteLine(new string('-', 65));
            for (int i = 0; i < cont_empl; i++)
            {
                if (nombres_empl[i] != null)
                {
                    Console.WriteLine($"{nombres_empl[i],-35} | {correo_emp[i]}");
                }
            }
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
        static public void guardar_datos_archivo()
        {
            Console.WriteLine("*****GUARDAR DATOS EN ARCHIVO*******");
            Console.WriteLine("*************************************");
            if (cont_empl == 0)
            {
                Console.WriteLine("No hay empleados registrados");
                return;
            }
            using (StreamWriter escribir = new StreamWriter(rutaArchivo))
            {
                for (int i = 0; i < cont_empl; i++)
                {
                    escribir.WriteLine(nombres_empl[i] + "," + correo_emp[i]);
                }
            }
            Console.WriteLine(cont_empl + "empleados guardados");
        }
        static public void leer_datos_Archivo()
        {
            Console.WriteLine("**********LEER DATOS DESDE EL ARCHIVO********");
            Console.WriteLine("**********************************************");
            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine("Archivo no existe");
                return;
            }
            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] partes = linea.Split(',');
                    if (partes.Length == 2)
                    {
                        Console.WriteLine("Nombres:" + partes[0] + "Correo:" + partes[1]);
                    }
                }
            }
        }
        static public void cargar_datos_desde_Archivo()
        {
            Console.WriteLine("*******CARGAR DATOS DESDE ARCHIVO********");
            Console.WriteLine("*****************************************");
            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine("Archivo no existe");
                return;
            }
            string[] lineas = File.ReadAllLines(rutaArchivo);
            for (int i = 0; i < lineas.Length && cont_empl < max_emp; i++)
            {
                string[] partes = lineas[i].Split(',');
                if (partes.Length == 2)
                {
                    nombres_empl[cont_empl] = partes[0];
                    correo_emp[cont_empl] = partes[1];
                    cont_empl++;
                }
            }
        }
        static void Main(string[] args)
        {
            int opc = 0;
            while (opc != 8)
            {
                Console.Clear();
                Console.WriteLine("[1] Registrar empleado");
                Console.WriteLine("[2] Buscar empleado");
                Console.WriteLine("[3] Ordenar empleado");
                Console.WriteLine("[4] Mostrar empleado");
                Console.WriteLine("[5] Guardar");
                Console.WriteLine("[6] Leer datos del archivo");
                Console.WriteLine("[7] Cargar datos desde archivo");
                Console.WriteLine("[8] Salir");
                Console.WriteLine("Ingresar opcion: ");
                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Error: Ingrese una opcion numerica");
                    Console.ReadKey();
                    continue;
                }
                switch (opc)
                {
                    case 1:
                        Registrar_empleado();
                        break;
                    case 2:
                        buscar_emp();
                        break;
                    case 3:
                        ordenar_alfabeticamente();
                        break;
                    case 4:
                        mostrar();
                        break;
                    case 5:
                        guardar_datos_archivo();
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 6:
                        leer_datos_Archivo();
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 7:
                        cargar_datos_desde_Archivo();
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.WriteLine("Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}