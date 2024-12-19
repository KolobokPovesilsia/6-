using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TemplatesOOPS  // определяем пространство имен для интерфейса и класса
{
    public class Cat : IMeow  
    {
        private string name;  //поле имени кота
        public int MeowCount { get; private set; }  // счетчик мяуканий
        public string Name { get { return name; } }  //свойство Name, предоставляющим доступ к полю только для чтения

        public Cat(string name)  // присваивание строки к полю, количество мяуканий иззначально нулевое
        {
            this.name = name;
            MeowCount = 0;  
        }

        public override string ToString()  // переопредленный метод для возвращения имени кота 
        {
            return $"Кот : {name}";
        }

        public void Meow()  // метод мяуканья 
        {
            MeowCount++;  // добавили к счетчику
            Console.WriteLine($"{name}: мяу!");  // ну и мяукнули:)
        }

        public void Meow(int n)  // метод мяуканья нужного количество раз
        {
            string meow = string.Concat(Enumerable.Repeat("мяу", (int)n));  // повторяем строку мяу нужное количество раз и записываем без пробелов
            MeowCount += n;
            Console.WriteLine($"{name}: {meow.Replace("мяу", "мяу-").TrimEnd('-')}"); // выводим, удаляя последний дефис
        }
    }
}
