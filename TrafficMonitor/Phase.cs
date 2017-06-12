using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TrafficMonitor
{
  public class Phase
  {
    public Phase(PhaseName phaseName)
    {
      switch (phaseName)
      {
        case PhaseName.A:
          Directions = new List<Direction> { Direction.NorthEast, Direction.NorthNorth, Direction.NorthWest };
          break;
        case PhaseName.B:
          Directions = new List<Direction> { Direction.SouthEast, Direction.SouthSouth, Direction.SouthWest };
          break;
        case PhaseName.C:
          Directions = new List<Direction> { Direction.WestNorth, Direction.WestWest, Direction.WestSouth };
          break;
        case PhaseName.D:
          Directions = new List<Direction> { Direction.EastSouth, Direction.EastEast, Direction.EastNorth };
          break;
      }
      PhaseName = phaseName;
      IsActive = false;
    }

    public IList<Direction> Directions { get; }
    public bool IsActive { get; set; }
    public PhaseName PhaseName { get; }

    public override bool Equals(object obj)
    {
      // Check for null values and compare run-time types.
      if (obj == null || GetType() != obj.GetType())
        return false;

      var phase = (Phase)obj;
      return PhaseName == phase.PhaseName && Directions.All(direction => phase.Directions.Contains(direction));
    }
  }
}
