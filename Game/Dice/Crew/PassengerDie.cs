using Game.Dice.Core;

namespace Game.Dice.Crew
{
    /// <summary>
    /// Represents a <see cref="PassengerDie"/>
    /// </summary>
    /// <param name="passengerName">Type of passenger</param>
    public class PassengerDie(PassengerName passengerName) : CrewDie(CrewType.Passenger)
    {
        /// <summary>
        /// Creates a new <see cref="PassengerDie"/>
        /// </summary>
        public PassengerDie() : this(PassengerName.Any.Roll()) { }

        /// <summary>
        /// The type of <see cref="PassengerName"/>
        /// </summary>
        public PassengerName PassengerName { get; } = passengerName;

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            var die = obj as PassengerDie;

            if (die == null)
            {
                return false;
            }

            if (CrewType != die.CrewType)
            {
                return false;
            }

            if (PassengerName != die.PassengerName)
            {
                return false;
            }

            return true;
        }
    }
}