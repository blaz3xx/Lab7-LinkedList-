using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            MyLinkedList list = new MyLinkedList();
            Console.WriteLine("Порожній список створено.");
            Console.WriteLine($"Розмір: {list.Size}");
            Console.WriteLine(list.isEmpty ? "Список порожній" : "Список не порожній");
            
            
            for (long i = 1; i <= 10; i++)
            {
                list.Add(i);
            }
            list.Add(25);
            list.Add(40);
            Console.WriteLine("\nЕлементи додано.");
            Console.WriteLine($"Розмір: {list.Size}");

            
            Console.WriteLine("\nСписок:");
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }

            
            long divisor = 5;
            var firstDivisible = list.firstElementDivisible(divisor);
            Console.WriteLine($"\n\nПерше кратне {divisor}: {(firstDivisible.HasValue ? firstDivisible.ToString() : "не знайдено")}");

           
            long sumEven = list.sumOnEvenPositions();
            Console.WriteLine($"Сума елементів на парних позиціях: {sumEven}");

            
            long threshold = 8;
            var filtered = list.filterGreaterThan(threshold);
            Console.WriteLine($"\nЕлементи більші за {threshold}:");
            foreach (var item in filtered)
            {
                Console.Write($"{item} ");
            }

            
            list.removeGreaterThanAverage();
            Console.WriteLine("\n\nПісля видалення елементів, більших за середнє:");
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine(list.isEmpty ? "Список порожній" : "Список не порожній");


            Console.WriteLine($"\n\nВидалення елементу за індексом 0:");
            list.removeAtIndex(0);
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
           
            
            list.Clear();
            Console.WriteLine("\n\nСписок очищено.");
            Console.WriteLine(list.isEmpty ? "Список порожній" : "Список не порожній");
            list.Clear();
        }
    }
}
