using System.Diagnostics;
using System.Text.RegularExpressions;
using aoc_2024.Helpers;

namespace aoc_2024.Solutions;

public static class Day03
{
    public static int Part1()
    {
        var lines = FileHelper.HelperDay03();
        var matches = GetNumberMatches(lines);
        var result = 0;
        
        foreach (var (x, y) in matches)
        {
            result += x * y;
        }
        
        return result;
    }

    public static int Part2()
    {
        var lines = FileHelper.HelperDay03();
        var operations = GetMatchesWithOperations(lines);
        var result = 0;
        var enabled = true;

        foreach (var item in operations)
        {
            enabled = item switch
            {
                "do()" => true,
                "don't()" => false,
                _ => enabled
            };

            if (enabled && item.Contains("mul"))
            {
                var x = item.Split("(")[1];
                x = x.Split(",")[0];
                var y = item.Split(",")[1];
                y = y.Split(")")[0];

                result += int.Parse(x) * int.Parse(y);
            }
        }
        
        return result;
    }
    

    private static List<(int, int)> GetNumberMatches(string[] lines)
    {
        var pattern = @"mul\((\d+),(\d+)\)";
        var regex = new Regex(pattern);
        var matches = new List<(int, int)>();

        foreach (var line in lines)
        {
            var matchCollection = regex.Matches(line);
            foreach (Match match in matchCollection)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                matches.Add((x, y));
            }
        }

        return matches;
    }
    
    private static List<string> GetMatchesWithOperations(string[] lines)
    {
        var pattern = @"mul\((\d+),(\d+)\)|do\(\)|don't\(\)";
        var regex = new Regex(pattern);
        var matches = new List<string>();

        foreach (var line in lines)
        {
            var matchCollection = regex.Matches(line);
            foreach (Match match in matchCollection)
            {
                if (match.Value.StartsWith("mul"))
                {
                    int x = int.Parse(match.Groups[1].Value);
                    int y = int.Parse(match.Groups[2].Value);
                    matches.Add($"mul({x},{y})");
                }
                else
                {
                    matches.Add(match.Value);
                }
            }
        }

        return matches;
    }
}