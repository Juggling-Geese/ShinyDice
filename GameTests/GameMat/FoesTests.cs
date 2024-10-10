using FluentAssertions;

using Game.Dice.Foes;
using Game.GameMat;

using Xunit;

namespace GameTests.GameMat
{
    public class FoesTests
    {
        private List<FoeDie> sampleFoeList =
        [
            new FoeDie(FoeName.Badger),
            new FoeDie(FoeName.Saffron),
            new FoeDie(FoeName.Badger),
            new FoeDie(FoeName.Niska),
            new FoeDie(FoeName.Saffron),
            new FoeDie(FoeName.Saffron)
        ];

        [Fact]
        public void Foes_Ctor_InitializesCorrectlyWithList()
        {
            var foes = new Foes();
            foes.Badger.Should().Be(0);
            foes.Saffron.Should().Be(0);
            foes.Niska.Should().Be(0);

            var foeDice = new FoeDice(sampleFoeList);

            var foesFromList = new Foes(foeDice);
            foesFromList.Badger.Should().Be(2);
            foesFromList.Niska.Should().Be(1);
            foesFromList.Saffron.Should().Be(3);
        }

        [Fact]
        public void Foes_Add_AddListUpdatesCorrectly()
        {
            var foeDice = new FoeDice(sampleFoeList);
            var foes = new Foes(foeDice);
            foes.Badger.Should().Be(2);
            foes.Niska.Should().Be(1);
            foes.Saffron.Should().Be(3);

            foes.Add(sampleFoeList.ToArray());

            foes.Badger.Should().Be(4);
            foes.Niska.Should().Be(2);
            foes.Saffron.Should().Be(6);
        }

        [Fact]
        public void Foes_ReRoll_CorrectlyRollsGivenDie()
        {
            var foeDice = new FoeDice(sampleFoeList);
            var foes = new Foes(foeDice);

            foes.Badger.Should().Be(2);
            foes.Niska.Should().Be(1);
            foes.Saffron.Should().Be(3);

            var badgerRolled = false;

            for (var i = 0; i < 5; i++)
            {
                foes.ReRoll(new FoeDie(FoeName.Badger));

                if (foes.Badger != 2) badgerRolled = true;
            }

            badgerRolled.Should().BeTrue();
        }

        [Fact]
        public void Foes_Remove_ReturnsTrueWhenDieIsPresent()
        {
            var foeDice = new FoeDice(sampleFoeList);
            var foes = new Foes(foeDice);
            foes.Badger.Should().Be(2);
            foes.Saffron.Should().Be(3);
            foes.Niska.Should().Be(1);

            foes.Remove(new FoeDie(FoeName.Badger)).Should().BeTrue();

            foes.Badger.Should().Be(1);
            foes.Saffron.Should().Be(3);
            foes.Niska.Should().Be(1);
        }

        [Fact]
        public void Foes_Remove_ReturnsFalseWhenDieNotPresent()
        {
            var list = sampleFoeList.Where(foe => foe.FoeName != FoeName.Niska);
            var foeDice = new FoeDice(list);
            var foes = new Foes(foeDice);

            foes.Badger.Should().Be(2);
            foes.Niska.Should().Be(0);
            foes.Saffron.Should().Be(3);

            foes.Remove(new FoeDie(FoeName.Niska)).Should().BeFalse();
            foes.Badger.Should().Be(2);
            foes.Niska.Should().Be(0);
            foes.Saffron.Should().Be(3);
        }
    }
}
