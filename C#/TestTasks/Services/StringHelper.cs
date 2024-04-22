namespace TestTasks.Services;

public static class StringHelper
{
    public static string ReverseString(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return str;
        }

        char[] charArray = str.ToCharArray();

        int left = 0;
        int right = charArray.Length - 1;
        char temp;

        while (left < right)
        {
            temp = charArray[left];
            charArray[left] = charArray[right];
            charArray[right] = temp;

            left++;
            right--;
        }

        return new string(charArray);
    }

    public static bool IsPalindromeСaseSensitive(string str)
    {
        return str.SequenceEqual(ReverseString(str));
    }

    public static bool IsPalindrome(string str)
    {
        return str.ToLower().SequenceEqual(ReverseString(str.ToLower()));
    }
}
