namespace CodeBrewery.Glime.Battle.Potions
{
    class Potion
    {
        public PotionType type { get; private set; }
        public PotionTypeList potionTypes { get; private set; }

        public Potion(PotionType type, PotionTypeList potionTypes)
        {
            this.type = type;
            this.potionTypes = potionTypes;
        }
    }
}