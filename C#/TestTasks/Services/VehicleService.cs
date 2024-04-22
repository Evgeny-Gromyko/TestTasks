using System.Reflection;
using TestTasks.Entities;

namespace TestTasks.Services;

public class VehicleService
{
    public static IEnumerable<Type> GetVehicleTypes()
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Vehicle)));
    }

    public static IEnumerable<Type> GetVehicleTypesSortedByModel()
    {
        return GetVehicleTypes().OrderBy(t => t.Name);
    }

    public static IEnumerable<Type> SearchVehicleTypes(string searchTerm)
    {
        return GetVehicleTypes().Where(t => t.Name.ToLower().Contains(searchTerm.ToLower()));
    }
}
