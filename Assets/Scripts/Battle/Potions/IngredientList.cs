
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CodeBrewery.Glime.Battle.Potions
{
    /// <summary>
    /// Represents a list of ingredients.
    /// </summary>
    public class IngredientList : IReadOnlyDictionary<PotionType, int>
    {
        /// <summary>
        /// The actual list of ingredients.
        /// </summary>
        private Dictionary<PotionType, int> innerList = new Dictionary<PotionType, int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientList"/> class.
        /// </summary>
        public IngredientList()
        {
        }

        /// <inheritdoc/>
        public int this[PotionType key] => innerList[key];

        /// <inheritdoc/>
        public IEnumerable<PotionType> Keys => innerList.Keys;

        /// <inheritdoc/>
        public IEnumerable<int> Values => innerList.Values;

        /// <inheritdoc/>
        public int Count => innerList.Count;

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
            innerList[potion] = (ContainsKey(potion) ? this[potion] : 0) + count;
        }

        /// <summary>
        /// Adds the specified <see cref="IngredientList"/> to this list.
        /// </summary>
        /// <param name="list">The list containing the ingredients to add.</param>
        public void AddIngredients(IngredientList list)
        {
            foreach (KeyValuePair<PotionType, int> entry in list)
            {
                AddIngredients(entry.Key, entry.Value);
                innerList[entry.Key] = (ContainsKey(entry.Key) ? this[entry.Key] : 0) + entry.Value;
            }
        }

        /// <inheritdoc/>
        public bool ContainsKey(PotionType key)
        {
            return innerList.ContainsKey(key);
        }

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<PotionType, int>> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        /// <inheritdoc/>
        public bool TryGetValue(PotionType key, out int value)
        {
            return innerList.TryGetValue(key, out value);
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
