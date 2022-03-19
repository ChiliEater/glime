
namespace CodeBrewery.Glime.Battle.Potions
{
    public class Ingredient
    {
        public PotionTypeList PotionTypes { get; private set; }

        public Ingredient(IngredientType type, PotionTypeList potionType)
        {
            this.PotionTypes = potionType;
        }
        void Test()
        {
            PotionTypes = new PotionTypeList();
        }

        public static PotionTypeList CreateFrailLavabloom()
        {
            return new IngredientListBuilder().AddIngredient(PotionType.Fire, 2).AddIngredient(PotionType.Weakness, 1).Build();
        }

        public static PotionTypeList CreateFrostMint()
        {
            return new IngredientListBuilder().AddIngredient(PotionType.Ice, 2).AddIngredient(PotionType.Fire, 1).Build();
        }

        public static PotionTypeList CreateLukewarmBerserkium()
        {
            return new IngredientListBuilder().AddIngredient(PotionType.Strength, 1).AddIngredient(PotionType.Ice, 1).AddIngredient(PotionType.Fire, 1).Build();
        }

        public static PotionTypeList CreateJuviBerries()
        {
            return new IngredientListBuilder().AddIngredient(PotionType.Healing, 2).Build();
        }

        public static PotionTypeList CreateParaleaf()
        {
            return new IngredientListBuilder().AddIngredient(PotionType.Electric, 1).Build();
        }
    }
}