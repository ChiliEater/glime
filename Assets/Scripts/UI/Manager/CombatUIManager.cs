using CodeBrewery.Glime.Battle.Potions;
using CodeBrewery.Glime.UI.Element;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CodeBrewery.Glime.UI.Manager {
    public class CombatUIManager : UIBehaviour
    {

        public TextMeshProUGUI PotionNameLabel;
        public TextMeshProUGUI PotionDescriptionlabel;
        public TextMeshProUGUI PotionIngredientsLabel;


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
        }

    }
}
