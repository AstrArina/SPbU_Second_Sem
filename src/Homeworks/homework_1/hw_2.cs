using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
#pragma warning disable  CS8602
 
namespace BW
{
    class Program2
    {      
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
            System.Console.Write("Input the tranform string: ");
            string? InputString = Console.ReadLine();
            System.Console.Write("Input the end of the string number: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Original string: {0}", Reborn(InputString)[n-1]);
        }
    }
}