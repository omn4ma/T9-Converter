namespace T9Converter.Domain
{
    internal class Click
    {
        public int ButtonNumber { get; }
        public int Count { get; }

        public Click(int number, int count)
        {
            ButtonNumber = number;
            Count = count;
        }
    }
}
