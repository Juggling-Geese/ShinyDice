using Game.Dice.Core;

namespace Game.Dice.Crew
{
    /// <summary>
    /// Represents an <see cref="OutlawDie"/>
    /// </summary>
    /// <param name="outlawName">The type of <see cref="OutlawName"/></param>
    public class OutlawDie(OutlawName outlawName) : CrewDie(CrewType.Outlaw)
    {
        /// <summary>
        /// Creates an instance of an <see cref="OutlawDie"/>
        /// </summary>
        public OutlawDie() : this(OutlawName.Any.Roll()) { }

        /// <summary>
        /// The type of <see cref="OutlawName"/>
        /// </summary>
        public OutlawName OutlawName { get; private set; } = outlawName;
    }
}