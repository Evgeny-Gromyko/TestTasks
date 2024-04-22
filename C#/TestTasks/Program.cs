using System.Text.Json;
using TestTasks.Entities;
using TestTasks.Services;

// task 1: create classes

// task 2
var instances = InstanceService.GetInstances<Vehicle>();

PrintObjects(instances);
PrintSeparator();

// task 3
var result = await SaveObjectsToGoogleDriveAsync(instances);
Console.WriteLine(result);
PrintSeparator();

PrintVehicleTypeNames();
PrintSeparator();

SearchVehicleTypes();
PrintSeparator();

// task 4
PrintStringHelperExecutionResults();
PrintSeparator();

PrintIntArrayHelperExecutionResults();
PrintSeparator();

async Task<string> SaveObjectsToGoogleDriveAsync(IEnumerable<Vehicle> instances)
{
    var jsonData = JsonSerializer.Serialize(instances);

    return await GoogleDriveService.UploadJsonTextAsFile(jsonData);
}

void PrintObjects(IEnumerable<Vehicle> instances)
{
    Console.WriteLine("Vehicle objects: \n");
    foreach (var instance in instances)
    {
        var vehicleInfo = "model: " + instance.Model + "\n" +
                          "MaxSpeed: " + instance.MaxSpeed + "\n";

        Console.WriteLine(vehicleInfo);
    }
}

void PrintVehicleTypeNames()
{
    var sortedTypes = VehicleService.GetVehicleTypesSortedByModel();

    Console.WriteLine("Vehicle Types:");
    foreach (var type in sortedTypes)
    {
        Console.WriteLine(type.Name);
    }
    Console.WriteLine();
}

void SearchVehicleTypes()
{
    while (true)
    {
        Console.WriteLine("Enter the name of the vehicle to search for it or type \"###\" to exit");
        var text = Console.ReadLine();

        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("The should cannot be empty or consist only of spaces.");
            continue;
        }
        if (text == "###")
        {
            break;
        }

        var searchResults = VehicleService.SearchVehicleTypes(text);
        if (searchResults.Any())
        {
            Console.WriteLine("Search results:");
            foreach (var type in searchResults)
            {
                Console.WriteLine(type.Name);
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No matching vehicle types found." + "\n");
        }
    }
}

void PrintStringHelperExecutionResults()
{
    var strToReverse = "dlrow olleH";
    Console.WriteLine($"Reversing of stirng \"{strToReverse}\": " + StringHelper.ReverseString(strToReverse) + "\n");

    var str1 = "abccba";
    var str2 = "abcdcba";
    var str3 = "AbCcBa";

    Console.WriteLine($"Palindrome check of stirng \"{str1}\": " + StringHelper.IsPalindrome(str1));
    Console.WriteLine($"Palindrome check of stirng \"{str2}\": " + StringHelper.IsPalindrome(str2));
    Console.WriteLine($"Palindrome check of stirng \"{str3}\": " + StringHelper.IsPalindrome(str3) + "\n");

    Console.WriteLine($"Сase sensitive palindrome check of stirng \"{str1}\": " + StringHelper.IsPalindromeСaseSensitive(str1));
    Console.WriteLine($"Сase sensitive palindrome check of stirng \"{str2}\": " + StringHelper.IsPalindromeСaseSensitive(str2));
    Console.WriteLine($"Сase sensitive palindrome check of stirng \"{str3}\": " + StringHelper.IsPalindromeСaseSensitive(str3) + "\n");
}

void PrintIntArrayHelperExecutionResults()
{
    var arr1 = new int[] { 4, 6, 9 };
    var arr2 = new int[] { 2, 3, 4 };
    var arr3 = new int[] { 1, 3, 4 };

    Console.WriteLine($"Missing elements check of array [{string.Join(",", arr1)}]: " + $"[{string.Join(",", IntArrayHelper.MissingElements(arr1))}]");
    Console.WriteLine($"Missing elements check of array [{string.Join(",", arr2)}]: " + $"[{string.Join(",", IntArrayHelper.MissingElements(arr2))}]");
    Console.WriteLine($"Missing elements check of array [{string.Join(",", arr3)}]: " + $"[{string.Join(",", IntArrayHelper.MissingElements(arr3))}]" + "\n");

}

void PrintSeparator()
{
    Console.WriteLine("------------------------------ \n");
}