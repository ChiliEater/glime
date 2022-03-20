namespace CodeBrewery.Glime.Battle.Potions
{
    /// <summary>
    /// Represents a potion.
    /// </summary>
    public class Potion
    {
        /// <summary>
        /// Gets the type of the potion.
        /// </summary>
        public ReadonlyPotionTypeSet PotionTypes { get; private set; }

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