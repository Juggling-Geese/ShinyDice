using Game.Dice.Core;
using Game.Dice.Crew;
using Game.Dice.Foes;

namespace Game.GameMat
{
    /// <summary>
    /// Represents the dies in the Add pile
    /// </summary>
    public class KO : GameMatContainer
    {
        private readonly FoeDice _foes;
        private readonly CrewDice _crew;

        /// <summary>
        /// Creates a new <see cref="KO"/>
        /// </summary>
        public KO()
        {
            _foes = new FoeDice();
            _crew = new CrewDice();
        }

        public KO(params Die[] dice)
        {
            _crew = new CrewDice(dice.Where(die => die.DieType is DieType.Crew).Cast<CrewDie>());
            _foes = new FoeDice(dice.Where(die => die.DieType is DieType.Foe).Cast<FoeDie>());
        }

        /// <summary>
        /// The <see cref="FoeDie"/>
        /// </summary>
        public FoeDice Foes => _foes;

        /// <summary>
        /// The <see cref="CrewDie"/>
        /// </summary>
        public CrewDice CrewDice => _crew;

        /// <inheritdoc />
        public override void Add(params Die[] dice)
        {
            foreach (var die in dice)
            {
                switch (die)
                {
                    case CrewDie crew:
                        _crew.AddCrew(crew); 
                        break;
                    case FoeDie foe:
                        _foes.AddFoes(foe);
                        break;
                }
            }
        }

        /// <inheritdoc />
        public override bool Remove(params Die[] dice)
        {
            foreach (var die in dice)
            {
                switch (die)
                {
                    case CrewDie crew:
                        if (!_crew.RemoveCrew(crew))
                            return false;
                        break;
                    case FoeDie foe:
                        if (!_foes.RemoveFoes(foe))
                            return false;
                        break;
                }
            }

            return true;
        }
    }
}
