using System;
using T9Converter.Domain;

namespace T9Converter.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            String text;
            int count = 0;
            var converter = new Converter(Keyboards.Default);

            Console.WriteLine($"Please enter text to convert it into a sequence of button presses for T9 spelling (or empty string to exit):");

            do
            {
                text = Console.ReadLine();
                var t9codes = converter.ToT9Codes(text);

                if (!String.IsNullOrEmpty(t9codes))
                {
                    count++;
                    Console.WriteLine($"Case #{count}: {t9codes}");
                }

            } while (text != String.Empty);

            Console.WriteLine($"Closing");
        }
    }
}
