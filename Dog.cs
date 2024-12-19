using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatesOOPS  // определяем пространство имен для интерфейса и класса
{
    public class Dog : IMeow  // класс dog, реализующий все методы интерфейса
    {
        private string name;  

        public Dog(string name)  // принимаем строку и присваиваем ее в поле имя
        {
            this.name = name;
        }

        public void Meow()  // метод мяуканья
        {
            Console.WriteLine($"{name}: гав! (но притворяется, что может мяукать)");  // вывод сообщения
        }

        public override string ToString()  // переопредленный метод для преобразования в строковый формат
        {
            return $"Собака: {name}";
        }
    }
}
