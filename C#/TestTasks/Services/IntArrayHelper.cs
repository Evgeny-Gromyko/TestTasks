namespace TestTasks.Services;

internal class IntArrayHelper
{
    public static IEnumerable<int> MissingElements(int[] arr)
    {
        var missingElements = new List<int>();
        var counter = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            counter = arr[i - 1] + 1;
            while (counter != arr[i])
            {
                missingElements.Add(counter);
                counter++;
            }
        }

        return missingElements;
    }
}
