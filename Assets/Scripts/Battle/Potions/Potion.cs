namespace CodeBrewery.Glime.Battle.Potions
{
    public class Potion
    {
        public PotionTypeSet PotionTypes { get; private set; }

        public Potion(PotionTypeSet potionTypes)
        {
            this.PotionTypes = potionTypes;
        }
    }
}