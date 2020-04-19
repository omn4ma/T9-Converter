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
                .SelectMany(s => s.Symbols.Select(v => new { Symbol = Char.ToLowerInvariant(v), Key = s.Number, Count = Array.IndexOf(s.Symbols, v) + 1 }))
                .ToDictionary(s => s.Symbol, s => new Click(s.Key, s.Count));
        }

        public string ToT9Codes(string text)
        {
            var result = new StringBuilder();
            int? lastButtonNumber = null;

            foreach (var symbol in text)
            {
                if (instruction.TryGetValue(symbol, out Click action))
                {
                    if (action.ButtonNumber == lastButtonNumber)
                    {
                        result.Append(delayActionCode);
                    }

                    for (int i = 0; i < action.Count; i++)
                    {
                        result.Append(action.ButtonNumber);
                    }

                    lastButtonNumber = action.ButtonNumber;
                }
            }

            return result.ToString();
        }
    }
}
