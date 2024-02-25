using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
#pragma warning disable CS8602

namespace BW
{
    class Program1
    {   
        public static string[] Transpositions(string? Str1) {
            string[] Transposition = new string[Str1.Length];
            Transposition[0] = Str1;
            for (int i = 0; i < Transposition.Length-1; i++) {
                Transposition[i+1] = Transposition[i].Substring(1) + Transposition[i].Substring(0, 1);
            }
            return Transposition;
        }     
        public static string LastColumn(string[] Str2) {
            string Result = string.Empty;  
            for (int i = 0; i < Str2.Length; i++) {
                Result = Result + Str2[i].Substring(Str2.Length-1);
            }   
            return Result; 
        }
        public static string[] Reborn (string? Str1) {
            string[] AddString = new string[Str1.Length];
            for (int j = 0; j < Str1.Length; j++) {
                for (int i = 0; i < Str1.Length; i++) {
                    AddString[i] = Str1.Substring(i,1) + AddString[i];
                }
                Array.Sort(AddString);
            }
            return AddString;
        }
        static void Main(string[] args) 
        { 
            System.Console.WriteLine("If you want a direct conversation, input 1, otherwise 2");
            string? chose = Console.ReadLine();
            if (chose == "1") {
                System.Console.Write("Input the string: ");
                string? InputString = Console.ReadLine();
                string[] Strings2 = Transpositions(InputString);
                Array.Sort(Strings2);
                Console.WriteLine("B-W transform: {0}, {1}", LastColumn(Strings2), Array.BinarySearch(Strings2, InputString)+1);
            }
            else if (chose == "2") {
                System.Console.Write("Input the tranform string: ");
                string? InputString = Console.ReadLine();
                System.Console.Write("Input the end of the string number: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Original string: {0}", Reborn(InputString)[n-1]);
            }
            Console.ReadKey(); 
        }
    }
}