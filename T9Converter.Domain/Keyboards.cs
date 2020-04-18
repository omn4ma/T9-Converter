namespace T9Converter.Domain
{
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
