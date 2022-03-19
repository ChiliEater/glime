
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;

namespace CodeBrewery.Glime.Battle.Potions
{
    /// <summary>
    /// Represents a list of ingredients.
    /// </summary>
    public class PotionTypeSet : Dictionary<PotionType, int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PotionTypeSet"/> class.
        /// </summary>
        public PotionTypeSet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PotionTypeSet"/> class.
        /// </summary>
        /// <param name="ingredients">The ingredients to add.</param>
        public PotionTypeSet(params KeyValuePair<PotionType, int>[] ingredients) : this(new[] { ingredients })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PotionTypeSet"/> class.
        /// </summary>
        /// <param name="ingredients">The ingredients to add.</param>
        public PotionTypeSet(params IEnumerable<KeyValuePair<PotionType, int>>[] ingredients)
        {
            foreach (IEnumerable<KeyValuePair<PotionType, int>> potionTypeList in ingredients)
            {
                AddIngredients(potionTypeList);
            }
        }

        /// <summary>
        /// Gets the total amount of ingredients.
        /// </summary>
        public int TotalAmount => this.Sum((entry) => entry.Value);

        /// <summary>
        /// Adds the specified <paramref name="potion"/> to the list.
        /// </summary>
        /// <param name="potion">The potion-type to add to the list.</param>
        public void AddIngredients(PotionType potion)
        {
            AddIngredients(potion, 1);
        }

        /// <summary>
        /// Adds the specified <paramref name="count"/> of the specified <paramref name="potion"/> to the list.
        /// </summary>
        /// <param name="potion">The potion-type to add to the list.</param>
        /// <param name="count">The number of potions to add to the list.</param>
        public void AddIngredients(PotionType potion, int count)
        {
            this[potion] = (ContainsKey(potion) ? this[potion] : 0) + count;
        }

        /// <summary>
        /// Adds the specified <see cref="PotionTypeSet"/> to this list.
        /// </summary>
        /// <param name="list">The list containing the ingredients to add.</param>
        public void AddIngredients(IEnumerable<KeyValuePair<PotionType, int>> list)
        {
            foreach (KeyValuePair<PotionType, int> entry in list)
            {
                AddIngredients(entry.Key, entry.Value);
                this[entry.Key] = (ContainsKey(entry.Key) ? this[entry.Key] : 0) + entry.Value;
            }
        }

        /// <summary>
        /// Creates a new recipe containing this list's current ingredients.
        /// </summary>
        /// <returns>A new recipe containing this list's current ingredients.</returns>
        public ReadonlyPotionTypeSet ToReadonly()
        {
            return new ReadonlyPotionTypeSet(this);
        }
    }
}
