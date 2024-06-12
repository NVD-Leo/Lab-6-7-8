using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace lab5
{
    public class UserAccountlab5 {
        public string name;
        public int rank;
        public float winRate;
        public string type;
        public int skin;
        public UserAccountlab5(string _name, int _rank, float _winRate, string _type, int _skin)
        {
            name = _name;
            rank = _rank;
            winRate = _winRate;
            type = _type;   
            skin = _skin;
        }
        public override string ToString()
        {
            return $"Name: {name}, Rank: {rank}, WinRate: {winRate}, Type: {type}, Skin: {skin}";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding= Encoding.UTF8;
            List<UserAccountlab5>list = new List<UserAccountlab5>();
            list.Add(new UserAccountlab5("Sơn Tùng", 10, 55.5f,"Ca nhạc", 50));
            list.Add(new UserAccountlab5("Đen vâu", 5, 70f, "Ca nhạc", 10));
            list.Add(new UserAccountlab5("Thuy linh",15,45.5f,"Ca nhạc",25));
            list.Add(new UserAccountlab5("Độ Mixi",1,90f,"All",2));
            list.Add(new UserAccountlab5("Bà Tuyết Diamond",3,60.5f,"Thực Phẩm",10));
            list.Add(new UserAccountlab5("Pew pew",4,55.5f,"Live",50));
            list.Add(new UserAccountlab5("Liên Minh",2,85.5f,"Game",255));
            list.Add(new UserAccountlab5("Liên Quân",11,55.5f,"Game",200));
            list.Add(new UserAccountlab5("Fifa4",7,55.5f,"Game",150));
            list.Add(new UserAccountlab5("CSO",8,55.5f,"Game",1000));
            list.Add(new UserAccountlab5("CSGO",6,85.5f,"Game",500));
            Console.WriteLine("Bài 1:");
            Console.WriteLine("------------------------");
            Console.WriteLine("Câu 1: Xuất dữ liệu ra màn hình");
            foreach( var user in list)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Câu 2: Sắp xếp danh sác UserAccount theo Rank giảm dần");
            var sortedByrank = list.OrderByDescending(user => user.rank).ToList();
            Console.WriteLine("Danh sách UserAccount sắp xếp theo Rank giảm dần");
            foreach ( var user in sortedByrank)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Câu 3: Sắp xếp danh sách UserAccount theo Name và Skin giảm dần");
            var sortedBynameAndskin = list.OrderByDescending(user => user.name).ThenByDescending(user => user.skin).ToList();
            Console.WriteLine("Danh sách UserAccount theo Name và Skin giảm dần");
            foreach ( var user in sortedBynameAndskin)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Câu 4: Liệt kê danh sách các người có Name bắt đầu băng ký tự B");
            var userwithB = list.Where(user => user.name.StartsWith("B")).ToList();
            Console.WriteLine("Danh sách các người có Name bắt đầu bằng ký tự B ");
            foreach (var user in userwithB)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Bài 2: ");
            Console.WriteLine("------------------------");
            Console.WriteLine("Câu 1: Xuất ra màn hình danh sách người chơi có Winrate > 50");

            var winrateAbove50 = list.Where(user => user.winRate>50).ToList();
            Console.WriteLine("Dánh sách người chơi có Winrate > 50");
            foreach (var user in winrateAbove50)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Câu 2 : Tìm người có Winrate cao nhất");
            var HightWinrate = list.OrderByDescending(user => user.winRate).FirstOrDefault();
            Console.WriteLine("Người có Winrate cao nhất là: ");
            if ( HightWinrate != null ) 
            {
                Console.WriteLine(HightWinrate);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Câu 3: Cho biết danh sách UserAccount có bao nhiêu tài khoản");
            int userCount = list.Count();
            Console.WriteLine($"Số lượng tài khoản có trong UserAccout là : {userCount}");
            Console.WriteLine("------------------------");
            Console.WriteLine("Bài 3: Dùng LINQ ToLookup() chuyển danh sách List< UserAccount > về định dạng kiểu key/Count theo “Type” và xuất toàn bộ thông tin ra màn hình");
            var lookupByType = list.ToLookup(user => user.type);
            Console.WriteLine("Dánh sách UserAccount theo Type");
            foreach (var group in lookupByType)
            {
                Console.WriteLine($"Type : {group.Key}, Count : {group.Count()}");
                foreach (var user in group)
                {
                    Console.WriteLine(user);
                }
            }
     

        }
    }
    
}
