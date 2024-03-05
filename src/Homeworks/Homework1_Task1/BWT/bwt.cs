namespace Alg;
using System.Text;
public static class BWT{
    public static (string, int) Direct(string text) {
        if (text == null || text == "") {
            throw new ArgumentException("NULL", text);
        } 
        string[] Transposition = new string[text.Length];
        Transposition[0] = text;
         for (int i = 0; i < text.Length-1; i++) {
            Transposition[i+1] = Transposition[i].Substring(1) + Transposition[i].Substring(0, 1);
        }
        Array.Sort(Transposition);
        string String2 = string.Empty;  
        for (int i = 0; i < Transposition.Length; i++) {
            String2 = String2 + Transposition[i].Substring(Transposition.Length-1);
        }    
        int n = Array.BinarySearch(Transposition, text);
        return (String2, n);
    }
    public static string Inverse(string bwtstring, int index) {
        if (bwtstring == null || bwtstring == "") {
            throw new ArgumentException("NULL", bwtstring);
        } 
            string[] AddString = new string[bwtstring.Length];
            for (int j = 0; j < bwtstring.Length; j++) {
                for (int i = 0; i < bwtstring.Length; i++) {
                    AddString[i] = bwtstring.Substring(i,1) + AddString[i];
                }
                Array.Sort(AddString);
            }
            return AddString[index-1];
    }
}