namespace TrafficMonitor
{
  public class Phase
  {
    public Phase(Direction direction)
    {
      Direction = direction;
      IsActive = false;
    }

    public Direction Direction { get; }
    public bool IsActive { get; set; }
  }
}
