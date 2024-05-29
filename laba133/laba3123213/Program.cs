using ClassLibrary133;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba133
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание двух коллекций MyObservableCollection
            MyObservableCollection<Auto> collection1 = new MyObservableCollection<Auto>();
            MyObservableCollection<Auto> collection2 = new MyObservableCollection<Auto>();

            // Создание двух объектов типа Journal
            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            // Подписка первого объекта Journal на события CollectionCountChanged и CollectionReferenceChanged из первой коллекции
            collection1.CollectionCountChanged += journal1.HandleCollectionCountChanged;
            collection1.CollectionReferenceChanged += journal1.HandleCollectionReferenceChanged;

            // Подписка второго объекта Journal на события CollectionReferenceChanged из обеих коллекций
            collection1.CollectionReferenceChanged += journal2.HandleCollectionReferenceChanged;
            collection2.CollectionReferenceChanged += journal2.HandleCollectionReferenceChanged;

            // Добавление элементов в коллекции
            collection1.Add(new Auto("BMW", "black", 2020, 50000, 5));
            collection1.Add(new Auto("Honda", "white", 2019, 40000, 6));
            collection2.Add(new Auto("Volkswagen", "green", 2018, 30000, 7));
            collection2.Add(new Auto("Ford", "purple", 2017, 20000, 8));

            // Удаление некоторых элементов из коллекций
            collection1.Remove(collection1[0]);
            collection2.Remove(collection2[1]);

            // Присвоение некоторым элементам коллекций новые значения
            collection1[0] = new Auto("Audi", "pink", 2016, 10000, 9);
            collection2[0] = new Auto("BMW", "black", 2020, 50000, 5);

            // Вывод данных об объектах Journal
            Console.WriteLine("Данные журнала 1:");
            Console.WriteLine(journal1);
            Console.WriteLine();

            Console.WriteLine("Данные журнала 2:");
            Console.WriteLine(journal2);
        }
    }
}
