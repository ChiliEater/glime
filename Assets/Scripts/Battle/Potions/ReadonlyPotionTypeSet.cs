using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeBrewery.Glime.Battle
{
    /// <summary>
    /// Represents a recipe.
    /// </summary>
    public class ReadonlyPotionTypeSet : IReadOnlyDictionary<PotionType, int>
    {
        /// <summary>
        /// The actual recipe list.
        /// </summary>
        private Dictionary<PotionType, int> innerList = new Dictionary<PotionType, int>();

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
        public int this[PotionType key] => InnerList[key];

        /// <inheritdoc/>
        public IEnumerable<PotionType> Keys => InnerList.Keys;

        /// <inheritdoc/>
        public IEnumerable<int> Values => InnerList.Values;

        /// <inheritdoc/>
        public int Count => InnerList.Count;

        /// <summary>
        /// Gets the total amount of ingredients.
        /// </summary>
        public int TotalAmount => this.Sum((entry) => entry.Value);

        /// <summary>
        /// Gets the actual recipe list.
        /// </summary>
        protected IDictionary<PotionType, int> InnerList => innerList;

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
