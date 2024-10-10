using FluentAssertions;

using Game.Dice.Core;
using Game.Dice.Crew;

using Xunit;

namespace GameTests.Dice
{
    public class RolledDiceTests
    {
        [Fact()]
        public void RolledDiceTest()
        {
            var dice = new RolledDice(foeCount: 5, passengerCount: 3, outlawCount: 7);

            dice.FoeDice.Count.Should().Be(5);

            var totalCrewDie = dice.CrewDice.Outlaws.Count() + dice.CrewDice.Passengers.Count() + dice.GetSupplies();
            totalCrewDie.Should().Be(10);

            if (dice.GetSupplies() == 0)
            {
                dice = new RolledDice(5, 3, 7);
            }

            dice.GetSupplies().Should().BeGreaterThan(0);
        }

        [Fact()]
        public void GetSuppliesTest()
        {
            var dice = new RolledDice(foeCount: 0, passengerCount: 10, outlawCount: 10);

            var count = dice.GetSupplies();
            count.Should().BeGreaterThan(0);

            dice.CrewDice.AddCrew(new OutlawDie(OutlawName.Supplies));
            dice.GetSupplies().Should().Be(count + 1);

            dice.CrewDice.AddCrew(new PassengerDie(PassengerName.Supplies));
            dice.GetSupplies().Should().Be(count + 2);
        }
    }
}