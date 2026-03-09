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

        // TODO Problem 1 Start
        // Plan:
        // 1) Created a new double array named result with size = length.
        // 2) Loop from index 0 up to length - 1.
        // 3) For each index i, compute the multiple using number * (i + 1).
        //    - i = 0 gives the first multiple: number * 1
        //    - i = 1 gives the second multiple: number * 2
        //    - etc.
        // 4) Store each computed value into result[i].
        // 5) After the loop finishes, return result.
        //
        // Example for number = 3 and length = 5:
        // i=0 -> 3*(0+1)=3
        // i=1 -> 3*(1+1)=6
        // i=2 -> 3*(2+1)=9
        // i=3 -> 3*(3+1)=12
        // i=4 -> 3*(4+1)=15
        // Returned array: {3, 6, 9, 12, 15}

        var result = new double[length];
        for (var i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
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
        // Plan for rotating a list to the right:
        // 
        // Rotating right by 'amount' means the last 'amount' elements move to the front.
        // 
        // Example: data = {1, 2, 3, 4, 5, 6, 7, 8, 9}, amount = 3
        // - Last 3 elements: {7, 8, 9}
        // - Remaining elements: {1, 2, 3, 4, 5, 6}
        // - Result: {7, 8, 9, 1, 2, 3, 4, 5, 6}
        //
        // Steps:
        // 1) Calculate the split position: splitIndex = data.Count - amount
        //    - This tells us where to split the list
        //    - Elements from splitIndex to end move to front
        //    - Elements from 0 to splitIndex-1 move to back
        //
        // 2) Extract the last 'amount' elements (the part that rotates to front):
        //    - Use GetRange(splitIndex, amount) to get elements starting at splitIndex
        //    - Store this in a temporary variable (e.g., rotatedPart)
        //
        // 3) Remove those elements from the original list:
        //    - Use RemoveRange(splitIndex, amount) to remove the last 'amount' elements
        //    - Now the list only contains the first part
        //
        // 4) Insert the rotated part at the beginning:
        //    - Use InsertRange(0, rotatedPart) to insert at index 0
        //    - This puts the last elements at the front
        //
        // 5) The list is now modified in place with the rotation complete.
        //
        // Example walkthrough with {1, 2, 3, 4, 5, 6, 7, 8, 9} and amount = 3:
        // - splitIndex = 9 - 3 = 6
        // - rotatedPart = GetRange(6, 3) = {7, 8, 9}
        // - After RemoveRange(6, 3): data = {1, 2, 3, 4, 5, 6}
        // - After InsertRange(0, {7, 8, 9}): data = {7, 8, 9, 1, 2, 3, 4, 5, 6} ✓

        var splitIndex = data.Count - amount;
        var rotatedPart = data.GetRange(splitIndex, amount);
        data.RemoveRange(splitIndex, amount);
        data.InsertRange(0, rotatedPart);
    }
}
