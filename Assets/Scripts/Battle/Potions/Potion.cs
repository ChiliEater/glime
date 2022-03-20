namespace CodeBrewery.Glime.Battle.Potions
{
    public class Potion
    {
        public PotionTypeSet potionTypes { get; private set; }

        public Potion(PotionTypeSet potionTypes)
        {
            this.potionTypes = potionTypes;
        }
    }
}