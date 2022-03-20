using CodeBrewery.Glime.Battle.Potions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

namespace CodeBrewery.Glime.UI.Model
{
    public class IngredientCraftingModel
    {
        private List<PotionIngredientsModel> potionIngredientModelList = new List<PotionIngredientsModel>();
        public IReadOnlyList<PotionIngredientsModel> PotionIngredientModels => potionIngredientModelList;

        public int CurrentPosion {get; private set;}

        public PotionIngredientsModel CurrentPotion  => potionIngredientModelList[CurrentPosion];

        public IngredientCraftingModel(int numberOfPotions)
        {
            for(int i = 0; i < numberOfPotions; i++) {
                potionIngredientModelList.Add(new PotionIngredientsModel());
            }
        }

        public void ActivatePosion(int index) {
            if(index < 0 || index > potionIngredientModelList.Count) {
                throw new IndexOutOfRangeException($"Index {index} is out of range (number of potions: {potionIngredientModelList.Count})");
            }
            CurrentPosion = index;
        }

                
        public class PotionIngredientsModel : ICollection<IngredientType>
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
                foreach (var keyValue in ingredientMixed)
                {
                    for (int i = 0; i < keyValue.Value; i++)
                    {
                        Ingredient ingredient = Ingredient.GetIngredient(keyValue.Key);
                        potionTypeSet.AddIngredients(ingredient.PotionTypes);
                    }
                }
                return new Potion(potionTypeSet.ToReadonly());
            }

            public IEnumerator<IngredientType> GetEnumerator()
            {
                return ingredientMixed.Keys.GetEnumerator();
            }

            public bool Remove(IngredientType item)
            {
                if (ingredientMixed.ContainsKey(item) && ingredientMixed[item] > 0)
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
}