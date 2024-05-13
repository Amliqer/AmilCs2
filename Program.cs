using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AmilCS {

    class Program
    {
        static void Main()
        {
            int[] A = new int[5];
            double[,] B = new double[3, 4];

            Console.WriteLine("Введите 5 чисел для массива A:");
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = Convert.ToInt32(Console.ReadLine());
            }

            Random rand = new Random();
            Console.WriteLine("\nМассив B:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = rand.NextDouble() * 100;
                    Console.Write($"{B[i, j]} ");
                }
                Console.WriteLine();
            }

            int maxA = A.Max();
            int minA = A.Min();
            int maxB = (int)B.Cast<double>().Max();
            int minB = (int)B.Cast<double>().Min();
            int sumA = A.Sum();
            double prodA = A.Aggregate(1, (acc, x) => acc * x);
            int sumEvenA = A.Where(x => x % 2 == 0).Sum();
            int sumOddBColumns = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j % 2 != 0)
                    {
                        sumOddBColumns += (int)B[i, j];
                    }
                }
            }

            Console.WriteLine($"\nМаксимальный элемент массива A: {maxA}");
            Console.WriteLine($"Минимальный элемент массива A: {minA}");
            Console.WriteLine($"Максимальный элемент массива B: {maxB}");
            Console.WriteLine($"Минимальный элемент массива B: {minB}");
            Console.WriteLine($"Сумма всех элементов массива A: {sumA}");
            Console.WriteLine($"Произведение всех элементов массива A: {prodA}");
            Console.WriteLine($"Сумма четных элементов массива A: {sumEvenA}");
            Console.WriteLine($"Сумма нечетных столбцов массива B: {sumOddBColumns}");
        }



        int[,] array2D = new int[5, 5];
        Random rand = new Random();
for (int i = 0; i< 5; i++)
{
    for (int j = 0; j< 5; j++)
    {
        array2D[i, j] = rand.Next(-100, 101);
    }



    int min = array2D.Cast<int>().Min();
    int max = array2D.Cast<int>().Max();
}
int minRowIndex = 0, minColIndex = 0, maxRowIndex = 0, maxColIndex = 0;
for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        if (array2D[i, j] == min)
        {
            minRowIndex = i;
            minColIndex = j;
        }
        if (array2D[i, j] == max)
        {
            maxRowIndex = i;
            maxColIndex = j;
        }
    }
}
int sumBetweenMinMax = 0;
int startRow = Math.Min(minRowIndex, maxRowIndex);
int endRow = Math.Max(minRowIndex, maxRowIndex);
int startCol = Math.Min(minColIndex, maxColIndex);
int endCol = Math.Max(minColIndex, maxColIndex);
for (int i = startRow; i <= endRow; i++)
{
    for (int j = startCol; j <= endCol; j++)
    {
        sumBetweenMinMax += array2D[i, j];
    }
}

Console.WriteLine($"Минимальный элемент: {min}, его индексы: ({minRowIndex}, {minColIndex})");
Console.WriteLine($"Максимальный элемент: {max}, его индексы: ({maxRowIndex}, {maxColIndex})");
Console.WriteLine($"Сумма элементов между минимальным и максимальным: {sumBetweenMinMax}");


string inputStr = Console.ReadLine().ToUpper();

int shift = 3;
string encryptedStr = CaesarCipher(inputStr, shift);
Console.WriteLine($"Зашифрованная строка: {encryptedStr}");

string decryptedStr = CaesarCipher(encryptedStr, -shift);
Console.WriteLine($"Расшифрованная строка: {decryptedStr}");
}

static string CaesarCipher(string input, int shift)
{
    char[] chars = input.ToCharArray();
    for (int i = 0; i < chars.Length; i++)
    {
        if (chars[i] >= 'A' && chars[i] <= 'Z')
        {
            chars[i] = (char)('A' + (chars[i] - 'A' + shift + 26) % 26);
        }
    }
    return new string(chars);
}


class MatrixOperations
{
    static void Main()
    {
        int[,] matrix1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int[,] matrix2 = { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } };

        PrintMatrix("Matrix 1:", matrix1);
        PrintMatrix("Matrix 2:", matrix2);

        int scalar = 2;
        int[,] resultScalarMultiplication = MultiplyMatrixByScalar(matrix1, scalar);
        PrintMatrix($"Matrix 1 multiplied by {scalar}:", resultScalarMultiplication);

        int[,] resultAddition = AddMatrices(matrix1, matrix2);
        PrintMatrix("Matrix 1 + Matrix 2:", resultAddition);

        int[,] resultMultiplication = MultiplyMatrices(matrix1, matrix2);
        PrintMatrix("Matrix 1 * Matrix 2:", resultMultiplication);
    }

    static int[,] MultiplyMatrixByScalar(int[,] matrix, int scalar)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }

        return result;
    }

    static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int cols2 = matrix2.GetLength(1);
        int[,] result = new int[rows1, cols2];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                for (int k = 0; k < cols1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return result;
    }

    static void PrintMatrix(string label, int[,] matrix)
    {
        Console.WriteLine(label);
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}



class ArithmeticCalculator
{
    static void Main()
    {
        Console.WriteLine;
        string input = Console.ReadLine();

        double result = CalculateExpression(input);
        Console.WriteLine($"Результат: {result}");
    }

    static double CalculateExpression(string input)
    {
        DataTable dt = new DataTable();
        return Convert.ToDouble(dt.Compute(input, ""));
    }
}



class SentenceCaseConverter
{
    static void Main()
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();

        string result = ConvertFirstLetterInSentencesToUppercase(input);
        Console.WriteLine($"Результат: {result}");
    }

    static string ConvertFirstLetterInSentencesToUppercase(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return text;
        }

        char[] punctuation = { '.', '!', '?' };
        string[] sentences = text.Trim().Split(punctuation, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < sentences.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(sentences[i]))
            {
                sentences[i] = char.ToUpper(sentences[i].Trim()[0]) + sentences[i].Trim().Substring(1);
            }
        }

        int index = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (index < sentences.Length && text[i] == sentences[index].Trim()[sentences[index].Trim().Length - 1])
            {
                sentences[index] += text[i];
                index++;
            }
        }

        return string.Join("", sentences);
    }
}


class WordCensor
{
    static void Main()
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();

        string forbiddenWord = "die";
        string censoredText = CensorText(input, forbiddenWord);

        Console.WriteLine($"Результат: {censoredText}");
    }

    static string CensorText(string text, string forbiddenWord)
    {
        string pattern = @"\b" + Regex.Escape(forbiddenWord) + @"\b";
        string censoredText = Regex.Replace(text, pattern, new MatchEvaluator(m => new string('*', m.Length)));
        return censoredText;
    }
}

