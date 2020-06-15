using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using T9Converter.Domain;

namespace T9Converter.Application
{
    class Program
    {
        static void Main()
        {
            int count = 0;
            var converter = new Converter(Keyboards.Default);

            Console.WriteLine($"Please enter text to convert it into a sequence of button presses for T9 spelling:");

            using (var inputEvent = ConsoleInput().Subscribe(s => Console.WriteLine($"Case #{count++}: {converter.ToT9Codes(s)}")))
            {
                Task.Delay(TimeSpan.FromSeconds(30)).Wait();
            }

            Console.WriteLine($"Time is up, the application will be closed.");
            Console.ReadKey();
        }

        private static IObservable<string> ConsoleInput()
        {
            return
                Observable
                    .FromAsync(() => Console.In.ReadLineAsync())
                    .Repeat()
                    .Publish()
                    .RefCount()
                    .SubscribeOn(Scheduler.Default);
        }
    }
}
