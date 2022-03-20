using CodeBrewery.Glime.Battle;
using CodeBrewery.Glime.Battle.Potions;
using CodeBrewery.Glime.UI.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace CodeBrewery.Glime.UI.Manager
{
    public class CraftingUIManager : UIBehaviour
    {
        public static readonly int MAX_INGREDIENTS = 3;
        private EncounterManager encounterManager;

        public TextMeshProUGUI MinuteLabel;
        public TextMeshProUGUI SecondLabel;

        public TextMeshProUGUI PotionNameLabel;
        public TextMeshProUGUI PotionDescriptionlabel;
        public TextMeshProUGUI PotionIngredientsLabel;

        private IngredientCraftingModel model = new IngredientCraftingModel();

        void Start()
        {
            encounterManager = MainUIManager.EncounterManager;
            UpdateBattleTime();
        }

        private void UpdateBattleTime()
        {
            MinuteLabel.text = encounterManager.BattleTimeMinute.ToString("00");
            SecondLabel.text = encounterManager.BattleTimeMinute.ToString("00");
        }

        public void AddIngredient(IngredientType ingredient)
        {
            if(model.Count < MAX_INGREDIENTS) 
            {
                model.Add(ingredient);
                UpdatePotionLabels();
            }
        }

        public void ClearIngredients()
        {
            model.Clear();
            UpdatePotionLabels();
        }

        private void UpdatePotionLabels()
        {
            Potion potion = model.CreatePotion();
            string description = "Description:" + Environment.NewLine;
            description += string.Join(
                Environment.NewLine,
                from entry in potion.potionTypes
                select $"- {entry.Value:00}x {entry.Key}");

            PotionDescriptionlabel.text = description;

            string ingredients = $"Ingredients: ({model.Count}/{MAX_INGREDIENTS})"  + Environment.NewLine;
            ingredients += string.Join(Environment.NewLine, model.IngredientMixed.Select(keyValue => $"- {keyValue.Value:00}x {keyValue.Key}"));
            PotionIngredientsLabel.text = ingredients;
        }

        public void StartTurn()
        {
            encounterManager.StartTurn();
        }
    }
}
