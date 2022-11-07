using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Project.Core
{
    public class ParserSystem
    {
        public List<string> Parse(string path, int lenght)
        {
            string text = ReadFromFile(path);
            text = ClearText(text);
            List<string> words = SplitText(text);
            words = UniqueValidator(words);
            words = RemoveStringUnder(lenght, words);
            return words;
        }

        private string ReadFromFile(string path)
        {
            string text = System.IO.File.ReadAllText(path);
            ;
            return text;
        }

        private string ClearText(string text)
        {
            Regex rgx = new Regex("[^a-z -]");
            text = rgx.Replace(text, " ");
            rgx = new Regex("[^a-z ]");
            text = rgx.Replace(text, "");

            return text;
        }

        private List<string> SplitText(string text)
        {
            List<string> newText = text.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            return newText;
        }

        private List<string> UniqueValidator(List<string> text)
        {
            HashSet<string> newText = new HashSet<string>();
            foreach (var str in text)
            {
                newText.Add(str);
            }

            return newText.ToList();
        }

        private List<string> RemoveStringUnder(int lenght, List<string> text)
        {
            List<string> newText = new List<string>();
            foreach (var str in text)
            {
                if (str.Length >= lenght)
                {
                    newText.Add(str);
                }
            }
            
            return newText;
        }
    }
}