using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficMonitor
{
  public class State
  {
    public State(int numberOfLights)
    {
      if (numberOfLights < 1) throw new Exception($"Invalid Number Of Lights ({numberOfLights}). State Needs At Least One Light.");
      Lights = Enumerable.Range(0, numberOfLights).Select(i => new Light(Colour.Red, new Position(i))).ToList();
      
      foreach (var light in Lights)
      {
        foreach (var otherLight in Lights)
        {
          if (light.Position.Value + otherLight.Position.Value == numberOfLights - 1)
          {
            light.Twin = otherLight;
          }
        }
      }
    }

    public IList<Light> Lights { get; }
  }
}
