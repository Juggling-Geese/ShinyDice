using Game.Dice.Crew;

namespace Game.GameMat
{
    /// <summary>
    /// Represents <see cref="Serenity"/>
    /// </summary>
    public class Serenity : GameMatCrewContainer
    {
        /// <summary>
        /// Creates an instance of <see cref="Serenity"/>
        /// </summary>
        public Serenity()
            : base()
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="Serenity"/>
        /// </summary>
        /// <param name="crew">The crew</param>
        public Serenity(CrewDice crew)
            : base(crew)
        {
        }
    }
}
