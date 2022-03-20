using CodeBrewery.Glime.Battle.Potions;
using CodeBrewery.Glime.UI.Element;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using static CodeBrewery.Glime.UI.Model.IngredientCraftingModel;

namespace CodeBrewery.Glime.UI.Manager
{
    public class CombatUIManager : UIBehaviour
    {

        public TextMeshProUGUI PotionNameLabel;
        public TextMeshProUGUI PotionDescriptionlabel;
        public TextMeshProUGUI PotionIngredientsLabel;

        public static readonly int MAX_INGREDIENTS = 3;


        void Start()
        {
            MainUIManager.EncounterManager.OnTurnStartEvent.AddListener(TurnStartHandler);
        }

        private void TurnStartHandler(int turnCount, List<Potion> potions)
        {
            potions.Clear();
            potions.AddRange(potions);
        }

        public void PotionSelectHandler(TabGroup tabGroup)
        {
            PotionShelf.SetCurrentPotion(tabGroup.CurrentTabIndex);
            UpdatePotionLabels();
        }



        public void UpdatePotionLabels()
        {
            Potion currentPotion = PotionShelf.CurrentPotion;
            PotionNameLabel.text = currentPotion.Name;

            string description = "Description:" + Environment.NewLine;
            description += string.Join(
                Environment.NewLine,
                from entry in currentPotion.PotionTypes
                select $"- {entry.Value:00}x {entry.Key}");

            PotionDescriptionlabel.text = description;

            //string ingredients = "Ingredients:" + Environment.NewLine;
            //PotionIngredientsLabel.text = ingredients;
        }


    }
}
