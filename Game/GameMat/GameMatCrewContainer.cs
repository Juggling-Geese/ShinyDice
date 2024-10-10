using Game.Dice.Core;
using Game.Dice.Crew;

namespace Game.GameMat
{
    public abstract class GameMatCrewContainer : GameMatContainer
    {
        private CrewDice _crew;

        protected GameMatCrewContainer()
        {
            _crew = new CrewDice();
        }

        protected GameMatCrewContainer(CrewDice crew) : this()
        {
            _crew = crew;
        }

        /// <inheritdoc />
        public override void Add(params Die[] dice)
        {
            _crew.AddCrew(dice.Where(die => die.DieType is DieType.Crew).Cast<CrewDie>().ToArray());
        }

        /// <inheritdoc />
        public override bool Remove(params Die[] dice)
        {
            return _crew.RemoveCrew(dice.Where(die => die.DieType is DieType.Crew).Cast<CrewDie>().ToArray());
        }
    }
}