using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_memory_game
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = EnterMatrixSize();
            int [,] matrix = new int[x, x];
            Randomatrix(x, matrix);
            PrintMatrix(matrix);
            int points1 = 0;
            int points2 = 0;
            
            do
            {
                int a, b, c, d;
                points1 = PointsPlayer1(x, matrix, points1, out a, out b, out c, out d);
                points2 = PointsPlayer2(x, matrix, points2, out a, out b, out c, out d);
            }
            while (points1+points2 !=(x * x) / 2);
            if(points1>points2)
            {
                Console.WriteLine("player1 won!!!");
            }
            else if (points2>points1)
            {
                Console.WriteLine("player2 won!!!");

            }
            else
            {
                Console.WriteLine("its a tie");
            }

           
            Console.WriteLine("game over!");
           
              
        }
        private static int PointsPlayer2(int x, int[,] matrix, int points2, out int a, out int b, out int c, out int d)
        {
            do
            {



                Console.Write("player2,");
                ChooseCard1(matrix, out a, out b, x);
                PrintNow(matrix, a, b);
                Console.Write("player2,");
                ChooseCard2(matrix, out c, out d, x);
                PrintNow(matrix, c, d);
                while (c == a && b == d)
                {
                    Console.Write("player2, again");
                    ChooseCard1(matrix, out a, out b, x);
                    PrintNow(matrix, a, b);
                    Console.Write("player2, again");
                    ChooseCard2(matrix, out c, out d, x);
                    PrintNow(matrix, c, d);
                }

                points2 = pointsnow(matrix, points2, a, b, c, d);
            }
            while (matrix[a-1, b-1] == matrix[c-1, d-1]);
            return points2;
        }


        private static int PointsPlayer1(int x, int[,] matrix, int points1, out int a, out int b, out int c, out int d)
        {
            do
            {



                Console.Write("player1,");
                ChooseCard1(matrix, out a, out b, x);
                PrintNow(matrix, a, b);
                Console.Write("player1,");
                ChooseCard2(matrix, out c, out d, x);
                PrintNow(matrix, c, d);
                while (c == a && b == d)
                {
                    Console.Write("player1, again");
                    ChooseCard1(matrix, out a, out b, x);
                    PrintNow(matrix, a, b);
                    Console.Write("player1, again");
                    ChooseCard2(matrix, out c, out d, x);
                    PrintNow(matrix, c, d);
                }

                points1 = pointsnow(matrix, points1, a, b, c, d);
            }
            while (matrix[a-1, b-1] == matrix[c-1, d-1]);
            return points1;
        }

        private static void PrintNow(int[,] matrix, int a, int b)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (a == i + 1 && b == j + 1)
                    {
                        if (matrix[i, j] < 10)
                        {
                            Console.Write($"  {matrix[i, j]}");
                        }
                        else
                        {
                            Console.Write($" {matrix[i, j]}");
                        }
                    }
                    else if (matrix[i, j] == 0)
                    {
                        Console.Write("  0");
                    }
                    else
                    {
                        Console.Write("  x");
                    }
                }
                Console.WriteLine();
            }
        }

        private static int pointsnow(int[,] matrix, int points, int a, int b, int c, int d)
        {
            if (matrix[a - 1, b - 1] == matrix[c - 1, d - 1])
            {
                points = points + 1;
                Console.WriteLine("you found a pair!!");
                matrix[a - 1, b - 1] = 0;
                matrix[c - 1, d - 1] = 0;

            }
            else
            {
                Console.WriteLine("not a pair");
            }
            return points;
        }

        private static void ChooseCard1(int[,] matrix, out int a, out int b, int x)
        {
            do
            {
                do
                {
                    Console.WriteLine("choose card1 row");
                    a = Convert.ToInt32(Console.ReadLine());
                }
                while (a > x || a < 0);
                do
                {
                    Console.WriteLine("choose card1 column");
                    b = Convert.ToInt32(Console.ReadLine());

                }

                while (b > x || b < 0);
            }
            while (matrix[a - 1, b - 1] == 0);

            Console.WriteLine($"the card that you choose is: { matrix[a - 1, b - 1]}");
        }
        private static void ChooseCard2(int[,] matrix, out int c, out int d, int x)
            {
            do
            { 
                do
                {
                    Console.WriteLine("choose card2 row");
                    c = Convert.ToInt32(Console.ReadLine());
                }
                while (c > x || c< 0);
                do
                {
                    Console.WriteLine("choose card2 column");
                    d = Convert.ToInt32(Console.ReadLine());
                   
                }
                while (d > x || d< 0);
            }
            while ((matrix[c - 1, d - 1] == 0));
            Console.WriteLine($"the card that you choose is: { matrix[c - 1, d - 1]}");
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i,j]<10)
                    {
                        Console.Write($"  {matrix[i,j]}");
                    }
                    else
                        Console.Write($" {matrix[i,j]}");
                }
                Console.WriteLine();
            }
        }

        private static int[,] Randomatrix(int x, int[,] matrix)
        {
            Random randomgenerator = new Random();
            for (int i = 1; i <= ((x * x) / 2); i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    int a = -1;
                    int b = -1;
                    do
                    {
                        a = randomgenerator.Next(0, x);
                        b = randomgenerator.Next(0, x);
                    }
                    while (matrix[a, b] != 0);
                    matrix[a, b] = i;
                }
            }
            return matrix;
        }

        private static int EnterMatrixSize()
        {
            int matrixsize = 0;
            while (matrixsize <= 0 || matrixsize % 2 != 0 || matrixsize > 8) 
            {
                Console.WriteLine("enter a number between 2 to 8");
                matrixsize = Convert.ToInt32(Console.ReadLine());
            }

            
            return matrixsize;
        }
         
    }
}
