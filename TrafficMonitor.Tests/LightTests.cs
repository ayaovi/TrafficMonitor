using NUnit.Framework;

namespace TrafficMonitor.Tests
{
  [TestFixture]
  public class LightTests
  {
    [TestCase(Colour.Red, TestName = "Red Colour")]
    [TestCase(Colour.Green, TestName = "Green Colour")]
    [TestCase(Colour.Yellow, TestName = "Yellow Colour")]
    public void Light_Colour_Upon_Creation(Colour colour)
    {
      // Arrange && Act && Assert
      Assert.IsTrue(new Light(colour).Colour == colour);
    }

    [TestCase(0, TestName = "Light at position 0")]
    public void Light_Position_Upon_Creation(int position)
    {
      //Arrange && Act && Assert
      Assert.IsTrue(new Light(Colour.Green, new Position(position)).Position == new Position(position));
    }

    [Test]
    public void Light_Twin_Upon_Creation_ExpectNull()
    {
      //Arrange && Act && Assert
      Assert.IsNull(new Light(Colour.Green, new Position(0)).Twin);
    }

    [Test]
    public void Equals_GivenSameLight_ExpectTrue()
    {
      //Assert
      Assert.IsTrue(new Light(Colour.Red, new Position(0)).Equals(new Light(Colour.Red, new Position(0))));
    }

    [Test]
    public void Equals_GivenOtherLight_ExpectFalse()
    {
      //Assert
      Assert.IsFalse(new Light(Colour.Red, new Position(0)).Equals(new Light(Colour.Red, new Position(1))));
    }
  }
}
