namespace TestTasks.Services;

public static class InstanceService
{
    public static IEnumerable<T> GetInstances<T>()
    {
        return typeof(T).Assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(T)))
            .Select(t => (T)Activator.CreateInstance(t)!);
    }
}
