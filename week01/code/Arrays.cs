public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Initialize an array to hold the multiples
        double[] multiples = new double[length];

        // A loop to generate the mutiples
        for (int i = 0; i < length; i++)
        {
                // Calculate the multiple and store it in the array
                multiples[i] = number * (i+1);
        }
        // Return the Array containing multiples
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Calculate the effective rotation amount
        int n = data.Count;
        int effectiveAmount = amount % n;

        // Split list into 2 parts
        List<int> part1 = data.GetRange(n - effectiveAmount, effectiveAmount);
        List<int> part2 = data.GetRange(0, n - effectiveAmount);

        // Clear OG list and combine the 2 parts to form the rotated list
        data.Clear();
        data.AddRange(part1);
        data.AddRange(part2);
    }
}
