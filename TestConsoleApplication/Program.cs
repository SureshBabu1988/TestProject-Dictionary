using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            //Dictionary<int,string> MyDictionary = new Dictionary<int, string>();

            var MyDictionary = new CustomDict<int, string>(25);

            for (int i = 0; i < 5; i++)
            {
                MyDictionary.Add(i + 1, "Bunny " + (i + 1));
            }

            foreach (var bunny in MyDictionary)
            {
                Console.WriteLine("K :{0}, V:{1}", bunny.Key, bunny.Value);
            }

            //Console.WriteLine(MyDictionary.Find(10));
            Console.WriteLine(MyDictionary.ContainsKey(10));
            
            //Action<string> println = Console.WriteLine;
            //string str = "mystring";
            //string newString = str.Substring(3);
            //stringChange(str);
            //Console.WriteLine(newString);
            //Console.WriteLine(str);


            //StringBuilder strB = new StringBuilder("mystring");
            //StringBuilder newString1 = strB.("Suresh");
            //stringBuilderChange(ref strB);

            //if (strB == newString1)
            //{ println("String builders are equal"); }
            //Console.WriteLine(newString1);
            //Console.WriteLine(strB);


            Console.ReadLine();
        }

        public static void stringChange(string teststring)
        {
            teststring = "changed";
        }

        public static void stringBuilderChange(ref StringBuilder teststring)
        {
           // teststring = new StringBuilder("Hello");
            teststring.Append("changed");
        }


    }
}
