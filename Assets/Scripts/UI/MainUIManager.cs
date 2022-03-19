using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeBrewery.Glime
{

    public class MainUIManager : MonoBehaviour
    {
        public GameObject CraftingUI;
        public GameObject CombatUI;

        void Start()
        {
        }


        public void SwitchToCraftingUI()
        {
            CraftingUI.SetActive(true);
            CombatUI.SetActive(false);
        }

        public void SwitchToBattleUI()
        {
            CraftingUI.SetActive(false);
            CombatUI.SetActive(true);
        }

    }
}