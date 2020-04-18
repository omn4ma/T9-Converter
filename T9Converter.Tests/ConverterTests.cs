using T9Converter.Domain;
using Xunit;

namespace T9Converter.Tests
{
    public class ConverterTests
    {
        [Theory]
        [InlineData("yes", "999337777")]
        public void Convert_ToT9String_CompareResult(string text, string t9codes)
        {
            var converter = GetConverter();

            var result = converter.ToT9Codes(text);

            Assert.Equal(t9codes, result);
        }

        private Converter GetConverter()
        {
            return new Converter(Keyboards.Default);
        }
    }
}
