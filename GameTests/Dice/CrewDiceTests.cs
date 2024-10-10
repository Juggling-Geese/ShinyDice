using FluentAssertions;

using Game.Dice.Core;
using Game.Dice.Crew;
using Game.Dice.Foes;

using Xunit;

namespace GameTests.Dice
{
    public class CrewDiceTests
    {
        [Fact()]
        public void CrewDice_Ctor()
        {
            var dice = new CrewDice( outlawCount: 10, passengerCount: 15);

            dice.Outlaws.All(die => die.OutlawName != OutlawName.Any).Should().BeTrue();

            dice.Passengers.All(die => die.PassengerName != PassengerName.Any).Should().BeTrue();

            dice.Supplies.Count().Should().BeGreaterThan(0);
            var total = dice.Supplies.Count() + dice.Outlaws.Count() + dice.Passengers.Count();
            total.Should().Be(25);
        }

        [Fact()]
        public void CrewDice_RollAllTest()
        {
            var dice = new CrewDice(outlawCount: 20, passengerCount: 20);
            var outlaws = new List<OutlawDie>(dice.Outlaws);
            var passengers = new List<PassengerDie>(dice.Passengers);
            var supplies = new List<CrewDie>(dice.Supplies);

            var rolled = dice.RollAllDice();
            outlaws.Should().NotBeEquivalentTo(rolled.Outlaws);
            rolled.Outlaws.All(die => die.OutlawName != OutlawName.Any).Should().BeTrue();

            passengers.Should().NotBeEquivalentTo(rolled.Outlaws);
            rolled.Passengers.All(die => die.PassengerName != PassengerName.Any).Should().BeTrue();

            supplies.Should().NotBeEquivalentTo(rolled.Supplies);
            rolled.Supplies.All(die => die.IsSupply()).Should().BeTrue();

            if (!rolled.Supplies.Any())
            {
                rolled.RollAllDice().Supplies.Count().Should().BeGreaterThan(0);
            }
        }

        [Fact()]
        public void CrewDice_RollCrewTest()
        {
            var dice = new CrewDice(passengerCount:10, outlawCount: 15);
            var passengerDice = new List<PassengerDie>(dice.Passengers);
            var outlawDice = new List<OutlawDie>(dice.Outlaws);
            var suppliesDice = new List<CrewDie>(dice.Supplies);

            var rolled = dice.RollCrewDice();

            passengerDice.Should().NotBeEquivalentTo(rolled.Passengers);
            dice.Passengers.All(die => die.PassengerName != PassengerName.Any).Should().BeTrue();

            outlawDice.Should().NotBeEquivalentTo(rolled.Outlaws);
            dice.Outlaws.All(die => die.OutlawName != OutlawName.Any).Should().BeTrue();

            suppliesDice.Should().NotBeEquivalentTo(rolled.Supplies);
            dice.Supplies.All(die => die.IsSupply()).Should().BeTrue();
        }

        [Fact]
        public void CrewDice_RemoveCrew_NoCrewPresentFails()
        {
            var crew = new List<CrewDie>()
            {
                new PassengerDie(PassengerName.River),
                new PassengerDie(PassengerName.Book),
                new OutlawDie(OutlawName.Wash),
                new OutlawDie(OutlawName.Jayne),
                new OutlawDie(OutlawName.Wash),
                new PassengerDie(PassengerName.Supplies),
                new OutlawDie(OutlawName.Supplies),
            };

            var crewDice = new CrewDice();
            crewDice.AddCrew(crew.ToArray());

            crewDice.Outlaws.Count().Should().Be(3);
            crewDice.Passengers.Count().Should().Be(2);
            crewDice.Supplies.Count().Should().Be(2);

            var success = crewDice.RemoveCrew(new OutlawDie(OutlawName.Wash));
            success.Should().BeTrue();
            crewDice.Outlaws.Count().Should().Be(2);
            crewDice.Outlaws.Count(die => die.OutlawName == OutlawName.Wash).Should().Be(1);
            crewDice.Passengers.Count().Should().Be(2);
            crewDice.Supplies.Count().Should().Be(2);
        }
    }
}
