using System;  //директивы
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatesOOPS  // определяем пространство имен для интерфейса и класса
{
    public interface IFraction  // создание интерфейса IFraction для реализации класса
    {
        double ToDouble();  // метод для возвращения вещественного числа
        void SetNumerator(int numerator);  // метод для установки числителя
        void SetDenominator(int denominator);  // метод для установки знаменателя
    }
}
