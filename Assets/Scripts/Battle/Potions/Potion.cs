namespace CodeBrewery.Glime.Battle.Potions
{
    class Potion
    {
        public PotionType type { get; private set; }
        public PotionTypeSet potionTypes { get; private set; }

        public Potion(PotionType type, PotionTypeSet potionTypes)
        {
            this.type = type;
            this.potionTypes = potionTypes;
        }
    }
}