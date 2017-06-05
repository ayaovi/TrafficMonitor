using System.Collections.Generic;

namespace TrafficMonitor
{
  public class Phase
  {
    public Phase(Direction direction)
    {
      Direction = direction;
      PhaseName = (PhaseName)direction;
      IsActive = false;
    }

    public Phase(PhaseName phaseName)
    {
      PhaseName = phaseName;
      Direction = (Direction)phaseName;
    }

    public Direction Direction { get; }
    public bool IsActive { get; set; }
    public PhaseName PhaseName { get; }
  }
}
