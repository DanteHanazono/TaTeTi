using System;
namespace Tres_es_raya
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, CantTurnos, Valor, Pos;
            int Objetivo, aux_i, aux_j, aux_d1, aux_d2;
            bool Terminado, Ganador, TurnoJugador1;
            string linea, Ficha;
            int[,] Tab1 = new int[3,3];
            string[,] Tab2 = new string[3,3];
            j = 0;
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    Tab1[i, j] = 0;
                    Tab2[i, j] = "";
                }
            }
            TurnoJugador1 = true;
            Terminado = false;
            Ganador = false;
            CantTurnos = 0;
            while (!Terminado)
            {
                // dibuja el tablero
                System.Console.Clear();
                System.Console.WriteLine("");
                System.Console.WriteLine("     ||     ||     ");
                System.Console.WriteLine($"  {Tab2[0,0]}  ||  {Tab2[0,1]}  ||  {Tab2[0,2]} ");
                System.Console.WriteLine("    1||    2||    3");
                System.Console.WriteLine("=====++=====++======");
                System.Console.WriteLine("     ||     ||     ");
                System.Console.WriteLine($"  {Tab2[1, 0]}  ||  {Tab2[1, 1]}  ||  {Tab2[1, 2]} ");
                System.Console.WriteLine("    4||    5||    6");
                System.Console.WriteLine("=====++=====++======");
                System.Console.WriteLine("     ||     ||     ");
                System.Console.WriteLine($"  {Tab2[2, 0]}  ||  {Tab2[2, 1]}  ||  {Tab2[2, 2]} ");
                System.Console.WriteLine("    7||    8||    9");
                System.Console.WriteLine("");
                if (!Ganador && CantTurnos < 9)
                {
                    // carga auxiliares segun a qué jugador le toca
                    if (TurnoJugador1)
                    {
                        Ficha = "O"; Valor = 1; Objetivo = 1;
                        System.Console.WriteLine("Turno del jugador 1 (O)");
                    }
                    else
                    {
                        Ficha = "X"; Valor = 2; Objetivo = 8;
                        System.Console.WriteLine("Turno del jugador 2 (X)");
                    }
                    // pide la posición para colocar la ficha y la valida
                    System.Console.WriteLine("Ingrese la Posición (1-9):");
                    do
                    {
                        linea = System.Console.ReadLine();
                        Pos = int.Parse(linea);
                        if (Pos < 1 || Pos > 9)
                        {
                            System.Console.WriteLine("Posición incorrecta, ingrese nuevamente: ");
                            Pos = 99;
                        }
                        else
                        {
                            i = Convert.ToInt32((Pos - 1) / 3);
                            j = ((Pos - 1) % 3);
                            if (Tab1[i, j] != 0)
                            {
                                Pos = 99;
                                System.Console.WriteLine("Posición incorrecta, ingrese nuevamente: ");
                            }
                        }
                    } while (Pos == 99);
                    // guarda la ficha en la matriz tab2 y el valor en tab1
                    CantTurnos++;
                    Tab1[i, j] = Valor;
                    Tab2[i, j] = Ficha;
                    // verifica si ganó, buscando que el producto de las fichas en el tablero de Objetivo
                    aux_d1 = 1; aux_d2 = 1;
                    for (i = 0; i < 3; i++)
                    {
                        aux_i = 1; aux_j = 1;
                        aux_d1 = aux_d1 * (Tab1[i, i]);
                        aux_d2 = aux_d2 * (Tab1[i, 2 - i]);
                        for (j = 0; j < 3; j++)
                        {
                            aux_i = aux_i * (Tab1[i, j]);
                            aux_j = aux_j * (Tab1[j, i]);
                        }
                        if (aux_i == Objetivo || aux_j == Objetivo)
                        {
                            Ganador = true;
                        }
                    }
                    if (aux_d1 == Objetivo || aux_d2 == Objetivo)
                    {
                        Ganador = true;
                    }
                    else
                    {
                        TurnoJugador1 = !TurnoJugador1;
                    }
                }
                else
                {
                    if (Ganador)
                    {
                        System.Console.Write("Ganador: ");
                        if (TurnoJugador1)
                        {
                            System.Console.WriteLine("Jugador 1!");
                        }
                        else
                        {
                            System.Console.WriteLine("Jugador 2!");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Empate!");
                    }
                    Terminado = true;
                }
            }
        }
    }
}
