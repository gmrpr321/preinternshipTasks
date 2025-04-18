using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncProgrammingDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting async data fetch...");

            try
            {
                var fetchTasks = new List<Task<string>>
                {
                    FetchDataFromSourceAsync("Source A", 2000),
                    FetchDataFromSourceAsync("Source B", 1500),
                    FetchDataFromSourceAsync("Source C", 3000),
                };

                var results = await Task.WhenAll(fetchTasks);

                Console.WriteLine("\nAll data fetched successfully:");
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred: {ex.Message}");
            }

            Console.WriteLine("\nFinished.");
        }

        static async Task<string> FetchDataFromSourceAsync(string sourceName, int delayMs)
        {
            Console.WriteLine($"{sourceName}: Fetching...");
            await Task.Delay(delayMs); 
            Console.WriteLine($"{sourceName}: Done.");
            return $"{sourceName} result";
        }
    }
}
