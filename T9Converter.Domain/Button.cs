namespace T9Converter.Domain
{
    public class Button
    {
        public int Key { get; }
        public char[] Values { get; }

        public Button(int key, params char[] values)
        {
            Key = key;
            Values = values;
        }
    }
}
