using FluentAssertions;

using Game.Dice.Core;
using Game.Dice.Foes;

using Xunit;

namespace GameTests.Dice
{
    public class FoeDiceTests
    {
        [Fact]
        public void FoeDice_Constructor_CreatesCorrectNumberOfDice()
        {
            var foeDice = new FoeDice(5);
            foeDice.Should().NotBeNull();
            foeDice.Foes.Should().NotBeNullOrEmpty();

            var totalEnemies = foeDice.Badger + foeDice.Niska + foeDice.Saffron;
            totalEnemies.Should().Be(foeDice.Foes.Count());
            foeDice.Foes.All(die => die.FoeName != FoeName.None).Should().BeTrue();
        }

        [Fact]
        public void FoeDice_RollDice_ChangesDiceFaces()
        {
            var foeDice = new FoeDice(5);
            var originalDice = new List<FoeDie>(foeDice.Foes);

            foeDice.RollDice();

            foeDice.Foes.Should().NotBeSameAs(originalDice);
            foeDice.Foes.All(die => die.FoeName != FoeName.None).Should().BeTrue();
        }
    }
}
