using System.Collections;
using System.Collections.Generic;

namespace CodeBrewery.Glime.Battle.Potions
{
    /// <summary>
    /// Represents a recipe.
    /// </summary>
    public class ReadonlyPotionTypeSet : IReadOnlyDictionary<PotionType, int>
    {
        /// <summary>
        /// The actual recipe list.
        /// </summary>
        private PotionTypeSet innerList = new PotionTypeSet();

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadonlyPotionTypeSet"/> class.
        /// </summary>
        public ReadonlyPotionTypeSet()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadonlyPotionTypeSet"/> class.
        /// </summary>
        /// <param name="ingredients">The ingredients of the recipe.</param>
        public ReadonlyPotionTypeSet(IEnumerable<KeyValuePair<PotionType, int>> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                InnerList[ingredient.Key] = ingredient.Value;
            }
        }

        /// <inheritdoc/>
        public virtual int this[PotionType key] => this.GetValueOrDefault(key, 0);

        /// <inheritdoc/>
        public IEnumerable<PotionType> Keys => InnerList.Keys;

        /// <inheritdoc/>
        public IEnumerable<int> Values => InnerList.Values;

        /// <inheritdoc/>
        public int Count => InnerList.Count;

        /// <summary>
        /// Gets the total amount of ingredients.
        /// </summary>
        public int TotalAmount => InnerList.TotalAmount;

        /// <summary>
        /// Gets the normalized set.
        /// </summary>
        public ReadonlyPotionTypeSet Normalized => InnerList.Normalized;

        /// <summary>
        /// Gets the actual recipe list.
        /// </summary>
        protected PotionTypeSet InnerList => innerList;

        /// <inheritdoc/>
        public bool ContainsKey(PotionType key)
        {
            return InnerList.ContainsKey(key);
        }

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<PotionType, int>> GetEnumerator()
        {
            return InnerList.GetEnumerator();
        }

        /// <inheritdoc/>
        public bool TryGetValue(PotionType key, out int value)
        {
            return InnerList.TryGetValue(key, out value);
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)InnerList).GetEnumerator();
        }
    }
}
