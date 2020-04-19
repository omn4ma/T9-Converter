namespace T9Converter.Domain
{
    public class Button
    {
        public int Number { get; }
        public char[] Symbols { get; }

        public Button(int number, params char[] symbols)
        {
            Number = number;
            Symbols = symbols;
        }
    }
}
