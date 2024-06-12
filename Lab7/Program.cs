using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Linq;
namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            bai1();
            
        }

        static void bai1()
        {
            Console.WriteLine("Bai 1: ");

            Console.WriteLine("A)");
            List<int> nums = new List<int>() { 1, 3, 4, 5, 8, 9 };
            string a = string.Join(", ", nums.Where(x => x > 4).Select(x => x * x));
            Console.WriteLine($"Binh phuong cac so lon hon 4 la: \n{a}");

            Console.WriteLine("B)");
            string str = "chao mung den voi binh nguyen vo tan";
            var characterCount = str
                                 .Where(c => !char.IsWhiteSpace(c))
                                 .GroupBy(c => c)
                                 .Select(g => new { Character = g.Key, Count = g.Count() })
                                 .ToList();
            Console.WriteLine("Số lần xuất hiện của từng chữ:");
            foreach (var item in characterCount)
            {
                Console.WriteLine($"'{item.Character}': {item.Count}");
            }

            Console.WriteLine("C)");
            string str2 = "CHAO mung DEN Voi binh nguyen vo tan";
            var result = str2
                            .Split(" ")
                            .Where(word => word.Equals(word.ToUpper()))
                            .ToList();
            Console.WriteLine("Cac chu viet hoa toan bo:");
            Console.WriteLine(string.Join(", ", result));
        }
    }
}

        

