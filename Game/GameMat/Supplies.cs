using Game.Dice.Core;
using Game.Dice.Crew;

namespace Game.GameMat
{
    /// <summary>
    /// Represents the supplies in Serenity
    /// </summary>
    public class Supplies() : GameMatCrewContainer
    {
        private readonly CrewDice _crew = new CrewDice();

        public Supplies(CrewDice crew)
            : this()
        {
            _crew = new CrewDice(
                crew.Outlaws.Where(outlaw => outlaw.IsSupply()),
                crew.Passengers.Where(passenger => passenger.IsSupply()));
        }

        /// <summary>
        /// The total number of supplies
        /// </summary>
        public int Count => _crew.Supplies.Count();

        /// <summary>
        /// Adds a <see cref="CrewDie"/>, if die is a supply die
        /// </summary>
        /// <param name="dice">The given die to add to the supplies hold</param>

        public override void Add(params Die[] dice)
        {
            var supplies = dice.Where(die => die is CrewDie crew && crew.IsSupply());
            base.Add(supplies.ToArray());
        }
    }
}
