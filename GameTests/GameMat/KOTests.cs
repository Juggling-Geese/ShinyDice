using FluentAssertions;

using Game.Dice.Core;
using Game.Dice.Crew;
using Game.Dice.Foes;
using Game.GameMat;

using Xunit;

namespace GameTests.GameMat
{
    public class KOTests
    {
        [Fact()]
        public void KO_Ctor_InitializesCorrectlyWithList()
        {
            var ko = new KO();
            ko.CrewDice.Supplies.Should().BeEmpty();
            ko.CrewDice.Outlaws.Should().BeEmpty();
            ko.CrewDice.Passengers.Should().BeEmpty();
            ko.Foes.Foes.Should().BeEmpty();

            var dice = new List<Die>()
            {
                new FoeDie(FoeName.Niska),
                new OutlawDie(OutlawName.Mal),
                new PassengerDie(PassengerName.Inara),
                new FoeDie(FoeName.Badger),
                new OutlawDie(OutlawName.Mal),
                new PassengerDie(PassengerName.Book),
                new OutlawDie(OutlawName.Supplies),
                new PassengerDie(PassengerName.Supplies)
            };

            ko = new KO(dice.ToArray());
        }

        [Fact()]
        public void KO_Add_AddListUpdatesCorrectly()
        {
            var ko = new KO();
            ko.Add(new FoeDie(FoeName.Niska));
            ko.Add(new OutlawDie(OutlawName.Jayne));
            ko.Add(new PassengerDie(PassengerName.Book));
            ko.Add(new FoeDie(FoeName.Niska));
            ko.Add(new OutlawDie(OutlawName.Mal));
            ko.Add(new PassengerDie(PassengerName.Book));

            ko.Foes.Count.Should().Be(2);
            ko.Foes.Badger.Should().Be(0);
            ko.Foes.Niska.Should().Be(2);
            ko.Foes.Saffron.Should().Be(0);
            ko.CrewDice.Outlaws.Count(die => die.OutlawName is OutlawName.Jayne).Should().Be(1);
            ko.CrewDice.Outlaws.Count(die => die.OutlawName is OutlawName.Mal).Should().Be(1);
            ko.CrewDice.Passengers.Count(die => die.PassengerName is PassengerName.Book).Should().Be(2);
            ko.CrewDice.Passengers.Count(die => die.PassengerName is PassengerName.Inara).Should().Be(0);

            ko.Add(new OutlawDie(OutlawName.Mal), new PassengerDie(PassengerName.Inara), new FoeDie(FoeName.Saffron), new FoeDie(FoeName.Niska));

            ko.Foes.Count.Should().Be(4);
            ko.Foes.Badger.Should().Be(0);
            ko.Foes.Niska.Should().Be(3);
            ko.Foes.Saffron.Should().Be(1);
            ko.CrewDice.Outlaws.Count(die => die.OutlawName is OutlawName.Jayne).Should().Be(1);
            ko.CrewDice.Outlaws.Count(die => die.OutlawName is OutlawName.Mal).Should().Be(2);
            ko.CrewDice.Passengers.Count(die => die.PassengerName is PassengerName.Book).Should().Be(2);
            ko.CrewDice.Passengers.Count(die => die.PassengerName is PassengerName.Inara).Should().Be(1);
        }

        [Fact()]
        public void KO_ReRoll_CorrectlyRollsGivenDie()
        {
            var ko = new KO();

            ko.Add(new OutlawDie(OutlawName.Mal), new OutlawDie(OutlawName.Mal), new PassengerDie(PassengerName.Inara), new FoeDie(FoeName.Saffron), new FoeDie(FoeName.Niska));

            ko.Foes.Count.Should().Be(2);
            ko.Foes.Badger.Should().Be(0);
            ko.Foes.Niska.Should().Be(1);
            ko.Foes.Saffron.Should().Be(1);
            ko.CrewDice.Outlaws.Count(die => die.OutlawName is OutlawName.Mal).Should().Be(2);
            ko.CrewDice.Passengers.Count(die => die.PassengerName is PassengerName.Inara).Should().Be(1);

            ko.Remove(new FoeDie(FoeName.Niska)).Should().BeTrue();
            ko.Foes.Count.Should().Be(1);
            ko.Foes.Niska.Should().Be(0);
            ko.Foes.Saffron.Should().Be(1);
            ko.CrewDice.Outlaws.Count(die => die.OutlawName is OutlawName.Mal).Should().Be(2);
            ko.CrewDice.Passengers.Count(die => die.PassengerName is PassengerName.Inara).Should().Be(1);

            ko.Remove(new OutlawDie(OutlawName.Mal)).Should().BeTrue();
            ko.Foes.Count.Should().Be(1);
            ko.Foes.Niska.Should().Be(0);
            ko.Foes.Saffron.Should().Be(1);
            ko.CrewDice.Outlaws.Count(die => die.OutlawName is OutlawName.Mal).Should().Be(1);
            ko.CrewDice.Passengers.Count(die => die.PassengerName is PassengerName.Inara).Should().Be(1);

        }

        [Fact]
        public void KO_Remove_ReturnsTrueWhenDieIsPresent()
        {

        }

        [Fact]
        public void KO_Remove_ReturnsFalseWhenDieNotPresent()
        {

        }
    }
}