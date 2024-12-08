using System.Diagnostics;
using aoc_2024.Helpers;

namespace aoc_2024.Solutions;

public static class Day02
{
    public static int Part1()
    {
        List<int[]> list = FileHelper.HelperDay02();
        int checksum = 0;
        
        foreach (var item in list)
        {
            var result = IsSafe(item);
            checksum += result ? 1 : 0;
        }

        return checksum;
    }

    public static int Part2()
    {
        List<int[]> list = FileHelper.HelperDay02();
        int checksum = 0;
        
        foreach (var item in list)
        {
            var result = IsSafe(item, true);
            checksum += result ? 1 : 0;
        }

        return checksum;
    }

    private static bool IsSafe(int[] numbers, bool problemDampener = false)
    {
        // if the list is empty or has only one element -> safe
        if (numbers.Length <= 1) return true;

        bool result = true;
        bool dampenOnce = problemDampener;
        
        string initialTrajectory = GetTrajectory(numbers[0], numbers[1]);
        
        for (var i = 0; i < numbers.Length; i++)
        {
            // at the end of the list -> safe
            if (i + 1 == numbers.Length) return true;
            
            var current = numbers[i];
            var next = numbers[i + 1];
            
            // if the trajectory changes -> unsafe
            if (initialTrajectory != GetTrajectory(current, next)) result = false;

            // if difference between numbers isn't either 1,2,3 -> unsafe 
            if (GetDifference(current, next)) result = false;
            
            // allow dampening the result once
            if (dampenOnce && !result)
            {
                result = dampenOnce;
                dampenOnce = false;
            }
            
            // only return the result immediately if a list is unsafe
            if (!result) return result;
        }

        return true;
    }
    
    private static string GetTrajectory(int number1, int number2) 
        =>  number1 < number2 ? "increase" : "decrease";
    
    
    private static bool GetDifference(int number1, int number2) 
        => Math.Abs(number1 - number2) < 1 || Math.Abs(number1 - number2) > 3;
}