using Game.Dice.Core;
using Game.Dice.Crew;
using Game.Dice.Foes;
using Game.MissionCards;

namespace Game.GameMat
{
    /// <summary>
    /// Represents the playing mat
    /// </summary>
    public class Mat
    {
        /// <summary>
        /// Creates a new game with new <see cref="RolledDice"/>
        /// </summary>
        public Mat()
        {
            KO = new KO();
            CargoHold = new CargoHold();
            Foes = new Foes();
            Serenity = new Serenity();
            Supplies = new Supplies();

            MissionCards = new MissionCardDeck();
            MissionCards.LoadDeck();
            MissionCards.ShuffleDeck();

            DiscardPile = new List<MissionCard>();
        }

        /// <summary>
        /// Creates a new game with provided <see cref="RolledDice"/>
        /// </summary>
        /// <param name="dice">A set of rolled dice</param>
        public Mat(RolledDice dice)
            : this(dice.FoeDice, dice.CrewDice)
        {

        }

        /// <summary>
        /// Creates a new game with provided dice
        /// </summary>
        /// <param name="foes">Rolled group of <see cref="FoeDice"/></param>
        /// <param name="crew">Rolled group of <see cref="CrewDie"/></param>
        public Mat(FoeDice foes, CrewDice crew)
            : this()
        {
            Foes = new Foes(foes);
            Serenity = new Serenity(crew);
            Supplies = new Supplies(crew);
        }

        /// <summary>
        /// The ship with available dice
        /// </summary>
        public Serenity Serenity { get; set; }

        /// <summary>
        /// The Add'd dice
        /// </summary>
        public KO KO { get; set; }

        /// <summary>
        /// The <see cref="GameMat.CargoHold"/> with unavailable dice
        /// </summary>
        public CargoHold CargoHold { get; set; }

        /// <summary>
        /// Available supplies
        /// </summary>
        public Supplies Supplies { get; set; }

        /// <summary>
        /// Active <see cref="GameMat.Foes"/>
        /// </summary>
        public Foes Foes { get; set; }

        /// <summary>
        /// Available deck of cards
        /// </summary>
        public MissionCardDeck MissionCards { get; }

        /// <summary>
        /// Discard pile of cards
        /// </summary>
        public List<MissionCard> DiscardPile { get; }

        public void ReRollAllDice()
        {
            var rolled = new RolledDice();
            Foes = new Foes(rolled.FoeDice);
            Serenity = new Serenity(rolled.CrewDice);
            Supplies = new Supplies(rolled.CrewDice);
        }

        public bool KOFoe(FoeDie foe)
        {
            if (!Foes.Remove(foe)) return false;
            
            KO.Add(foe);

            return true;
        }

        public bool KOCrew(CrewDie die)
        {
            if (!Serenity.Remove(die)) return false;

            KO.Add(die);

            return true;
        }
    }
}
