using Game.Dice.Core;

namespace Game.MissionCards
{
    /// <summary>
    /// Represents a <see cref="MissionCard"/>
    /// </summary>
    public class MissionCard
    {
        /// <summary>
        /// Creates a <see cref="MissionCard"/>
        /// </summary>
        public MissionCard()
        {
            Title = String.Empty;
            Description = String.Empty;
            MissionType = MissionType.Default;
            Requirements = new List<Die>();
            Reward = new Reward();
        }

        /// <summary>
        /// The title of the card
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description of the card
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The type of mission
        /// </summary>
        public MissionType MissionType { get; set; }

        /// <summary>
        /// The requirements to complete the mission
        /// </summary>
        public List<Die> Requirements { get; set; }

        /// <summary>
        /// The reward for completing the mission
        /// </summary>
        public Reward Reward { get; set; }

        /// <summary>
        /// Indicates if the rolled dice will complete the mission
        /// </summary>
        /// <param name="dice">The rolled dice</param>
        /// <returns>True if the rolled dice has the correct requirements</returns>
        public bool MeetsRequirements(RolledDice dice)
        {
            var availableDice = new List<Die>();
            availableDice.AddRange(dice.FoeDice.Foes);
            availableDice.AddRange(dice.CrewDice.Outlaws);
            availableDice.AddRange(dice.CrewDice.Passengers);

            foreach (var requirement in Requirements)
            {
                if (availableDice.Any(die => die == requirement)) return false;
                availableDice.Remove(requirement);
            }

            return true;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            var card = (MissionCard)obj;

            if (Title != card.Title)
            {
                return false;
            }

            if (Description != card.Description)
            {
                return false;
            }

            if (MissionType != card.MissionType)
            {
                return false;
            }

            if (!Reward.Equals(card.Reward))
            {
                return false;
            }

            if (!Requirements.Except(card.Requirements).Any())
            {
                return false;
            }

            return true;
        }
    }
}