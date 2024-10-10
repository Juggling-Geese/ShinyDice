namespace Game.Dice.Foes
{
    /// <summary>
    /// Represents a collection of <see cref="FoeDie"/>
    /// </summary>
    public class FoeDice
    { 
        private readonly List<FoeDie> _foes;

        /// <summary>
        /// Creates a new instance of <see cref="FoeDice"/>
        /// </summary>
        public FoeDice()
        {
            _foes = new List<FoeDie>();
        }

        /// <summary>
        /// Creates a new instance of <see cref="FoeDice"/>
        /// </summary>
        /// <param name="count">The number of <see cref="FoeDie"/> to include</param>
        public FoeDice(int count)
        {
            var foes = new List<FoeDie>();

            for (var i = 0; i < count; i++)
            {
                foes.Add(new FoeDie());
            }

            _foes = foes;
        }

        /// <summary>
        /// Creates a new instance of <see cref="FoeDice"/>
        /// </summary>
        /// <param name="foes">The <see cref="FoeDie"/> to add</param>
        public FoeDice(IEnumerable<FoeDie> foes)
        {
            _foes = foes.ToList();
        }

        /// <summary>
        /// The collection of <see cref="FoeDie"/>
        /// </summary>
        public IEnumerable<FoeDie> Foes => _foes;

        /// <summary>
        /// Indicates the number of foe dice that are for Niska
        /// </summary>
        public int Niska => _foes.Count(die => die.FoeName is FoeName.Niska);

        /// <summary>
        /// Indicates the number of foe dice that are for Badger
        /// </summary>
        public int Badger => _foes.Count(die => die.FoeName is FoeName.Badger);

        /// <summary>
        /// Indicates the number of foe dice that are for Saffron
        /// </summary>
        public int Saffron => _foes.Count(die => die.FoeName is FoeName.Saffron);

        /// <summary>
        /// The total number of foes
        /// </summary>
        public int Count => _foes.Count;

        /// <summary>
        /// Removes the given <see cref="FoeDie"/> from the collection
        /// </summary>
        /// <param name="foe">The <<see cref="FoeDie"/> to remove</param>
        /// <returns>True if the <see cref="FoeDie"/> was successfully removed</returns>
        public bool RemoveFoes(params FoeDie[] foes)
        {
            foreach (var foe in foes)
            {
                var found = _foes.FirstOrDefault(die => die.FoeName == foe.FoeName);
                if (found is null) return false;
                _foes.Remove(found);
            }

            return true;
        }

        /// <summary>
        /// Adds the <see cref="FoeDie"/> to the collection
        /// </summary>
        /// <param name="foes">The <see cref="FoeDie"/> to add</param>
        public void AddFoes(params FoeDie[] foes)
        {
            _foes.AddRange(foes);
        }
    }
}