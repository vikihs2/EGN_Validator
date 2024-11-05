using System;

public class EGNValidator
{
    public static bool ValidateEGN(string egn)
    {
        if (egn.Length != 10 || !long.TryParse(egn, out _)) return false;

        int[] weights = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
        int sum = 0;

        for (int i = 0; i < 9; i++)
        {
            sum += (egn[i] - '0') * weights[i];
        }

        int checkDigit = sum % 11;
        if (checkDigit == 10) checkDigit = 0;

        return checkDigit == (egn[9] - '0');
    }

    public static void Main()
    {
        string egn = Console.ReadLine();

        if (ValidateEGN(egn))
            Console.WriteLine("EGN is valid.");
        else
            Console.WriteLine("EGN is invalid.");
    }
}
