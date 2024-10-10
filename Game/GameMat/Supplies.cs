using Game.Dice.Core;
using Game.Dice.Crew;

namespace Game.GameMat
{
    /// <summary>
    /// Represents the supplies in Serenity
    /// </summary>
    public class Supplies()
    {
        private readonly List<CrewDie> _supplies = new List<CrewDie>();

        public Supplies(CrewDice crew)
            : this()
        {
            _supplies = crew.Supplies.ToList();
        }

        /// <summary>
        /// The total number of supplies
        /// </summary>
        public int Count => _supplies.Count;

        /// <summary>
        /// Adds a <see cref="CrewDie"/>, if die is a supply die
        /// </summary>
        /// <param name="dice">The given die to add to the supplies hold</param>
        public void Add(params CrewDie[] dice)
        {
            _supplies.AddRange(dice.Where(die => die.IsSupply()));
        }
    }
}
