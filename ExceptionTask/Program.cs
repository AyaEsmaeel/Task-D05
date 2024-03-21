using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExceptionTask
{
    internal class Program
    {
        public static bool Search(int Number, List<int> List)
        {
            for (int j = 0; j < List.Count; j++)
            {
                if (List[j] == Number)
                {
                    return true;
                }
            }
            return false;
        }
        public static void ValidateVowels(string text)
        {
            string vowels = "aeiouAEIOU";

            bool hasVowel = false;
            foreach (char letter in text)
            {
                if (vowels.IndexOf(letter) != -1)  //-1 (not found)
                {
                    hasVowel = true;
                    break; 
                }
            }
            if (!hasVowel)                          //false
            {
                throw new ArgumentException("String does not contain any vowels!");
            }
            else if (hasVowel)
            {
                Console.WriteLine($"Text[{text}] : does Contain Vowels");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("<==========Programs==========>");
            Console.WriteLine("1 - reads a list of integers from the user and throws an exception if any numbers are duplicates");
            Console.WriteLine("2 - create a method that takes a string as input and throws an exception if the string does not contain vowels");
            Console.Write("Enter your Option: ");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        List<int> list = new List<int>();
                        Console.Write("how many Numbers that you want to add?: ");
                        int num = int.Parse(Console.ReadLine());
                        for (int i = 0; i < num; i++)
                        {
                            Console.Write($"Enter num{i + 1}: ");
                            int Num = int.Parse(Console.ReadLine());
                            if (Search(Num, list))
                            {
                                throw new ArgumentException("Duplicate number found!");
                            }
                            list.Add(Num);
                        }
                        break;
                    }
                case 2:
                    {
                        List<string> STR = new List<string>();

                        Console.WriteLine("<===checkVowels=======>");
                        Console.Write("what is the string that you check it?: ");
                        string str = Console.ReadLine();
                        ValidateVowels(str);
                        break;
                    }
            }
        }
    }
}
   