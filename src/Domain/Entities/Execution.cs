namespace RoboSimulator.Domain.Entities;
public class Execution
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int Commands { get; set; }
    public int Result { get; set; }
    public double Duration { get; set; }
}
