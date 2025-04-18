using System;
using System.IO;

class Task5
{
    static void Main()
    {
        string inputFilePath = "input.txt";
        string outputFilePath = "output.txt";

        try
        {
            string[] lines = File.ReadAllLines(inputFilePath);

            int lineCount = lines.Length;
            int wordCount = 0;

            foreach (string line in lines)
            {
                wordCount += line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            }

            
            string result = $"Total Lines: {lineCount}\nTotal Words: {wordCount}";

            File.WriteAllText(outputFilePath, result);

            Console.WriteLine("Processing complete. Results written to output.txt");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The file '{inputFilePath}' was not found.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("An I/O error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}
