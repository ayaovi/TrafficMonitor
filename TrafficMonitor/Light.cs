using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficMonitor
{
  public class Light
  {
    public Light(Colour colour)
    {
      Colour = colour;
    }

    public Light(Colour colour, Position position) : this(colour)
    {
      Position = position;
    }

    public Colour Colour { get; set; }
    public Position Position { get; }
    public Light Twin { get; set; }

    public override bool Equals(object obj)
    {
      // Check for null values and compare run-time types.
      if (obj == null || GetType() != obj.GetType())
        return false;

      var light = (Light)obj;
      return Colour == light.Colour && Position == light.Position;
    }
  }
}
