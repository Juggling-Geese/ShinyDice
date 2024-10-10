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

        [Fact]
        public void FoeDice_RemoveFoes_RemoveFoeShouldBeTrue()
        {
            var foeDice = new FoeDice(5);
            var badger = foeDice.Badger;
            var niska = foeDice.Niska;
            var saffron = foeDice.Saffron;

            if (badger > 0)
            {
                foeDice.RemoveFoes(new FoeDie(FoeName.Badger)).Should().BeTrue();
                foeDice.Badger.Should().Be(badger - 1);
                foeDice.Saffron.Should().Be(saffron);
                foeDice.Niska.Should().Be(niska);
            }
            else if (saffron > 0) 
            {
                foeDice.RemoveFoes(new FoeDie(FoeName.Saffron)).Should().BeTrue();
                foeDice.Badger.Should().Be(badger);
                foeDice.Saffron.Should().Be(saffron - 1);
                foeDice.Niska.Should().Be(niska);
            }
            else
            {
                foeDice.RemoveFoes(new FoeDie(FoeName.Niska)).Should().BeTrue();
                foeDice.Badger.Should().Be(badger);
                foeDice.Saffron.Should().Be(saffron);
                foeDice.Niska.Should().Be(niska - 1);
            }
        }

        [Fact]
        public void FoeDice_RemoveFoes_RemoveFoeShouldBeFalse()
        {
            var foeList = new List<FoeDie>()
            {
                new FoeDie(FoeName.Badger),
                new FoeDie(FoeName.Badger),
                new FoeDie(FoeName.Saffron)
            };

            var foeDice = new FoeDice(foeList);
            foeDice.Badger.Should().Be(2);
            foeDice.Niska.Should().Be(0);
            foeDice.Saffron.Should().Be(1);

            foeDice.RemoveFoes(new FoeDie(FoeName.Niska)).Should().BeFalse();
            foeDice.Badger.Should().Be(2);
            foeDice.Niska.Should().Be(0);
            foeDice.Saffron.Should().Be(1);
        }
    }
}
