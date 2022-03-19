using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeBrewery.Glime
{

    [RequireComponent(typeof(UIDocument))]
    public class MainUIManager : MonoBehaviour
    {
        private UIDocument uIDocument;
        private VisualElement craftingUI;
        private VisualElement battleUI;

        async void Start()
        {
            uIDocument = GetComponent<UIDocument>();
            VisualElement rootEl = this.uIDocument.rootVisualElement;
            craftingUI = rootEl.Q("PosionUI");
            battleUI = rootEl.Q("BattleUI");

            rootEl.Q<Button>("CraftButton").clickable.clicked += SwitchToCraftingUI;
            rootEl.Q<Button>("BattleButton").clickable.clicked += SwitchToBattleUI;

            SwitchToCraftingUI();
        }

        void Update()
        {

        }

        void SwitchToCraftingUI()
        {
            craftingUI.style.display = DisplayStyle.Flex;
            battleUI.style.display = DisplayStyle.None;
        }

        void SwitchToBattleUI()
        {
            battleUI.style.display = DisplayStyle.Flex;
            craftingUI.style.display = DisplayStyle.None;
        }

    }
}