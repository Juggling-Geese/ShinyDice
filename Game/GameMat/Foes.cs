using Game.Dice.Core;
using Game.Dice.Foes;

namespace Game.GameMat
{
    /// <summary>
    /// Represents the <see cref="Foes"/>
    /// </summary>
    public class Foes : GameMatContainer
    {
        private readonly FoeDice _foes;

        /// <summary>
        /// Creates an instance of <see cref="Foes"/>
        /// </summary>
        public Foes()
        {
            _foes = new FoeDice();
        }

        /// <inheritdoc cref="Foes()"/>
        public Foes(FoeDice foes)
        {
            this._foes = foes;
        }

        /// <summary>
        /// The number of <see cref="FoeName.Niska"/> dice
        /// </summary>
        public int Niska => _foes.Niska;

        /// <summary>
        /// The number of <see cref="FoeName.Badger"/> dice
        /// </summary>
        public int Badger => _foes.Badger;

        /// <summary>
        /// The number of <see cref="FoeName.Saffron"/> dice
        /// </summary>
        public int Saffron => _foes.Saffron;

        /// <inheritdoc />
        /// <param name="dice">The foes to add</param>
        public override void Add(params Die[] dice)
        {
            _foes.AddFoes(dice.Where(die => die.DieType is DieType.Foe).Cast<FoeDie>().ToArray());
        }

        /// <inheritdoc />
        /// <param name="dice">The foes to remove</param>
        public override bool Remove(params Die[] dice)
        {
            return _foes.RemoveFoes(dice.Where(die => die.DieType is DieType.Foe).Cast<FoeDie>().ToArray());
        }

        /// <summary>
        /// Re-rolls the <see cref="FoeDie"/>
        /// </summary>
        /// <param name="die">The <see cref="FoeDie"/> to roll</param>
        public bool ReRoll(FoeDie die)
        {
            if ( !_foes.RemoveFoes(die) ) return false;

            _foes.AddFoes(new FoeDie());

            return true;
        }
    }
}
