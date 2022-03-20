using CodeBrewery.Glime.Battle;
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

        void Start()
        {
        }


        public void SwitchToCraftingUI()
        {
            CraftingUI.gameObject.SetActive(true);
            CombatUI.gameObject.SetActive(false);
        }

        public void SwitchToBattleUI()
        {
            CraftingUI.gameObject.SetActive(false);
            CombatUI.gameObject.SetActive(true);
        }

    }
}