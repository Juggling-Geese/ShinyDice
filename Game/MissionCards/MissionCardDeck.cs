using System.Globalization;
using CsvHelper;
using Game.Dice.Crew;
using Game.Dice.Foes;

namespace Game.MissionCards
{
    /// <summary>
    /// Represents a <see cref="MissionCardDeck"/>
    /// </summary>
    public class MissionCardDeck
    {
        private readonly string[] _expectedHeaders = new[]
        {
            "Title", "Type", "Description", "Reward", "Requirements"
        };

        private readonly string _filePath = "MissionCards\\cards.csv";

        /// <summary>
        /// Creates an empty <see cref="MissionCardDeck"/>
        /// </summary>
        public MissionCardDeck()
        {
            Deck = new List<MissionCard>();
        }

        /// <summary>
        /// The cards
        /// </summary>
        public List<MissionCard> Deck { get; }

        /// <summary>
        /// Loads the cards into the deck from the file
        /// </summary>
        /// <exception cref="FileNotFoundException">Thrown if the expected CSV file is not found</exception>
        /// <exception cref="FileLoadException">Thrown if the CSV doesn't match the expected format</exception>
        /// <exception cref="ArgumentException">Thrown if a datapoint could not be parsed</exception>
        public void LoadDeck()
        {
            if ( !File.Exists(_filePath) ) throw new FileNotFoundException("Can't find card files", _filePath);

            using var stream = new StreamReader(_filePath);
            using var csv = new CsvReader(stream, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<dynamic>();
        
            var file = new List<string>(File.ReadAllLines(_filePath));

            var headers = file.First().Split(",");
            file.RemoveAt(0);

            if ( !headers.SequenceEqual(_expectedHeaders) ) throw new FileLoadException("Card deck file does not match expected input");

            foreach ( var record in records )
            {
                var card = new MissionCard
                {
                    Title = record.Title,
                    Description = record.Description,
                    Reward = new Reward(record.Reward)
                };

                string missionType = record.Type;

                card.MissionType = Enum.TryParse<MissionType>(missionType, out var type)
                    ? type
                    : throw new ArgumentException("Could not parse mission type");

                var requirements = ((string)record.Requirements).Split("|");

                foreach ( var requirement in requirements )
                {
                    if ( Enum.TryParse<OutlawName>(requirement, out var outlaw) )
                    {
                        card.Requirements.Add(new OutlawDie(outlaw));
                        continue;
                    }

                    if ( Enum.TryParse<PassengerName>(requirement, out var passenger) )
                    {
                        card.Requirements.Add(new PassengerDie(passenger));
                        continue;
                    }

                    if ( Enum.TryParse<FoeName>(requirement, out var foe) )
                    {
                        card.Requirements.Add(new FoeDie(foe));
                        continue;
                    }

                    throw new ArgumentException($"Requirement value '{requirement}' did not parse correctly");
                }

                Deck.Add(card);
            }
        }

        /// <summary>
        /// Shuffles the deck
        /// </summary>
        public void ShuffleDeck()
        {
            new Random().Shuffle<MissionCard>(Deck.ToArray());
        }
    }
}
