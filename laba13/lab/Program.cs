using ClassLibrary12;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace lab
{
    public class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            do
            {
                Commands();
                number = InputIntNumber();
                switch (number)
                {
                    case 1:
                        MyList<Auto> list = new MyList<Auto>();
                        MyList<Auto> clonelist = new MyList<Auto>(); //клонированный список
                        {
                            int ans = 0;
                            do
                            {
                                PrintMenu1();
                                ans = InputIntNumber();
                                switch (ans)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine();
                                            Console.Write("Какого размера будет список?: ");
                                            int size = InputIntNumber();
                                            MyList<Auto> array = new MyList<Auto>(size);
                                            list = array;
                                            Console.WriteLine("Список создан");
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine();
                                            list.PrintList();
                                            break;
                                        }
                                    case 3:
                                        {
                                            int choose = 0;
                                            do
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("1) Добавить в список элементы с номерами 1, 3, 5 и т. д.");
                                                Console.WriteLine("2) Удалить из списка все элементы, начиная с элемента с заданным информационным полем (например, с заданным именем), и до конца списка");
                                                Console.WriteLine("3) Распечатать список");
                                                Console.WriteLine("4) Выход");
                                                Console.Write("Выберите пункт меню: ");
                                                choose = InputIntNumber();
                                                switch (choose)
                                                {
                                                    case 1:
                                                        {
                                                            Console.WriteLine("Идет добавление...");
                                                            // Прогресс добавдения от 0 до 100
                                                            for (int progress = 0; progress <= 100; progress++)
                                                            {
                                                                DrawTextProgressBar(progress);
                                                                Thread.Sleep(50); // Задержка для эффекта загрузки
                                                            }
                                                            for (int i = 0; i <= list.Count; i+=2)
                                                            {
                                                                Auto auto = new Auto();
                                                                auto.RandomInit();
                                                                list.AddToOdd();
                                                            }
                                                            list.AddToOdd();
                                                            Console.WriteLine("\nДобавление завершено!");
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.WriteLine("Введите элемент, начиная с которого хотите удалить все до конца списка");
                                                            Auto auto = new Auto();
                                                            auto.Init();
                                                            list.RemoveFrom(auto);
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            list.PrintList();
                                                            break;
                                                        }
                                                }
                                            } while (choose != 4);
                                            break;
                                        }
                                    case 4:
                                        {
                                            clonelist = list.Clone();
                                            Console.WriteLine("Оригинальный список");
                                            list.PrintList();
                                            Console.WriteLine("Клонированный список:");
                                            clonelist.PrintList();
                                            break;
                                        }
                                    case 5:
                                        {
                                            list.Clear();
                                            break;
                                        }
                                }
                            } while (ans != 6);
                            break;
                        }
                    case 2:
                        {
                            //MyHashTable<Auto> = new MyHashTable<Auto>();
                            int ans;
                            MyHashTable<Auto> hashtable = new MyHashTable<Auto>();
                            do
                            {
                                PrintMenu2();
                                ans = InputIntNumber();
                                switch (ans)
                                {
                                    case 1:
                                        {
                                            int num;
                                            do
                                            {
                                                Console.Write("Из скольки строк хотите сделать таблицу (число больше или равно 0)?: ");
                                                num = InputIntNumber();
                                            } while (num < 0);
                                            MyHashTable<Auto> table = new MyHashTable<Auto>(num);
                                            for (int i = 0; i < num; i++)
                                            {
                                                Auto auto = new Auto();
                                                auto.RandomInit();
                                                table.AddPoint(auto);
                                            }
                                            hashtable = table;
                                            Console.WriteLine("Таблица создана");
                                            break;
                                        }
                                    case 2:
                                        {
                                            hashtable.PrintTable();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("Введите элемент для поиска:");
                                            Auto auto = new Auto();
                                            auto.Init();
                                            hashtable.Contains(auto);
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("Введите элемент для удаления: ");
                                            Auto auto = new Auto();
                                            auto.Init();
                                            hashtable.RemoveData(auto);
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.WriteLine("Добавление осуществляется");
                                            Auto auto = new Auto();
                                            auto.RandomInit();
                                            hashtable.AddPoint(auto);
                                            break;
                                        }
                                }
                            } while (ans!=6);
                            break;
                        }
                    case 3:
                        {
                            int ans;
                            Tree<Auto> tree1 = new Tree<Auto>();
                            Tree<Auto> tree2 = new Tree<Auto>();
                            do
                            {
                                PrintMenu3();
                                ans = InputIntNumber();
                                switch(ans)
                                {
                                    case 1:
                                        {
                                            Console.Write("Введите длину дерева: ");
                                            int num = InputIntNumber();
                                            Tree<Auto> treehelp = new Tree<Auto>(num);
                                            tree1 = treehelp;
                                            Console.WriteLine("Деревье создано!");
                                            break;
                                        }
                                    case 2:
                                        {
                                            
                                            tree1.ShowTree();
                                            break;
                                        }
                                    case 3:
                                        {
                                            tree1.FindAndDisplayMaxCostItem();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("Первое дерево:");
                                            tree1.ShowTree();
                                            Console.WriteLine("Второе дерево");
                                            tree1.TransformToFindTree();
                                            tree1.ShowTree();
                                            break;
                                        }
                                    case 5:
                                        {
                                            tree1.CleanTree();
                                            Console.WriteLine("Дерево удалено");
                                            break;
                                        }
                                }

                            } while (ans != 6);
                            break;
                        }
                    case 4:
                        {
                            MyCollection<Auto> collection = new MyCollection<Auto>(10);
                            
                            Console.WriteLine("Элементы коллекции:");
                            collection.PrintList();
                            //Console.WriteLine();

                            
                            //Auto[] array = new Auto[collection.Count];
                            //collection.CopyTo(array, 0);
                            //Console.WriteLine("Массив после копирования:");
                            ////collection.PrintList();
                            //for (int i = 0; i < collection.Count; i++)
                            //{
                            //    Console.WriteLine(array[i]);
                            //}
                            //Console.WriteLine();


                            int index = collection.IndexOf(new Auto("Honda", "white", 2015, 30000, 12));
                            Console.WriteLine($"Индекс элемента Honda: {index}");
                            Console.WriteLine();

                            
                            Auto vol = new Auto("Volkswagen", "green", 2020, 40000, 13);
                            bool contains = collection.Contains(vol);
                            Console.WriteLine($"Коллекция содержит {vol}: {contains}");
                            Console.WriteLine();

                            
                            collection.Insert(1, new Auto("Audi", "blue", 2019, 60000, 14));
                            Console.WriteLine("После вставки элемента Audi:");
                            collection.PrintList();
                            Console.WriteLine();

                            
                            collection.RemoveAt(2);
                            Console.WriteLine("После удаления элемента по индексу 2:");
                            collection.PrintList();
                            Console.WriteLine();

                            Auto t = new Auto("BMW", "black", 2018, 50000, 15);
                            collection.Insert(1,t);
                            Console.WriteLine($"Добавил: {t}");
                            collection.PrintList();
                            collection.Remove(t);
                            Console.WriteLine("После удаления элемента BMW:");
                            collection.PrintList();
                            break;
                        }
                }
            } while (number != 5);
        }
        public static void Commands()
        {
            Console.WriteLine("1) 1 Часть");
            Console.WriteLine("2) 2 Часть");
            Console.WriteLine("3) 3 Часть");
            Console.WriteLine("4) 4 Часть");
            Console.WriteLine("5) Выход");
            Console.Write("Введите номер: ");
        }
        public static void PrintMenu1()
        {
            Console.WriteLine("1) Сформировать список");
            Console.WriteLine("2) Распечатать список");
            Console.WriteLine("3) Задание");
            Console.WriteLine("4) Глубокое клонирование");
            Console.WriteLine("5) Удаление из памяти");
            Console.WriteLine("6) Назад");
            Console.Write("Введите номер пункта: ");
        }
        public static void PrintMenu2()
        {
            Console.WriteLine();
            Console.WriteLine("1) Создать хэш-таблицу (метод цепочек)");
            Console.WriteLine("2) Печать хэш-таблицы");
            Console.WriteLine("3) Поиск элемента (по ключу)");
            Console.WriteLine("4) Удаление элемента (по ключу)");
            Console.WriteLine("5) Добавление элемента");
            Console.WriteLine("6) Назад");
            Console.Write("Введите номер: ");
        }
        public static void PrintMenu3()
        {
            Console.WriteLine("1) Сформировать дерево");
            Console.WriteLine("2) Печать дерева");
            Console.WriteLine("3) Найти элемент с максимальной стоимостью");
            Console.WriteLine("4) Преобразовать идеально сбалансированное дерево в дерево поиска + сравнение 2 деревьев");
            Console.WriteLine("5) Удалить дерево");
            Console.WriteLine("6) Выход");

        }
        public static int InputIntNumber() // проверка на целое число
        {
            bool isCorrert;
            int number;
            do
            {
                isCorrert = int.TryParse(Console.ReadLine(), out number);
                if (!isCorrert) Console.Write("Пожалуйста, введите число: ");
            } while (!isCorrert);
            return number;
        }
        static void DrawTextProgressBar(int progress)
        {
            Console.CursorLeft = 0;
            Console.Write("["); // Начало полоски

            // Ширина полоски загрузки в символах (здесь 30 символов)
            int totalWidth = 30;
            int filledWidth = (int)(totalWidth * (progress / 100.0));

            // Заполнение полоски символами
            for (int i = 0; i < totalWidth; i++)
            {
                Console.Write(i <= filledWidth ? "=" : " "); // Заполненные и пустые символы
            }

            Console.Write($"] {progress}%"); // Процент загрузки
        }
    }
}