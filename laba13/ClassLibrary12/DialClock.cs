using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary12
{
    public class IdNumber
    {
        public int number;
        public IdNumber(int number)
        {
            this.number=number;
        }
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return number.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is IdNumber n) return this.number == n.number;
            return false;
        }

        public override int GetHashCode()
        {
            return 769468832+number.GetHashCode();
        }
    }
    public class DialClock<T> where T: IInit, IComparable, new()
    {
        public int hours;
        public int minutes;
        static int count = 0;
        public IdNumber id;

        Random rnd = new Random();
        public DialClock() // если конструктор пустой
        {
            Hours = 0;
            Minutes = 0;
            id = new IdNumber(1);
            count++;
        }
        public DialClock(int hours, int minutes, int number) // конструктор с параметрами
        {
            Hours = hours;
            Minutes = minutes;
            id = new IdNumber(number);
            count++;
        }

        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (value < 0 || value >= 24)
                {
                    throw new Exception("Часы неправильные");
                }
                hours = value;
            }
        }
        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                if (value < 0 || value >= 60)
                {
                    throw new Exception("Минуты неправильные");
                }
                minutes = value;

            }
        }
        public void Init()
        {
            Console.Write("Введите id:");
            try
            {
                id.number = int.Parse(Console.ReadLine());
            }
            catch
            {
                id.number = 0;
            }
            Console.Write("Введите количество минут:");
            Minutes = InputIntNumber();
            Console.Write("Введите количество часов:");
            Hours = InputIntNumber();
        }
        public void RandomInit()
        {
            Hours = rnd.Next(0, 23);
            Minutes = rnd.Next(0, 59);
            id.number = rnd.Next(1, 100);
        }
        public override bool Equals(object obj) // сравнение двух объектов класса DialClock
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            DialClock<T> otherClock = (DialClock<T>)obj;
            return Hours == otherClock.hours && Minutes == otherClock.minutes;
        }
        public override string ToString() // вывод на экран
        {
            return $"Часы: {Hours}, минуты: {Minutes}, id: {id}.";
        }
        private static int InputIntNumber() // проверка на целое число
        {
            bool isCorrert;
            int number;
            do
            {
                isCorrert = int.TryParse(Console.ReadLine(), out number);
                if (!isCorrert) Console.WriteLine("Пожалуйста, введите число: ");
            } while (!isCorrert);
            return number;
        }
        public object Clone()
        {
            return new DialClock<T>(Hours, Minutes, id.number);
        }
        public object ShallowCopy() //поверхностное копирование
        {
            return this.MemberwiseClone();
        }

        public override int GetHashCode()
        {
            int hashCode = -1688639373;
            hashCode=hashCode*-1521134295+hours.GetHashCode();
            hashCode=hashCode*-1521134295+minutes.GetHashCode();
            hashCode=hashCode*-1521134295+EqualityComparer<IdNumber>.Default.GetHashCode(id);
            hashCode=hashCode*-1521134295+EqualityComparer<Random>.Default.GetHashCode(rnd);
            hashCode=hashCode*-1521134295+Hours.GetHashCode();
            hashCode=hashCode*-1521134295+Minutes.GetHashCode();
            return hashCode;
        }
    }
}
