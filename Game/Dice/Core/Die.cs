namespace Game.Dice.Core
{
    /// <summary>
    /// Represents a single Die
    /// </summary>
    /// <param name="dieType">The type of die</param>
    public abstract class Die(DieType dieType)
    {
        /// <summary>
        /// The type of <see cref="Die"/>
        /// </summary>
        public DieType DieType { get; } = dieType;
    }
}