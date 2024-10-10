namespace Game.MissionCards
{
    /// <summary>
    /// Represents a <see cref="Reward"/>
    /// </summary>
    /// <param name="reward">The description of the reward</param>
    public class Reward(string reward)
    {
        /// <summary>
        /// Creates a <see cref="Reward"/>
        /// </summary>
        public Reward() : this(String.Empty)
        {
        }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; } = reward;

        /// <inherit />
        public override bool Equals(object? obj)
        {
            var reward = obj as Reward;

            if (reward is null) return false;

            if (Description != reward.Description) return false;

            return true;
        }
    }
}
