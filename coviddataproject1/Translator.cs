using System;
using System.Collections.Generic;
using System.IO;

namespace coviddataproject1
{
    internal class Translator
    {
        private string v;

        public Dictionary<string, List<string>> Dictionary { get; set; }

        public Translator(String file)
        {
            Dictionary = new Dictionary<string, List<string>>();

            string[] lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                if (line.StartsWith("geo_merge")) continue;
                string[] words = line.Split(new char[] { ',' });
                Console.Write("WORDS: " + words);
                List<string> translations;
                if (Dictionary.TryGetValue(words[0], out translations))
                {
                    translations.Add(words[1]);
                }
                else
                {
                    translations = new List<string>();
                    translations.Add(words[1]);
                    Dictionary.Add(words[0], translations);
                }
            }
        }
    }
}