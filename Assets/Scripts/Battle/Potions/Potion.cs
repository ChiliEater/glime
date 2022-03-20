namespace CodeBrewery.Glime.Battle.Potions
{
    /// <summary>
    /// Represents a potion.
    /// </summary>
    public class Potion
    {
        /// <summary>
        /// The name of the potion.
        /// </summary>
        private string name = null;

        /// <summary>
        /// Gets the type of the potion.
        /// </summary>
        public ReadonlyPotionTypeSet PotionTypes { get; private set; }

        /// <summary>
        /// Gets the name of the potion.
        /// </summary>
        public string Name
        {
            get
            {
                if (name == null)
                {
                }

                return name;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Potion"/> class.
        /// </summary>
        /// <param name="potionTypes">The type of the potion.</param>
        public Potion(ReadonlyPotionTypeSet potionTypes)
        {
            this.PotionTypes = potionTypes;
        }
    }
}