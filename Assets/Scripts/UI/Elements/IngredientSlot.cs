using CodeBrewery.Glime.Battle.Potions;
using CodeBrewery.Glime.UI.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBrewery.Glime.UI.Element
{
    public class IngredientSlot : UIBehaviour
    {
        public IngredientType ingredientType;
        public Ingredient ingredient { get; private set; }

        void Start()
        {
            ingredient = Ingredient.CreateIngredient(ingredientType);
        }

    }
}
