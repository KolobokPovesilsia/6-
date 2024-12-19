using TemplatesOOPS;

internal class Program
{
    private static void Main(string[] args)
    {
        // Коты
        Console.WriteLine("Задание 1");
        Console.WriteLine("1.1 Кот мяукает");
        
        Cat barsik = new Cat("Барсик");
        barsik.Meow();
        int number;
        Console.WriteLine("Введите число (столько раз мяукнет котик)");

        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out number))
            {
                break; // Ввод корректен, выходим из цикла
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите корректное число.");
            }
        }
        barsik.Meow(number);
        Console.WriteLine();
        Console.WriteLine("1.2 Интерфейс мяуканья");
        Cat murzik = new Cat("Мурзик");

        // Создаем "мяукающую" собаку
        Dog sharik = new Dog("Шарик");

        // Список мяукающих объектов
        List<IMeow> meowingObjects = new List<IMeow> { barsik, murzik, sharik };

        // Вызываем метод MakeThemMeow
        
        MakeThemMeow(meowingObjects);
        Console.WriteLine();
        Console.WriteLine("1.3 Количество мяуканий");
        Console.WriteLine($"Количество мяуканий кота: {barsik.Name} -  {barsik.MeowCount}");

        Console.WriteLine();
        // Дроби
        Console.WriteLine("Задание 2");
        Console.WriteLine();
        Console.WriteLine("2.1 Дроби");
        // Создание нескольких экземпляров дробей
        Fraction f1 = new Fraction(1, 2);
        Fraction f2 = new Fraction(0, -3);
        Fraction f3 = new Fraction(4, 5);

        // Примеры использования методов
        Console.WriteLine($"{f1} + {f2} = {f1.Add(f2)}");
        Console.WriteLine($"{f1} - {f2} = {f1.Subtract(f2)}");
        Console.WriteLine($"{f1} * {f2} = {f1.Multiply(f2)}");
        Console.WriteLine($"{f1} / {f2} = {f1.Divide(f2)}");

        // Выражение f1.sum(f2).div(f3).minus(5)
        Fraction result = f1.Add(f2).Divide(f3).Subtract(5);
        Console.WriteLine($"{f1} + {f2} / {f3} - 5 = {result}");

        // Сравнение дробей
        Console.WriteLine();
        Console.WriteLine("2.2. Сравнение дробей");
        Console.WriteLine($"Дробь1: {f1}");
        Console.WriteLine($"Дробь2: {f2}");
        Console.WriteLine($"Дроби одинаковые? {f1.Equals(f2)}");

        // Клонирование дроби
        Console.WriteLine();
        Console.WriteLine("2.3. Клонирование дроби");
        var fractionClone = (Fraction)f1.Clone();
        Console.WriteLine($"Клонируем дробь: {fractionClone}");
        Console.WriteLine($"Дробь1 Клон? {f1.Equals(fractionClone)}");

        // Проверка независимости клона
        fractionClone.SetNumerator(3);
        Console.WriteLine($"Модифицированная клонированная дорбь: {fractionClone}");
        Console.WriteLine($"Оригинальная дробь остаётся неизменной: {f1}");

        Console.WriteLine();
        Console.WriteLine("2.4. Шаблоны");
        // Работа с интерфейсом IFraction
        Console.WriteLine($"Дробь1 как вещественное число: {f1.ToDouble()}");

        f1.SetNumerator(3);
        f1.SetDenominator(4);
        Console.WriteLine($"Изменённая Дробь1: {f1}");
        Console.WriteLine($"Дробь1 как вещественное число после модифицикации: {f1.ToDouble()}");

        // Проверка кэширования
        Console.WriteLine($"Кешированное значение: {f1.ToDouble()}"); // Повторный вызов не пересчитывает значение
    }

    public static void MakeThemMeow(IEnumerable<IMeow> meowingObjects)
    {
        foreach (var obj in meowingObjects)
        {
            obj.Meow();
        }
    }
}