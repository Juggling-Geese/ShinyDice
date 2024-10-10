namespace Game.Player
{
    public class Player
    {
        public string Name { get; set; } = string.Empty;
        public Color Color { get; set; } = Color.White;
        public int VictoryPoints { get; set; } = 0;
        public int Supplies { get; set; } = 0;
    }
}
