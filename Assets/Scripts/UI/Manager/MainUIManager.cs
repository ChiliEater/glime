using CodeBrewery.Glime.Battle;
using CodeBrewery.Glime.Battle.Potions;
using CodeBrewery.Glime.UI.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeBrewery.Glime.UI.Manager
{

    public class MainUIManager : MonoBehaviour
    {
        public CraftingUIManager CraftingUI;
        public CombatUIManager CombatUI;
        public EncounterManager EncounterManager;
        public PotionShelf PotionShelf { get; } = new PotionShelf(3);
        void Start()
        {
            SwitchToCraftingUI();
        }


        public void StartTurn(List<Potion> craftedPotions) {
            SwitchToBattleUI();
            EncounterManager.StartTurn(craftedPotions);
        }

        public void SwitchToCraftingUI()
        {
            if(!EncounterManager.BattleOngoing) {
                CraftingUI.gameObject.SetActive(true);
                CombatUI.gameObject.SetActive(false);
            }
        }

        public void SwitchToBattleUI()
        {
            CraftingUI.gameObject.SetActive(false);
            CombatUI.gameObject.SetActive(true);
        }

    }
}