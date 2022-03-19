
namespace CodeBrewery.Glime.Battle.Potions
{
    /// <summary>
    /// Provides a set of recipes.
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Gets the type of the ingredient.
        /// </summary>
        public IngredientType Type { get; private set; }

        /// <summary>
        /// The types 
        /// </summary>
        public ReadonlyPotionTypeSet PotionTypes { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient"/> class.
        /// </summary>
        /// <param name="type">The type of the ingredient.</param>
        /// <param name="potionType">The types of the potions required for bu</param>
        public Ingredient(IngredientType type, ReadonlyPotionTypeSet potionType)
        {
            this.Type = type;
            this.PotionTypes = potionType;
        }

        /// <summary>
        /// Creates a new <see cref="IngredientType.FrailLavaBloom"/> ingredient.
        /// </summary>
        /// <returns>A new <see cref="IngredientType.FrailLavaBloom"/> ingredient.</returns>
        public static Ingredient CreateFrailLavabloom()
        {
            return new Ingredient(
                IngredientType.FrailLavaBloom,
                new PotionTypeSet() {
                    { PotionType.Fire, 2 },
                    { PotionType.Weakness, 1}
                }.ToReadonly());
        }

        /// <summary>
        /// Creates a new <see cref="IngredientType.FrostMint"/> ingredient.
        /// </summary>
        /// <returns>A new <see cref="IngredientType.FrostMint"/> ingredient.</returns>
        public static Ingredient CreateFrostMint()
        {
            return new Ingredient(
                IngredientType.FrostMint,
                new PotionTypeSet() {
                    { PotionType.Ice, 2 },
                    { PotionType.Fire, 1}
                }.ToReadonly());
        }

        /// <summary>
        /// Creates a new <see cref="IngredientType.LukewarmBeserkium"/> ingredient.
        /// </summary>
        /// <returns>A new <see cref="IngredientType.LukewarmBeserkium"/> ingredient.</returns>
        public static Ingredient CreateLukewarmBerserkium()
        {
            return new Ingredient(
                IngredientType.LukewarmBeserkium,
                new PotionTypeSet() {
                    { PotionType.Strength, 1 },
                    { PotionType.Ice, 1},
                    { PotionType.Fire, 1 }
                }.ToReadonly());
        }

        /// <summary>
        /// Creates a new <see cref="IngredientType.JuviBerries"/> ingredient.
        /// </summary>
        /// <returns>A new <see cref="IngredientType.JuviBerries"/> ingredient.</returns>
        public static Ingredient CreateJuviBerries()
        {
            return new Ingredient(
                IngredientType.JuviBerries,
                new PotionTypeSet() {
                    { PotionType.Healing, 2 }
                }.ToReadonly());
        }

        /// <summary>
        /// Creates a new <see cref="IngredientType.Paraleaf"/> ingredient.
        /// </summary>
        /// <returns>A new <see cref="IngredientType.Paraleaf"/> ingredient.</returns>
        public static Ingredient CreateParaleaf()
        {
            return new Ingredient(
                IngredientType.Paraleaf,
                new PotionTypeSet() {
                    { PotionType.Electric, 1 }
                }.ToReadonly());
        }
    }
}