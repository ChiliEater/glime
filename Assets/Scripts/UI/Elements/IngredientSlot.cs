using CodeBrewery.Glime.Battle.Potions;
using CodeBrewery.Glime.UI.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBrewery.Glime.UI.Element
{
    public class IngredientSlot : UIBehaviour
    {
        public IngredientType ingredientType;

        public TextMeshProUGUI ingredientText;

        void Start() {
            ingredientText.text = ingredientType.ToString();
        }

        public void AddIngredient()
        {
            CraftingUI.AddIngredient(ingredientType);
        }

    }
}
