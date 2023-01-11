
namespace AMOLab2
{
    internal class Methods
    { 

        private double[,] matrix1 = {{26, 65, -32, -35, 91, 70, 27, -96, 25},
                                    {-55, 88, -11, 71, -15, -18, -10, 29, -46},
                                    {-69, 12, -78, 52, -93, -77, -95, 3, -20},
                                    {-86, -11, -60, -83, -1, -39, 54, 13, 41},
                                    {-61, -22, 99, -56, -64, -79, -46, 53, -58},
                                    {41, -46, -18, 84, 69, 38, -71, -84, -26},
                                    {87, -14, -60, 40, 12, 13, -58, -18, -50},
                                    {93, -91, 65, -85, -26, -12, 91, 4, 58},
                                    {33, -34, -75, -72, -66, 15, 84, 11, -72} };

        private double[] vector1 = { -69, 1, -45, -79, -97, -72, 87, 44, -15 };

        private const int SIZE = 9; 


        /// <summary>
        /// Метод відбиття QR факторизації.
        /// </summary>
        public void Method4()
        {
            PrintMatrixAndVectore(matrix1, vector1);
            double[] b = new double[SIZE];
            double[] m = new double[SIZE];
            double[,] H = new double[SIZE, SIZE];
            double[,] W = new double[SIZE, SIZE];
            double[] Wi = new double[SIZE];
            double[,] resW = new double[SIZE, SIZE];
            double[,] Q = new double[SIZE, SIZE];
            double[,] R = new double[SIZE, SIZE];
            double[,] identityMatrix = CreateIdentityMatrix();
            for (int i = 0; i < SIZE; i++)
            {
                double sum = 0;
                for (int k = i; k < SIZE; k++)
                {
                    sum += matrix1[k, k] * matrix1[k, k];
                }
                b[i] = Math.Sign((-1) * matrix1[i, i]) * Math.Sqrt(sum);
                Console.WriteLine("\nVector B: ");
                PrintVector(b);
                m[i] = 1.0 / (Math.Sqrt(2 * b[i] * b[i] - 2 * b[i] * matrix1[i, i]));
                Console.WriteLine("\n\nVectore M:");
                PrintVector(m);

                for (int j = i; j < SIZE; j++)
                {
                    if (j == i)
                        W[i, j] = m[i] * (matrix1[i, i] - b[i]);
                    else
                        W[i, j] = m[i] * matrix1[j, i];
                }
                Console.WriteLine("\n\nMatrix W:");
                PrintMatrix(W);

                for (int q = 0; q < SIZE; q++)
                    Wi[q] = W[i, q];

                resW = MultiplyColumnByVectore(Wi, Wi); 
                for (int k = 0; k < SIZE; k++)
                    for (int j = 0; j < SIZE; j++)
                        H[k, j] = identityMatrix[k, j] - resW[k, j];
                Console.WriteLine("\nMatrix H:");
                PrintMatrix(H);
                if (i == 0)
                    for (int j = 0; j < SIZE; j++)
                        for (int k = 0; k < SIZE; k++)
                            Q[j, k] = H[j, k];
                else
                    Q = MultiplyMatrixByMatrix(Q, H);
                R = MultiplyMatrixByMatrix(H, matrix1);

                for (int j = 0; j < SIZE; j++)
                    for (int k = 0; k < j; k++)
                        if (Math.Abs(R[j, k]) - 0 < 0.000001)///
                            R[j, k] = 0;
                for (int j = 0; j < SIZE; j++)
                    for (int k = 0; k < SIZE; k++)
                        matrix1[j, k] = R[j, k];
                Console.WriteLine("Matrix R: ");
                PrintMatrix(R);
                Console.WriteLine("Matrix Q: ");
                PrintMatrix(Q);
            }

            Console.WriteLine("Result: ");
            for (int i = 0; i < SIZE; i++)
                for (int j = i; j < SIZE; j++)
                    Transpose(Q);
            double[] y = MultiplyMatrixByColumn(Q, vector1);
            PrintMatrixAndVectore(R, y);
            Console.WriteLine("Method result: ");
            double[] result = new double[SIZE];
            result[SIZE - 1] = y[SIZE - 1] / R[SIZE - 1, SIZE - 1];
            //Console.WriteLine(result[SIZE - 1]);
            for (int i = SIZE - 2; i > -1; i--)
            {
                double res = 0;
                for (int j = SIZE - 1; j > i; j--)
                    res += R[i, j] * result[j];
                res = y[i] - res;
                result[i] = res / R[i, i];
            }
            PrintVector(result);
        }

        /// <summary>
        /// Метод для транспонування матриці.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private double[,] Transpose(double[,] matrix)
        {
            double b;
            double[,] transponMatrix = matrix;
            for (int i = 0; i < SIZE; i++)
                for (int j = i; j < SIZE; j++)
                {
                    b = transponMatrix[i, j];
                    transponMatrix[i, j] = transponMatrix[j, i];
                    transponMatrix[j, i] = b;
                }
            return transponMatrix;
        }

        /// <summary>
        /// Множення матриці на стовпець.
        /// </summary>
        /// <returns></returns>
        private double[] MultiplyMatrixByColumn(double[,] matrix, double[] column)
        {
            int columnLen = column.Length;
            double[] result = new double[columnLen];
            for(int i = 0; i < columnLen; i++)
            {
                double sum = 0;
                for(int j = 0;j < columnLen; j++)
                    sum += matrix[i, j] * column[j];
                result[i] = sum;
            }
            return result;
        }

        /// <summary>
        /// Множення стовпця на рядок.
        /// </summary>
        /// <param name="C">Стовпець</param>
        /// <param name="R">Рядок</param>
        /// <returns></returns>
        private double[,] MultiplyColumnByVectore(double[] C, double[] R)
        {
            int rLen = R.Length;
            double[,] arr = new double[rLen, rLen];
            for (int i = 0; i < rLen; i++)
                for (int j = 0; j < rLen; j++)
                    arr[i, j] = 2 * C[i] * R[j];
            return arr;
        }

        /// <summary>
        /// Множення матриці на матрицю.
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public double[,] MultiplyMatrixByMatrix(double[,] m1, double[,] m2)
        {

            double[,] arr = new double[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < SIZE; k++)
                        sum += m1[i, k] * m2[k, j];
                    arr[i, j] = sum;
                }
            }
            return arr;
        }

        /// <summary>
        /// Створення одиничної матриці.
        /// </summary>
        /// <returns></returns>
        private double[,] CreateIdentityMatrix()
        {
            double[,] identityMatrix = new double[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
                identityMatrix[i, i] = 1;
            return identityMatrix;
        }

        /// <summary>
        /// Вивід матриці на консоль.
        /// </summary>
        private void PrintMatrix(double [,] matrix)
        {
            for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(String.Format("{0,20}", Math.Round(matrix[i, j], 4)));
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Вивід вектора на консоль. 
        /// </summary>
        private void PrintVector(double[] vectore)
        {
            for (int i = 0; i < vectore.Length; i++)
            {
                Console.Write(String.Format("{0,20}", Math.Round(vectore[i], 6)));
            }
        }

        /// <summary>
        /// Вивід на матриці разом з вектором на консоль.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="vectore"></param>
        private void PrintMatrixAndVectore(double[,] matrix, double[] vectore)
        {
            Console.WriteLine("Matrix: {0, 190}", "Vectore");
            for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(String.Format("{0,20}", matrix[i, j]));
                }
                Console.Write("\t" + String.Format("{0,20}", vectore[i]));
                Console.WriteLine();
            }
        }
    }
}
