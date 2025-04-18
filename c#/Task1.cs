using System;
namespace std{
class Task1{
    static void Main()
    {
        Console.WriteLine("Enter a number : ");
        string input = Console.ReadLine();
        int number;
        while(!int.TryParse(input,out number) || number <0)
        {
            Console.WriteLine("Invalid Input ");
            input = Console.ReadLine();
        }
        long result = CalculateFactorial(number);
        Console.WriteLine($"Factorial of {number} is :{result}");
    }
    static long CalculateFactorial(int num)
    {
        long result = 1;
        for(int i = 2;i<=num;i++)
        {
            result *=i;
        }
        return result;
    }
}}