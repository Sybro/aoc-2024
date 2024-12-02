namespace aoc_2024.Helpers;

public static class FileHelper
{
    public static (List<int> list1, List<int> list2) LoadNumbers()
    {
        const string filePath = "../../../Inputs/day01_lists.txt";
        var list1 = new List<int>();
        var list2 = new List<int>();

        // retrieve numbers from each row, and split them into two lists
        foreach (var line in File.ReadLines(filePath))
        {
            var numbers = line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries);
            
            if (numbers.Length == 2)
            {
                list1.Add(int.Parse(numbers[0]));
                list2.Add(int.Parse(numbers[1]));
            }
        }
        
        if (list1.Count != list2.Count)
        {
            throw new Exception("Lists must be the same length");
        }

        // sort lists (necessary for Day1A)
        list1 = list1.OrderBy(x => x).ToList();
        list2 = list2.OrderBy(x => x).ToList();
        
        return (list1, list2);
    }
}