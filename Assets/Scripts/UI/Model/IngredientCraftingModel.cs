using CodeBrewery.Glime.Battle.Potions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBrewery.Glime.UI.Model
{
    public class IngredientCraftingModel : ICollection<IngredientType>
    {
        private Dictionary<IngredientType, int> ingredientMixed = new Dictionary<IngredientType, int>();

        public IReadOnlyDictionary<IngredientType, int> IngredientMixed => ingredientMixed;

        public int Count => ingredientMixed.Select(keyValue => keyValue.Value).Sum();

        public bool IsReadOnly => true;

        public void Add(IngredientType item)
        {
            ingredientMixed[item] = ingredientMixed.GetValueOrDefault(item, 0) + 1;
        }

        public void Clear()
        {
            ingredientMixed.Clear();
        }

        public bool Contains(IngredientType item)
        {
            return ingredientMixed.ContainsKey(item);
        }

        public void CopyTo(IngredientType[] array, int arrayIndex)
        {
            ingredientMixed.Keys.CopyTo(array, arrayIndex);
        }

        public Potion CreatePotion()
        {
            PotionTypeSet potionTypeSet = new PotionTypeSet();
            foreach(var keyValue in ingredientMixed)
            {
                for(int i = 0; i < keyValue.Value; i++ )
                {
                    Ingredient ingredient = Ingredient.CreateIngredient(keyValue.Key);
                    potionTypeSet.AddIngredients(ingredient.PotionTypes);
                }
            }
            return new Potion(potionTypeSet);
        }

        public IEnumerator<IngredientType> GetEnumerator()
        {
            return ingredientMixed.Keys.GetEnumerator();
        }

        public bool Remove(IngredientType item)
        {
            if(ingredientMixed.ContainsKey(item) && ingredientMixed[item] > 0)
            {
                ingredientMixed[item]--;
                return true;
            } 
            else
            {
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ingredientMixed.Keys.GetEnumerator();
        }
    }
}