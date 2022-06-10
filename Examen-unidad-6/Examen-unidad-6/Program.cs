using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Examen_unidad_6
{
    class Inventario
    {
        public string Nom, Carac;
        public float Pre;
        public int Can;
        public void Registro()
        {
            StreamWriter sw = new StreamWriter("Productos.txt", true); //Creacion del objeto
            //Variables
            

            try
            {
                //Captura de datos
                Console.WriteLine("--Registro de productos--");
                Console.Write("\nNombre del producto: ");
                Nom = Console.ReadLine();
                Console.Write("Caracterisicas: ");
                Carac = Console.ReadLine();
                Console.Write("Precio por unidad: ");
                Pre = float.Parse(Console.ReadLine());
                Console.Write("Cantidad en stock: ");
                Can = int.Parse(Console.ReadLine());

                Console.WriteLine("Registrando datos...");
                Console.WriteLine("Precione <enter> para continiar");
                Console.ReadLine();
                Console.Clear();
                //Escritura de los datos
                sw.WriteLine("Nombre del producto: {0}", Nom);
                sw.WriteLine("Caracteristicas: {0}", Carac);
                sw.WriteLine("Precio por unidad: {0:C}", Pre);
                sw.WriteLine("Cantidad en stock: {0}", Can);

                sw.Close();

            }
            catch(IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine("Ruta: " + e.StackTrace); 
            }
            finally
            {
                Console.WriteLine("Producto registado...");
                Console.WriteLine("Precione <enter> para regresar al menu");
                Console.ReadLine();
                Console.Clear();
            }
        }
        public void MostrarInventario(string Producto)
        {
            try
            {
                StreamReader sr = new StreamReader("Productos.txt");
                sr = new StreamReader(new FileStream(Producto, FileMode.Open, FileAccess.Read));
                Console.Clear();
                Nom = sr.ReadToEnd();
                Carac = sr.ReadToEnd();
                Pre = sr.Read();
                Can = sr.Read();
                Console.WriteLine("--Informacion del inventario ");
                Console.WriteLine("");
                Console.WriteLine( Nom);
                Console.WriteLine( Carac);
                Console.WriteLine( Pre);
                Console.WriteLine(Can);
                Console.WriteLine("");
                Console.ReadLine();
                Console.Clear();

            }
            catch(EndOfStreamException )
            {
                Console.WriteLine("Fin del listado \nPrecione <enter> para continuar");
                Console.ReadKey();
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Inventario inv = new Inventario(); //Creacion del objeto de clase
            char opc;
            string Producto = "Productos.txt";
            do
            {//Menu de opcciones
                Console.WriteLine("--Bienvenido al inventario--");
                Console.WriteLine("   --Menu de opcciones--");
                Console.WriteLine("\na) Agregar nuevo producto");
                Console.WriteLine("b) Mostrar inventario");
                Console.WriteLine("c) Salir");
                Console.Write("Seleccione una opccion: ");
                opc = char.Parse(Console.ReadLine());
                Console.Clear();
                switch (opc)
                {
                    case 'a': inv.Registro(); break;
                    case 'b': inv.MostrarInventario(Producto); break;
                    case 'c': Console.WriteLine("Saliendo del programa \nTenga buen día"); break;
                    default: Console.WriteLine("Opccion no valida \nPrecione enter para continuar"); break;
                }
            } while (opc != 'c');
        }
    }
}
