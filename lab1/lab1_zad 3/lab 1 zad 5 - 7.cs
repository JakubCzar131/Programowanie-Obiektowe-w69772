using System;
static void Task5()
{
    int[] skipNumbers = { 2, 6, 9, 15, 19 };
    for (int num = 20; num >= 0; num--)
    {
        if (skipNumbers.Contains(num)) continue;
        else Console.WriteLine(num);
    }
}
Task5();