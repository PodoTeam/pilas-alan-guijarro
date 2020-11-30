using System;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;

namespace ImplementaciónPilas
{
    //Se crea la clase Pila
    class Pila
    {
        //Se crean los atributos de la clase pila
        public string[] elemento = new string[20];
        public int tope;
        public string[] complemento = new string[20];

        //Se inicializa la pila en vacío mediante el método constructor
        public Pila()
        {
            for (int contador = 0; contador < 20; contador++)
                elemento[contador] = "";
            tope = -1;
        }
        //Se devuelve el tope de la pila
        public int EntregaTope()
        {
            return tope;
        }
        //Devuelve un booleano que representa si la pila está vacía o no
        public bool Vacio()
        {
            if (tope == -1)
                return true;
            else
                return false;
        }
        //Método que imprime la pila por consola
        public void ImprimePila()
        {

            for (int contador = 0; contador <= tope; contador++)
            {
                Console.WriteLine("{0}", elemento[contador]);

            };
            Console.WriteLine("Esto es todo!");
        }
        //Método que nos permite agregar un elemento a la pila
        public void Push(string a)
        {
            elemento[tope + 1] = a;
            tope = tope + 1;
        }
        //Método que nos permite quitar une elemento de la pila
        public string Pop()
        {
            string auxiliar;
            auxiliar = elemento[tope];
            elemento[tope] = "";
            tope = tope - 1;
            return auxiliar;
        }
        //Método que nos permite saber si la pila está balanceada o no
        public void Balanceo(string cad)
        {
            string aux, ecuacion = "";

            //Bucle for que nos permite eliminar todos los signos que no sean signos de agrupación de la cadena
            for (int i = 0; i < cad.Length; i++)
            {
                aux = cad.Substring(i, 1);
                if (aux == "(" || aux == "[" || aux == "{" || aux == ")" || aux == "]" || aux == "}")
                    ecuacion += aux;
            }
            //Bucle for que recorre la longitud de la cadena 
            for (int j = 0; j < ecuacion.Length; j++)
            {
                aux = ecuacion.Substring(j, 1);
                //Condicional que compara si el signo es de cierre
                if (aux == ")" || aux == "]" || aux == "}")
                {
                    //En caso de ser un signo de cierre y que su complemento no sea el adecuado
                    //o que antes de él no haya un signo de apertura entonces sale del bucle y aumenta 1 al tope
                    if (tope == -1 || aux != complemento[tope])
                    {
                        tope++;
                        break;
                    }
                    //En caso de que su complemento si sea adecuado entonces se llama al método Pop
                    if (aux == complemento[tope])
                    {
                        Pop();
                    }
                }
                //En caso de ser signos de apertura se establecen sus complementos en un arreglo
                //y se llama al método push que va a contener el signo de apertura
                else
                {
                    if (aux == "(")
                        complemento[tope + 1] = ")";
                    if (aux == "[")
                        complemento[tope + 1] = "]";
                    if (aux == "{")
                        complemento[tope + 1] = "}";
                    Push(aux);
                }
            }
        }
        //Se crea la clase programa
        class Program
        {
            //Programa principañ
            static void Main(string[] args)
            {
                //Se define la variable que contendrá la ecuación
                string Ecuación;

                //Se instancia a la clase Pila
                Pila Mi_Pila = new Pila();

                //Se ingresa por consola el valor del string Ecuación
                Console.WriteLine("Ingrese su ecuación");
                Ecuación = Console.ReadLine();

                //Se llama al método balanceo de la Pila pasando como parámetro la ecuación
                Mi_Pila.Balanceo(Ecuación);

                //Condicional que nos permite saber si la ecuación está balanceada o no
                if (Mi_Pila.Vacio() == true)
                    Console.WriteLine("Ecuación balanceada correctamente");
                else
                    Console.WriteLine("Error, no se pudo balancear la ecuación.");
            }
        }
    }
}
