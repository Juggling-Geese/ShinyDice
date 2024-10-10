using Game.Dice.Core;

namespace Game.Dice.Crew
{
    /// <summary>
    /// Represents a Crew die
    /// </summary>
    public abstract class CrewDie : Die
    {
        /// <summary>
        /// Creates a <see cref="CrewDie"/>
        /// </summary>
        /// <param name="type">Type of crew member</param>
        protected CrewDie(CrewType type) : base(DieType.Crew)
        {
            CrewType = type;
        }

        /// <summary>
        /// Type of crew member
        /// </summary>
        public CrewType CrewType { get; protected set; }
    }
}