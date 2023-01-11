
namespace AMOLab2
{
    internal class Methods
    {
        public Methods()
        {
            PrintMatrix(matrix1);
            PrintVector(vector1);
            PrintMatrixAndVectore(matrix1, vector1);
        }

        private double[,] matrix1 = {{26, 65, -32, -35, 91, 70, 27, -96, 25},
                                  {-55, 88, -11, 71, -15, -18, -10, 29, -46},
                                  {-69, 12, -78, 52, -93, -77, -95, 3, -20},
                                  {-86, -11, -60, -83, -1, -39, 54, 13, 41},
                                  {-61, -22, 99, -56, -64, -79, -46, 53, -58},
                                  {41, -46, -18, 84, 69, 38, -71, -84, -26},
                                  {87, -14, -60, 40, 12, 13, -58, -18, -50},
                                  {93, -91, 65, -85, -26, -12, 91, 4, 58},
                                  {33, -34, -75, -72, -66, 15, 84, 11, -72} };

        double[] vector1 = { -69, 1, -45, -79, -97, -72, 87, 44, -15 };

        /// <summary>
        /// Вивід матриці на консоль.
        /// </summary>
        private void PrintMatrix(double [,] matrix)
        {
            Console.WriteLine("Matrix: ");
            for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(String.Format($"{matrix[i, j], 10}"));
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Вивід вектора на консоль. 
        /// </summary>
        private void PrintVector(double[] vectore)
        {
            Console.WriteLine("Vectore: ");
            for (int i = 0; i < vectore.Length; i++)
            {
                Console.WriteLine(String.Format($"{vectore[i], 10}"));
            }
        }

        /// <summary>
        /// Вивід на матриці разом з вектором на консоль.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="vectore"></param>
        private void PrintMatrixAndVectore(double[,] matrix, double[] vectore)
        {
            Console.WriteLine("Matrix: \t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tVectore:");
            for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(String.Format($"{matrix[i, j],10}"));
                }
                Console.Write(String.Format($"\t{vectore[i],10}"));
                Console.WriteLine();
            }
        }
    }
}
