using Game.Dice.Crew;

namespace Game.GameMat
{
    /// <summary>
    /// Represents a <see cref="CargoHold"/>
    /// </summary>
    public class CargoHold : GameMatCrewContainer
    {
        /// <summary>
        /// Creates a <see cref="CargoHold"/>
        /// </summary>
        public CargoHold()
        {
        }

        public CargoHold(CrewDice crew) : base(crew)
        {
        }
    }
}
