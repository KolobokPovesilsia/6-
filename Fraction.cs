using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatesOOPS  // определяем пространство имен для интерфейса и класса
{
    public class Fraction : ICloneable, IFraction  // определяем класс, реализуем интерфейсы
    {
        private int numerator;  // поле, хранящее числитель
        private int denominator;  
        private double? cachedValue = null;  // поле кэшированного значения дроби при переводе в десятичную

        public int Numerator { get; private set; }  // определяем свойство. получаем его значение и изменяем
        public int Denominator { get; private set; }

        public Fraction(int numerator, int denominator)  // создание конструктора с двумя параметрами
        {
            if (denominator == 0)  // если знаменатель нулевой
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю.");  // прерываем работу блока и создаем экземпляр исключения с текстом
            }

            if (denominator < 0)  // если знаменатель меньше нуля
            {
                denominator = -denominator;  //знаменатель станет положительным
                numerator = -numerator;  // числитель отрицательным(или тоже положительным, если изначально был с -)
            }

            this.numerator = numerator;  // присваивание полям класса
            this.denominator = denominator;  

            Numerator = numerator;  // для доп.проверок
            Denominator = denominator;

        }

        

        public override string ToString()  // метод для представления дроби в виде строки
        {
            return $"{numerator} / {denominator}";
        }

        public Fraction Add(Fraction other)  // метод сложения дробей
        {
            int newNumerator = Numerator * other.Denominator + Denominator * other.Numerator;
            int newDenominator = Denominator * other.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Subtract(Fraction other)  // метод вычитания дробей
        {
            int newNumerator = Numerator * other.Denominator - Denominator * other.Numerator;
            int newDenominator = Denominator * other.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Multiply(Fraction other)  // умножение
        {
            int newNumerator = Numerator * other.Numerator;
            int newDenominator = Denominator * other.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Divide(Fraction other)  // деление
        {
            if (other.Numerator == 0)  //проверяем, если числитель второй дроби 0, то выбрасываем исключение
            {
                throw new DivideByZeroException("Деление на ноль.");
            }

            int newNumerator = Numerator * other.Denominator;
            int newDenominator = Denominator * other.Numerator;
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Add(int number)  // сложение с целым числом
        {
            return Add(new Fraction(number, 1));  // возвращаем результат работы метода, представляя, что целое число = это же число : 1
        }

        public Fraction Subtract(int number)  // вычитание
        {
            return Subtract(new Fraction(number, 1));
        }

        public Fraction Multiply(int number)  // умножение
        {
            return Multiply(new Fraction(number, 1));
        }

        public Fraction Divide(int number)  // деление
        {
            return Divide(new Fraction(number, 1));
        }

        public override bool Equals(object obj)  // переопределенный метод для сравнения на равенство дробей
        {
            if (obj == null || GetType() != obj.GetType())  // проверяем, на пустоту объекта и на его типы
            {
                return false;
            }

            var other = (Fraction)obj;  // приводим объект к типу fraction
            return Numerator == other.Numerator && Denominator == other.Denominator;  // если числители и знаменатели одинаковые, вернем правду, а если нет, то ложь
        }

        public override int GetHashCode()  // переопредленный метод для генерации уникального хеш-кода для объекта.
        {
            return HashCode.Combine(Numerator, Denominator);  // объединение хэш-кода числителя и знаменателя
        }

        public object Clone()  // метод клонирования 
        {
            return new Fraction(this.Numerator, this.Denominator); 
        }

        public double ToDouble()  // метод преобразования дроби в формат десятичной
        {
            if (cachedValue == null)  // если дробь еще не переведена 
            {
                cachedValue = (double)Numerator / Denominator;
            }
            return cachedValue.Value;  // возвращаем значение 
        }

        public void SetNumerator(int numerator)  // обновляем числитель дроби
        {
            this.numerator = numerator;  //  Полю numerator присваивается новое значение, переданное в параметр numerator.
            
            cachedValue = null;  // очищаем кэш
        }

        public void SetDenominator(int denominator)  // обновление знаменателя дроби
        {
            if (denominator == 0)  // опять же, знаменатель не может быть нулевым!
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            }
            this.denominator = denominator;  // новому значению присваивается поле знаменателя класса.

            cachedValue = null;  // очистили кэш
        }
    }
}
