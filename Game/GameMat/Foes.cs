using Game.Dice.Foes;

namespace Game.GameMat
{
    /// <summary>
    /// Represents the <see cref="Foes"/>
    /// </summary>
    public class Foes
    {
        private List<FoeDie> _foes;

        /// <summary>
        /// Creates an instance of <see cref="Foes"/>
        /// </summary>
        public Foes()
        {
            _foes = new List<FoeDie>();
        }

        /// <inheritdoc cref="Foes()"/>
        public Foes(FoeDice foes)
        {
            this._foes = foes.Foes.ToList();
        }

        /// <summary>
        /// The number of <see cref="Foe.Niska"/> dice
        /// </summary>
        public int Niska => _foes.Count(die => die.FoeName is FoeName.Niska);

        /// <summary>
        /// The number of <see cref="Foe.Badger"/> dice
        /// </summary>
        public int Badger => _foes.Count(die => die.FoeName is FoeName.Badger);

        /// <summary>
        /// The number of <see cref="Foe.Saffron"/> dice
        /// </summary>
        public int Saffron => _foes.Count(die => die.FoeName is FoeName.Saffron);

        /// <summary>
        /// Attempts to remove a <see cref="FoeDie"/>
        /// </summary>
        /// <param name="foe">The <see cref="FoeDie"/> to remove</param>
        /// <returns>True if the foe was available to remove</returns>
        public bool KnockOut(FoeDie foe)
        {
            if (_foes.All(die => die.FoeName != foe.FoeName)) 
                return false;

            _foes.Remove(foe);
            return true;
        }

        /// <summary>
        /// Adds the <see cref="FoeDie"/> to the active foes
        /// </summary>
        /// <param name="dice">The <see cref="FoeDie"/> to add</param>
        public void AddRange(List<FoeDie> dice)
        {
            _foes.AddRange(dice);
        }

        /// <summary>
        /// Re-rolls the <see cref="FoeDie"/>
        /// </summary>
        /// <param name="die">The <see cref="FoeDie"/> to roll</param>
        public void ReRoll(FoeDie die)
        {
            _foes.Remove(die);
            _foes.Add(new FoeDie());
        }
    }
}
