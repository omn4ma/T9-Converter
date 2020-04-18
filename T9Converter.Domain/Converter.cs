using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T9Converter.Domain
{
    public class Converter
    {
        private Dictionary<char, Click> instruction;
        private string delayActionCode => " ";

        public Converter(Button[] keyboard)
        {
            instruction = keyboard
                .SelectMany(s => s.Values.Select(v => new { Symbol = Char.ToLowerInvariant(v), Key = s.Key, Count = Array.IndexOf(s.Values, v) + 1 }))
                .ToDictionary(s => s.Symbol, s => new Click(s.Key, s.Count));
        }

        public string ToT9Codes(string text)
        {
            var result = new StringBuilder();
            int? lastKey = null;

            foreach (var symbol in text)
            {
                if (instruction.TryGetValue(symbol, out Click action))
                {
                    if (action.Key == lastKey)
                    {
                        result.Append(delayActionCode);
                    }

                    for (int i = 0; i < action.Count; i++)
                    {
                        result.Append(action.Key);
                    }

                    lastKey = action.Key;
                }
            }

            return result.ToString();
        }
    }
}
