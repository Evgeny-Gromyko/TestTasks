namespace TestTasks.Entities;

public class Vehicle
{
    public string Model { get; }
    public int MaxSpeed { get; }

    public Vehicle(string model, int maxSpeed)
    {
        Model = model;
        MaxSpeed = maxSpeed;
    }
}