using System;
using System.Collections.Generic;
using System.Linq;

class WordCountTool
{
    static void Main(string[] args)
    {
        string text = "Este es un ejemplo de texto para contar palabras. Este texto tiene palabras repetidas.";
        Dictionary<string, int> wordCount = CountWords(text);

        foreach (var word in wordCount)
        {
            Console.WriteLine($"{word.Key}: {word.Value}");
        }
    }

    static Dictionary<string, int> CountWords(string text)
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        string[] words = text.Split(new char[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            string lowerWord = word.ToLower();
            if (wordCount.ContainsKey(lowerWord))
            {
                wordCount[lowerWord]++;
            }
            else
            {
                wordCount[lowerWord] = 1;
            }
        }

        return wordCount;
    }

    static Dictionary<string, int> CountWordsWithLinq(string text)
    {
        var words = text.Split(new char[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(word => word.ToLower());

        var wordCount = words.GroupBy(word => word)
                             .ToDictionary(group => group.Key, group => group.Count());

        return wordCount;
    }
}