using CodeBrewery.Glime.Battle;
using CodeBrewery.Glime.Battle.Potions;
using CodeBrewery.Glime.UI.Element;
using CodeBrewery.Glime.UI.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using static CodeBrewery.Glime.UI.Model.IngredientCraftingModel;

namespace CodeBrewery.Glime.UI.Manager
{
    public class CraftingUIManager : UIBehaviour
    {
        public static readonly int MAX_POTIONS = 3;
        public static readonly int MAX_INGREDIENTS = 3;
        private EncounterManager encounterManager;

        public TextMeshProUGUI PotionNameLabel;
        public TextMeshProUGUI PotionDescriptionlabel;
        public TextMeshProUGUI PotionIngredientsLabel;

        private IngredientCraftingModel model = new IngredientCraftingModel(MAX_POTIONS);

        private PotionIngredientsModel currentPotion => model.CurrentPotion;

        void Start()
        {
            encounterManager = MainUIManager.EncounterManager;
        }

        public void StartTurn() {
            MainUIManager.StartTurn(model.CraftPotions());
        }


        public void ActivatePotion(TabGroup group) {
            model.ActivatePosion(group.CurrentTabIndex);
            UpdatePotionLabels();
        }

        public void AddIngredient(IngredientType ingredient)
        {
            if(currentPotion.Count < MAX_INGREDIENTS) 
            {
                currentPotion.Add(ingredient);
                UpdatePotionLabels();
            }
        }

        public void ClearIngredients()
        {
            currentPotion.Clear();
            UpdatePotionLabels();
        }

        private void UpdatePotionLabels()
        {
            Potion potion = currentPotion.CreatePotion();
            PotionShelf.SetPotion(model.CurrentPotionIndex, potion);
            PotionNameLabel.text = potion.Name;

            string description = "Description:" + Environment.NewLine;
            description += string.Join(
                Environment.NewLine,
                from entry in potion.PotionTypes
                select $"- {entry.Value:00}x {entry.Key}");

            PotionDescriptionlabel.text = description;

            string ingredients = $"Ingredients: ({currentPotion.Count}/{MAX_INGREDIENTS})"  + Environment.NewLine;
            ingredients += string.Join(Environment.NewLine, currentPotion.IngredientMixed.Select(keyValue => $"- {keyValue.Value:00}x {keyValue.Key}"));
            PotionIngredientsLabel.text = ingredients;
        }

    }
}
