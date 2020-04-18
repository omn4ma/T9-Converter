using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T9Converter.Domain
{
    public class Converter
    {
        private Dictionary<char, Click> dictionary;

        public Converter(Button[] keyboard)
        {
            dictionary = keyboard
                .SelectMany(s => s.Values.Select(v => new { Symbol = Char.ToLowerInvariant(v), Key = s.Key, Count = Array.IndexOf(s.Values, v) + 1 }))
                .ToDictionary(s => s.Symbol, s => new Click(s.Key, s.Count));
        }

        public string ToT9Codes(string text)
        {
            var result = new StringBuilder();

            foreach (var symbol in text)
            {
                if (dictionary.TryGetValue(symbol, out Click action))
                {
                    for (int i = 0; i < action.Count; i++)
                    {
                        result.Append(action.Key);
                    }
                }
            }

            return result.ToString();
        }
    }

    public static class Keyboards
    {
        public static Button[] Default => new Button[] {
            new Button(0, ' '),
            new Button(1),
            new Button(2, 'A', 'B', 'C'),
            new Button(3, 'D', 'E', 'F'),
            new Button(4, 'G', 'H', 'I'),
            new Button(5, 'J', 'K', 'L'),
            new Button(6, 'M', 'N', 'O'),
            new Button(7, 'P', 'Q', 'R', 'S'),
            new Button(8, 'T', 'U', 'V'),
            new Button(9, 'W', 'X', 'Y', 'Z')
        };
    }
}
