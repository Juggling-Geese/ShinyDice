using FluentAssertions;
using Game.Dice.Core;
using Game.Dice.Crew;
using Xunit;

namespace Game.MissionCards.Tests;

public class MissionCardDeckTests
{
    [Fact()]
    public void MissionCardDeckTest()
    {
        var riverDie = new PassengerDie(PassengerName.River);

        var missionCard = new MissionCard()
        {
            Title = "Test Shiny River",
            Description = "Test Shiny River",
            MissionType = MissionType.Shiny,
            Reward = new Reward("Test Reward"),
            Requirements = new List<Die>(){ riverDie }
        };

        var deck = new MissionCardDeck();
        deck.LoadDeck();

        foreach (var card in deck.Deck)
        {
            if (card.Equals(missionCard) )
                break;
        }

        deck.Deck.Any(card => card.Equals(missionCard)).Should().BeTrue();
    }

    [Fact()]
    public void LoadDeckTest()
    {
        var deck = new MissionCardDeck();
        var action = () => deck.LoadDeck();
        action.Should().NotThrow();
        deck.Deck.Should().NotBeNullOrEmpty();
    }

    [Fact()]
    public void ShuffleDeckTest()
    {
        var cardDeck = new MissionCardDeck();
        cardDeck.LoadDeck();

        var deck = new List<MissionCard>(cardDeck.Deck);
        cardDeck.ShuffleDeck();
        cardDeck.Deck.SequenceEqual(deck).Should().BeFalse();
    }
}