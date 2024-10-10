using Game.Dice.Crew;
using Game.Dice.Foes;

namespace Game.GameMat
{
    /// <summary>
    /// Represents the dies in the Add pile
    /// </summary>
    public class KO
    {
        private FoeDice _foes;
        private CrewDice _crew;

        /// <summary>
        /// Creates a new <see cref="KO"/>
        /// </summary>
        public KO()
        {
            _foes = new FoeDice();
            _crew = new CrewDice();
        }

        /// <summary>
        /// The <see cref="FoeDie"/>
        /// </summary>
        public FoeDice Foes => _foes;

        /// <summary>
        /// The <see cref="CrewDie"/>
        /// </summary>
        public CrewDice CrewDice => _crew;

        /// <summary>
        /// Adds the <see cref="CrewDie"/> to the collection
        /// </summary>
        /// <param name="crew">The <see cref="CrewDie"/> to add</param>
        public void Add(CrewDie crew)
        {
            _crew.AddCrew(crew);
        }

        /// <summary>
        /// Adds the <see cref="FoeDie"/> to the collection
        /// </summary>
        /// <param name="foe">The <see cref="FoeDie"/> to add</param>
        public void Add(params FoeDie[] foes)
        {
            _foes.Add(foes);
        }

        /// <summary>
        /// Removes the <see cref="CrewDie"/> from the collection
        /// </summary>
        /// <param name="crew"></param>
        /// <returns>True if the <see cref="CrewDie"/> was present and removed from the collection</returns>
        public bool Remove(CrewDie crew)
        {
            return _crew.RemoveCrew(crew);
        }

        /// <summary>
        /// Removes the <see cref="FoeDie"/> from the collection
        /// </summary>
        /// <param name="foe"></param>
        /// <returns>True if the <see cref="FoeName"/> was present and removed from the collection</returns>
        public bool Remove(FoeDie foe)
        {
            return _foes.Remove(foe);
        }
    }
}
