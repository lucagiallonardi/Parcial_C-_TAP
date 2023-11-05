using System;
using System.Reflection;
using System.Xml.Linq;

class Enteros
{
    private const int MaxElementos = 100;
    private int[] arreglo = new int[MaxElementos];
    private int CantidadElementos = 0;
    private int indexRef = 0;



    public Enteros()
    {
        for (int i = 0; i < MaxElementos; i++)
        {
            arreglo[i] = -1;
        }
    }

    public int Add(int elemento)
    {
        if (CantidadElementos < MaxElementos)
        {
            if (arreglo[indexRef] == -1)
            {
                arreglo[indexRef] = elemento;
                Console.WriteLine("\n\nSe añadió correctamente el numero " + elemento + " en la posición " + indexRef + "\n\n");
                CantidadElementos++;
                indexRef++;
                return CantidadElementos - 1;
            }
            else
            {
                indexRef++;
                return Add(elemento);
            }  
        }
        else
        {
            Console.WriteLine("No se puede agregar más elementos, el arreglo está lleno.");
            return -1;
        }
    }

    public void GetAt(int index)
    {
        if (index >= 0 && index < MaxElementos)
        {
            Console.WriteLine("\n\nEl elemento en la posición " + index + " es " + arreglo[index] + "\n\n");
        }
        else
        {
            Console.WriteLine("\n\nÍndice no válido.\n\n");
        }
    }

    public void RemoveAll()
    {
        for (int i = 0; i < MaxElementos; i++)
        {
            arreglo[i] = -1; 
        }
        CantidadElementos = 0;
        indexRef = 0;
    }

    public void SetAt(int elemento, int index)
    {
        if (index >= 0 && index < MaxElementos)
        {
            if (arreglo[index] == -1)
            {
                arreglo[index] = elemento;
                Console.WriteLine("\n\nSe ingresó correctamente el numero " + elemento + " en la posición " + index + "\n\n");
                CantidadElementos++;
            }
            else
            {
                Console.WriteLine("\n\nLa posición en la que desea agregar el elemento se encuentra ocupada.\n\n");
            }

        }
        else
        {
            Console.WriteLine("\nÍndice no válido. No se pudo establecer el elemento.\n");
        }
    }

    public int GetLength()
    {
        return CantidadElementos;
    }

    public int GetIndexRef()
    {
        return indexRef;
    }

    public bool IsEmpty()
    {
        if(CantidadElementos == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ConsultAll()
    {
        Console.WriteLine("Estas son las posiciones que contienen elementos:\n");
        for ( int i = 0; i < MaxElementos; i++)
        {
            if (arreglo[i] != -1)
            {
                Console.WriteLine("Posición " + i + " elemento (" + arreglo[i] + ")\n");
            }
        }
    }
}

class Parcial2_LucaGiallonardi
{
    static void Main()
    {
        Enteros miEntero = new Enteros();

        Console.WriteLine("Bienvenido/a al Arreglo de Numeros Enteros\n\n");

        while (true)
        {
            Console.WriteLine("Opciones:");
            Console.WriteLine("1. Agregar un número al arreglo.");
            Console.WriteLine("2. Consultar elemento en una posición");
            Console.WriteLine("3. Eliminar todos los elementos");
            Console.WriteLine("4. Consultar si el arreglo esta vacío");
            Console.WriteLine("5. Agregar un numero a una posición específica del arreglo");
            Console.WriteLine("6. Consultar cuales son las posiciones que contienen un elemento.");
            Console.WriteLine("7. Salir");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    int numero;
                    bool esNumero = false;

                    Console.Clear();
                    Console.Write("Ingrese el número que desea agregar: ");
                    do
                    {
                        if (int.TryParse(Console.ReadLine(), out numero))
                        {
                            miEntero.Add(numero);
                            int indexRef = miEntero.GetIndexRef() - 1;
                            esNumero = true;
                        }
                        else
                        {
                            Console.WriteLine("La entrada no es un número válido. Intente de nuevo.");
                        }
                    } while (!esNumero);

                    break;

                case "2":
                    Console.Clear();
                    Console.Write("Ingrese la posición que desea consultar: ");
                    if (int.TryParse(Console.ReadLine(), out int posicion))
                    {
                        miEntero.GetAt(posicion);
                    }
                    else
                    {
                        Console.WriteLine("\nPosición no válida.\n\n");
                    }
                    break;

                case "3":
                    Console.Clear();
                    miEntero.RemoveAll();
                    Console.WriteLine("Todos los elementos han sido eliminados.\n\n");
                    break;

                case "4":
                    Console.Clear();
                    if (miEntero.IsEmpty())
                    {
                        Console.WriteLine("Si, el arreglo está vacío!\n\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No, el arreglo NO está vacío. Numero de elementos que contiene: " + miEntero.GetLength() + "\n\n");
                        break;
                    }

                case "5":
                    Console.Clear();
                    int num;
                    int pos;
                    bool esPosNum = false;
                    bool esNum = false;

                    Console.Write("Ingrese el número que desea agregar:");
                    do
                    {
                        if (int.TryParse(Console.ReadLine(), out num))
                        {
                            Console.WriteLine("\n\nEl numero a agregar será: " + num + "\n\n");
                            esNum = true;
                        }
                        else
                        {
                            Console.WriteLine("La entrada no es un número válido. Intente de nuevo.");
                        }
                    } while (!esNum);

                    Console.WriteLine("Ingrese la posición en la que desea agregar este número:");
                    do
                    {
                        if (int.TryParse(Console.ReadLine(), out pos))
                        {
                            miEntero.SetAt(num, pos);
                            esPosNum = true;
                        }
                        else
                        {
                            Console.WriteLine("La entrada no es un número válido. Intente de nuevo.");
                        }
                    } while (!esPosNum);
                    break;

                case "6":
                    Console.Clear();
                    if (miEntero.IsEmpty())
                    {
                        Console.WriteLine("El arreglo está vacío!\n\n");
                        break;
                    }
                    else
                    {
                        miEntero.ConsultAll();
                        break;
                    }

                case "7":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}
