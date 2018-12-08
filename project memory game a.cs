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
            int points = 0;
            do
            {
              
                Console.WriteLine("choose card1 row");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("choose card1 column");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"the card that you choose is: { matrix[a - 1, b - 1]}");
                Console.WriteLine("choose card2 row");

                int c = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("choose card2 column");
                int d = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"the card that you choose is: { matrix[c - 1, d - 1]}");

                if (matrix[a - 1, b - 1] == matrix[c - 1, d - 1])
                {
                    points = points + 1;
                    Console.WriteLine("you found a pair!!");
                    matrix[a - 1, b - 1] = 0;
                    matrix[c - 1, d - 1] = 0;

                }
            }
            while (points != (x * x) / 2);
            Console.WriteLine("very good!!! you found all the pairs!");
            Console.WriteLine("game over!");
           
              
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"  {matrix[i, j]}");
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
