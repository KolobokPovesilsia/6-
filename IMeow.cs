using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatesOOPS  // определяем пространство имен для интерфейса и класса
{
    public interface IMeow  // определяем контракт, чтобы любой класс, реализующий этот интерфейс, предоставлял метод мяуканья
    {
        void Meow();
    }
}
