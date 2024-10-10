using Game.Dice.Crew;

namespace Game.GameMat
{
    /// <summary>
    /// Represents <see cref="Serenity"/>
    /// </summary>
    public class Serenity()
    {
        private CrewDice _crew = new CrewDice();

        /// <summary>
        /// Creates an instance of <see cref="Serenity"/>
        /// </summary>
        /// <param name="crew">The crew</param>
        public Serenity(CrewDice crew)
            : this()
        {
            _crew = crew;

            Add(crew.Passengers.ToArray());
            Add(crew.Outlaws.ToArray());
        }

        /// <summary>
        /// The passengers available in Serenity
        /// </summary>
        public IEnumerable<PassengerDie> Passengers
        {
            get => _crew.Passengers;
        }

        /// <summary>
        /// The outlaws available in Serenity
        /// </summary>
        public List<OutlawDie> Outlaws { get; set; } = new();

        /// <summary>
        /// Adds outlaws and/or passengers
        /// </summary>
        /// <param name="dice">The dice to add to <see cref="Serenity"/></param>
        public void Add(params CrewDie[] dice)
        {
            _crew.AddCrew(dice);
        }

        /// <summary>
        /// Removes outlaws and/or passengers
        /// </summary>
        /// <param name="dice">The dice to remove</param>
        public bool Remove(params CrewDie[] dice)
        {
            return _crew.RemoveCrew(dice);
        }
    }
}
