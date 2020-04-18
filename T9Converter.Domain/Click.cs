namespace T9Converter.Domain
{
    internal class Click
    {
        public int Key { get; }
        public int Count { get; }

        public Click(int key, int count)
        {
            Key = key;
            Count = count;
        }
    }
}
