using System;
using System.Text.RegularExpressions;
using System.Text;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<border1>[@][#]+)(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])(?<border2>[@][#]+)";
            string pattern4Group = @"\d+|\d+";
            Regex regex = new Regex(pattern);
            Regex regex2 = new Regex(pattern4Group);
            int n = int.Parse(Console.ReadLine());
            for (int i  = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                if (match.Success)
                {
                    MatchCollection match2 = regex2.Matches(match.Groups[2].Value);
                    if (match2.Count == 0)
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int j = 0; j < match2.Count; j++)
                        {
                            sb.Append(match2[j]);
                        }
                        Console.WriteLine($"Product group: {sb.ToString()}");
                        sb.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
