Домашняя работа №0
Тема: Повторение основ C#.

Задания: 
Задание 1: Напишите программу, которая принимает два числа от пользователя и вычисляет результат выражения (a+b)×(a−b).
Он не читает readline, поэтому дополнила parse 
```
internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Задайте первое число: ");
        int a = int.Parse(Console.ReadLine()); 

        Console.Write("Задайте второе число: ");
        int b = int.Parse(Console.ReadLine());

        int c = (a + b) * (a - b);
        Console.WriteLine($"Результат выражения: {c}");
        Console.ReadKey();
    }
}

```
 

Задание 2: Создайте программу-калькулятор, которая запрашивает два числа и операцию (сложение, вычитание, умножение или деление) от пользователя. Программа должна выполнять соответствующую операцию и выводить результат. Используйте оператор switch.
```
class Calculator
{
    public double Calculate(double num1, double num2, char operation)
    {
        double result = 0;

        switch (operation)
        {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
                if (num2 != 0)
                    result = num1 / num2;
                else
                    Console.WriteLine("На ноль делить нельзя");
                break;

            default:
                Console.WriteLine("Ошибка");
                break;
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();

        Console.WriteLine("Первое число: ");
        double number1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите второе число:");
        double number2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите операцию (+, -, *, /):");
        char operation = Console.ReadLine()[0];

        double result = calculator.Calculate(number1, number2, operation);

        if (operation == '+' || operation == '-' || operation == '*' || (operation == '/' && number2 != 0))
        {
            Console.WriteLine("Результат = " + result);
        }

        Console.ReadKey();
    }
}
```

Проще реализацию сделать не получается, выдает ошибки



Задание 3: Напишите программу, которая выводит таблицу умножения на 5 с использованием цикла while.
```
class Program
{
    static void Main(string[] args)
    {
        int i = 1;
        while (i <= 10)
        {
            Console.WriteLine(i*5);
            i++;
        }
        Console.ReadKey();
    }
}

```

Задание 4: Напишите программу, которая вычисляет среднее арифметическое элементов массива. Используйте цикл для суммирования элементов.
```
class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 5,8,21,11 };
        int sum = 0;
      
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        double avg = (double)sum / numbers.Length;
        Console.WriteLine($"Среднее арифм: {avg}");

        Console.ReadKey();
    }
}
```

Задание 5: Напишите метод, который принимает массив целых чисел и возвращает максимальное значение. Вызовите этот метод и выведите результат.
```
class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 5, 2, 9, 1, 7 };
        int max = FindMax(numbers);
        Console.WriteLine($"Максимальное значение: {max}");

        Console.ReadKey();
    }

    static int FindMax(int[] numbers)
    {
        if (numbers.Length == 0)
        {
            return 0;
        }

        int max = numbers[0]; 
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i]; 
            }
        }
        return max;
    }
}
```

