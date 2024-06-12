using System.Text;

namespace Lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<int>  listInt = new List<int>() { 2,4,5,6,7,8,9  };
            List<string> listStr = new List<string>() {null , "T1", "T2", "T3", null };
            List<string> listNull = new List<string>();
            Console.WriteLine("Bài 1: ");
            Console.WriteLine("--------------------");
            Console.WriteLine("Câu 1: Tìm số chẵn đầu tiên và lớn hơ 5 trong litsInt");
            var evenGreaterThanFive = listInt.FirstOrDefault(x => x %2 == 0 && x > 5);
            Console.WriteLine(evenGreaterThanFive != 0 ? evenGreaterThanFive.ToString() : "Không có phần tử nào thoả mãn điều kiện");
            Console.WriteLine("--------------------");
            Console.WriteLine("Câu 2: Tìm phần tử cuối cùng trong litsInt có giá trị > 200");
            var lastGreaterThan200 = listInt.LastOrDefault(x => x > 200);
            Console.WriteLine("Phần tử cuối cùng trong listInt có giá trị > 200 là : ");
            Console.WriteLine(lastGreaterThan200 != 0 ? lastGreaterThan200.ToString() : "Không có phầ tử nào thoả mãn điều kiện");
            var firstStartsWithT = listStr.FirstOrDefault(x => x != null && x.StartsWith("T"));
            Console.WriteLine("--------------------");
            Console.WriteLine("Câu 3: Tìm phần tử đầu tiên trong listStr có giá trị bắt đầu bằng ký tự 'T'");
            Console.WriteLine(firstStartsWithT ?? "Không có phần tử nào thỏa mãn điều kiện");
            var sumOddIndexDivisibleBy2 = listInt.Where((x, index) => index % 2 != 0 && x % 2 == 0).Sum();
            Console.WriteLine("--------------------");
            Console.WriteLine("Câu 4: Tính tổng các trị tại vị trí index lẻ và số đó chia hết cho 2 trong listInt");
            Console.WriteLine(sumOddIndexDivisibleBy2);
        }
    }
}
