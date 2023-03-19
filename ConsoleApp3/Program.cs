using System; // Используем пространство имен System
using System.Linq; // Используем пространство имен System.Linq

namespace ConsoleApp3 // Объявляем пространство имен ConsoleApp3
{
    internal class Program // Объявляем внутренний класс Program
    {
        static void Main(string[] args) // Объявляем статический метод Main с аргументами типа string[]
        {
            Random rnd = new Random(); // Создаем новый экземпляр класса Random

            var array = new int[5, 5]; // Создаем двумерный массив размером 5 на 5 элементов типа int
            var sum = 0; // Объявляем переменную sum для хранения суммы элементов массива
            var max = 0; // Объявляем переменную max для хранения максимального значения элементов массива
            var min = 999999; // Объявляем переменную min для хранения минимального значения элементов массива
            double avg = 0.0; // Объявляем переменную avg для хранения среднего значения элементов массива

            for (var i = 0; i < 5; i++) // Цикл по строкам массива
            {
                for (var j = 0; j < 5; j++) // Цикл по столбцам массива
                {
                    array[i, j] = rnd.Next(1, 10 + 1); // Заполняем каждый элемент массива случайным числом от 1 до 10 включительно
                }
            }
            WriteArray(array); // Вызываем метод WriteArray с аргументом array

            Array_Sum(out sum, array); // Вызываем метод Array_Sum с аргументами out sum и array
            Array_Max(out max, array); // Вызываем метод Array_Max с аргументами out max и array
            Array_Min(out min, array); // Вызываем метод Array_Min с аргументами out min и array
            Array_Average(sum, out avg, array); // Вызываем метод Array_Average с аргументами sum, out avg и array
            SortArray(array); // Вызываем метод SortArray с аргументом array
            ReversArray(array); // Вызываем метод ReversArray с аргументом array
            Console.ReadLine(); // Читаем строку из стандартного входного потока (ожидаем нажатия клавиши Enter)
        }

        static void Array_Sum(out int sum, int[,] array) // Объявляем статический метод Array_Sum с выходным параметром типа int и двумерным массивом типа int[,]
        {
            sum = 0; // Инициализируем переменную sum значением 0
            foreach (var element in array) // Цикл по всем элементам массива
            {
                sum += element; // Добавляем значение текущего элемента к переменной sum
            }
            Console.WriteLine($"\nsum = {sum}"); // Выводим значение переменной sum в стандартный выходной поток
        }

        static void Array_Max(out int max, int[,] array) // Объявляем статический метод Array_Max с выходным параметром типа int и двумерным массивом типа int[,]
        {
            max = 0; // Инициализируем переменную max значением 0
            int rows = array.GetLength(0); // Получаем количество строк в массиве
            int cols = array.GetLength(1); // Получаем количество столбцов в массиве
            int[] tempArray = new int[rows * cols]; // Создаем одномерный массив размером rows * cols элементов типа int
            int index = 0; // Объявляем переменную index для хранения текущего индекса элемента в tempArray

            for (int i = 0; i < rows; i++) // Цикл по строкам массива
                for (int j = 0; j < cols; j++) // Цикл по столбцам массива
                    tempArray[index++] = array[i, j]; // Копируем значение текущего элемента из двумерного массива в одномерный

            max = tempArray.Max(); // Назначаем переменной max максимальное значение элементов tempArray

            Console.WriteLine($"Max = {max}"); // Выводим значение переменной max в стандартный выходной поток
        }

        static void Array_Min(out int min, int[,] array) // Объявляем статический метод Array_Min с выходным параметром типа int и двумерным массивом типа int[,]
        {
            min = 0; // Инициализируем переменную min значением 0
            int rows = array.GetLength(0); // Получаем количество строк в массиве
            int cols = array.GetLength(1); // Получаем количество столбцов в массиве
            int[] tempArray = new int[rows * cols]; // Создаем одномерный массив размером rows * cols элементов типа int
            int index = 0; // Объявляем переменную index для хранения текущего индекса элемента в tempArray

            for (int i = 0; i < rows; i++) // Цикл по строкам массива
                for (int j = 0; j < cols; j++) // Цикл по столбцам массива
                    tempArray[index++] = array[i, j]; // Копируем значение текущего элемента из двумерного массива в одномерный

            min = tempArray.Min(); // Назначаем переменной min минимальное значение элементов tempArray

            Console.WriteLine($"Min = {min}"); // Выводим значение переменной min в стандартный выходной поток
        }

        static void Array_Average(int sum, out double avg, int[,] array) // Объявляем статический метод Array_Average с параметрами типа int и double и двумерным массивом типа int[,]
        {
            avg = sum / array.Length; // Вычисляем среднее арифметическое элементов массива и назначаем его переменной avg
            Console.WriteLine($"Avg = {avg}"); // Выводим значение переменной avg в стандартный выходной поток

        }

        static int[,] SortArray(int[,] array) // Объявляем статический метод SortArray с двумерным массивом типа int[,] в качестве параметра и возвращаемым значением
        {
            int rows = array.GetLength(0); // Получаем количество строк в массиве
            int cols = array.GetLength(1); // Получаем количество столбцов в массиве
            int[] tempArray = new int[rows * cols]; // Создаем одномерный массив размером rows * cols элементов типа int
            int index = 0; // Объявляем переменную index для хранения текущего индекса элемента в tempArray

            for (int i = 0; i < rows; i++) // Цикл по строкам массива
                for (int j = 0; j < cols; j++) // Цикл по столбцам массива
                    tempArray[index++] = array[i, j]; // Копируем значение текущего элемента из двумерного массива в одномерный

            Array.Sort(tempArray); // Сортируем элементы tempArray по возрастанию
            index = 0; // Сбрасываем значение переменной index на 0

            for (int i = 0; i < rows; i++) // Цикл по строкам массива
                for (int j = 0; j < cols; j++) // Цикл по столбцам массива
                    array[i, j] = tempArray[index++]; // Копируем значение текущего элемента из одномерного массива в двумерный

            Console.WriteLine("\nSortArray:"); // Выводим строку "SortArray:" в стандартный выходной поток
            WriteArray(array); // Вызываем метод WriteArray с аргументом array
            return array; // Возвращаем отсортированный двумерный массив array
        }

        static int[,] ReversArray(int[,] array) // Объявляем статический метод ReversArray с двумерным массивом типа int[,] в качестве параметра и возвращаемым значением
        {
            int rows = array.GetLength(0); // Получаем количество строк в массиве
            int cols = array.GetLength(1); // Получаем количество столбцов в массиве
            int[] tempArray = new int[rows * cols]; // Создаем одномерный массив размером rows * cols элементов типа int
            int index = 0; // Объявляем переменную index для хранения текущего индекса элемента в tempArray

            for (int i = 0; i < rows; i++) // Цикл по строкам массива
                for (int j = 0; j < cols; j++) // Цикл по столбцам массива
                    tempArray[index++] = array[i, j]; // Копируем значение текущего элемента из двумерного массива в одномерный

            Array.Reverse(tempArray); // Изменяем порядок элементов tempArray на обратный
            index = 0; // Сбрасываем значение переменной index на 0

        static int[,] ReverseArray(int[,] array) // Объявляем статический метод ReverseArray с двумерным массивом типа int[,] в качестве параметра и возвращаемым значением
        {
            int rows = array.GetLength(0); // Получаем количество строк в массиве
            int cols = array.GetLength(1); // Получаем количество столбцов в массиве
            int[,] result = new int[rows, cols]; // Создаем новый двумерный массив result с такими же размерами как исходный массив

            Console.WriteLine("\nReverseArray:"); // Выводим строку "ReverseArray:" в стандартный выходной поток
            WriteArray(array); // Вызываем метод WriteArray с аргументом array
            return array; // Возвращаем отсортированный в обратном порядке двумерный массив array
        }

        static int[,] WriteArray(int[,] array) // Объявляем статический метод WriteArray с двумерным массивом типа int[,] в качестве параметра и возвращаемым значением
        {
            for (int i = 0; i < array.GetLength(0); i++) // Цикл по строкам массива
            {
                for (int j = 0; j < array.GetLength(1); j++) // Цикл по столбцам массива
                {
                    Console.Write(array[i, j] + " "); // Выводим значение текущего элемента массива и пробел в стандартный выходной поток
                }
                Console.WriteLine(); // Переходим на новую строку в стандартном выходном потоке
            }
            return array; // Возвращаем двумерный массив array без изменений
        }
    }
}
