using aoc_2024.Helpers;

namespace aoc_2024.Solutions;

public static class Day01
{
    public static int Part1()
    {
        var (list1, list2) = FileHelper.HelperDay01();
        
        var distance = 0;

        for (var i = 0; i < list1.Count; i++)
        {
            // add the difference between the two items
            distance += Math.Abs(list1[i] - list2[i]);
        }
        
        return distance;
        
        // return list1.Select((t, i) => Math.Abs(t - list2[i])).Sum(); LINQ alternative
    }
    
    public static int Part2()
    {
        var (list1, list2) = FileHelper.HelperDay01();
        
        var similarity = 0;
        
        foreach (var item in list1.ToList())
        {
            // count occurrences in the second list
            var amount = list2.Count(x => x.Equals(item));
            
            // add the similarity score
            similarity += item * amount;
        }
        
        return similarity;
        
        // return (from item in list1.ToList() let amount = list2.Count(x => x.Equals(item)) select item * amount).Sum(); LINQ alternative
    }
}