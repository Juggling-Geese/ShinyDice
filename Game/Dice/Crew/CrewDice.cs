using Game.Dice.Core;

namespace Game.Dice.Crew
{
    /// <summary>
    /// Represents a set of <see cref="CrewDie"/>
    /// </summary>
    public class CrewDice()
    {
        private readonly List<OutlawDie> _outlaws = new();
        private readonly List<PassengerDie> _passengers = new();
        private readonly List<CrewDie> _supplies = new();

        /// <summary>
        /// Creates a new instance of <see cref="CrewDice"/>
        /// </summary>
        /// <param name="outlawCount">Number of <see cref="OutlawDie"/> to roll</param>
        /// <param name="passengerCount">Number of <see cref="PassengerDie"/> to roll</param>
        public CrewDice(int outlawCount, int passengerCount)
        : this()
        {
            var outlaws = new List<OutlawDie>();
            for (var i = 0; i < outlawCount; i++)
            {
                outlaws.Add(new OutlawDie());
            }

            AddCrew(outlaws.ToArray());

            var passengers = new List<PassengerDie>();
            for (var i = 0; i < passengerCount; i++)
            {
                passengers.Add(new PassengerDie());
            }

            AddCrew(passengers.ToArray());
        }

        /// <summary>
        /// Creates a new instance of <see cref="CrewDice"/>
        /// </summary>
        /// <param name="outlaws"><see cref="OutlawDie"/> to include</param>
        /// <param name="passengers"><see cref="PassengerDie"/> to include</param>
        public CrewDice(IEnumerable<OutlawDie> outlaws, IEnumerable<PassengerDie> passengers)
        : this()
        {
            _passengers = passengers.Where(die => !die.IsSupply()).ToList();
            _outlaws = outlaws.Where(die => !die.IsSupply()).ToList();

            _supplies.AddRange(outlaws.Where(die => die.IsSupply()));
            _supplies.AddRange(passengers.Where(die => die.IsSupply()));
        }

        /// <summary>
        /// The outlaws
        /// </summary>
        public IEnumerable<OutlawDie> Outlaws => _outlaws;

        /// <summary>
        /// The passengers
        /// </summary>
        public IEnumerable<PassengerDie> Passengers => _passengers;

        /// <summary>
        /// The supplies
        /// </summary>
        public IEnumerable<CrewDie> Supplies => _supplies;

        /// <summary>
        /// Adds the <see cref="CrewDie"/> to the collection
        /// </summary>
        /// <param name="crew">The <see cref="CrewDie"/> to add</param>
        public void AddCrew(params CrewDie[] crew)
        {
            _outlaws.AddRange(crew.Where(die => die is OutlawDie outlaw && !outlaw.IsSupply()).Cast<OutlawDie>());
            _passengers.AddRange(crew.Where(die => die is PassengerDie passenger && !passenger.IsSupply()).Cast<PassengerDie>());
            _supplies.AddRange(crew.Where(die => die.IsSupply()));
        }

        /// <summary>
        /// Removes the <see cref="CrewDie"/> from the collection
        /// </summary>
        /// <param name="crew">The <see cref="CrewDie"/> to remove</param>
        public bool RemoveCrew(params CrewDie[] crew)
        {
            foreach (var crewDie in crew)
            {
                switch (crewDie)
                {
                    case OutlawDie outlaw:
                        {
                            var outlawMatch = _outlaws.FirstOrDefault(die => die.OutlawName == outlaw.OutlawName);

                            if (outlawMatch is null || !_outlaws.Remove(outlawMatch))
                            {
                                return false;
                            }

                            break;
                        }
                    case PassengerDie passenger:
                        {
                            var passengerMatch = _passengers.FirstOrDefault(die => die.PassengerName == passenger.PassengerName);

                            if (passengerMatch is null || !_passengers.Remove(passengerMatch))
                            {
                                return false;
                            }

                            break;
                        }
                    default:
                        return false;
                }
            }

            return true;
        }
    }
}
