using Game.Dice.Core;

namespace Game.GameMat
{
    public abstract class GameMatContainer
    {
        /// <summary>
        /// Adds provided <see cref="Die"/>
        /// </summary>
        /// <param name="dice"><see cref="Die"/> to add to collection</param>
        public abstract void Add(params Die[] dice);

        /// <summary>
        /// Removes provided <see cref="Die"/>
        /// </summary>
        /// <param name="dice"><see cref="Die"/> to remove from collection</param>
        /// <returns>True if the die is present and removed</returns>
        public abstract bool Remove(params Die[] dice);
    }
}
