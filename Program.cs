using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using System;
using System.Text.Unicode;

namespace Digital_Design;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\Users\User\Desktop\Digital Design\tolstoj.txt";
        string outPath =  @"C:\Users\User\Desktop\Digital Design\output.txt";
        

        List<string> lines = new List<string>();
        lines = File.ReadAllLines(filePath).ToList();

        Dictionary<string,int> counts = new Dictionary<string,int>();
        foreach (string line in lines)
        {
            string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words){
                string sl = word.ToLower();
                sl = sl.Replace(".", "");
                sl = sl.Replace(",", "");
                sl = sl.Replace(":", "");
                sl = sl.Replace("\"", "");
                sl = sl.Replace("-", "");
                sl = sl.Replace("!", "");
                sl = sl.Replace("?", "");
                sl = sl.Replace(")", "");
                sl = sl.Replace("(", "");

                if (counts.ContainsKey(sl))
                {
                    counts[sl]++;
                }
                else
                {
                    counts.Add(sl, 1);
                }
            }
        }
        counts.Remove("");
        var items = from pair in counts
                orderby pair.Value descending
                select pair;
        TextWriter tw = new StreamWriter(outPath,false,Encoding.UTF8);
        foreach (KeyValuePair<string, int> pair in items) {
            tw.WriteLine("{0}    {1}", pair.Key, pair.Value);
        }
        
        Console.WriteLine("Файл записан");        
        Console.ReadKey();
    }
}
