using Game.Dice.Crew;
using Game.Dice.Foes;

namespace Game.Dice.Core
{
    /// <summary>
    /// Extensions for different types of <see cref="Die"/>
    /// </summary>
    public static class DiceExtensions
    {
        private static readonly Random Random = new Random();

        /// <summary>
        /// Re-rolls a <see cref="FoeType"/> type
        /// </summary>
        /// <param name="foeType">The original <see cref="FoeType"/></param>
        /// <returns>A new <see cref="FoeType"/></returns>
        public static FoeName Roll(this FoeName foeName)
        {
            return (FoeName)Random.Next(1, 4);
        }

        /// <summary>
        /// Re-rolls a <see cref="OutlawName"/> type
        /// </summary>
        /// <param name="outlawName">The original <see cref="OutlawName"/></param>
        /// <returns>A new <see cref="OutlawName"/></returns>
        public static OutlawName Roll(this OutlawName outlawName)
        {
            return (OutlawName)Random.Next(1, 7);
        }

        /// <summary>
        /// Re-rolls a <see cref="PassengerType"/> type
        /// </summary>
        /// <param name="outlaw">The original <see cref="PassengerType"/></param>
        /// <returns>A new <see cref="PassengerType"/></returns>
        public static PassengerName Roll(this PassengerName outlaw)
        {
            return (PassengerName)Random.Next(1, 6);
        }

        /// <summary>
        /// Rolls a <see cref="CrewDie"/>
        /// </summary>
        /// <returns></returns>
        public static CrewDie RollCrewDie(this CrewDie die)
        {
            return new Random().Next(0, 1) == 0 ? new PassengerDie() : new OutlawDie();
        }

        /// <summary>
        /// Rolls the <see cref="CrewDice"/>
        /// </summary>
        /// <param name="dice">The <see cref="CrewDice"/> to roll</param>
        /// <returns>New set of <see cref="CrewDice"/></returns>
        public static CrewDice RollCrewDice(this CrewDice dice)
        {
            return new CrewDice(outlawCount: dice.Outlaws.Count(), passengerCount: dice.Passengers.Count());
        }

        /// <summary>
        /// Indicates if the <see cref="CrewDie"/> is a supply
        /// </summary>
        /// <param name="die">The <see cref="CrewDie"/> to check</param>
        /// <returns>True if the type of <see cref="CrewDie"/> is a supply</returns>
        public static bool IsSupply(this CrewDie die)
        {
            if ( die.CrewType is CrewType.Outlaw )
            {
                return ((OutlawDie) die).OutlawName is OutlawName.Supplies;
            }

            return ((PassengerDie) die).PassengerName is PassengerName.Supplies;
        }

        /// <summary>
        /// Creates a new <see cref="CrewDice"/> of the same size as the <param name="dice"></param>
        /// </summary>
        /// <param name="dice">The <see cref="CrewDice"/> to roll</param>
        /// <returns>A new set of <see cref="CrewDice"/></returns>
        public static CrewDice RollAllDice(this CrewDice dice)
        {
            var outlawCount = dice.Outlaws.Count() + dice.Supplies.Count(die => die.CrewType is CrewType.Outlaw && die.IsSupply());
            var passengers = dice.Passengers.Count() + dice.Supplies.Count(die => die.CrewType is CrewType.Passenger && die.IsSupply());

            return new CrewDice(outlawCount: outlawCount, passengerCount: passengers);
        }

        /// <summary>
        /// Creates a new <see cref="FoeDice"/> of the same size as the incoming <see cref="FoeDice"/>
        /// </summary>
        /// <param name="foes">The <see cref="FoeDice"/> to roll</param>
        /// <returns>A new set of <see cref="FoeDice"/></returns>
        public static FoeDice RollDice(this FoeDice foes)
        {
            return new FoeDice(foes.Count);
        }

        /// <summary>
        /// Rolls the die
        /// </summary>
        public static FoeDie Roll(this FoeDie foe)
        {
            return new FoeDie(foe.FoeName);
        }

        /// <summary>
        /// Rolls the die
        /// </summary>
        /// <param name="outlaw">The <see cref="OutlawDie"/> to roll</param>
        /// <returns>The rolled <see cref="OutlawDie"/></returns>
        public static OutlawDie Roll(this OutlawDie outlaw)
        {
            return new OutlawDie(outlaw.OutlawName);
        }

        /// <summary>
        /// Rolls the die
        /// </summary>
        /// <param name="passenger">The <see cref="PassengerDie"/> to roll</param>
        /// <returns>The rolled <see cref="PassengerDie"/></returns>
        public static PassengerDie Roll(this PassengerDie passenger)
        {
            return new PassengerDie(passenger.PassengerName);
        }
    }
}