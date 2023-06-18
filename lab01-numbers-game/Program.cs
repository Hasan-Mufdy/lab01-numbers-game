using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            StartSequence();
        }
        catch (Exception ex)
        {
            Console.WriteLine("there is an error, " + ex);
        }
        finally
        {
            Console.WriteLine("the program is completed...");
        }
    }

    //////////////////////
    public static void StartSequence()
    {
        Console.WriteLine("please enter a positive number...");
        string userInput = Console.ReadLine();
        int userInputInt = Convert.ToInt32(userInput);
        int[] intArr = new int[userInputInt];
        Populate(intArr);

        int sum = GetSum(intArr);
        int product = GetProduct(intArr, sum);
        decimal quotient = GetQuotient(product);

        Console.WriteLine("sum: " + sum);
        Console.WriteLine("product: " + product);
        Console.WriteLine("quotient: " + quotient);
    }

    public static int[] Populate(int[] arr) 
    {
        for(int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("please enter a number: " + (i+1) +"/" + arr.Length);
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }
        return arr;
    }

    public static int GetSum(int[] arr)
    {
        int sum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        if (sum < 20)
        {
            throw new Exception($"Value of {sum} is too low.");
        }

        return sum;
    }

    public static int GetProduct(int[] arr, int sum)
    {
        int product = 0;

        Console.WriteLine("please enter a random number between 1 and " + arr.Length);
        int randomNumber = Convert.ToInt32(Console.ReadLine());
        product = sum * arr[randomNumber - 1];

        return product;

    }

    public static decimal GetQuotient(int prod)
    {
        decimal quotient = 0;

        Console.WriteLine("please enter a number to divide the product by, product: " + prod);
        string inputtedNumber = Console.ReadLine();
        int inputtedNumberInt = Convert.ToInt32(inputtedNumber);
        if (inputtedNumberInt == 0)
        {
            throw new DivideByZeroException("cannot divide by zero...");
        }
        else
        {
            quotient = decimal.Divide(prod, inputtedNumberInt);

        }

        return quotient;
    }

}
