using System;

public static class UserInputHandler
{
    public static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    public static string ReadString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public static double ReadDouble(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double result))
            {
                return result;
            }
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}
