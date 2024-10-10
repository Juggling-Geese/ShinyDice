using Game.Dice.Core;

namespace Game.Dice.Foes
{
    /// <summary>
    /// Represents a <see cref="FoeDie"/>
    /// </summary>
    /// <param name="foeName">The type of <see cref="FoeName"/></param>
    public class FoeDie(FoeName foeName) : Die(DieType.Foe)
    {
        /// <summary>
        /// Creates an instance of a <see cref="FoeDie"/>
        /// </summary>
        public FoeDie() : this(FoeName.None.Roll()) { }

        /// <summary>
        /// The type of <see cref="FoeName"/>
        /// </summary>
        public FoeName FoeName { get; } = foeName;
    }
}
