using System; // Используем пространство имен System

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
            var min = 0; // Объявляем переменную min для хранения минимального значения элементов массива
            double avg = 0.0; // Объявляем переменную avg для хранения среднего значения элементов массива

            for (var i = 0; i < 5; i++) // Цикл по строкам массива
            {
                for (var j = 0; j < 5; j++) // Цикл по столбцам массива
                {
                    array[i, j] = rnd.Next(1, 10 + 1); // Заполняем каждый элемент массива случайным числом от 1 до 10 включительно
                }
            }

            Console.WriteLine("Array:"); // Выводим строку "Array:" в стандартный выходной поток с новой строки перед ней
            WriteArray(array); // Вызываем метод WriteArray с аргументом array

            Array_Sum(out sum, array); // Вызываем метод Array_Sum с аргументами out sum и array
            ArrayMaxMin(out max, out min, array); // Вызываем метод Array_MaxMin с аргументами out max, out min и array
            Array_Average(sum, out avg, array); // Вызываем метод Array_Average с аргументами sum, out avg и array
            ReverseArray(array); // Вызываем метод ReversArray с аргументом array
            SortArray(array); // Вызываем метод SortArray с аргументом array
            SortArrayDescending(array); // Вызываем метод SortArrayDescending с аргументом array
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

        static void ArrayMaxMin(out int max, out int min, int[,] array) // Объявляем статический метод ArrayMaxMin с двумя выходными параметрами типа int и двумерным массивом типа int[,]
        {
            min = array[0, 0]; // Присваиваем начальное значение переменной min равное первому элементу массива
            max = array[0, 0]; // Присваиваем начальное значение переменной max равное первому элементу массива
            for (int i = 0; i < array.GetLength(0); i++) // Цикл for для перебора строк массива
            {
                for (int j = 0; j < array.GetLength(1); j++) // Цикл for для перебора столбцов массива
                {
                    if (array[i, j] < min) // Если текущий элемент меньше значения переменной min
                        min = array[i, j]; // Присваиваем значение переменной min равное текущему элементу
                    if (array[i, j] > max) // Если текущий элемент больше значения переменной max
                        max = array[i, j]; // Присваиваем значение переменной max равное текущему элементу
                }
            }

            Console.WriteLine($"Max = {max}"); // Выводим значение переменной max в стандартный выходной поток с помощью интерполяции строк
            Console.WriteLine($"Min = {min}"); // Выводим значение переменной min в стандартный выходной поток с помощью интерполяции строк
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

            for (int i = 0; i < rows * cols; i++) // Цикл for для перебора элементов массива
            {
                for (int j = 0; j < rows * cols - 1; j++) // Вложенный цикл for для сравнения текущего элемента с оставшимися элементами массива
                {
                    int currentRow = j / cols; // Вычисляем номер строки текущего элемента
                    int currentCol = j % cols; // Вычисляем номер столбца текущего элемента
                    int nextRow = (j + 1) / cols; // Вычисляем номер строки следующего элемента
                    int nextCol = (j + 1) % cols; // Вычисляем номер столбца следующего элемента

                    if (array[currentRow, currentCol] > array[nextRow, nextCol]) // Если текущий элемент больше следующего элемента
                    {
                        int temp = array[currentRow, currentCol]; // Сохраняем значение текущего элемента во временной переменной temp
                        array[currentRow, currentCol] = array[nextRow, nextCol]; // Присваиваем значение следующего элемента текущему элементу
                        array[nextRow, nextCol] = temp; // Присваиваем значение временной переменной temp следующему элементу
                    }
                }
            }

            Console.WriteLine("\nSortArray:"); // Выводим строку "SortArray:" в стандартный выходной поток с новой строки перед ней
            WriteArray(array); // Вызываем метод WriteArray с аргументом array для вывода отсортированного массива на экран

            return array; // Возвращаем отсортированный массив как результат работы метода SortArray.
        }

        static int[,] SortArrayDescending(int[,] array) // Объявляем статический метод SortArrayDescending с двумерным массивом типа int[,] в качестве параметра и возвращаемым значением
        {
            int rows = array.GetLength(0); // Получаем количество строк в массиве
            int cols = array.GetLength(1); // Получаем количество столбцов в массиве
            for (int i = 0; i < rows * cols; i++) // Цикл for для перебора элементов массива
            {
                for (int j = 0; j < rows * cols - 1; j++) // Вложенный цикл for для сравнения текущего элемента с оставшимися элементами массива
                {
                    int currentRow = j / cols; // Вычисляем номер строки текущего элемента
                    int currentCol = j % cols; // Вычисляем номер столбца текущего элемента
                    int nextRow = (j + 1) / cols; // Вычисляем номер строки следующего элемента
                    int nextCol = (j + 1) % cols; // Вычисляем номер столбца следующего элемента
                    if (array[currentRow, currentCol] < array[nextRow, nextCol]) // Если текущий элемент меньше следующего элемента (измененное условие)
                    {
                        int temp = array[currentRow, currentCol]; // Сохраняем значение текущего элемента во временной переменной temp
                        array[currentRow, currentCol] = array[nextRow, nextCol]; // Присваиваем значение следующего элемента текущему элементу
                        array[nextRow, nextCol] = temp; // Присваиваем значение временной переменной temp следующему элементу
                    }
                }
            }
            Console.WriteLine("\nSortArrayDescending:"); // Выводим строку "SortArrayDescending:" в стандартный выходной поток с новой строки перед ней
            WriteArray(array); // Вызываем метод WriteArray с аргументом array для вывода отсортированного массива на экран

            return array; // Возвращаем отсортированный по убыванию массив как результат работы метода SortArrayDescending.
        }

        static int[,] ReverseArray(int[,] array) // Объявляем статический метод ReverseArray с двумерным массивом типа int[,] в качестве параметра и возвращаемым значением
        {
            int rows = array.GetLength(0); // Получаем количество строк в массиве
            int cols = array.GetLength(1); // Получаем количество столбцов в массиве
            int[,] result = new int[rows, cols]; // Создаем новый двумерный массив result с такими же размерами как исходный массив

            for (int i = 0; i < rows; i++) // Цикл for для перебора строк массива
            {
                for (int j = 0; j < cols; j++) // Вложенный цикл for для перебора столбцов массива
                {
                    result[i, j] = array[rows - 1 - i, cols - 1 - j]; // Присваиваем значение текущего элемента из исходного массива соответствующему элементу в новом массиве с обратным индексом
                }
            }
            Console.WriteLine("\nReverseArray:"); // Выводим строку "nReverseArray:" в стандартный выходной поток с новой строки перед ней
            WriteArray(array); // Вызываем метод WriteArray с аргументом array для вывода отсортированного массива на экран
            return result; // Возвращаем новый отсортированный по убыванию массив как результат работы метода ReverseArray.
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
