namespace лаба3
{
    class Program
    {
        static void Main(string[] args)
        {

            //запрашиваем число n
            Console.WriteLine("Введите число n:");
            int n = Convert.ToInt16(Console.ReadLine());

            //Запрашиваем 2*n элементов
            Console.WriteLine("Введите {0} элементов массива:", 2 * n);
            string[] input = Console.ReadLine().Split(' ');
            Console.WriteLine("-----------------------------\n");

            //проверяем корректность ввода,если введено меньше или больше элементов, повторяем запрос
            while (input.Length != 2 * n)
            {
                Console.WriteLine("Неверное количество элементов");
                Console.WriteLine("-----------------------------\n");
                Console.WriteLine("Введите {0} элементов массива:", 2 * n);
                input = Console.ReadLine().Split(' ');
            }

            //составляем массив
            double[] numbers = new double[2 * n];
            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = double.Parse(input[i]);
            }

            //вывод исходного набора интервалов
            Console.WriteLine("Исходный набор интервалов");
            for (int i = 0; i <= numbers.Length - 2; i += 2)
            {
                Console.Write("({0} , {1}) ", numbers[i], numbers[i + 1]);
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------\n");


            if (checking(numbers, out double start, out double end))
            {
                Console.WriteLine($"Объединение интервалов является интервалом: ({start}, {end})");
            }
            else
            {
                Console.WriteLine("Объединение интервалов не является интервалом.");
            }
        }


        static bool checking(double[] a, out double start, out double end)
        {
            start = a[0];//левая граница конечного интервала
            end = a[1];//правая граница конечного интервала
            bool flag = true;

            for (int i = 0; i <= a.Length - 2; i += 2)
            {
                for (int j = i + 2; j <= a.Length - 2; j += 2)
                {
                    if (a[j] > a[i + 1] || a[j + 1] < a[i])//сравниваем два интервала, если не пересекаются то false
                        flag = false;
                    else//если пересекаются расширяем границы конечного интервала
                    {
                        start = Math.Min(start, a[j]);
                        end = Math.Max(end, a[j + 1]);
                        flag = true;
                    }
                }
            }
            return flag;

        }
    }
}

    
