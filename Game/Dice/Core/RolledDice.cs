using Game.Dice.Crew;
using Game.Dice.Foes;

namespace Game.Dice.Core
{
    /// <summary>
    /// Represents a collection of rolled dice for a round
    /// </summary>
    public class RolledDice
    {
        /// <summary>
        /// Creates an instance of a <see cref="RolledDice"/> with standard initial roll counts
        /// </summary>
        public RolledDice() : this(5, 3, 7)
        {
        }

        /// <summary>
        /// Creates an instance of a <see cref="RolledDice"/>
        /// </summary>
        /// <param name="foeCount">Number of <see cref="FoeDie"/> to roll</param>
        /// <param name="passengerCount">Number of <see cref="PassengerDie"/> to roll</param>
        /// <param name="outlawCount">Number of <see cref="OutlawDie"/> to roll</param>
        public RolledDice(int foeCount, int passengerCount, int outlawCount)
        {
            FoeDice = new FoeDice(foeCount);
            CrewDice = new CrewDice(passengerCount, outlawCount);
        }

        /// <summary>
        /// The foes
        /// </summary>
        public FoeDice FoeDice { get; set; }

        /// <summary>
        /// The crew
        /// </summary>
        public CrewDice CrewDice { get; set; }

        /// <summary>
        /// Counts the number of dice that are supplies
        /// </summary>
        /// <returns>Count of supplies in crew dice</returns>
        public int GetSupplies()
        {
            return CrewDice.Supplies.Count();
        }
    }
}