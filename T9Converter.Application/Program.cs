using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using T9Converter.Domain;

namespace T9Converter.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            var converter = new Converter(Keyboards.Default);

            Console.WriteLine($"Please enter text to convert it into a sequence of button presses for T9 spelling (or empty string to exit):");

            using (var subsctiption = ConsoleInput()
                .Subscribe(s => Console.WriteLine($"Case #{count++}: {converter.ToT9Codes(s)}")))
            {
                Thread.Sleep(TimeSpan.FromSeconds(30));
            }

            Console.WriteLine($"Time is up, the application will be closed.");
            Console.ReadLine();
        }

        private static IObservable<string> ConsoleInput()
        {
            return
                Observable
                    .FromAsync(() => Console.In.ReadLineAsync())
                    .Repeat()
                    .Publish()
                    .SubscribeOn(Scheduler.Default);
        }
    }
}
