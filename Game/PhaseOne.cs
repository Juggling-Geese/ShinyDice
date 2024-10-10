using Game.Dice.Core;
using Game.Dice.Crew;
using Game.Dice.Foes;
using Game.GameMat;
using Game.MissionCards;

namespace Game
{
    public class StepOne
    {
        #region Phase 1 - Roll all the dice 

        private readonly FoeDice _foes;
        private readonly CrewDice _crew;
        private readonly List<FoeDie> _koFoes;

        public StepOne(List<FoeDie> koFoes)
        {
            _koFoes = koFoes;
            _foes = new FoeDice(5);

            _crew = new CrewDice(outlawCount: 7, passengerCount: 3);
        }

        #endregion

        #region Phase 2 - Re-roll Crew die and/or Passenger/Foe die

        public bool CanReRollCrew()
        {
            return _crew.Outlaws.Any(outlaw => outlaw.OutlawName is OutlawName.Wash);
        }

        public bool CanReRollFoes()
        {
            return _crew.Passengers.Any(passenger => passenger.PassengerName is PassengerName.River);
        }

        public bool ReRollOutlaws(List<CrewDie> crew, out CrewDice rolled)
        {
            rolled = new CrewDice();

            var washes = crew.Count(die => die is OutlawDie { OutlawName: OutlawName.Wash });

            var others = crew.Count(die => die is not OutlawDie { OutlawName: OutlawName.Wash });

            if (washes < others) return false;
            {
                rolled = new CrewDice(crew.Count(die => die.CrewType is CrewType.Passenger), crew.Count(die => die.CrewType is CrewType.Outlaw));
                return true;
            }
        }

        public bool ReRollFoes(IEnumerable<PassengerDie> passengers, FoeDice foes, out IEnumerable<PassengerDie> newPassengers,
            out FoeDice newFoes)
        {
            newFoes = new FoeDice();
            newPassengers = new List<PassengerDie>();

            if (!passengers.All(die => die.PassengerName is PassengerName.River) || passengers.Count() < foes.Count)
            {
                return false;
            }

            newFoes = new FoeDice(foes.Count);
            newPassengers = new CrewDice(outlawCount: 0, passengerCount: passengers.Count()).Passengers;
            return true;
        }

        #endregion

        #region Phase 3 - Check number of foes, place crew in serenity, apply bonus

        public bool ShouldEndTurn()
        {
            return _foes.Badger > 4 || _foes.Niska > 4 | _foes.Saffron > 4;
        }

        public bool RequiresOtherPlayerPayments()
        {
            return _foes.Badger > 3 || _foes.Niska > 3 | _foes.Saffron > 3;
        }

        public bool CanApplyBonus()
        {
            return _crew.Outlaws.DistinctBy(die => die.OutlawName).Count() > 4;
        }

        public void ApplyBonus(FoeDie foe)
        {
            _foes.RemoveFoes(foe);
            _koFoes.Add(foe);
        }

        #endregion

        /// <summary>
        /// Creates a new <see cref="Mat"/> with results of <see cref="StepOne"/>
        /// </summary>
        /// <returns></returns>
        public Mat CreateNewGameMat()
        {
            var ko = new KO();
            ko.Add(_koFoes.ToArray());

            return new Mat(foes: _foes, crew: _crew)
            {
                KO = ko
            };
        }
    }

    public class StepTwo
    {
        // Get a mission
    }

    public class StepThree
    {
        private Mat _mat;
        private MissionCard _card;

        public StepThree(Mat mat, MissionCard card)
        {
            _mat = mat;
            _card = card;
        }

        // Phase 1 - Is the mission shiny?

        public bool IsMissionShiny()
        {
            return _card.MissionType == MissionType.Shiny;
        }

        public bool ShinyMission(FoeDie foe)
        {
            if (!IsMissionShiny()) return false;


            return true;
        }

        // Phase 2 - Foes strike
        // Phase 3 - Have a plan
        // Phase 4 - Damage report

    }

    public class StepFour
    {
        // Lay low or stay flying
    }
}
