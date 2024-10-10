using Game.Dice.Crew;

namespace Game.GameMat;

/// <summary>
/// Represents a <see cref="CargoHold"/>
/// </summary>
public class CargoHold
{
    /// <summary>
    /// Creates a <see cref="CargoHold"/>
    /// </summary>
    public CargoHold()
    {
        Passengers = new List<PassengerDie>();
        Outlaws = new List<OutlawDie>();
    }

    /// <summary>
    /// The <see cref="PassengerDie"/> in the <see cref="CargoHold"/>
    /// </summary>
    public List<PassengerDie> Passengers { get; set; }

    /// <summary>
    /// The <see cref="OutlawDie"/> in the <see cref="CargoHold"/>
    /// </summary>
    public List<OutlawDie> Outlaws { get; set; }
}
