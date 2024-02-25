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
        static void Main(string[] args) 
        { 
            System.Console.Write("Input the string: ");
            string? InputString = Console.ReadLine();
            string[] Strings2 = Transpositions(InputString);
            Array.Sort(Strings2);
            Console.WriteLine("B-W transform: {0}, {1}", LastColumn(Strings2), Array.BinarySearch(Strings2, InputString)+1);
            Console.ReadKey(); 
        }
    }
}