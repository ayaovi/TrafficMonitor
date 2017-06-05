using System.Collections.Generic;

namespace TrafficMonitor
{
  public class Phase
  {
    public Phase(IList<Direction> directions)
    {
      Directions = directions;
      IsActive = false;
    }

    public Phase(char index)
    {
      Directions = new List<Direction>();
      switch (index)
      {
        case 'A':
          Directions.Add(Direction.NorthNorth);
          Directions.Add(Direction.NorthWest);
          break;
        case 'B':
          Directions.Add(Direction.SouthSouth);
          Directions.Add(Direction.SouthEast);
          break;
      }
    }

    public IList<Direction> Directions { get; }
    public bool IsActive { get; set; }
  }
}
