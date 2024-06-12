using System.Text;

namespace lab6
{
    class Program
    {
        static List<int> listInt = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 10 };
        static List<string> listStr = new List<string>() { null, "T1", "T2", "T3", null };
        static List<string> listNull = new List<string>();
        static void Main()
        {
            bai1();
            bai2();
            bai3();
        }

        static void bai1()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Bai 1: ");
            Console.WriteLine("A) ");
            int result = listInt.FirstOrDefault(i => i % 2 == 0 && i > 5);
            if (result > 5)
                Console.WriteLine($"So chan dau tien lon hon 5 trong listInt: {result}");
            else
                Console.WriteLine($"So chan dau tien lon hon 5 trong listInt khong ton tai");

            Console.WriteLine("B) ");
            int result2 = listInt.LastOrDefault(i => i > 200);
            if (result2 > 200)
                Console.WriteLine($"So cuoi cung lon ho 200 trong listInt: {result2}");
            else
                Console.WriteLine($"So cuoi cung lon ho 200 trong listInt khong ton tai");

            Console.WriteLine("C) ");
            string result3 = listStr.FirstOrDefault(u => u != null && u.StartsWith("T"));
            if (result3.StartsWith("T"))
                Console.WriteLine($"Pt dau tien bat dau bang \"T\" la: {result3}");
            else
                Console.WriteLine($"Pt dau tien bat dau bang \"T\" khong ton tai");

            Console.WriteLine("D) ");
            int result4 = listInt.Where((value, index) => index % 2 != 0 && value % 2 == 0).Sum();
            Console.WriteLine($"Tong cac pt vi tri le gia tri chan la: {result4}");
        }

        static void bai2()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\nBai 2: ");
            List<Shop> shops = new List<Shop>(){
            new Shop(1, "Hcm", "o dau cung dc"),
            new Shop(2, "Da nang", "asdwadawd"),
            new Shop(3, "HAnoi", "dadwadawd")
        };

            List<Phone> phones = new List<Phone>(){
            new Phone(1, 1, "IP 15", 19999, "Ip 15 co ch play"),
            new Phone(2, 1, "IP 16", 24999, "Ip 16 co ch play"),
            new Phone(3, 2, "IP 20", 99999, "IP 20 den tu tuong lai"),
            new Phone(4, 3, "IP 99", 999999, "IP 99 den tu giac mo")
        };

            Console.WriteLine("A) su dung LINQ Querry Syntax ");
            var query = from shop in shops
                        join phone in phones on shop.id equals phone.shop_id
                        select new { ShopName = shop.name, PhoneName = phone.name };

            foreach (var result in query)
                Console.WriteLine($"ShopName: {result.ShopName}, PhoneName: {result.PhoneName}");

            Console.WriteLine("B) su dung LINQ Method Syntax ");
            var query2 = shops
                        .GroupJoin(phones, shop => shop.id, phone => phone.shop_id, (shop, shopPhones) => new { Shop = shop, Phones = shopPhones });

            foreach (var result in query2)
            {
                Console.WriteLine($"ShopName: {result.Shop.name}");
                Console.WriteLine("-------------");
                foreach (var phone in result.Phones)
                {
                    Console.WriteLine($"PhoneName: {phone.name}");
                    Console.WriteLine($"Price: {phone.price}");
                }
                Console.WriteLine();
            }
            // var query = from shop in shops
            //             join phone in phones on shop.id equals phone.shop_id into shopPhones
            //             select new { ShopName = shop.name, Phones = shopPhones };
        }

        static void bai3()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\nBai 3: ");
            Console.WriteLine("A) ");
            List<int> listInt2 = new List<int>() { 2, 4, 5, 8, 9 };
            List<int> a = listInt
                                   .Union(listInt2)
                                   .OrderByDescending(x => x)
                                   .ToList();
            Console.WriteLine("Hợp nhất Union và sắp xếp giảm dần:");
            Console.WriteLine(string.Join(", ", a));

            Console.WriteLine("B) ");
            List<int> b = listInt
                            .Intersect(listInt2)
                            .ToList();
            Console.WriteLine("Su dung Intersect:");
            Console.WriteLine(string.Join(", ", b));

            Console.WriteLine("C) ");
            List<int> c = listInt
                            .Concat(listInt2)
                            .OrderBy(x => x)
                            .ToList();
            Console.WriteLine("Su dung Concat:");
            Console.WriteLine(string.Join(", ", c));

            Console.WriteLine("D) ");
            List<int> d = listInt
                            .Except(listInt2)
                            .ToList();
            Console.WriteLine("Su dung Except:");
            Console.WriteLine(string.Join(", ", d));
        }
    }

    class Phone
    {
        public int id { get; set; }
        public int shop_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string des { get; set; }

        public Phone(int id, int shop_id, string name, int price, string des)
        {
            this.id = id;
            this.shop_id = shop_id;
            this.name = name;
            this.price = price;
            this.des = des;
        }
    }

    class Shop
    {
        public int id { get; set; }
        public string name { get; set; }
        public string adress { get; set; }

        public Shop(int id, string name, string adress)
        {
            this.id = id;
            this.name = name;
            this.adress = adress;
        }
    }


}
